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
using lewHRISlocal.Employees;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Services;

namespace lewHRISlocal.HumanResources
{
    public static class Extensions
    {
        

        public static string GetDomain(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(0, stop) : string.Empty;
        }

        public static string GetLogin(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : string.Empty;
        }
    }
    public partial class HRDash : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        //public static string GetJson(string name)
        public static string GetJsonNewCounseling()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Employee_Status] As 'EmpStatus', COUNT(Counseling_ID) As 'Count' FROM dbo.View_1 WHERE [Overall Status] = 'Sent to HR for Final Review'  GROUP BY [Employee_Status] FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString();
            
        }

        [System.Web.Services.WebMethod]
        //public static string GetJson(string name)
        public static string GetJsonOpenCounseling()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Employee_Status] As 'EmpStatus', COUNT(Counseling_ID) As 'Count' FROM dbo.View_1 WHERE [Overall Status] = 'Waiting for HR Decision' GROUP BY [Employee_Status] FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString();
            
        }

        [System.Web.Services.WebMethod]
        //public static string GetJson(string name)
        public static string GetJsonInitiated()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Employee_Status] As 'EmpStatus', COUNT(Counseling_ID) As 'Count' FROM dbo.View_3 WHERE [Overall Status] = 'Initiated Disciplinary Action' GROUP BY [Employee_Status] FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString();
            
        }

        [System.Web.Services.WebMethod]
        public static string GetJsonReview()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Employee_Status] As 'EmpStatus', COUNT(Counseling_ID) As 'Count' FROM dbo.View_1 WHERE [EE_Status] = 'Unavailable' AND [Sup_Status] = 'Sup Open' AND [HR_Status] = 'HR Sent' GROUP BY [Employee_Status] FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString();

        }

        [System.Web.Services.WebMethod]
        public static string GetTrendCounseling()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT CONVERT(VARCHAR(10), Date_Incident, 101) AS [DateEntered], Count([Counseling_ID]) AS [DailyCount] FROM dbo.CounselingReport GROUP BY CONVERT(VARCHAR(10), Date_Incident, 101) FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0);

        }

        [System.Web.Services.WebMethod]
        public static string GetTrendDisciplinary()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT CONVERT(VARCHAR(10), Date_Incident, 101) AS [DateEntered], Count([Counseling_ID]) AS [DailyCount] FROM dbo.DisciplinaryRecords GROUP BY CONVERT(VARCHAR(10), Date_Incident, 101) FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0);

        }


        //private PrincipalContext ctx;
        public static string GetUserFullName(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = HttpContext.Current.User.Identity;

            WelcomeLabel.Text = "Welcome, " + GetUserFullName(id.GetDomain(), id.GetLogin()) + "!";

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT COUNT(Counseling_ID) As 'Count' FROM dbo.View_1", cnn);
            SqlDataReader dataReader;
            
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                numCounselingsYTD.Text = "" + dataReader.GetInt32(0);
            }
            dataReader.Close();
            command.Dispose(); 

            SqlCommand command2 = new SqlCommand("SELECT COUNT(Disciplinary_ID) As 'Count' FROM dbo.View_3", cnn);

            SqlDataReader dataReader2;
            dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                numDAYTD.Text = "" + dataReader2.GetInt32(0);
            }
            dataReader2.Close();
            command2.Dispose();
            cnn.Close();

        }


        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Supervisors/DetailOnly.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Supervisors/Detail.aspx?id=" + id + "", false);
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
       
    }

    
}


    
