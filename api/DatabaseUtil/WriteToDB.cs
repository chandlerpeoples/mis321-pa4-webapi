using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace api.DatabaseUtil
{
    public class WriteToDB : ICreateSongs
    {
        public void Create(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(id, songtitle, timeadded, deleted, Favorited) VALUES(@id, @songtitle, @timeadded, @deleted, @Favorited)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", song.SongID);
            cmd.Parameters.AddWithValue("@songtitle", song.SongTitle);
            cmd.Parameters.AddWithValue("@timeadded", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@Favorited", 0);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}