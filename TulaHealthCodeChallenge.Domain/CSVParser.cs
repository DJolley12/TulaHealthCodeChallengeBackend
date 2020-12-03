using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TulaHealthCodeChallenge.Domain
{
    public class CSVParser
    {
        public Tuple<List<Order>, List<Ticket>> ParseWithRegularExpressions(string csv)
        {
            var lines = csv.Split('\n');

            var orderList = new List<Order>();
            var ticketList = new List<Ticket>();

            foreach (var line in lines)
            {
                Regex pattern = new Regex(",");
                string[] data = pattern.Split(line);

                if (data[0] != "OrderId" && data[0] != "")
                {


                    var ticket = new Ticket();

                    ticket.FirstName = data[1];
                    ticket.LastName = data[2];
                    ticket.TicketNumber = data[3];

                    DateTime.TryParse(data[4], out DateTime eventDate);
                    ticket.EventDate = eventDate;

                    Int32.TryParse(data[0], out int orderId);

                    var existingOrder = orderList.FirstOrDefault(o => o.Id == orderId);
                    if (existingOrder == null)
                    {
                        var order = new Order();
                        order.Id = orderId;
                        if (order.Tickets == null)
                        {
                            order.Tickets = new List<Ticket>();
                        }
                        order.Tickets.Add(ticket);

                        orderList.Add(order);
                    }
                    else
                    {
                        existingOrder.Tickets.Add(ticket);
                    }
                    ticketList.Add(ticket);
                }
            }

            return new Tuple<List<Order>, List<Ticket>>(orderList, ticketList);
        }
    }
}
