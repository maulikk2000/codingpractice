using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainofResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver director = new Director();
            Approver vp = new VicePresident();
            Approver president = new President();

            director.SetSuccessor(vp);
            vp.SetSuccessor(president);

            Purchase pur = new Purchase
            {
                Number = 1000,
                Amount = 350.00,
                Purpose = "assets"
            };

            director.ProcessRequest(pur);

            pur = new Purchase
            {
                Number = 2000,
                Amount = 35000.00,
                Purpose = "assets2"
            };
            director.ProcessRequest(pur);

            pur = new Purchase
            {
                Number = 3000,
                Amount = 95000.00,
                Purpose = "assets"
            };

            director.ProcessRequest(pur);
        }
    }

    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if(purchase.Amount < 10000)
            {
                Console.WriteLine("");
            }
            else if(Successor != null)
            {
                Successor.ProcessRequest(purchase);
            }
        }
    }

    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if(purchase.Amount < 25000)
            {
                Console.WriteLine("VP approved");
            }
            else if(Successor != null)
            {
                Successor.ProcessRequest(purchase);
            }
        }
    }

    public class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if(purchase.Amount < 100000)
            {
                Console.WriteLine("President Approved");
            }
            else
            {
                Console.WriteLine("Need another way to approve");
            }
        }
    }

    public abstract class Approver
    {
        protected Approver Successor;

        public void SetSuccessor(Approver successor)
        {
            this.Successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    public class Purchase
    {
        public int Number { get; set; }
        public double Amount { get; set; }
        public string Purpose { get; set; }
    }
}
