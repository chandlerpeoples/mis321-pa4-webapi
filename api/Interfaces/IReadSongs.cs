using api.Models;


namespace api.Interfaces
{
    public interface IReadSongs
    {
           List<Song> ReadSongs();
           Song ReadOne(int temp);
           
    }
}