using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLab
{
    public abstract class Kettle
    {
        protected bool isEmpty;
        protected string type;
        public string GetType()
        {
            return type;
        }
        public void AddWater()
        {
            isEmpty = false;
            Console.WriteLine($" -- Added water to {type}");
        }
        public abstract void Boil();
        public abstract void BrewAcup(Cup cup, RawMaterial raw = null);
    }

    public interface IPutOnStove
    {
        void PutOnStove();
    }

    public interface IFill
    {
        void Fill(Cup cup);
    }

    
}
