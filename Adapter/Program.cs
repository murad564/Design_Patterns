namespace Adapter;

interface IAudioFile
{
    void Play();
}

class Mp3 : IAudioFile
{
    public void Play()
    {
        Console.WriteLine("Mp3 audio playing");
    }
}

class Wav : IAudioFile
{
    public void Play()
    {
        Console.WriteLine("Wav audio playing");
    }
}

class FLAC : IAudioFile
{
    public void Play()
    {
        Console.WriteLine("FLAC audio playing");
    }
}



// Nuget
class OGG
{
    public void PlayAudio()
    {
        Console.WriteLine("OGG audio playing");
    }
}





// Object Adapter
class OggAdapter : IAudioFile
{
    private readonly OGG _ogg;

    public OggAdapter()
    {
        _ogg = new OGG();
    }

    public void Play()
    {
        _ogg.PlayAudio();
    }
}





//// Class Adapter
//class OggAdapter : OGG, IAudioFile
//{
//    public void Play()
//    {
//        PlayAudio();
//    }
//}



class Program
{
    static void Main()
    {
        List<IAudioFile> winamp = new()
        {
            new Mp3(),
            new Wav(),
            new OggAdapter(),
            new FLAC(),
            new Mp3(),
            new FLAC(),
            new OggAdapter()
        };


        foreach (var audio in winamp)
            audio.Play();
    }
}