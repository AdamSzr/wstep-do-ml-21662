using CSharp_Utils;

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Weight { get; set; }
    public int Length { get; set; }
    public int MaxSpeed { get; set; }
    public int DoorsCount { get; set; }
    public int Height { get; set; }

    public static Car Random(){
        var x = new Car();
        var rand = new System.Random();
        x.DoorsCount = rand.Next(2,6);
        x.Weight = rand.Next(500,3500);
        x.Height = rand.Next(150,260);
        x.MaxSpeed = rand.Next(70,360);
        x.Length = rand.Next(220,450);
        x.Brand = List.Of("BMW","VW","AUDI","SKODA")[rand.Next(0,4)];
        x.Model = List.Of("E30","POLO","A3","FABIA")[rand.Next(0,4)];
        return x;
    }
}