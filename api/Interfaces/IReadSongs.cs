using api.Models;
using System.Collections.Generic;

namespace api.Interfaces
{
    public interface IReadSongs
    {
           List<Song> ReadSongs();
           Song ReadOne(int temp);
           
    }
}