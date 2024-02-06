using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piotrowicz_Alicja_RazorPages.Models
{
    public class Trening
    {
        public int Id { get; set; }
        public string? Type { get; set; }

        [Display(Name = "Dzień tygodnia")]
        public required string WeekDay { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Czas rozpoczęcia")]
        public  required DateTime DateStart { get; set; }
        [Display(Name = "Czas trwania")]

        public int Duration { get; set; }

        [Display(Name = "Cena")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string DateStop()
        {
            return DateStart.AddMinutes(Duration).ToString("hh:mm tt");
        }
    }
}
