using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLab
{
    public class BasicKettle : Kettle, IFill, IPutOnStove
    {
        public BasicKettle()
        {
            type = "basic kettle";
            isEmpty = true;
        }

       public void PutOnStove()
        {
            Console.WriteLine("Switched on the stove, set maximum fire");
        }

        public override void Boil()
        {
            if (isEmpty)
            {
                AddWater();
            }
            PutOnStove();
            Console.WriteLine($"=== {type}`s boiled ===");

        }
        public void Fill(Cup cup)
        {
            cup.isFilled = true;
            cup.DisplayContent();
        }

        public override void BrewAcup(Cup cup, RawMaterial raw = null)
        {
            Console.WriteLine("\tBASIC KETTLE");
            Boil();
            Console.WriteLine("--- Switched the stove off --- ");
            if (raw == null)
            {
                raw = new Tea("");
            }
            cup.AddRaw(raw);
            Fill(cup);
        }
    }
}
