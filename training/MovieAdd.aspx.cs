using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using training.Repositories;

namespace training
{
    public partial class MovieAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
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
                if (!fuCoverImg.HasFile)
                {
                    showAlertError("alertFileErr", "กรุณาเลือกไฟล์รูปภาพ");
                    return;
                }
                string extFile = Path.GetExtension(fuCoverImg.FileName);
                if (!(extFile == ".jpg" || extFile == ".png"))
                {
                    showAlertError("alertExtErr", "กรุณาเลือกไฟล์รูปภาพเป็น .jpg หรือ .png เท่านั้น");
                    return;
                }
                // Validate
                string folderImg = "/movieCover";
                string pathFolderImg = Server.MapPath("~/" + folderImg);
                if (!Directory.Exists(pathFolderImg))
                {
                    Directory.CreateDirectory(pathFolderImg);
                }
                string fileName = Guid.NewGuid().ToString();
                string fileNameExt = "/" + fileName + extFile;
                fuCoverImg.SaveAs(pathFolderImg + fileNameExt);
                string coverImg = folderImg + fileNameExt;

                int duration = int.Parse(txtDuration.Text);
                DateTime releaseDate = DateTime.Parse(txtDate.Text);
                MovieRepository movieRepo = new MovieRepository();
                MovieModel data = new MovieModel()
                {
                    title = txtTitle.Text,
                    coverImg = coverImg,
                    duration = duration,
                    genre = ddlGenre.Text,
                    releaseDate = releaseDate
                };
                movieRepo.insertMovie(data);
                showAlertSuccess("alertSuccess", "Insert success");
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

        void showAlertSuccess(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertSuccess('" + msg + "');", true);
        }

        void showAlertError(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertError('" + msg + "');", true);
        }
    }
}