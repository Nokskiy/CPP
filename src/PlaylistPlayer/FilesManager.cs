using Newtonsoft.Json;

namespace PP.PlaylistPlayer;

public static class FilesManager
{
    private static string ProgramFilesPath => Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ConsolePlaylistsPlayer")).ToString();
    public static string PathToPlaylist(string playlistName) => Path.Combine(ProgramFilesPath, $"{playlistName}.json");

    public static void CreatePlaylist(string playlistName) => File.Create(PathToPlaylist(playlistName));
    public static void RemovePlaylist(string playlistName) => File.Delete(PathToPlaylist(playlistName));

    public static void AddSongToPlaylist(string playlistName, string songPath)
    {
        if (!File.Exists(songPath))
        {
            Console.WriteLine($"Song with path {songPath} not exists");
            Environment.Exit(1);
        }

        var playlistData = GetPlaylistData(playlistName);
        playlistData.AddSong(songPath);
        File.WriteAllText(PathToPlaylist(playlistName), JsonConvert.SerializeObject(playlistData, Formatting.Indented));
    }
    public static void AddFolderToPlaylist(string playlistName, string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder with path {folderPath} not exists");
            Environment.Exit(1);
        }

        Console.WriteLine(folderPath);
        var playlistData = GetPlaylistData(playlistName);
        foreach (var i in Directory.GetFiles(folderPath))
            playlistData.AddSong(i);


        File.WriteAllText(PathToPlaylist(playlistName), JsonConvert.SerializeObject(playlistData, Formatting.Indented));
    }
    public static void RemoveSongFromPlaylist(string playlistName, string songPath)
    {
        var playlistData = GetPlaylistData(playlistName);
        playlistData.RemoveSong(songPath);
        File.WriteAllText(PathToPlaylist(playlistName), JsonConvert.SerializeObject(playlistData, Formatting.Indented));
    }

    public static PlaylistData GetPlaylistData(string playlistName)
    {
        if (!File.Exists(PathToPlaylist(playlistName)))
        {
            Console.WriteLine($"Playlist with name {playlistName} not exists");
            Environment.Exit(1);
        }
        try
        {
            return JsonConvert.DeserializeObject<PlaylistData>(File.ReadAllText(PathToPlaylist(playlistName)));
        }
        catch
        {
            return new PlaylistData();
        }
    }

    public static string[] PlaylistsNames => Directory.GetFiles(ProgramFilesPath).ToList().Select(x => Path.GetFileNameWithoutExtension(x)).ToArray();
    public static string[] PlaylistSongs(string playlistName)
    {
        try
        {
            return GetPlaylistData(playlistName).SongsPaths.ToArray();
        }
        catch
        {
            Console.Write("Playlist is null");
            Environment.Exit(1);
            string[] ret = new string[0];
            return ret;
        }
    }

    public static void RemoveAllRemovedSongs()
    {
        foreach (var playlistName in PlaylistsNames)
        {
            var playlist = GetPlaylistData(playlistName);
            foreach (var songPath in playlist.SongsPaths)
                if (!File.Exists(songPath))
                    RemoveSongFromPlaylist(playlistName, songPath);
        }
    }
}