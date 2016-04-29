using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace PetaPocoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Database("dbString");
            List<SalesPerson> salespeople = new List<SalesPerson>
            {
                new SalesPerson("Deacon"),
                new SalesPerson("Edan"),
                new SalesPerson("Yardley"),
                new SalesPerson("Farrah"),
                new SalesPerson("Jessamine"),
                new SalesPerson("Isabelle"),
                new SalesPerson("Judah")
            };

            //if (!salespeople.Any())
            foreach (var person in salespeople)
            {
                db.Insert(person);
            }

            List<SalesMade> salesmade = new List<SalesMade>
            {
                new SalesMade("Deacon", new DateTime(2015, 10, 15), 2846),
                new SalesMade("Deacon", new DateTime(2015, 09, 21), 8852),
                new SalesMade("Edan", new DateTime(2015, 12, 07), 5255),
                new SalesMade("Edan", new DateTime(2016, 02, 27), 5259),
                new SalesMade("Yardley", new DateTime(2015, 11, 23), 7244),
                new SalesMade("Farrah", new DateTime(2015, 12, 21), 8711),
                new SalesMade("Deacon", new DateTime(2015, 10, 02), 740),
                new SalesMade("Jessamine", new DateTime(2015, 04, 02), 9970),
                new SalesMade("Isabelle", new DateTime(2015, 12, 25), 6009),
                new SalesMade("Judah", new DateTime(2014, 07, 03), 9703)
            };


            foreach (var sale in salesmade)
            {
                db.Insert(sale);
            }

            //foreach (var s in db.Query<Sale>("Select * from salesmade"))
            //{
            //    Console.WriteLine($"{0} - {2}", s.Name, s.Amount);
            //}
            foreach (var sale in db.Query<SalesPerson>("select * from SalesPerson"))
            {
                Console.WriteLine($"Sales Person: {sale.Name}");
            }

            foreach (var sale in db.Query<SalesMade>("select * from SalesMade"))
            {
                Console.WriteLine($"{sale.Name} made a sale on {sale.Date.ToShortDateString()} for ${sale.Amount}");
            }

            foreach (var salelow in db.Query<SalesMade>("Select min(PreTaxAmount) SalesMade"))
            {
                Console.WriteLine(salelow.Amount);
            }

            foreach (var salehigh in db.Query<SalesMade>("Select min(PreTaxAmount) SalesMade"))
            {
                Console.WriteLine(salehigh.Amount);
            }


            Console.ReadLine();
        }
    }
}
