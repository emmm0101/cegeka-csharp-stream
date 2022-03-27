using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Requests
{
    public class OrderRequestModel 
    {

        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int CarOfferId { get; set; }


    }
}
