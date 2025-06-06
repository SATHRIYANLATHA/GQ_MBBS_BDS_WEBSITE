using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mbbs_MBBS_BDS_WEBSITE
{
    public partial class addinfo : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["DBConnMbbsGovt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_session_one();

                if (Session["Indian"] != null && (bool)Session["Indian"] == true)
                {
                    aadhar.Visible = true;
                    AADHARNO.Enabled = true;

                }
                else
                {
                    aadhar.Visible = false; ;
                    AADHARNO.Enabled = false;
                }

                BindDistrictDropDown();
                BindStateDropDown(); // dropdown for states ...
                BindAnnualIncomeDropDown(); // dropdown for annual income ...
                BindParentsOccupationDropDown(); // dropdown for parents occupation ...


                String loginId = Session["LoginId"] as string;
                loaduserdetails(loginId);

                if (Session["LoginId"] == null)
                {
                    Response.Redirect("error.aspx");
                }
            }

        }

        protected void load_session_one()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM PersonalInformation WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            if ((dr["Nationality"].ToString().Trim()) == "1") // checking if INDIAN
                            {
                                Session["Indian"] = true;
                            }
                            else
                            {
                                Session["Indian"] = false;
                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }
        protected void loaduserdetails(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM AdditionalInformation WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            if (FirstGraduateOptions.Items.FindByValue(dr["FGApplicant"].ToString().Trim()) != null)
                            {
                                FirstGraduateOptions.SelectedValue = dr["FGApplicant"].ToString().Trim();
                            }


                            if (ddlParentsOccupation.Items.FindByValue(dr["ParentOccupation"].ToString().Trim()) != null)
                            {
                                ddlParentsOccupation.SelectedValue = dr["ParentOccupation"].ToString().Trim();
                            }

                            if (ddlAnnualIncome.Items.FindByValue(dr["ParentAnnualIncome"].ToString().Trim()) != null)
                            {
                                ddlAnnualIncome.SelectedValue = dr["ParentAnnualIncome"].ToString().Trim();
                            }

                            if (ddlNativeState.Items.FindByValue(dr["NativeState"].ToString().Trim()) != null)
                            {
                                ddlNativeState.SelectedValue = dr["NativeState"].ToString().Trim();
                            }



                            if (ddlNativeDistrict.Items.FindByValue(dr["NativeDistrict"].ToString().Trim()) != null)
                            {
                                ddlNativeDistrict.SelectedValue = dr["NativeDistrict"].ToString().Trim();
                            }


                            IDENTMARKS.InnerText = dr["IdentificationMarks"].ToString().Trim();

                            if (Session["Indian"] != null && (bool)Session["Indian"] == true)
                            {
                                aadhar.Visible = true;
                                AADHARNO.Enabled = true;

                            }
                            else
                            {
                                aadhar.Visible = false; ;
                                AADHARNO.Enabled = false;
                            }

                            AADHARNO.Text = dr["AadharNumber"].ToString().Trim();

                            EMAILID.Value = dr["EmailId"].ToString().Trim();

                            PHONENO.Value = dr["PhoneNumber"].ToString().Trim();

                            Text1.InnerText = dr["AddressForCorrespondence"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            try
            {
                String LoginId = Session["LoginId"] as string;

                if (Session["LoginId"] == null)
                {
                    Response.Redirect("error.aspx");
                    return;
                }

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    String checkQuery = "SELECT COUNT(*) FROM AdditionalInformation where LoginId = @LoginId";
                    SqlCommand checkcmd = new SqlCommand(checkQuery, con);
                    checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    int count = Convert.ToInt32(checkcmd.ExecuteScalar());
                    con.Close();

                    string query;

                    if (count > 0)
                    {
                        query = "UPDATE AdditionalInformation SET FGApplicant=@FGApplicant,ParentOccupation=@ParentOccupation,ParentAnnualIncome=@ParentAnnualIncome,NativeState=@NativeState,NativeDistrict=@NativeDistrict,IdentificationMarks=@IdentificationMarks,AadharNumber=@AadharNumber,EmailId=@EmailId,PhoneNumber=@PhoneNumber,AddressForCorrespondence=@AddressForCorrespondence,ModifiedAt=getdate(),ModifiedUserID=@ModifiedUserID WHERE LoginId=@LoginId";
                    }
                    else
                    {
                        query = "INSERT INTO AdditionalInformation(LoginId,FGApplicant,ParentOccupation,ParentAnnualIncome,NativeState,NativeDistrict,IdentificationMarks,AadharNumber,EmailId,PhoneNumber,AddressForCorrespondence,ModifiedAt,ModifiedUserID) VALUES (@LoginId,@FGApplicant,@ParentOccupation,@ParentAnnualIncome,@NativeState,@NativeDistrict,@IdentificationMarks,@AadharNumber,@EmailId,@PhoneNumber,@AddressForCorrespondence,getdate(),@ModifiedUserID)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@LoginId", LoginId);
                    cmd.Parameters.AddWithValue("@FGApplicant", FirstGraduateOptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@ParentOccupation", ddlParentsOccupation.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@ParentAnnualIncome", ddlAnnualIncome.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@NativeState", ddlNativeState.SelectedValue.Trim());

                    //string district = hdnNativeDistrict.Value;  // Get the value from the hidden field

                   

                    //// Proceed with saving the district value to the database
                    //cmd.Parameters.AddWithValue("@NativeDistrict", district);

                    cmd.Parameters.AddWithValue("@NativeDistrict", ddlNativeDistrict.SelectedValue.Trim());

                    cmd.Parameters.AddWithValue("@IdentificationMarks", IDENTMARKS.InnerText.Trim());

                    if (Session["Indian"] != null && (bool)Session["Indian"] == true)
                    {
                        AADHARNO.Text = AADHARNO.Text.Trim();
                    }
                    else
                    {
                        AADHARNO.Text = "";
                    }

                    cmd.Parameters.AddWithValue("@AadharNumber", AADHARNO.Text.Trim());

                    cmd.Parameters.AddWithValue("@EmailId", EMAILID.Value.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", PHONENO.Value.Trim());
                    cmd.Parameters.AddWithValue("@AddressForCorrespondence", Text1.InnerText.Trim());

                   
                    cmd.Parameters.AddWithValue("@ModifiedUserID", LoginId);



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                   



                }

                Session["AdditionalInformationComplete"] = true;

                setuserstatus();

                Response.Redirect("upload.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void setuserstatus()
        {
            try
            {
                string loginId = Session["LoginId"] as string;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string checkQuery = "SELECT PageStatus FROM UserProgress where LoginId =@LoginId";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                    object result = checkCmd.ExecuteScalar();
                    int currentPageStatus = result != null ? Convert.ToInt32(result) : -1; // -1 indicates no record

                    string query;

                    if (currentPageStatus <= 4)
                    {
                        query = "UPDATE UserProgress SET PageStatus = 4 WHERE LoginId = @LoginId";

                    }
                    else
                    {
                        return;
                    }


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }






        // ............: DROPDOWN :...................

        // Bind District Dropdown using IDs as values
      



        protected void BindStateDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT StateId, StateName FROM States"; // Fetch State ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlNativeState.Items.Clear(); // Clear existing items
                ddlNativeState.Items.Add(new ListItem("-- Select State --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["StateId"]); // Get ID
                    string state = reader["StateName"].ToString().Trim(); // Get State Name

                    ddlNativeState.Items.Add(new ListItem(state, id.ToString())); // Set ID as value
                }

                reader.Close(); // Close reader
            }
        }

        protected void BindDistrictDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT DistrictId, DistrictName FROM District"; // Fetch State ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlNativeDistrict.Items.Clear(); // Clear existing items
                ddlNativeDistrict.Items.Add(new ListItem("-- Select District --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["DistrictId"]); // Get ID
                    string district = reader["DistrictName"].ToString().Trim(); // Get State Name

                    ddlNativeDistrict.Items.Add(new ListItem(district, id.ToString())); // Set ID as value
                }

                reader.Close(); // Close reader
            }
        }


        protected void BindAnnualIncomeDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT AnnualIncomeId, AnnualIncomeRange FROM AnnualIncome"; // Fetch ID & Range
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlAnnualIncome.Items.Clear(); // Clear existing items
                ddlAnnualIncome.Items.Add(new ListItem("-- Select Annual Income --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["AnnualIncomeId"]); // Get ID
                    string incomeRange = reader["AnnualIncomeRange"].ToString().Trim(); // Get Income Range

                    ddlAnnualIncome.Items.Add(new ListItem(incomeRange, id.ToString())); // Set ID as value
                }

                reader.Close(); // Close reader
            }
        }


        protected void BindParentsOccupationDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT ParentsOccupationId, ParentsOccupationName FROM ParentsOccupation"; // Fetch ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlParentsOccupation.Items.Clear(); // Clear existing items
                ddlParentsOccupation.Items.Add(new ListItem("-- Select Occupation --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ParentsOccupationId"]); // Get ID
                    string occupationName = reader["ParentsOccupationName"].ToString().Trim(); // Get Occupation Name

                    ddlParentsOccupation.Items.Add(new ListItem(occupationName, id.ToString())); // Set ID as value
                }

                reader.Close(); // Close reader
            }
        }


    }
}