using Microsoft.AspNetCore.Mvc;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public InvoiceController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal amount = 0;

            IList<int> orderIds = (IList<int>)model.OrderIds;
            IList<Order> orders= new List<Order>(); 
            
            // find the associated orders and calculate the total amount  
            for (int i = 0; i < orderIds.Count; i++)
            {
                orders.Add(_dbContext.Orders.Find(orderIds[i]));
                amount += orders[i].OrderAmount;
                
            }

            // create the invoice             
            var dbModel = new Invoice
            {
                InvoiceNumber = model.InvoiceNumber,
                InvoiceDate = model.InvoiceDate,
                Amount = amount,
                CustomerId = model.CustomerId
            };

            _dbContext.Invoices.Add(dbModel);
            await _dbContext.SaveChangesAsync();

            // wait for invoice to be saved and have a generated id to update the reference key for the orders
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceNumber == dbModel.InvoiceNumber);

            int id = invoice.Id;
            for (int i = 0; i < orderIds.Count; i++)
            {
                orders[i].InvoiceId = id;

            }
            await _dbContext.SaveChangesAsync();
            return Created(Request.GetDisplayUrl(), dbModel);
        }
    }
}
