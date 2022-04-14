using api.Interfaces;
using api.Models;

namespace api.DatabaseUtil
{
    public class ReadFromDB : IReadSongs
    {
        public Song ReadOne(int temp)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"SELECT * FROM songs WHERE id = {temp}";
            using var cmd = new MySqlCommand(stm, con);
            MySqlDataReader sdr = cmd.ExecuteReader();
            

            return new Song(){SongID = sdr.GetInt32(0), SongTitle = sdr.GetString(1), SongTimestamp = sdr.GetDateTime(2), Deleted = sdr.GetString(3), Favorited = sdr.GetBit(4)};
        }

        public List<Song> ReadSongs()
        {
            List<Song> playlist = new List<Song>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM songs";

            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                playlist.Add(new Song(){SongID = sdr.GetInt32(0), SongTitle = sdr.GetString(1), SongTimestamp = sdr.GetDateTime(2), Deleted = sdr.GetString(3), Favorited = sdr.GetBit(4)});
            }

            con.Close();
            return playlist;
        }
        }
    }
}