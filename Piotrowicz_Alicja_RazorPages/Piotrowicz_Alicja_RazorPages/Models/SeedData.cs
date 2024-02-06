using Microsoft.EntityFrameworkCore;
using Piotrowicz_Alicja_RazorPages.Data;
using System.ComponentModel.DataAnnotations;

namespace Piotrowicz_Alicja_RazorPages.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Piotrowicz_Alicja_RazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Piotrowicz_Alicja_RazorPagesContext>>()))
            {
                if (context == null || context.Trening == null)
                {
                    throw new ArgumentNullException("Null Piotrowicz_Alicja_RazorPagesContext");
                }

                // Look for any movies.
                if (context.Trening.Any())
                {
                    return;   // DB has been seeded
                }

                context.Trening.AddRange(
                    new Trening
                    {
                        Type = "Air Yoga",
                        WeekDay = "Poniedziałek",
                        DateStart = DateTime.Parse("13:30"),
                        Duration = 90,
                        Price = 60
                    },

                    new Trening
                    {
                        Type = "Hataha Yoga",
                        WeekDay = "Wtorek",
                        DateStart = DateTime.Parse("18:30"),
                        Duration = 90,
                        Price = 60
                    },

                    new Trening
                    {
                        Type = "Yoga IYENGARA",
                        WeekDay = "Wtorek",
                        DateStart = DateTime.Parse("8:30"),
                        Duration = 90,
                        Price = 30
                    },

                    new Trening
                    {
                        Type = "Yoga Vinjasa",
                        WeekDay = "Piątek",
                        DateStart = DateTime.Parse("20:30"),
                        Duration = 90,
                        Price = 60
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
