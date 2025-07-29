namespace PP.PlaylistPlayer;

public struct PlaylistData()
{
    public string PlaylistName { get; set; } = string.Empty;
    public List<string> SongsPaths { get; set; } = new List<string>();

    public void AddSong(string songPath) => SongsPaths.Add(songPath);
    public void RemoveSong(string songPath) => SongsPaths.Remove(songPath);
}