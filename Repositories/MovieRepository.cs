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
        public DataSet getMovieList()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            string cmdText = "SELECT * FROM [Movie]";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            return ds;
        }
    }
}