# ООП модель чайника
## Автор
Калинич КС-34
## Классы
Класс, определяющий логику работы чайника:
```cs
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

        public async Task AddWater(int water){...}
        public async Task Boil(){...}
        public async Task BrewACup(int cup){...}
        void CheckWaterLvl(){...}

        enum occupancyState : int
        {
            isFull,
            isFilled,
            isEmpty,
        }
}
```
Класс ошибок:
```cs
  internal class KettleErrors
    {
        internal class NotEnoughWaterException : Exception
        {
            public NotEnoughWaterException() : base("Not enough water to boil") { }
        }
    }
```
Класс исполняемой программы:
```cs
using KettleOOP;

internal class Program
{
    static async Task Main(string[] args)
    {
        var kettle = new Kettle(1000, 250);
        await kettle.BrewACup(250);
        await kettle.BrewACup(100);
    }
}
```
