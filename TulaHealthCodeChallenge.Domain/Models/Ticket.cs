using System;
using System.Collections.Generic;
using System.Text;

namespace TulaHealthCodeChallenge.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EventDate { get; set; }
        public int OrderId { get; set; }
    }
}
