using static System.Console;




abstract class AbstractCover { }

class CocaColaCover : AbstractCover { }

class FantaCover : AbstractCover { }

class SpriteCover : AbstractCover { }





abstract class AbstractWater { }

class CocaColaWater : AbstractWater { }

class FantaWater : AbstractWater { }

class SpriteWater : AbstractWater { }







abstract class AbstractBottle
{
    public abstract void Interact(AbstractWater water);
    public abstract void Interact(AbstractCover water);
}

class CocaColaBottle : AbstractBottle
{
    public override void Interact(AbstractWater water)
    {
        WriteLine(this + " interacts with " + water);
    }

    public override void Interact(AbstractCover cover)
    {
        WriteLine(this + " interacts with " + cover);
    }
}

class FantaBottle : AbstractBottle
{
    public override void Interact(AbstractWater water)
    {
        WriteLine(this + " interacts with " + water);
    }

    public override void Interact(AbstractCover cover)
    {
        WriteLine(this + " interacts with " + cover);
    }
}

class SpriteBottle : AbstractBottle
{
    public override void Interact(AbstractWater water)
    {
        WriteLine(this + " interacts with " + water);
    }

    public override void Interact(AbstractCover cover)
    {
        WriteLine(this + " interacts with " + cover);
    }
}








abstract class AbstractFactory
{
    public abstract AbstractBottle CreateBottle();
    public abstract AbstractWater CreateWater();
    public abstract AbstractCover CreateCover();
}



class CocaColaFactory : AbstractFactory
{
    public override AbstractBottle CreateBottle()
        => new CocaColaBottle();

    public override AbstractCover CreateCover()
        => new CocaColaCover();

    public override AbstractWater CreateWater()
        => new CocaColaWater();
}

class FantaFactory : AbstractFactory
{
    public override AbstractBottle CreateBottle()
        => new FantaBottle();

    public override AbstractCover CreateCover()
        => new FantaCover();

    public override AbstractWater CreateWater()
        => new FantaWater();
}

class SpriteFactory : AbstractFactory
{
    public override AbstractBottle CreateBottle()
        => new SpriteBottle();

    public override AbstractCover CreateCover()
        => new SpriteCover();

    public override AbstractWater CreateWater()
        => new SpriteWater();
}









class Client
{
    private AbstractBottle _bottle;
    private AbstractWater _water;
    private AbstractCover _cover;

    public Client(AbstractFactory factory)
    {
        _bottle = factory.CreateBottle();
        _water = factory.CreateWater();
        _cover = factory.CreateCover();
    }

    public void Run()
    {
        _bottle.Interact(_water);
        _bottle.Interact(_cover);
    }
}



class Program
{
    static void Main()
    {
        Client? client = null;

        client = new Client(new CocaColaFactory());
        client.Run();


        client = new Client(new FantaFactory());
        client.Run();


        client = new Client(new SpriteFactory());
        client.Run();
    }
}