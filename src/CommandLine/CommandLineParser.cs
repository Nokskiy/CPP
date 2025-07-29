using CommandLine;
using PP.PlaylistPlayer;

namespace PP.CommandLine;

public class CommandLineParser
{
    public class Options
    {
        [Option("cp", Required = false, HelpText = "Create new playlist <Playlist name>")]
        public string? CreatePlaylist { get; set; }

        [Option("rp", Required = false, HelpText = "Remove playlist <Playlist name>")]
        public string? RemovePlaylist { get; set; }


        [Option("as", Required = false, HelpText = "Add song to playlist <Playlist name> <Song path>")]
        public IEnumerable<string>? AddSongToPlaylist { get; set; }

        [Option("rs", Required = false, HelpText = "Remove song from playlist <Playlist name> <Song path>")]
        public IEnumerable<string>? RemoveSongFromPlaylist { get; set; }


        [Option("pl", Required = false, HelpText = "Print playlists list")]
        public bool PlaylistsList { get; set; }

        [Option("ps", Required = false, HelpText = "Print playlist songs")]
        public string? PlaylistSongs { get; set; }

    }
    public CommandLineParser(string[] args) => Parse(args);

    private void Parse(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args).
        WithParsed<Options>(o =>
        {
            if (o.CreatePlaylist != null) FilesManager.CreatePlaylist(o.CreatePlaylist);
            if (o.RemovePlaylist != null) FilesManager.RemovePlaylist(o.RemovePlaylist);

            if (o.AddSongToPlaylist?.ToArray().Length == 2) FilesManager.AddSongToPlaylist(o.AddSongToPlaylist.ToArray()[0], o.AddSongToPlaylist.ToArray()[1]);
            if (o.RemoveSongFromPlaylist?.ToArray().Length == 2) FilesManager.RemoveSongFromPlaylist(o.RemoveSongFromPlaylist.ToArray()[0], o.RemoveSongFromPlaylist.ToArray()[1]);

            if (o.PlaylistsList) FilesManager.PlaylistsNames.ToList().ForEach(x => Console.WriteLine(x));
            if (o.PlaylistSongs != null) FilesManager.PlaylistSongs(o.PlaylistSongs.ToString()).ToList().ForEach(x => Console.WriteLine(x));
        });
    }
}