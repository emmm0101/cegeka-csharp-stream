using Microsoft.AspNetCore.Mvc;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebCarDealership.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly DealershipDbContext _dbContext;

        public InvoiceController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // TODO: finish implementation
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceRequest model)
        {
            decimal amount = 0;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Invoice
            {
                InvoiceNumber = model.InvoiceNumber,
                InvoiceDate = model.InvoiceDate
            };

            // TODO
            //_dbContext.Invoices.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
    }
}
