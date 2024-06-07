# Чайники и Абстракции
## Автор
Калинич КС-34
## Что использовано?
интерфейсы, абстрактные классы, перегрузка абстрактных методов
## Основные классы
1. Kettle
```cs
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
```
2. EKettle.cs
```cs
public class EKettle : Kettle, IFill
    {
        protected bool IsOn;

        public EKettle(){...}

        public void SwitchOn(){...}

        public override void Boil(){...}
           
        public void Fill(Cup cup){...}

        public override void BrewAcup(Cup cup, RawMaterial raw = null) {...}
    }
```
3. BasicKettle.cs
```cs
public class BasicKettle : Kettle, IFill, IPutOnStove
    {
        public BasicKettle() {}

       public void PutOnStove() {}
       
        public override void Boil() {}
        
        public void Fill(Cup cup) {}

        public override void BrewAcup(Cup cup, RawMaterial raw = null) {}
    }
```
4. GeyserCoffeMaker.cs
```cs
 internal class GeyserCoffeMaker : Kettle, IPutOnStove
    {
        public GeyserCoffeMaker() {...}
       
        public void PutOnStove() {...}
        
        public override void Boil() {...}
        
        public void Fill(Cup cup) {...}

        public override void BrewAcup(Cup cup, RawMaterial raw = null) {...}
    }
```
5. RawMaterial.cs
```cs
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
```
6. Cup.cs
```cs
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
```
7. Program.cs
```cs
internal class Program
{
    private static void Main(string[] args)
    {
        List<Kettle> kettleList = new List<Kettle>() { new EKettle(), new BasicKettle(), new GeyserCoffeMaker(), new BasicKettle(),  new GeyserCoffeMaker(), new EKettle() };
        List<Cup> cups = new List<Cup>(5);
        for (int i = 0; i < 6; i++)
        {
            cups.Add(new Cup());
        }
        for (int i = 0; i < 3; i++)
        {
            kettleList[i].BrewAcup(cups[i]);
        }
        kettleList[3].BrewAcup(cups[3], new Tea("Ceilon"));
        kettleList[4].BrewAcup(cups[4], new CoffeBeans());
        kettleList[5].BrewAcup(cups[5], new GroundCoffe());

        for (int i = 0;i < 6; i++)
        {
            Console.WriteLine($"\n-=-= cup #{i+1} =-=-\t");
            cups[i].DisplayContent();
        }
    }
}
```
## Вывод программы
```
        E-KETTLE
 -- Added water to e - kettle
-- Switched on e - kettle
=== e - kettle`s boiled ===
 --- Added tea ---
The cup contains: tea

        BASIC KETTLE
 -- Added water to basic kettle
Switched on the stove, set maximum fire
=== basic kettle`s boiled ===
--- Switched the stove off ---
 --- Added tea ---
The cup contains: tea

        GEYSER COFFE MAKER
 -- Added water to geyser coffe maker
 --- Added coffee ---
Switched on the stove, set medium fire
=== geyser coffe maker`s boiled ===
--- Switched the stove off ---
The cup contains: coffee

        BASIC KETTLE
 -- Added water to basic kettle
Switched on the stove, set maximum fire
=== basic kettle`s boiled ===
--- Switched the stove off ---
 --- Added Ceilontea ---
The cup contains: Ceilontea

-/- grinded coffe beans -/-
        GEYSER COFFE MAKER
 -- Added water to geyser coffe maker
 --- Added coffee ---
Switched on the stove, set medium fire
=== geyser coffe maker`s boiled ===
--- Switched the stove off ---
The cup contains: coffee

        E-KETTLE
 -- Added water to e - kettle
-- Switched on e - kettle
=== e - kettle`s boiled ===
 --- Added coffee ---
The cup contains: coffee


-=-= cup #1 =-=-
The cup contains: tea


-=-= cup #2 =-=-
The cup contains: tea


-=-= cup #3 =-=-
The cup contains: coffee


-=-= cup #4 =-=-
The cup contains: Ceilontea


-=-= cup #5 =-=-
The cup contains: coffee


-=-= cup #6 =-=-
The cup contains: coffee
```
