using Data.Models.Models.Request.Ticket;
using Data.Models.Models.Response.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.TicketServices
{
    public interface ITicketService
    {
        int  BookTicket(Ticket ticket);
        void UpdateTicketStatus(TicketUpdate updateTicket);
        IEnumerable<Ticket> GetAllTickets(GetTicket getTicket);
    }
}
