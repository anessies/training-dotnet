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

        public DataSet getMovieList()
        {
            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            string cmdText = "SELECT * FROM [Movie]";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            return ds;
        }

        public void insertMovie(MovieModel data)
        {
            SqlConnection conn = new SqlConnection(connStr);
            string cmdTextRaw = "INSERT INTO [movie] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', GETDATE(), GETDATE())";
            string cmdText = string.Format(cmdTextRaw, data.title, data.coverImg, data.releaseDate, data.genre, data.duration);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }

    public class MovieModel
    {
        public string title { get; set; }
        public int duration { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
        public string coverImg { get; set; }
    }
}