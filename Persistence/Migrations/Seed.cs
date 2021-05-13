using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Reservations.Any()) return;

            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    House = "Hütte",
                    Guests = "Monica, Peter",
                    StartDate = new DateTime(2020, 9, 1),
                    EndDate = new DateTime(2020, 9, 6),
                },
                new Reservation
                {
                    House = "Burg",
                    Guests = "Ulrike, Carlos",
                    StartDate = new DateTime(2020, 9, 1),
                    EndDate = new DateTime(2020, 9, 6),
                },
                new Reservation
                {
                    House = "Hütte",
                    Guests = "Alicia, Javier, Marcos, Fabian",
                    StartDate = new DateTime(2021, 7, 1),
                    EndDate = new DateTime(2021, 8, 15),
                },
                new Reservation
                {
                    House = "Hütte",
                    Guests = "Ulrike, Carlos",
                    StartDate = new DateTime(2021, 8, 23),
                    EndDate = new DateTime(2021, 9, 5),
                },
            };

            await context.Reservations.AddRangeAsync(reservations);
            await context.SaveChangesAsync();
        }
    }
}