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
using lewHRISlocal.Employees;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using System.IO;
using DocumentFormat.OpenXml.Office2010.Excel;
//using Microsoft.Office.Interop.Excel;

namespace lewHRISlocal.HumanResources
{
    
    public partial class SearchResults : System.Web.UI.Page
    {
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

        public static string GetEmpFullName(string empId)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + empId + ")",
                    PropertiesToLoad = { "name" },
                })
                {
                    return (string)search.FindOne().Properties["name"][0];
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
            string empId = Request.QueryString["id"].ToString();

            //MessageBox.ShowMessage(empName, this.Page);
            IIdentity id = HttpContext.Current.User.Identity;
            string empName = GetEmpFullName(empId);    
            //TextBox1.Text =  id.GetLogin();
            //TextBox1.Text =  GetUserFullName(id.GetDomain(), id.GetLogin());
            
            if (!this.IsPostBack)
            {
                this.BindGrid1(empName);
                this.BindGrid2(empName);
                try
                {
                    Label1.Text = "Files available for " + empName + ".";


                    string subPath = "~/SupportDocs/" + empName;


                    if (!IsPostBack)
                    {
                        string[] filePaths = Directory.GetFiles(Server.MapPath(subPath));
                        List<System.Web.UI.WebControls.ListItem> files = new List<System.Web.UI.WebControls.ListItem>();
                        foreach (string filePath in filePaths)
                        {
                            files.Add(new System.Web.UI.WebControls.ListItem(System.IO.Path.GetFileName(filePath), filePath));
                        }
                        GridView11.DataSource = files;
                        GridView11.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = "No files uploaded for " + empName + ".";
                }
                finally
                {
                    
                }
            }

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            SqlCommand command = new SqlCommand("Select * from dbo.MasterList WHERE [EE] = " + empId + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtEEStatus.Text = dataReader.GetString(11);
                txtEmpID.Text = "" + dataReader.GetInt32(1);
                if (!dataReader.IsDBNull(5))
                {
                    txtDepartment.Text = dataReader.GetString(5);
                }
                else txtDepartment.Text = "";
                if (!dataReader.IsDBNull(16))
                {
                    txtPosition.Text = dataReader.GetString(16);
                }
                else txtPosition.Text = "";
            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();


            txtEmployeeName.Text = empName;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        //VOID
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DeleteDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DeleteDisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        //protected void LinkButton5_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/FileViewer.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}


        private void BindGrid1(string empName)
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            DataSet ds2 = new DataSet();
            SqlDataAdapter sda2 = new SqlDataAdapter();
            SqlCommand command2 = new SqlCommand("SELECT * FROM [View_1] WHERE [EE_Name] LIKE '%" + empName + "%' ORDER BY [Date_Incident]", cnn);
            sda2.SelectCommand = command2;
            using (DataTable dt2 = new DataTable())
            {
                sda2.Fill(dt2);
                if (dt2.Rows.Count>0)
                {
                    //NeedAttn.Text = dt2.Rows.Count.ToString() + " record(s) returned.";
                    mydatagrid.DataSource = dt2;
                    mydatagrid.DataBind();
                }
                else
                {
                    CounselingRecord.Text = "No records available.";
                }
            }
            command2.Dispose();
            cnn.Close();
        }

        private void BindGrid2(string empName)
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM [View_3] WHERE [EE_Name] LIKE '%" + empName + "%' ORDER BY [Date_Incident]", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    DisciplinaryRecord.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        protected void mydatagrid_DataBound(object sender, EventArgs e)
        {
            if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
            {
                CounselingRecord.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else CounselingRecord.Text = "No record(s) returned.";
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if ((GridView1.DataSource as DataTable).Rows.Count>0)
            {
                DisciplinaryRecord.Text = (GridView1.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else DisciplinaryRecord.Text = "No record(s) returned.";
        }

        protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //string empName = Request.QueryString["empName"].ToString();
            string empName = txtEmployeeName.Text;
            mydatagrid.PageIndex = e.NewPageIndex;
            this.BindGrid1(empName);    
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //string empName = Request.QueryString["empName"].ToString();
            string empName = txtEmployeeName.Text;
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid2(empName);

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


    }
}