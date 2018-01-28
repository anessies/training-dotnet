using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using training.Controller;
using training.Repositories;

namespace training
{
    public partial class MovieList : BasePage
    {
        MovieRepository movieRepo = new MovieRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataMovie();
            }
        }

        void bindDataMovie()
        {
            gvMovie.DataSource = movieRepo.getMovieList();
            gvMovie.DataBind();
        }
    }
}