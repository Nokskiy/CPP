using PP.CommandLine;
using PP.PlaylistPlayer;

namespace PP;

internal class Progtram
{
    private static void Main(string[] args)
    {
        FilesManager.RemoveAllRemovedSongs();
        new CommandLineParser(args);
    }
}