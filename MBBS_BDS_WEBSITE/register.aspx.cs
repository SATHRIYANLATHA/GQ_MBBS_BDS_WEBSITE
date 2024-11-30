using mbbs_MBBS_BDS_WEBSITE;
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

namespace MBBS_BDS_WEBSITE
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


                    // Convert and format the date
                    DateTime dob = DateTime.ParseExact(txtDOB.Text.Trim(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    string formattedDOB = dob.ToString("dd-MM-yyyy"); // Convert to "DD-MM-YYYY" format
                    cmd.Parameters.AddWithValue("@DateOfBirth", formattedDOB);


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
                String query = "SELECT QualifyingExaminationName FROM QualifyingExamination";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    String qualifyingexamination = reader["QualifyingExaminationName"].ToString();

                    ddlQualifyingExamination.Items.Add(new ListItem(qualifyingexamination));
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

        private static readonly Random random = new Random();
        private const string ApiKey = "GsqwL9vfBYxG+uwgadAeI73FR8Myrf9Tps1V4Rbt1PE=";
        private const string ClientId = "8119feed-acaf-4580-a07e-9a63e3ff9559";
        private const string BaseUrl = "http://smsssl.dial4sms.com/api/v2";

        protected void btnSendSMS_Click(object sender, EventArgs e)
        {
            // Generate a random 6-digit OTP
            int otp = random.Next(100000, 999999);

            // Store OTP in session for verification
            Session["GeneratedOTP"] = otp;

            // Get the mobile number from the input field
            string mobileNumber = txtMobileNumber.Text.Trim();
            string defaultCountryCode = "+91"; // Change as per your region

            if (!mobileNumber.StartsWith("+"))
            {
                mobileNumber = defaultCountryCode + mobileNumber;
            }

            // Prepare the SMS content
            string message = $"Your OTP is: {otp}";
            string senderId = "CALLER"; // Change to your Sender ID
            string templateId = "1407162065828534452"; // Replace with your actual Template ID

            // Construct the API URL for sending the SMS
            string url = $"{BaseUrl}/SMS?ApiKey={ApiKey}&ClientId={ClientId}&sender={senderId}&number={mobileNumber}&sms={message}&templateid={templateId}";

            try
            {
                // Send the SMS using WebRequest
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();

                // Read and log the response
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string apiResponse = reader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine("SMS API Response: " + apiResponse);
                }

                // Display success message or next panel
                sendSMS.Visible = false;
                smssent.Visible = true;

                // Debug the generated OTP (remove in production)
                System.Diagnostics.Debug.WriteLine("Generated OTP: " + otp);
            }
            catch (Exception ex)
            {
                // Log and display error
                System.Diagnostics.Debug.WriteLine("Error sending SMS: " + ex.Message);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Failed to send SMS. Please try again.');", true);
            }
        }

        protected void resend_Click(object sender, EventArgs e)
        {
            // Generate a new OTP
            int newOtp = random.Next(100000, 999999);
            Session["GeneratedOTP"] = newOtp;

            string mobileNumber = txtMobileNumber.Text.Trim();
            string defaultCountryCode = "+91";

            if (!mobileNumber.StartsWith("+"))
            {
                mobileNumber = defaultCountryCode + mobileNumber;
            }

            string message = $"Your new OTP is: {newOtp}";
            string senderId = "CALLER";
            string templateId = "1407162065828534452";

            string url = $"{BaseUrl}/SMS?ApiKey={ApiKey}&ClientId={ClientId}&sender={senderId}&number={mobileNumber}&sms={message}&templateid={templateId}";

            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string apiResponse = reader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine("Resend SMS API Response: " + apiResponse);
                }

                sendSMS.Visible = false;
                smssent.Visible = true;
                otpsuccess.Visible = false;
                otpfailure.Visible = false;

                System.Diagnostics.Debug.WriteLine("Resent OTP: " + newOtp);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error resending SMS: " + ex.Message);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Failed to resend SMS. Please try again.');", true);
            }
        }

        protected void verify_Click(object sender, EventArgs e)
        {
            // Concatenate entered OTP from multiple input boxes
            string enteredOTP = Request.Form["otp1"] + Request.Form["otp2"] +
                                Request.Form["otp3"] + Request.Form["otp4"] +
                                Request.Form["otp5"] + Request.Form["otp6"];

            string generatedOTP = Session["GeneratedOTP"]?.ToString();

            if (!string.IsNullOrEmpty(enteredOTP) && enteredOTP == generatedOTP)
            {
                sendSMS.Visible = false;
                smssent.Visible = false;
                otpsuccess.Visible = true;
                otpfailure.Visible = false;
                fourfive.Visible = true;
            }
            else
            {
                sendSMS.Visible = false;
                smssent.Visible = true;
                otpsuccess.Visible = false;
                otpfailure.Visible = true;
            }
        }

        // Fetch Template List
        public void FetchTemplates()
        {
            string url = $"{BaseUrl}/Template?ApiKey={ApiKey}&ClientId={ClientId}";

            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string apiResponse = reader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine("Template List Response: " + apiResponse);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error fetching templates: " + ex.Message);
            }
        }
    



}
}