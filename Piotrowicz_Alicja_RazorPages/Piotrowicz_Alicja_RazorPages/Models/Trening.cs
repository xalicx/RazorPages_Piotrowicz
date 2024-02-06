using System.ComponentModel.DataAnnotations;

namespace Piotrowicz_Alicja_RazorPages.Models
{
    public class Trening
    {
        public int Id { get; set; }
        public string? Type { get; set; }

        [Display(Name = "Day of week")]
        public required string WeekDay { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Czas rozpoczęcia")]
        public  required DateTime DateStart { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public string DateStop()
        {
            return DateStart.AddMinutes(Duration).ToString("hh:mm");
        }
    }
}
