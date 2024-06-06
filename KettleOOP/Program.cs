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