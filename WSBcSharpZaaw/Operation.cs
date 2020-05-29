using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSBcSharpZaaw
{
    class Operation
    {
        public short Price { get; private set; }
        public DateTime Date { get; private set; }
        public Operation(short price,DateTime date)
        {
            Price = price;
            Date = date;
        }
    }

    enum jobMode
    {
        FullTime,
        PartTime,
        Contract
    }
}
