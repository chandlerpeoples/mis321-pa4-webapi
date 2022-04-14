using api.Interfaces;
using api.Models;

namespace api.DatabaseUtil
{
    public class UpdateDB : IUpdateSongs
    {
        public void Update(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE songs SET songtitle = @songtitle, timeadded = @timeadded, Favorited = @favorited WHERE id = {song.SongID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@songtitle", song.SongTitle);
            cmd.Parameters.AddWithValue("@timeadded", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@Favorited", 0);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}