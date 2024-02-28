using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.UI.WebControls.WebParts;
//using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Common;
using System.Security.Policy;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.DirectoryServices;
using System.Windows.Controls;
using lewHRISlocal;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using System.IO;
using System.Net.Mime;
using System.Reflection.Emit;
using iTextSharp.text.pdf.parser;
using System.Diagnostics;
//using Microsoft.Office.Interop.Excel;

namespace lewHRISlocal
{
    
    public partial class FileViewer : System.Web.UI.Page
    {
        public static class MessageBox
        {
            public static void ShowMessage(string MessageText, System.Web.UI.Page MyPage)
            {
                MyPage.ClientScript.RegisterStartupScript(MyPage.GetType(),
                    "MessageBox", "alert('" + MessageText.Replace("'", "\'") + "');", true);
            }
        }
        //private PrincipalContext ctx;
        public static string GetUserFullName(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }

        public static string GetUserDepartmentEmployee(string empName)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + empName + ")",
                    PropertiesToLoad = { "department" },
                })
                {
                    return (string)search.FindOne().Properties["department"][0];
                }
            }
        }

        public static string GetFolderName(string empID)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + Int32.Parse(empID) + ")",
                    PropertiesToLoad = { "name" },
                })
                {
                    return (string)search.FindOne().Properties["name"][0];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            
            //string empName = GetFolderName(id);
            try
            {
                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();
                //Response.Write("Connection Made");

                SqlCommand command = new SqlCommand("Select [EE_ID] from dbo.CounselingReport WHERE [Counseling_ID] = " + id + "", cnn);
                SqlDataReader dataReader;
                //String Output = " ";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    TextBox1.Text = "" + dataReader.GetInt32(0);
                }

                string empName = GetFolderName(TextBox1.Text);


                Label1.Text = "Files available for " + empName + ".";


                string subPath = "~/SupportDocs/" + empName;


                if (!IsPostBack)
                {
                    string[] filePaths = Directory.GetFiles(Server.MapPath(subPath));
                    List<ListItem> files = new List<ListItem>();
                    foreach (string filePath in filePaths)
                    {
                        files.Add(new ListItem(System.IO.Path.GetFileName(filePath), filePath));
                    }
                    GridView11.DataSource = files;
                    GridView11.DataBind();
                }
                //Response.Write(Output);
                dataReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.ShowMessage("No files associate with Employee.", this.Page);
            }
            finally
            {

            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            //int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        //private void BindGrid1(string subPath)
        //{
        //    string[] filePaths = Directory.GetFiles(Server.MapPath(subPath));
        //    List<ListItem> files = new List<ListItem>();
        //    foreach (string filePath in filePaths)
        //    {
        //        files.Add(new ListItem(System.IO.Path.GetFileName(filePath), filePath));
        //    }
        //    GridView11.DataSource = files;
        //    GridView11.DataBind();
        //}

    }
}