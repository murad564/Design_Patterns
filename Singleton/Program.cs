namespace Builder;
using System.Text;

// Product
// IBuilder
// ConcreteBuilder1, ConcreteBuilder2
// Director (Optional)



//class House
//{
//    public string? Name { get; set; }
//    public int Walls { get; set; }
//    public int Doors { get; set; }
//    public int Windows { get; set; }
//    public bool HasRoof { get; set; }
//    public bool HasGarage { get; set; }
//    public bool HasGarden { get; set; }
//    public bool HasPool { get; set; }

//    public override string ToString()
//    => @$"
//        Name {Name}
//        Walls {Walls}
//        Doors {Doors}
//        Windows {Windows}
//        HasRoof {HasRoof}
//        HasGarage {HasGarage}
//        HasGarden {HasGarden}
//        HasPool {HasPool}";
//}


//interface IHouseBuilder
//{
//    House House { get; set; }

//    IHouseBuilder BuildWalls(int count);
//    IHouseBuilder BuildDoors(int count);
//    IHouseBuilder BuildWindows(int count);
//    IHouseBuilder BuildRoof();
//    IHouseBuilder BuildGarage();
//    IHouseBuilder BuildGarden();
//    IHouseBuilder BuildPool();

//    void Reset();
//    House Build();
//}


//class WoodHouseBuilder : IHouseBuilder
//{
//    public House House { get; set; } = new House { Name = "WoodHouse" };

//    public IHouseBuilder BuildDoors(int count)
//    {
//        House.Doors = count;
//        return this;
//    }
//    public IHouseBuilder BuildGarage()
//    {
//        House.HasGarage = true;
//        return this;
//    }
//    public IHouseBuilder BuildGarden()
//    {
//        House.HasGarden = true;
//        return this;
//    }
//    public IHouseBuilder BuildPool()
//    {
//        House.HasPool = true;
//        return this;
//    }
//    public IHouseBuilder BuildRoof()
//    {
//        House.HasRoof = true;
//        return this;
//    }
//    public IHouseBuilder BuildWalls(int count)
//    {
//        House.Walls = count;
//        return this;
//    }
//    public IHouseBuilder BuildWindows(int count)
//    {
//        House.Windows = count;
//        return this;
//    }
//    public House Build() => House;

//    public void Reset() => House = new House();
//}

//class StoneHouseBuilder : IHouseBuilder
//{
//    public House House { get; set; } = new House { Name = "StoneHouse" };

//    public IHouseBuilder BuildDoors(int count)
//    {
//        House.Doors = count;
//        return this;
//    }
//    public IHouseBuilder BuildGarage()
//    {
//        House.HasGarage = true;
//        return this;
//    }
//    public IHouseBuilder BuildGarden()
//    {
//        House.HasGarden = true;
//        return this;
//    }
//    public IHouseBuilder BuildPool()
//    {
//        House.HasPool = true;
//        return this;
//    }
//    public IHouseBuilder BuildRoof()
//    {
//        House.HasRoof = true;
//        return this;
//    }
//    public IHouseBuilder BuildWalls(int count)
//    {
//        House.Walls = count;
//        return this;
//    }
//    public IHouseBuilder BuildWindows(int count)
//    {
//        House.Windows = count;
//        return this;
//    }
//    public House Build() => House;

//    public void Reset() => House = new House();
//}






//class Program
//{
//    static void Main()
//    {

//        IHouseBuilder builder = new StoneHouseBuilder();


//        House house = builder
//            .BuildGarage()
//            .BuildDoors(2)
//            .BuildWalls(7)
//            .BuildGarden()
//            .Build();

//        Console.WriteLine(house);




//        // FluentValidation 

//        /*
//            StringBuilder sb = new StringBuilder();
//            string str = sb
//                .Append("text1")
//                .Append("text2")
//                .Append("text3")
//                .ToString();
//            Console.WriteLine(str); 
//        */
//    }
//}

//EndPointBuilder

//-baseUrl: string
//-routeParameters: StringBuilder
//-queryStrings: StringBuilder

//+EndPointBuilder(baseUrl:string)

//+AppendRoute(string route) : EndPointBuilder
//+AppendQueryString(string key, string value) : EndPointBuilder
//+Build() : string




class EndPointBuilder
{
    private string baseUrl;

    private StringBuilder routeParameters;
    private StringBuilder queryStrings;

    public EndPointBuilder(string baseUrl)
    {
        this.baseUrl = baseUrl;
        routeParameters = new();
        queryStrings = new();
    }


    public EndPointBuilder AppendRoute(string route)
    {
        routeParameters.Append('/');
        routeParameters.Append(route);
        return this;
    }


    public EndPointBuilder AppendQueryString(string key, string value)
    {
        queryStrings.Append(key);
        queryStrings.Append('=');
        queryStrings.Append(value);
        queryStrings.Append('&');
        return this;
    }

    public string Build()
    {
        var url = $"{baseUrl}{routeParameters}";

        if (queryStrings.Length > 0)
            url += $"?{queryStrings.ToString().TrimEnd('&')}";

        return url;
    }

}


class Program
{
    static void Main()
    {
        EndPointBuilder builder = new("https://www.instagram.com");

        string url = builder
            .AppendRoute("api")
            .AppendRoute("v1")
            .AppendRoute("students")
            .AppendQueryString("name", "Murad")
            .AppendQueryString("surname", "Meherremli")
            .Build();

        Console.WriteLine(url);
    }
}