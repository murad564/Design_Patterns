using static System.Console;
#nullable disable



namespace Prototype_1
{


    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return MemberwiseClone() as Person;
        }

        public Person DeepCopy()
        {
            Person clone = (Person)MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            return clone;
        }
    }



    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            IdNumber = idNumber;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 15;
            p1.BirthDate = Convert.ToDateTime("2007-09-05");
            p1.Name = "Emin Novruz";
            p1.IdInfo = new IdInfo(777);

            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();


            WriteLine("Original values of p1, p2, p3:");

            WriteLine("   \np1 instance values: ");
            DisplayValues(p1);

            WriteLine("   \np2 instance values:");
            DisplayValues(p2);

            WriteLine("   \np3 instance values:");
            DisplayValues(p3);



            p1.Age = 25;
            p1.BirthDate = Convert.ToDateTime("1997-06-17");
            p1.Name = "Royal";
            p1.IdInfo.IdNumber = 135;

            WriteLine("\nValues of p1, p2 and p3 after changes to p1:");

            WriteLine("   \np1 instance values: ");
            DisplayValues(p1);

            WriteLine("   \np2 instance values (reference values have changed):");
            DisplayValues(p2);

            WriteLine("   \np3 instance values (everything was kept the same):");
            DisplayValues(p3);

        }


        public static void DisplayValues(Person p)
        {
            WriteLine($"\tName: {p.Name}, Age: {p.Age}, BirthDate: {p.BirthDate.ToShortDateString()}");
            WriteLine($"\tID#: {p.IdInfo.IdNumber}");
        }
    }
}





namespace Prototype_2
{

    //public interface IProtoType
    //{
    //    IProtoType Clone();
    //}

    public class Person : ICloneable
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        //public IProtoType Clone()
        //{
        //    // Shallow Copy
        //    return MemberwiseClone() as Person;
        //}



        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }
    }


    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            IdNumber = idNumber;
        }
    }
}





namespace Prototype_3
{
    using System.Runtime.Serialization.Formatters.Binary;


    [Serializable]
    public abstract class IPrototype<T>
    {
        // Shallow copy
        public T Clone()
        {
            return (T)MemberwiseClone();
        }


        // Deep Copy
        public T DeepCopy()
        {
            using MemoryStream stream = new();
            BinaryFormatter formatter = new();

#pragma warning disable SYSLIB0011
            formatter.Serialize(stream, this);

            stream.Seek(0, SeekOrigin.Begin);

            T copy = (T)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011

            return copy;
        }
    }
}