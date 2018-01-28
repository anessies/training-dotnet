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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var btnDelete = (Button)sender;
                var row = (GridViewRow)btnDelete.NamingContainer;
                var img = (Image)row.FindControl("img");
                string pathImg = Server.MapPath("~") + img.ImageUrl;
                if (File.Exists(pathImg))
                {
                    File.Delete(pathImg);
                }
                int id = int.Parse(row.Cells[0].Text);
                movieRepo.deleteMovie(id);
                bindDataMovie();
                showAlertSuccess("alertDelSuccess", "Delete success");
            }
            catch (SqlException sqlEx)
            {
                showAlertError("alertSqlErr", sqlEx.Message);
            }
            catch (Exception ex)
            {
                showAlertError("alertErr", ex.Message);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btnEdit = (Button)sender;
            var row = (GridViewRow)btnEdit.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            Response.Redirect("~/MovieEdit.aspx?id=" + id);
        }
    }
}