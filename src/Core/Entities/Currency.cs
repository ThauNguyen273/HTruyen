using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double ExchangeRate { get; set; }
    }
}
