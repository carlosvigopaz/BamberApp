using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Persistence;
using System.Linq;

namespace Application.Reservations
{
    public class CheckAvailability
    {
        public class Query : IRequest<bool>
        {
            public string House { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class Handler : IRequestHandler<Query, bool>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var reservations = await _context.Reservations
                    // .Where(r =>
                    //     r.House == request.House &&
                    //     r.StartDate < request.EndDate &&
                    //     r.EndDate > request.StartDate)
                    .Where(r =>
                        r.House == request.House &&
                        r.StartDate.Date <= request.EndDate.Date &&
                        r.EndDate.Date >= request.StartDate.Date)
                    .ToListAsync();

                if (reservations.Count > 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}