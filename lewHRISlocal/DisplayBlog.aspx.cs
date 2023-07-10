using ClosedXML.Excel;
using lewHRISlocal.Employees;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Net.PeerToPeer;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace lewHRISlocal
{
    public partial class DisplayBlog : Page
    {
   
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            if (!this.IsPostBack)
            {
                this.PopulateBlog(id);
            }
        }

        private void PopulateBlog(string id)
        {
            //string id = Request.QueryString["hotelId"];
            //string blogId = this.Page.RouteData.Values["BlogId"].ToString();
            string query = "SELECT [Title], [Date_Entered], [Body] FROM [Blogs] WHERE [Blog_Id] = @BlogId";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@BlogId", id);
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            lblTitle.Text = dt.Rows[0]["Title"].ToString();
                            lblBody.Text = dt.Rows[0]["Body"].ToString();
                            lblDate.Text = dt.Rows[0]["Date_Entered"].ToString();
                        }
                    }
                }
            }

            string bodyText = lblBody.Text;
            if (bodyText.Contains("<img"))
            {
                //MessageBox.ShowMessage("it has an image", this.Page);
                lblBody.Text = bodyText.Replace("<img", "<img style='width: 50%;'");
            }
            else
            {
                //MessageBox.ShowMessage("it has No image", this.Page);
                //Do nothing.
            }
            
        }
    }
}