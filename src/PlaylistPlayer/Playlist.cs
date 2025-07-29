namespace PP.PlaylistPlayer;

public class Playlist
{
    private string _lastSongPath = null!;
    public Playlist(string playlistName)
    {
        PlayLoopingPlaylist(playlistName);
    }

    private void PlayLoopingPlaylist(string playlistName)
    {
        while (true)
        {
            List<string> songsPaths = FilesManager.GetPlaylistData(playlistName).SongsPaths;

            songsPaths.Remove(_lastSongPath);

            string randomSongPath = songsPaths[new Random().Next(songsPaths.ToArray().Length)];

            _lastSongPath = randomSongPath;

            new MediaPlayer(randomSongPath);
        }
    }
}