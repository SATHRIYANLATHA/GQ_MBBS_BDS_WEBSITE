
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mbbs_MBBS_BDS_WEBSITE
{
    public partial class register : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQualifyingExaminationDropDown(); // dropdown for qualifying examination
            }



        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string EmailValid = hdnEmailValid.Value;

            if (EmailValid == "invalid")
            {
                emailError.InnerHtml = "enter a valid email";
                return;
            }
            else
            {
                emailError.InnerHtml = "";
            }



            string MobileValid = hdnMobileValid.Value;

            if (MobileValid == "invalid")
            {
                mobileError.InnerHtml = "enter a valid mobile number";
                return;
            }
            else
            {
                mobileError.InnerHtml = "";
            }


            string passwordStrength = hdnPasswordStrength.Value;

            if (passwordStrength == "none" || passwordStrength == "weak" || passwordStrength == "invalid")
            {
                errorPassword.InnerHtml = "Password does not match the conditions.";
                return; // Exit the method to prevent form submission
            }
            else
            {
                errorPassword.InnerHtml = "";
            }




            if (txtPassword.Text.Trim() == txtConfpassword.Text.Trim())
            {
                if (checkuserexists())
                {
                    errorLoginID.InnerHtml = "user already exists with the id, try with different id";
                }
                else
                {

                    newuserregister();
                    setapplicationnumber();
                    beforelogin.Visible = false;
                    afterlogin.Visible = true;
                    regusername.InnerHtml = txtName.Text.Trim();
                }
            }
            else
            {
                
                errorPassword.InnerHtml = "Password and confirm password are wrong. ";

            }


        }






        bool checkuserexists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM UserRegister where LoginId= '" + txtLoginid.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
                return false;
            }
        }


        protected void newuserregister()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "INSERT INTO UserRegister (UserName,Email,Gender,Mobile,DateOfBirth,PlusOnePassed,HSCRollNumber,NEETRollNumber,NEETRegNumber,QualifyingExamination,QualifiedYear,NEETMarks,LoginId,UserPassword) values (@UserName, @Email, @Gender, @Mobile, @DateOfBirth, @PlusOnePassed, @HSCRollNumber, @NEETRollNumber,@NEETRegNumber, @QualifyingExamination, @QualifiedYear, @NEETMarks, @LoginId, @UserPassword)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserName", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", rdGender.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobileNumber.Text.Trim());


                    
                    cmd.Parameters.AddWithValue("@DateOfBirth", txtDOB.Text.Trim());


                    cmd.Parameters.AddWithValue("@PlusOnePassed", rdPlusonepassed.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@HSCRollNumber", txtHsc.Text.Trim());
                    cmd.Parameters.AddWithValue("@NEETRollNumber", txtNeet.Text.Trim());
                    cmd.Parameters.AddWithValue("@NEETRegNumber", txtreg.Text.Trim());
                    cmd.Parameters.AddWithValue("@QualifyingExamination", ddlQualifyingExamination.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@QualifiedYear", ddlQualifiedYear.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@NEETMarks", txtNeetMarks.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoginId", txtLoginid.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    // SESSION FOR SETTING APPLICATION NUMBER....
                    Session["LoginId"] = txtLoginid.Text.Trim();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }

        // ..........................: RESET BUTTON ......:....................



        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtEmail.Text = "";
            rdGender.SelectedValue = "";
            txtMobileNumber.Text = "";
            txtDOB.Text = "";
            rdPlusonepassed.SelectedValue = "";
            txtHsc.Text = "";
            txtNeet.Text = "";
            txtreg.Text = "";
            ddlQualifyingExamination.SelectedValue = "";
            ddlQualifiedYear.SelectedValue = "";
            txtNeetMarks.Text = "";
            txtLoginid.Text = "";
            txtPassword.Text = "";
            txtConfpassword.Text = "";
        }


        //.............................: DROPDOWNS :.................................
        protected void BindQualifyingExaminationDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT QualifyingExaminationId, QualifyingExaminationName FROM QualifyingExamination";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlQualifyingExamination.Items.Clear();
                ddlQualifyingExamination.Items.Add(new ListItem("-- Select --", ""));

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["QualifyingExaminationId"]);
                    string qualifyingExamination = reader["QualifyingExaminationName"].ToString().Trim().ToUpper();

                    ddlQualifyingExamination.Items.Add(new ListItem(qualifyingExamination, id.ToString()));
                }
            }
        }





        protected void setapplicationnumber()
        {
            try
            {
                string loginId = null; // Declare a variable to store the LoginId

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open(); // Open the connection

                    // Query to fetch the LoginId from the UserRegister table
                    string query = "SELECT LoginId FROM UserRegister WHERE LoginId = @LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Replace these with the values you are using for verification
                    cmd.Parameters.AddWithValue("@LoginId", txtLoginid.Text.Trim());


                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            loginId = dr["LoginId"].ToString(); // Retrieve the LoginId from the reader
                        }
                    }
                    dr.Close(); // Close the reader

                    // If no LoginId is found, exit the function
                    if (string.IsNullOrEmpty(loginId))
                    {
                        return; // Exit if LoginId is not found
                    }

                    // Check if the application number already exists for this LoginId
                    string checkQuery = "SELECT COUNT(*) FROM Applications WHERE LoginId = @LoginId";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    // If the application number already exists, exit the function early
                    if (count > 0)
                    {
                        return; // Exit the function if the application number already exists
                    }

                    // Get the next application number and prepend the prefix
                    string applicationNumber = "25UG" + GetNextApplicationNumber().ToString();

                    // Insert a new record with generated application number
                    string insertQuery = "INSERT INTO Applications (LoginId, ApplicationNumber) VALUES (@LoginId, @ApplicationNumber)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@LoginId", loginId);
                    insertCmd.Parameters.AddWithValue("@ApplicationNumber", applicationNumber);

                    // Execute the insert command
                    insertCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }




        private int GetNextApplicationNumber()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                // Open the connection
                con.Open();

                // SQL query to get the next value from the sequence
                string seqQuery = "SELECT NEXT VALUE FOR ApplicationNumberSeq";
                SqlCommand seqCmd = new SqlCommand(seqQuery, con);

                // Execute the query and return the next application number
                return Convert.ToInt32(seqCmd.ExecuteScalar());
            }
        }

       


}
}