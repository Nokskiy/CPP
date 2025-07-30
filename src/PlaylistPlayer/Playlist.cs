namespace PP.PlaylistPlayer;

public class Playlist
{
    private List<string> songsPaths = new List<string>();
    public Playlist(string playlistName)
    {
        PlayLoopingPlaylist(playlistName);
    }

    private void PlayLoopingPlaylist(string playlistName)
    {
        while (true)
        {
            songsPaths = songsPaths.Count == 0 ? FilesManager.GetPlaylistData(playlistName).SongsPaths : songsPaths;

            string randomSongPath = songsPaths[new Random().Next(songsPaths.ToArray().Length)];

            songsPaths.Remove(randomSongPath);

            Console.WriteLine($"Now playing {Path.GetFileNameWithoutExtension(randomSongPath)}");

            new MediaPlayer(randomSongPath);
        }
    }
}