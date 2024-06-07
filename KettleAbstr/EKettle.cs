using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLab
{
    public class EKettle : Kettle, IFill
    {
        protected bool IsOn;
        public EKettle()
        {
            type = "e - kettle";
            isEmpty = true;
            IsOn = false;
        }

        public void SwitchOn()
        {
            if (!IsOn)
            {
                Console.WriteLine($"-- Switched on {type}");
            }
        }
        public override void Boil()
        {
            if (isEmpty)
            {
                AddWater();
            }
            SwitchOn();
            Console.WriteLine($"=== {type}`s boiled ===");

        }
        public void Fill(Cup cup)
        {
            cup.isFilled = true;
            cup.DisplayContent();
        }
        public override void BrewAcup(Cup cup, RawMaterial raw = null)
        {
            Console.WriteLine("\tE-KETTLE");
            Boil();
            if (raw == null)
            {
                raw = new Tea("");
            }
            cup.AddRaw(raw);
            Fill(cup);
        }
    }
}
