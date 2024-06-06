using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// набрать воду, вскипятить, доаждаться пока вскипит
namespace KettleOOP
{
    public class Kettle
    {
        int waterLvl, maxLvl, minLvl;
        int temperature;
        bool isHot;
        occupancyState stateO;
        public Kettle(int max, int min)
        {
            maxLvl = max;
            minLvl = min;
            temperature = 0;
            stateO = occupancyState.isEmpty;
            isHot = false;
        }
        //void Utilize()
        //{

        //}

        public async Task AddWater(int water)
        {
            if (stateO == occupancyState.isFull)
            {
                return;
            }
            var info = new StringBuilder($"Water level changed: {waterLvl}/{maxLvl} -> ");
            int portion = maxLvl - water - waterLvl;
            if (temperature > 20){
                temperature -= 20;
            }
            else
            {
                temperature = 20;
            }
            waterLvl += portion;
            CheckWaterLvl();
            info.Append(waterLvl);
            info.Append($"/{maxLvl} (ml)");
            Console.WriteLine(info.ToString());
            isHot = false;
            await Task.Delay(1000);
        }

        public async Task Boil()
        {
            if (stateO == occupancyState.isEmpty)
            {
               throw new KettleErrors.NotEnoughWaterException();
            }
            Console.WriteLine(" --- Kettle is Boiling ---");
            while (temperature < 100)
            {
                temperature ++;
                Console.WriteLine($"\tT = {temperature} C");
                await Task.Delay(100);
            }
            Console.WriteLine("\n --- Kettle is Boiled ---");
            isHot = true;
        }

        public async Task BrewACup(int cup)
        {
            if (!isHot)
            {
                
                try
                {
                    await Boil(); // Пытаемся кипятить вновь
                }
                catch (KettleErrors.NotEnoughWaterException ex)
                {
                    Console.WriteLine(ex.Message);
                    Random rnd = new Random();
                    await AddWater(rnd.Next(cup, maxLvl));
                    await Boil();
                }
            }

            Console.WriteLine("\nBrewing ... ");
            var water = 0;
            while (water < cup)
            {
                water ++;
                if (water % 50 == 0)
                {
                    Console.WriteLine($"filling cup: {water}/{cup}");
                }
                await Task.Delay(10);
            }
            waterLvl -= cup;
           
            Console.WriteLine("\n\t=-=-=- Tea is ready -=-=-=");
        }


        void CheckWaterLvl()
        {
            if (waterLvl < minLvl)
            {
                stateO = occupancyState.isEmpty;
            }
            else if (waterLvl == maxLvl)
            {
                stateO = occupancyState.isFull;
            }
            else
            {
                stateO = occupancyState.isFilled;
            }
        }
    }

    enum occupancyState : int
    {
        isFull,
        isFilled,
        isEmpty,
    }
}
