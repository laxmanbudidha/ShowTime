using Data.Models.Models.Response.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.TicketRepository;
using Data.Models.Models.Request.Ticket;

namespace Business_Logic_Layer.TicketServices
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public int BookTicket(Ticket ticket)
        {
            try
            {
                return _ticketRepository.BookTicket(ticket);
            }
            catch (Exception ex)
            {
                if (ex.Message == "No tickets are available .")
                {
                    throw new ApplicationException("No tickets are available .", ex);
                }
                throw new ApplicationException("An error occurred while booking the ticket.", ex);
            }
        }

        public void UpdateTicketStatus(TicketUpdate updateTicket)
        {
            try
            {
                _ticketRepository.UpdateTicketStatus(updateTicket);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid User")
                {
                    throw new ApplicationException("Invalid User UserID", ex);
                }
                throw new ApplicationException("An error occurred while updating the ticket status.", ex);
            }
        }

        public IEnumerable<Ticket> GetAllTickets(GetTicket getTicket)
        {
            try
            {
                return _ticketRepository.GetAllTickets(getTicket);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the tickets.", ex);
            }
        }
    }

}
