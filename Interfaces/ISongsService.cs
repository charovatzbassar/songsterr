using Project_Task.Genius;
using Project_Task.Interfaces;

namespace Project_Task.Interfaces;

public interface ISongsService
{
    Task<GeniusResponse?> GetSongs(string query);
}