using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLab
{
    public class Cup : IAddRawMaterial
    {
        private string content;
        public bool isFilled;
        public Cup()
        {
            isFilled = false;
        }
        public void AddRaw(RawMaterial raw)
        {
            content = raw.GetName();
            Console.WriteLine($" --- Added {content} ---");
        }

        public void DisplayContent()
        {
            Console.WriteLine($"The cup contains: { content}\n");
        }
    }
}
