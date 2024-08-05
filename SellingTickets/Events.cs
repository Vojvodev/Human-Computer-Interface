using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTickets
{
    public class Events
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ticketsTotal { get; set; }
        public int ticketsRegularAvailable { get; set; }
        public int ticketsVIPAvailable { get; set; }
    }
}
