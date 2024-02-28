using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Text;
using System.EnterpriseServices.Internal;
using Microsoft.Identity.Client;
using System.Windows.Controls;
using ClosedXML.Excel;
using lewHRISlocal.Employees;
using Microsoft.Ajax.Utilities;
using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Net.PeerToPeer;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace lewHRISlocal.General
{
    
    public partial class DeleteDetailOnly : System.Web.UI.Page
    {
        
        string udpateSupComments;


        protected void Page_Load(object sender, EventArgs e)
        {

            IIdentity id2 = HttpContext.Current.User.Identity;
            // set up domain context
            

            string id = Request.QueryString["id"];

            txtCounselingID.Text = id;
            //timedateAck.Text = "Acknowledging on " + System.DateTime.Now.ToString();
    // Removed 12.28.23 due to SQL injection going on //Context.ApplicationInstance.CompleteRequest();


            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            SqlCommand command = new SqlCommand("Select * from dbo.View_1 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtDateEntered.Text = dataReader.GetDateTime(2).ToString();
                txtDateIncident.Text = dataReader.GetDateTime(3).ToString();
                txtEEStatus.Text = dataReader.GetString(25);
                txtEmpID.Text = "" + dataReader.GetInt32(1);
                txtEmployeeName.Text = dataReader.GetString(4);
                txtDepartment.Text = dataReader.GetString(5);
                txtPosition.Text = dataReader.GetString(36);
                txtCategory.Text = dataReader.GetString(6);
                txtSubCategory.Text = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                {
                    txtSubject.Text = dataReader.GetString(8);
                }
                else txtSubject.Text = "";

                if (!dataReader.IsDBNull(9))
                {
                    txtLevel.Text = dataReader.GetString(9);
                }
                else txtLevel.Text = "";

                if (!dataReader.IsDBNull(10))
                {
                    txtSupComments.Text = dataReader.GetString(10);
                }
                else txtSupComments.Text = "";

                if (!dataReader.IsDBNull(21))
                {
                    txtOverallStatus.Text = dataReader.GetString(21);
                    //cboStatus.Text = dataReader.GetString(9);
                }
                else txtOverallStatus.Text = "";


                if (!dataReader.IsDBNull(11))
                {
                    txtEmployeeComments.Text = dataReader.GetString(11);
                }
                else txtEmployeeComments.Text = "";

                if (!dataReader.IsDBNull(13))
                {
                    txtFollowUp.Text = dataReader.GetString(13);
                }
                else txtFollowUp.Text = "";

                //Bottom Data
                if (!dataReader.IsDBNull(26))
                {
                    txtEEAck.Text = dataReader.GetString(26);
                }
                else txtEEAck.Text = "";
                if (!dataReader.IsDBNull(32))
                {
                    txtEESigned.Text = dataReader.GetString(32);
                }
                else txtEESigned.Text = "";
                if (!dataReader.IsDBNull(27))
                {
                    txtSupFin.Text = dataReader.GetString(27);
                }
                else txtSupFin.Text = "";
                if (!dataReader.IsDBNull(34))
                {
                    txtSupSigned.Text = dataReader.GetString(34);
                }
                else txtSupSigned.Text = "";
                if (!dataReader.IsDBNull(28))
                {
                    txtHRCSigned.Text = dataReader.GetString(28);
                }
                else txtHRCSigned.Text = "";
                if (!dataReader.IsDBNull(30))
                {
                    txtHRMSigned.Text = dataReader.GetString(30);
                }
                else txtHRMSigned.Text = "";

                if (!dataReader.IsDBNull(12))
                {
                    txtEEAckDate.Text = dataReader.GetDateTime(12).ToString();
                }
                else txtEEAckDate.Text = "";
                if (!dataReader.IsDBNull(33))
                {
                    txtEEDate.Text = dataReader.GetDateTime(33).ToString();
                }
                else txtEEDate.Text = "";
                if (!dataReader.IsDBNull(14))
                {
                    txtSupFinDate.Text = dataReader.GetDateTime(14).ToString();
                }
                else txtSupFinDate.Text = "";
                if (!dataReader.IsDBNull(35))
                {
                    txtSupDate.Text = dataReader.GetDateTime(35).ToString();
                }
                else txtSupDate.Text = "";
                if (!dataReader.IsDBNull(29))
                {
                    txtHRCDate.Text = dataReader.GetDateTime(29).ToString();
                }
                else txtHRCDate.Text = "";
                if (!dataReader.IsDBNull(31))
                {
                    txtHRMDate.Text = dataReader.GetDateTime(31).ToString();
                }
                else txtHRMDate.Text = "";
                if (!dataReader.IsDBNull(21))
                {
                    txtNewStatus.Text = dataReader.GetString(21);
                }
                else txtNewStatus.Text = "";
            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

            

            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, id2.GetDomain());

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, id2.GetLogin());

            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - Human Resource Department");

            if (user != null)
            {
                // check if user is member of that group
                if (user.IsMemberOf(group))
                {
                    //Button2.Visible = true;
                    //LabelAccess.Visible = false;
                    Label38.Visible = false;
                    ConfirmDelete.Visible = true;
                    LinkButton2.Visible = true;
                }
                else
                {
                    //Button2.Visible = false;
                    //LabelAccess.Text = "  No action available for user.";
                    Label38.Visible = true;
                    ConfirmDelete.Visible = false;
                    LinkButton2.Visible = false;
                }
            }


            //if (txtNewStatus.Text == "HR Dismissed Report" || txtNewStatus.Text == "Counseling Closed")
            if (txtNewStatus.Text == "HR Dismissed Report")
            {
                LinkButton2.Visible = false;
                Label38.Visible = true;
                Label38.Text = "No actions available.";
                ConfirmDelete.Visible = false;
            }
            else
            {
                LinkButton2.Visible = true;
                Label38.Visible = false;
                ConfirmDelete.Visible = true;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string myConnection;
            //SqlConnection cnn;
            //myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            //cnn = new SqlConnection(myConnection);

            //SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = 'EE Acknowledged', [Sup_Status] = 'Sup Finalized', [HR_Status] = 'HR Sent'" +
            //    ", [Supervisor_FollowUp] = '" + txtFollowUp.Text + "', [Supervisor_Finalized_Date] = '" + System.DateTime.Now.ToString() + "' WHERE [Counseling_ID] = "
            //    + txtCounselingID.Text + "", cnn);

            //cnn.Open();
            //command.ExecuteNonQuery();
            //MessageBox.ShowMessage("Counseling Record forwarded to HR successfully.", this.Page);
            //cnn.Close();
            ////MessageBox.ShowMessage(newStatus, this.Page);
            //Response.Redirect("~/Supervisors/SupervisorDash", false);
        }

        
        //protected void txtSupComments_TextChanged(object sender, EventArgs e)
        //{
        //    udpateSupComments = txtSupComments.Text;
        //}


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            //int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            //int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);
            int id = Convert.ToInt32(txtCounselingID.Text);
            Response.Redirect("~/HumanResources/EditCounseling.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
            //Response.Redirect("~/HumanResources/EditCounseling", false);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCounselingID.Text);
            Response.Redirect("~/CounselingPrint.aspx?id=" + id + "", false);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(txtCounselingID.Text);
            ////Response.Redirect("~/CounselingPrint.aspx?id=" + id + "", false);
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", 
            //    "function confirmMessage() {if (confirm('Are you sure you want to delete')) {alert('hello');} else {alert('Bye');}}", true);
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [VoidedCounseling] SELECT * FROM [CounselingReport] WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            command.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("DELETE FROM [CounselingReport] WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            command2.ExecuteNonQuery();

            SqlCommand command3 = new SqlCommand("UPDATE [VoidedCounseling] SET [Date_Voided] = '" + System.DateTime.Now.ToString() + "' WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            command3.ExecuteNonQuery();

            command.Dispose();
            command2.Dispose();
            command3.Dispose();
            cnn.Close();

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Record voided successfully.'); window.location.replace('/lewHRISlocal/HumanResources/HRDash.aspx');", true);

        }
    }
}