using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence;
using System.Threading;

namespace Application.Reservations
{
    public class List
    {
        public class Query : IRequest<List<Reservation>>
        { }

        public class Handler : IRequestHandler<Query, List<Reservation>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<Reservation>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Reservations.ToListAsync();
            }
        }
    }
}