using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLab
{
    public interface IAddRawMaterial
    {
        void AddRaw(RawMaterial raw);
    }

    public abstract class RawMaterial
    {

        public abstract string GetName();
    }

    public class GroundCoffe : RawMaterial
    {
        public string name = "coffee";
        public GroundCoffe() { }
        public override string GetName()
        {
            return name;
        }
    }

    public class CoffeBeans : GroundCoffe
    {
        public void Grind()
        {
            Console.WriteLine("-/- grinded coffe beans -/-");
        }
        public CoffeBeans()
        {
            Grind();
        }
        public override string GetName()
        {
            return name;
        }
    }

    public class Tea : RawMaterial
    {
        public string type = string.Empty;

        public string name = "tea";
        public Tea(string _type)
        {
            type = _type;
        }
        public override string GetName()
        {
            return type+name;
        }
    }
}
