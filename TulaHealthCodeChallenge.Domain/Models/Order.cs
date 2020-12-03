using System;
using System.Collections.Generic;

namespace TulaHealthCodeChallenge.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}
