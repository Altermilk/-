using AbstractLab;

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

