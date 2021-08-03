using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment
{
    public partial class CompanyMaster : System.Web.UI.Page
    {
        public static string ConStr = ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString;

        static SqlConnection con = new SqlConnection(ConStr);
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlCommand cmd = new SqlCommand("INSERT INTO CompanyMaster values(@CompanyName,@Status) insert into FileMaster values(@FileName, @ContentType, @Data,@CompanyId)", con);
                //cmd.CommandType = CommandType.StoredProcedure;
               
                foreach (HttpPostedFile postedFile in fuDocs.PostedFiles)
                {
                    string filename = Path.GetFileName(postedFile.FileName);
                    string contentType = postedFile.ContentType;
                    using (Stream fs = postedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            

                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            cmd.Parameters.AddWithValue("@CompanyName", txtName.Text.ToString());
                            cmd.Parameters.AddWithValue("@Status", "");
                            cmd.Parameters.AddWithValue("@FileName", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            SqlCommand cmd1 = new SqlCommand("Select Top(1) CompanyId from CompanyMaster", con);
                            con.Open();
                                var Id=cmd1.ExecuteScalar();
                            con.Close();
                            cmd.Parameters.AddWithValue("@CompanyId", Id);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmd.Parameters.Clear();
                        }

                    }
                }


                
                
                Response.Redirect("CompanyViewPage.aspx");

               
            }
            catch(Exception Ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+Ex+"');", true);
            }
        }
    }
}