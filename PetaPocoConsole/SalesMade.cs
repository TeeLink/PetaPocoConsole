using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetaPocoConsole
{
    public class SalesMade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public SalesMade(string name, DateTime date, double amount)
        {
            Name = name;
            Date = date;
            Amount = amount;
        }
    }
}
