# CPP

## About
CPP is a lightweight console playlist player


## Installation

1. Build the project to get the executable

2. Add the directory containing cpp.exe to your system PATH:
    - Open System Properties → Advanced → Environment Variables

    - Add the directory path to the "Path" variable under System variables

## Usage
type ```cpp --help``` in console to get help menu for commands

### Commands
- --cp         Create new playlist <Playlist name>

- --rp         Remove playlist <Playlist name>

- --as         Add song to playlist <Playlist name> <Song path>

- --rs         Remove song from playlist <Playlist name> <Song path>

- --pl         Print playlists list

- --ps         Print playlist songs

- --play       Play playlist <playlist name>

- --help       Display this help screen.

- --version    Display version information.

### Example

```cpp --as "AC DC playlist" "C:\Songs\AC DC - Thunderstruck.mp3"```

### Libraries used

- [NAudio](https://github.com/naudio/NAudio)
- [commandline](https://github.com/commandlineparser/commandline)
- [Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/)