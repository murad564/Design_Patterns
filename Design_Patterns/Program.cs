namespace FactoryPattern_Example_1
{
    interface IProduct
    {
        string ShipFrom();
    }

    class ProductA : IProduct
    {
        public string ShipFrom()
        {
            return " from South Africa";
        }
    }

    class ProductB : IProduct
    {
        public string ShipFrom()
        {
            return " from Spain";
        }
    }

    class DefaultProduct : IProduct
    {
        public string ShipFrom()
        {
            return "not available";
        }
    }


    class Creator
    {
        public IProduct FactoryMethod(int month)
            => month switch
            {
                >= 4 and <= 11 => new ProductA(),
                1 or 2 or 12 => new ProductB(),
                _ => new DefaultProduct()
            };
    }


    class Program
    {
        // static void Main()
        // {
        //     Creator c = new Creator();
        //     IProduct product;
        // 
        //     for (int i = 1; i <= 12; i++)
        //     {
        //         product = c.FactoryMethod(i);
        //         Console.WriteLine("Avocados " + product.ShipFrom());
        //     }
        // }
    }
}











namespace FactoryPattern_Example_2
{
    public abstract class Logistics
    {
        public abstract ITransport CreateTransport();
        public void PlanDelivery()
        {
            ITransport transport = CreateTransport();
            transport?.Deliver();
        }

    }
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }
    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }
    public class AirLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Airplane();
        }
    }


    public interface ITransport
    {
        public void Deliver();
    }

    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivered by land in a box");
        }
    }
    public class Airplane : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivered by Airplane in a container");
        }
    }

    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivered by Sea in a container");

        }
    }

    class Client
    {
        static void Main()
        {
            // Logistics logistics = new RoadLogistics();
            // ITransport transport = logistics.CreateTransport();
            // transport.Deliver();


            Logistics? logistics = null;

            while (true)
            {
                Console.WriteLine(@"
				1: Road
				2: Sea
				3: Air
				Any: Exit");

                Console.Write("\n\tEnter choice: ");


                logistics = Console.ReadLine() switch
                {
                    "1" => new RoadLogistics(),
                    "2" => new SeaLogistics(),
                    "3" => new AirLogistics(),
                    _ => null
                };

                if (logistics == null)
                    break;


                logistics?.PlanDelivery();
            }
        }
    }
}