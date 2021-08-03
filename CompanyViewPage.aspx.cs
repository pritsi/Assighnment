using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Assignment
{
    public partial class CompanyViewPage : System.Web.UI.Page
    {
        public static string ConStr = ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString;

        static SqlConnection con = new SqlConnection(ConStr);
        string Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGrid();
                string id = Id;
            }

            foreach (GridViewRow item in gdvCompany.Rows)
            {
                if (item.Cells[2].Text == "False")
                {

                }
            }
        }

        public DataTable BindGrid()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter apd = new SqlDataAdapter("SELECT * FROM CompanyMaster", con);
            apd.Fill(dt);


            gdvCompany.DataSource = dt;
            gdvCompany.DataBind();
            con.Close();
            return dt;
        }
        public DataTable GetFiles()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter apd = new SqlDataAdapter("SELECT * FROM FileMaster WHERE CompanyId = '" + lblCompId.Text + "'", con);
            apd.Fill(dt);
            DataGridView.DataSource = dt;
            DataGridView.DataBind();

            con.Close();
            return dt;
        }
        protected void BtnShow_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            lblCompId.Text = (btn.NamingContainer as GridViewRow).Cells[1].Text;
            GetFiles();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openShow();", true);
        }

        protected void BtnYes_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("UPDATE CompanyMaster SET STATUS = '1'  where CompanyId= '" + lblCompId.Text + "'", con);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();

        }



        protected void BtnNo_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE CompanyMaster SET STATUS = '0'  where CompanyId = '" + lblCompId.Text + "'", con);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }

        protected void BtnApproveDisapprove_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            lblCompId.Text = (btn.NamingContainer as GridViewRow).Cells[1].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openYesNo();", true);
        }



        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            lblCompId.Text = (btn.NamingContainer as GridViewRow).Cells[0].Text;


            //byte[] bytes;
            string fileName, contentType;


            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from FileMaster where CompanyId=@Id";
                cmd.Parameters.AddWithValue("@Id", lblCompId.Text);
                cmd.Connection = con;
                con.Open();

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    //bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["FileName"].ToString();
                }
                con.Close();
            }

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            //Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void DataGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


    }
}


