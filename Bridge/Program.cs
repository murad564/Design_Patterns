namespace Bridge;




//// Implementation
//interface IColor
//{
//    string? Name { get; set; }
//    (int, int, int) GetRGB();
//}



//// Concrete implementation 1
//class Red : IColor
//{
//    public string? Name { get; set; } = "Red";
//    public (int, int, int) GetRGB() => (255, 0, 0);
//}


//// Concrete implementation 2

//class Blue : IColor
//{
//    public string? Name { get; set; } = "Blue";
//    public (int, int, int) GetRGB() => (0, 0, 255);
//}



//// Abstraction
//abstract class Shape
//{
//    public IColor? Color { get; set; }

//    public double Area { get; protected set; }
//    public byte Corner { get; init; }
//    public string? Name { get; set; }


//    protected Shape(IColor? color, double area, byte corner, string? name)
//    {
//        Color = color;
//        Area = area;
//        Corner = corner;
//        Name = name;
//    }
//}



//// Refined abstraction (optional)
//class Rectangle : Shape
//{
//    public double Width { get; set; }
//    public double Height { get; set; }

//    public Rectangle(IColor color, double width, double height)
//        : base(color, width * height, 4, nameof(Rectangle))
//    {
//        Width = width;
//        Height = height;
//    }

//}



//// Refined abstraction (optional)
//class Circle : Shape
//{
//    public double Radius { get; set; }


//    public Circle(IColor color, double radius)
//        : base(color, 3.14 * Math.Pow(radius, 2), 0, nameof(Circle))
//    {
//        Radius = radius;
//    }
//}



//class Program
//{
//    static void Main()
//    {
//        IColor color = new Red();
//        // color = new Blue();

//        Shape shape = new Rectangle(color, 10, 7);
//        shape = new Circle(color, 10);


//        Console.WriteLine(shape.Name);
//        Console.WriteLine(shape.Area);
//        Console.WriteLine(shape.Corner);
//        Console.WriteLine(shape.Color?.Name);


//        Console.WriteLine(shape.Color?.GetRGB());
//    }
//}




public interface IDevice
{
    int Channel { get; set; }
    byte Volume { get; set; }
    bool IsEnabled { get; set; }
}


public class Radio : IDevice
{
    private int channel;

    public int Channel
    {
        get { return channel; }
        set { channel = value; }
    }

    private byte volume;

    public byte Volume
    {
        get { return volume; }
        set { volume = value; }
    }

    private bool isEnabled;

    public bool IsEnabled
    {
        get { return isEnabled; }
        set { isEnabled = value; }
    }
}

public class TV : IDevice
{
    private int channel;

    public int Channel
    {
        get { return channel; }
        set { channel = value; }
    }

    private byte volume;

    public byte Volume
    {
        get { return volume; }
        set { volume = value; }
    }

    private bool isEnabled;

    public bool IsEnabled
    {
        get { return isEnabled; }
        set { isEnabled = value; }
    }
}



public class Remote
{
    protected IDevice device;

    public Remote(IDevice device)
    {
        this.device = device;
    }

    public void TogglePower() => device.IsEnabled = !device.IsEnabled;

    public void VolumeDown()
    {
        if (device.Volume > 0)
            --device.Volume;
    }


    public void VolumeUp()
    {
        if (device.Volume < 100)
            ++device.Volume;
    }

    public void ChannelDown()
    {
        if (device.Channel > 0)
            --device.Channel;
    }

    public void ChannelUp() => ++device.Channel;

    public override string ToString()
        => $"IsEnabled: {device.IsEnabled}, Volume: {device.Volume}, Channel: {device.Channel} ";
}


public class AdvancedRemote : Remote
{
    public AdvancedRemote(IDevice device) : base(device) { }
    public void Mute() => device.Volume = 0;
}


public class Program
{
    static void Main()
    {
        IDevice device = new TV();
        Remote remote = new Remote(device);

        remote.TogglePower();

        remote.VolumeUp();
        remote.VolumeUp();
        remote.ChannelUp();
        
        // remote.Mute();

        Console.WriteLine(remote);
    }
}