using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class BuyTicketModel
    {
        [Required(ErrorMessage ="Ad zorunludur")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Soyad zorunludur")]
        public string Surname { get; set; }

        public int VoyageId { get; set; }

        public decimal Price { get; set; }

        public int SeatNumber { get; set; }

    }
}
