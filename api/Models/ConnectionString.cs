namespace api.Models
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString()
        {
            string server = "uzb4o9e2oe257glt.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "mbay4g7gyimp2of1";
            string port = "3306";
            string userName = "hftt72ewwmwtna49";
            string password = "w5lmelkd26ydpncw";

            cs = $@"server={server};user={userName};database={database};port={port};password={password};";
        }
    }
}