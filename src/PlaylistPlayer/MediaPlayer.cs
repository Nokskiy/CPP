using NAudio.Wave;
using PP.PlaylistPlayer;

public class MediaPlayer
{
    public MediaPlayer(string songPath)
    {
        try
        {
            using (var audioFile = new AudioFileReader(songPath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing) Thread.Sleep(1000);
            }
        }
        catch
        {
            Console.WriteLine($"{songPath} is invalid");
        }

        FilesManager.RemoveAllRemovedSongs();
    }
}