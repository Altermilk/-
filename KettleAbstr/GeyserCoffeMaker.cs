using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLab
{
    internal class GeyserCoffeMaker : Kettle, IPutOnStove
    {
        public GeyserCoffeMaker()
        {
            type = "geyser coffe maker";
            isEmpty = true;
        }

        public void PutOnStove()
        {
            Console.WriteLine("Switched on the stove, set medium fire");
        }

        public override void Boil()
        {
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
            Console.WriteLine("\tGEYSER COFFE MAKER");
            AddWater();
            if (raw == null)
            {
                raw = new GroundCoffe();
            }
            cup.AddRaw(raw);
            Boil();
            Console.WriteLine("--- Switched the stove off --- ");
            Fill(cup);
        }
    }
}
