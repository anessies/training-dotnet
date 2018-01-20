using System;
using System.Collections.Generic;
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
    public partial class MovieEdit : BasePage
    {
        MovieRepository movieRepo = new MovieRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setData();
            }
        }

        void setData()
        {
            try
            {
                string paramId = Request["id"];
                int id = 0;
                if (string.IsNullOrEmpty(paramId) || !int.TryParse(paramId, out id))
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                else
                {
                    id = int.Parse(paramId);
                }
                var data = movieRepo.getMovieById(id);
                if (data.Tables[0].Rows.Count == 0)
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                var row = data.Tables[0].Rows[0];
                txtDuration.Text = row["duration"].ToString();
                txtTitle.Text = row["title"].ToString();
                ddlGenre.SelectedValue = row["genre"].ToString();
                Img.ImageUrl = row["coverImg"].ToString();
                txtDate.Value = ((DateTime)row["releaseDate"]).ToString("yyyy/MM/dd");
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                string paramId = Request["id"];
                int id = 0;
                if (string.IsNullOrEmpty(paramId) || !int.TryParse(paramId, out id))
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                else
                {
                    id = int.Parse(paramId);
                }

                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    showAlertError("alertTitleErr", "กรุณากรอกชื่อภาพยนต์");
                    return;
                }
                if (string.IsNullOrEmpty(txtDuration.Text))
                {
                    showAlertError("alertDurErr", "กรุณากรอกความยาว(นาที)");
                    return;
                }
                int numDuration;
                if (!int.TryParse(txtDuration.Text, out numDuration))
                {
                    showAlertError("alertDurNotNumErr", "กรุณากรอกความยาว(นาที) ให้เป็นตัวเลขเท่านั้น");
                    return;
                }
                string extFile = "";
                string coverImg = Img.ImageUrl;
                if (fuCoverImg.HasFile)
                {
                    extFile = Path.GetExtension(fuCoverImg.FileName);
                    if (!(extFile == ".jpg" || extFile == ".png"))
                    {
                        showAlertError("alertExtErr", "กรุณาเลือกไฟล์รูปภาพเป็น .jpg หรือ .png เท่านั้น");
                        return;
                    }
                    // save file
                    string folderImg = "/movieCover";
                    string pathFolderImg = Server.MapPath("~/" + folderImg);
                    if (!Directory.Exists(pathFolderImg))
                    {
                        Directory.CreateDirectory(pathFolderImg);
                    }
                    string fileName = Guid.NewGuid().ToString();
                    string fileNameExt = "/" + fileName + extFile;
                    fuCoverImg.SaveAs(pathFolderImg + fileNameExt);
                    coverImg = folderImg + fileNameExt;
                }
                // Validate
                int duration = int.Parse(txtDuration.Text);
                DateTime releaseDate = DateTime.Parse(txtDate.Value);
                var movie = new MovieModel()
                {
                    id = id,
                    title = txtTitle.Text,
                    coverImg = coverImg,
                    duration = duration,
                    genre = ddlGenre.Text,
                    releaseDate = releaseDate
                };

                movieRepo.updateMovie(movie);
                Response.Redirect("~/MovieList.aspx");
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
    }
}