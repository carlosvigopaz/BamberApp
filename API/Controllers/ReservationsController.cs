using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.Reservations;

namespace API.Controllers
{
    public class ReservationsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> GetReservations()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(Guid id)
        {
            return await Mediator.Send(new Details.Query{ Id = id});
        }

        [HttpPost("check")]
        public async Task<ActionResult<bool>> CheckAvailability(Reservation reservation)
        {
            return await Mediator.Send(new CheckAvailability.Query
            {
                House = reservation.House,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            });
        }
    }
}