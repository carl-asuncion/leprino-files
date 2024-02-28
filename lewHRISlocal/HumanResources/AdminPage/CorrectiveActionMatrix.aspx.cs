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
using System.Web.Providers.Entities;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Windows.Media.TextFormatting;

namespace lewHRISlocal.HumanResources.AdminPage
{
    
    public partial class CorrectiveActionMatrix : System.Web.UI.Page
    {
        //private PrincipalContext ctx;
        //public static string GetUserFullName(string domain, string userName)
        public static string GetUserFullName(string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("LDAP://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["fullname"].Value;
            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + userName + ")",
                    PropertiesToLoad = { "name" },
                })
                {
                    return (string)search.FindOne().Properties["name"][0];
                }
            }
            // set up domain context
            //PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);

            //// find a user
            //UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);

            //return user.GivenName + " " + user.Surname + " " + user.EmailAddress;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = HttpContext.Current.User.Identity;
            //TextBox1.Text =  id.GetLogin();
            //TextBox1.Text =  GetUserFullName(id.GetDomain(), id.GetLogin());
            Label1.Text =  "Welcome, " + GetUserFullName(id.GetLogin()) + "!";
            if (!this.IsPostBack)
            {
                this.BindGrid1();
            }
        }

        protected void btnCorrectiveAction_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/HumanResources/AdminPage/CorrectiveActionMatrix.aspx", false);
        }

        private void BindGrid1()
        {
            //IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            DataSet ds2 = new DataSet();
            SqlDataAdapter sda2 = new SqlDataAdapter();

            if (CategoryName.Text == "All")
            {
                SqlCommand command2 = new SqlCommand("SELECT [SubCategory_ID],[Level],[Category],[Sub_Category],[SubCategory]" +
                " FROM [dbo].[SubCategory] WHERE NOT [Sub_Category] = 0", cnn);
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
                        //NeedAttn.Text = "No records available.";
                    }
                }
                command2.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            else
            {
                SqlCommand command2 = new SqlCommand("SELECT [SubCategory_ID],[Level],[Category],[Sub_Category],[SubCategory]" +
                " FROM [dbo].[SubCategory] WHERE NOT [Sub_Category] = 0 AND [Category] LIKE '%" + CategoryName.Text + "%'", cnn);
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
                        //NeedAttn.Text = "No records available.";
                    }
                }
                command2.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            
        }

        protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            mydatagrid.PageIndex = e.NewPageIndex;
            this.BindGrid1();
        }

        protected void mydatagrid_DataBound(object sender, EventArgs e)
        {
            //if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
            //{
            //    //NeedAttn.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            //}
            //else NeedAttn.Text = "No record(s) returned.";

        }

        protected void mydatagrid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            mydatagrid.EditIndex = e.NewEditIndex;
            BindGrid1();
        }
        protected void mydatagrid_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            //Finding the controls from Gridview for the row which is going to update  
            Label id = mydatagrid.Rows[e.RowIndex].FindControl("SubCategory_ID") as Label;
            //DropDownList status = mydatagrid.Rows[e.RowIndex].FindControl("txt_Status") as DropDownList;
            TextBox ticket = mydatagrid.Rows[e.RowIndex].FindControl("txt_Ticket") as TextBox;
            //TextBox remarks = mydatagrid.Rows[e.RowIndex].FindControl("txt_Remarks") as TextBox;



            //updating the record  
            using (SqlCommand cmd = new SqlCommand("Update [dbo].[SubCategory] set [SubCategory] =@ticket," +
                " where [ISSDetail_ID]="+ Convert.ToInt32(id.Text), cnn))
            {
                if (string.IsNullOrEmpty(ticket.Text))
                {
                    cmd.Parameters.AddWithValue("@ticket", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ticket", ticket.Text);
                }


                cmd.ExecuteNonQuery();
            }


            cnn.Dispose();
            cnn.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            mydatagrid.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            BindGrid1();
        }

        protected void mydatagrid_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            mydatagrid.EditIndex = -1;
            BindGrid1();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            BindGrid1();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                      "showMeAdd();", true);
        }

        protected void btnAddDetails_Click(object sender, EventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            SqlCommand command = new SqlCommand("Select MAX([Sub_Category]) + 1 from dbo.[SubCategory] WHERE [Category] = '" + DropDownList1.SelectedItem.Text + "'", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                MaxSubCategory.Text = "" + dataReader.GetInt32(0);
            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();

            using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[SubCategory] ([Level], [Category], [Sub_Category], " +
                "[SubCategory]) VALUES ('" + DropDownList2.SelectedItem.Text + "', '" + DropDownList1.SelectedItem.Text + "', " +
                "'" + MaxSubCategory.Text + "', '" + TextBox2.Text + "')", cnn))
            {

                cmd.ExecuteNonQuery();
            }


            cnn.Dispose();
            cnn.Close();
            BindGrid1();
        }

       

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string myConnection;
        //    SqlConnection cnn;
        //    myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
        //    cnn = new SqlConnection(myConnection);
        //    cnn.Open();
        //    //Response.Write("Connection Made");

        //    SqlCommand command = new SqlCommand("Select MAX([Sub_Category]) + 1 from dbo.[SubCategory] WHERE [Category] = '" + DropDownList1.SelectedItem.Text + "'", cnn);
        //    SqlDataReader dataReader;
        //    //String Output = " ";
        //    dataReader = command.ExecuteReader();
        //    while (dataReader.Read())
        //    {
        //        MaxSubCategory.Text = "" + dataReader.GetInt32(0);
        //    }
        //    //Response.Write(Output);
        //    dataReader.Close();
        //    command.Dispose();
        //    cnn.Close();
        //}
    }
}