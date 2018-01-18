using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using training.Repositories;

namespace training
{
    public partial class MovieList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataMovie();
            }
        }

        void bindDataMovie()
        {
            MovieRepository movieRepo = new MovieRepository();
            gvMovie.DataSource = movieRepo.getMovieList();
            gvMovie.DataBind();
        }
    }
}