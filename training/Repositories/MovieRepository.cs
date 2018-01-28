using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace training.Repositories
{
    public class MovieRepository
    {
        string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
        DataSet callDbWithValue(string cmdText)
        {
            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            return ds;
        }

        void callDb(string cmdText)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public DataSet getMovieList()
        {
            string cmdText = "SELECT * FROM [Movie]";
            return callDbWithValue(cmdText);
        }

        public void insertMovie(MovieModel data)
        {
            string cmdTextRaw = "INSERT INTO [movie] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', GETDATE(), GETDATE())";
            string cmdText = string.Format(cmdTextRaw, data.title, data.coverImg, data.releaseDate, data.genre, data.duration);
            callDb(cmdText);
        }
    }

    public class MovieModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
        public string coverImg { get; set; }
    }
}