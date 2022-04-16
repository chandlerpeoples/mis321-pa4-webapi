using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace api.DatabaseUtil
{
    public class DeleteSongFromDB : IDeleteSongs
    {
        public void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"DELETE FROM songs WHERE id = {id}";

            using var cmd = new MySqlCommand(stm, con);
            
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
    }
}