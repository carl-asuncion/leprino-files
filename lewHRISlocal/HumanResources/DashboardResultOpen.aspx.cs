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
//using Microsoft.Office.Interop.Excel;

namespace lewHRISlocal.HumanResources
{
    
    public partial class DashboardResultOpen : System.Web.UI.Page
    {
        //private PrincipalContext ctx;
        public static string GetUserFullName(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string empName = Request.QueryString["empName"].ToString();

            //MessageBox.ShowMessage(empName, this.Page);
            IIdentity id = HttpContext.Current.User.Identity;
            //TextBox1.Text =  id.GetLogin();
            //TextBox1.Text =  GetUserFullName(id.GetDomain(), id.GetLogin());
            if (!this.IsPostBack)
            {
                this.BindGrid1(empName);
            }



            //DataSet ds2 = new DataSet();
            //SqlDataAdapter sda2 = new SqlDataAdapter();
            //SqlCommand command2 = new SqlCommand("SELECT [Date_Incident], [EE_Name], [Counseling_Category]," +
            //    "[Counseling_SubCategory], [Counseling_Subject], [Counseling_Count], [EE_Status], [Sup_Status], " +
            //    "[Counseling_ID], [Supervisor_Name], [Overall Status] FROM [View_2] WHERE [EE_Name] LIKE '%" + empName + "%' ORDER BY [Date_Incident]", cnn);
            //sda2.SelectCommand = command2;
            //using (DataTable dt2 = new DataTable())
            //{
            //    sda2.Fill(dt2);
            //    if (dt2.Rows.Count>0)
            //    {
            //        DisciplinaryRecord.Text = dt2.Rows.Count.ToString() + " record(s) returned.";
            //        GridView1.DataSource = dt2;
            //        GridView1.DataBind();
            //    }
            //    else
            //    {
            //        DisciplinaryRecord.Text = "No records that matches '" + empName + "'.";
            //    }
            //}
            //command2.Dispose();
            //command.Dispose();
            //cnn.Close();
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

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/HumanResources/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}


        //protected void LinkButton3_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView2.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Supervisors/DetailOnly.aspx?id=" + id + "", false);
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
            SqlCommand command = new SqlCommand("SELECT * FROM [View_1] WHERE [Employee_Status] LIKE '%" + empName + "%' AND ([Overall Status] = 'Waiting for HR Decision' OR" +
               " [Overall Status] = 'Requires HR Manager Decision') ORDER BY [Date_Incident]", cnn);
            sda2.SelectCommand = command;
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

        protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string empName = Request.QueryString["empName"].ToString();
            mydatagrid.PageIndex = e.NewPageIndex;
            this.BindGrid1(empName);
        }
    }
}