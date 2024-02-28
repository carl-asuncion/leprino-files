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
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Web.Providers.Entities;
using System.Windows.Controls;

namespace lewHRISlocal.General
{
    
    public partial class DisciplinaryDetailOnly : System.Web.UI.Page
    {
        
        string udpateSupComments;


        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            // set up domain context
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
                    LinkButton1.Visible = true;
                    Button2.Visible = true;
                    LabelAccess.Visible = false;
                }
                else
                {
                    LinkButton1.Visible = false;
                    Button2.Visible = false;
                    LabelAccess.Text = "  No action available for user.";
                }
            }

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

            SqlCommand command = new SqlCommand("Select * from dbo.View_3 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtEmpID.Text = "" + dataReader.GetInt32(1);
                txtDisciplinaryID.Text = dataReader.GetInt32(36).ToString();
                txtDateEntered.Text = dataReader.GetDateTime(2).ToString();
                txtDateIncident.Text = dataReader.GetDateTime(3).ToString();
                if (!dataReader.IsDBNull(42))
                {
                    txtPosition.Text = dataReader.GetString(42);
                }
                else txtPosition.Text = "";

                txtEEStatus.Text = dataReader.GetString(25);
                txtEmployeeName.Text = dataReader.GetString(4);
                txtDepartment.Text = dataReader.GetString(5);
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
                //Disciplinary Main
                if (!dataReader.IsDBNull(37))
                {
                    txtDamageValue.Text = dataReader.GetString(37);
                }
                else txtDamageValue.Text = "";
                if (!dataReader.IsDBNull(38))
                {
                    txtSuspensionDate.Text = dataReader.GetDateTime(38).ToString();
                }
                else txtSuspensionDate.Text = "";
                if (!dataReader.IsDBNull(39))
                {
                    txtRTW.Text = dataReader.GetDateTime(39).ToString();
                }
                else txtRTW.Text = "";

                if (!dataReader.IsDBNull(10))
                {
                    if (dataReader.GetString(10) == "Termination" && dataReader.GetString(25) == "Full-Time")
                    {
                        //txtCounselingCount.Text = ;
                        txtCounselingCount.Text = "5";
                    }
                    else if (dataReader.GetString(10) == "Termination" && (dataReader.GetString(25) == "Part-Time" || dataReader.GetString(25) == "Introductory"))
                    {
                        //txtCounselingCount.Text = "" + dataReader.GetInt32(19);
                        txtCounselingCount.Text = "3";
                    }
                    else
                    {
                        if (!dataReader.IsDBNull(19))
                        {
                            txtCounselingCount.Text = "" + dataReader.GetInt32(19);
                        }
                        else txtCounselingCount.Text = "";
                    }
                }

                

            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

            //IIdentity id2 = HttpContext.Current.User.Identity;
            //// set up domain context
            //PrincipalContext ctx = new PrincipalContext(ContextType.Domain, id2.GetDomain());

            //// find a user
            //UserPrincipal user = UserPrincipal.FindByIdentity(ctx, id2.GetLogin());

            //// find the group in question
            //GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - HRIS");

            //if (user != null)
            //{
            //    // check if user is member of that group
            //    if (user.IsMemberOf(group))
            //    {
            //        Button2.Visible = true;
            //        pagelabel.Text = "";
            //        pagelabel.Visible= false;
            //    }
            //    else
            //    {
            //        pagelabel.Text = "No actions available for user.";
            //        Button2.Visible = false;
            //    }

            //}

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

        
        protected void txtSupComments_TextChanged(object sender, EventArgs e)
        {
            udpateSupComments = txtSupComments.Text;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/HRDash", false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCounselingID.Text;
            Response.Redirect("~/HumanResources/DisciplinaryAction.aspx?id=" + id + "", false);
            //Response.Redirect("~/HumanResources/HRDash", false);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCounselingID.Text);
            Response.Redirect("~/DisciplinePrint.aspx?id=" + id + "", false);
        }
    }
}