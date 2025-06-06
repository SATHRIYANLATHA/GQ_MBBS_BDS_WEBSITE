using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mbbs_MBBS_BDS_WEBSITE
{
    public partial class pinfo : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["DBConnMbbsGovt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindCommunityDropDown(); // dropdown for community ...
                BindNationalityDropDown(); // dropdown for nationality ...
                BindMotherTongueDropDown(); // dropdown for mother tongue ...
                BindReligionDropDown(); // dropdown for religion ...
                BindNativityDropDown(); // dropdown for nativity ...
                BindDistrictDropDown(); // dropdown for district ...


                string loginId = Session["LoginId"] as string;

                if (Session["LoginId"] != null)
                {
                    username.InnerHtml = Session["UserName"].ToString();
                    hscrollno.InnerHtml = Session["HSCRollNumber"].ToString();
                    neetrollno.InnerHtml = Session["NEETRollNumber"].ToString();
                    dateofbirth.InnerHtml = Session["DateOfBirth"].ToString();
                    yearofpassing.InnerHtml = Session["YearOfPassing"].ToString();
                    gender.InnerHtml = Session["Gender"].ToString();

                }
                loaduserdetails(loginId);

                if (Session["LoginId"] == null)
                {
                    Response.Redirect("error.aspx");
                }
            }
        }

        //protected void btnNext_Click(object sender, EventArgs e)
        //{
        //    // Set the session variable to mark the current step as complete
        //    Session["PersonalInformationComplete"] = true;

        //    // Redirect to the next page (e.g., splres.aspx)
        //    Response.Redirect("splres.aspx");


        //}



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
                    String checkQuery = "SELECT COUNT(*) FROM PersonalInformation WHERE LoginId = @LoginId";
                    SqlCommand checkcmd = new SqlCommand(checkQuery, con);
                    checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    int count = Convert.ToInt32(checkcmd.ExecuteScalar());
                    con.Close();

                    string query;

                    if (count > 0)
                    {
                        query = "UPDATE PersonalInformation SET NameOfTheParent=@NameOfTheParent, Nationality=@Nationality, MotherTongue=@MotherTongue, SchoolingStudied=@SchoolingStudied, Religion=@Religion, Nativity=@Nativity, Community=@Community, CasteWithSubCode=@CasteWithSubCode, CertificateNumber=@CertificateNumber, IssuedBy=@IssuedBy, IssuedTaluk=@IssuedTaluk, CommDistrict=@CommDistrict, IssuedDate=@IssuedDate, ModifiedAt=getdate(), ModifiedUserId=@ModifiedUserID WHERE LoginId=@LoginId";
                    }
                    else
                    {
                        query = "INSERT INTO PersonalInformation(LoginId, NameOfTheParent, Nationality, MotherTongue, SchoolingStudied, Religion, Nativity, Community, CasteWithSubCode, CertificateNumber, IssuedBy, IssuedTaluk, CommDistrict, IssuedDate, ModifiedAt, ModifiedUserID) VALUES (@LoginId, @NameOfTheParent, @Nationality, @MotherTongue, @SchoolingStudied, @Religion, @Nativity, @Community, @CasteWithSubCode, @CertificateNumber, @IssuedBy, @IssuedTaluk, @CommDistrict, @IssuedDate, getdate(), @ModifiedUserID)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", LoginId);
                    cmd.Parameters.AddWithValue("@NameOfTheParent", txtParent.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nationality", ddlNationality.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@MotherTongue", ddlMotherTongue.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@SchoolingStudied", ddlSchooling.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@Religion", ddlReligion.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@Nativity", ddlNativity.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@Community", ddlCommunity.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@CasteWithSubCode", ddlCaste.SelectedValue.Trim());

                    if (ddlCommunity.SelectedValue.Trim() == "1")
                    {
                        txtCertificate.Text = "";
                        txtIssuedby.Text = "";
                        txtIssuedTaluk.Text = "";
                        ddlDistrict.SelectedValue = "";
                        txtDate.Text = "";
                    }

                    cmd.Parameters.AddWithValue("@CertificateNumber", txtCertificate.Text.Trim());
                    cmd.Parameters.AddWithValue("@IssuedBy", txtIssuedby.Text.Trim());
                    cmd.Parameters.AddWithValue("@IssuedTaluk", txtIssuedTaluk.Text.Trim());
                    cmd.Parameters.AddWithValue("@CommDistrict", ddlDistrict.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@IssuedDate", txtDate.Text.Trim());

                    //cmd.Parameters.AddWithValue("@ModifiedAt", modifiedAt);


                    cmd.Parameters.AddWithValue("@ModifiedUserID", LoginId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                Session["PersonalInformationComplete"] = true;
                setuserstatus();
                Response.Redirect("splres.aspx");
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
                    string query = "SELECT * FROM PersonalInformation WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // Load parent name
                            txtParent.Text = dr["NameOfTheParent"].ToString();

                            // Load Nationality
                            string nationalityId = dr["Nationality"].ToString().Trim();
                            ListItem nationalityItem = ddlNationality.Items.FindByValue(nationalityId);
                            if (nationalityItem != null)
                            {
                                ddlNationality.SelectedValue = nationalityId;
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("Nationality ID not found: " + nationalityId);
                            }

                            // Load Mother Tongue
                            string motherTongue = dr["MotherTongue"].ToString().Trim();
                            if (ddlMotherTongue.Items.FindByValue(motherTongue) != null)
                            {
                                ddlMotherTongue.SelectedValue = motherTongue;
                            }

                            // Load Schooling Studied
                            string schoolingStudied = dr["SchoolingStudied"].ToString().Trim();
                            if (ddlSchooling.Items.FindByValue(schoolingStudied) != null)
                            {
                                ddlSchooling.SelectedValue = schoolingStudied;
                            }

                            // Load Religion
                            string religion = dr["Religion"].ToString().Trim();
                            if (ddlReligion.Items.FindByValue(religion) != null)
                            {
                                ddlReligion.SelectedValue = religion;
                            }

                            // Load Nativity
                            string nativity = dr["Nativity"].ToString().Trim();
                            if (ddlNativity.Items.FindByValue(nativity) != null)
                            {
                                ddlNativity.SelectedValue = nativity;
                                NativityChange(ddlNativity, EventArgs.Empty);  // Trigger any change for Nativity
                                BindCasteDropDown();
                            }

                            // Load Community
                            string community = dr["Community"].ToString().Trim();
                            if (ddlCommunity.Items.FindByValue(community) != null)
                            {
                                ddlCommunity.SelectedValue = community;
                                BindCasteDropDown();
                            }

                            // Load Caste
                            string casteWithSubCode = dr["CasteWithSubCode"].ToString().Trim();
                            if (ddlCaste.Items.FindByValue(casteWithSubCode) != null)
                            {
                                ddlCaste.SelectedValue = casteWithSubCode;
                            }

                            // If OC and Tamilnadu selected, hide certificate details
                            if (ddlNativity.SelectedValue.Trim() == "1" && ddlCommunity.SelectedValue.Trim() == "1")
                            {
                                commmunity_certificate_detail.Visible = false;

                                txtCertificate.Text = "";
                                txtCertificate.Enabled = false;
                                txtCertificate.Visible = false;

                                txtIssuedby.Text = "";
                                txtIssuedby.Enabled = false;
                                txtIssuedby.Visible = false;

                                txtIssuedTaluk.Text = "";
                                txtIssuedTaluk.Enabled = false;
                                txtIssuedTaluk.Visible = false;

                                ddlDistrict.SelectedValue = "";
                                ddlDistrict.Enabled = false;
                                ddlDistrict.Visible = false;

                                txtDate.Text = "";
                                txtDate.Enabled = false;
                                txtDate.Visible = false;
                            }

                            // Load Certificate and Issue details
                            txtCertificate.Text = dr["CertificateNumber"].ToString();
                            txtIssuedby.Text = dr["IssuedBy"].ToString();
                            txtIssuedTaluk.Text = dr["IssuedTaluk"].ToString();

                            // Load District
                            string commDistrict = dr["CommDistrict"].ToString().Trim();
                            if (ddlDistrict.Items.FindByValue(commDistrict) != null)
                            {
                                ddlDistrict.SelectedValue = commDistrict;
                            }

                            // Load Issued Date
                            txtDate.Text = dr["IssuedDate"].ToString().Trim();
                        }
                    }
                }
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

                    if (currentPageStatus <=1)
                    {
                        query = "UPDATE UserProgress SET PageStatus = 1 WHERE LoginId = @LoginId";

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


        //....................  DROPDOWNS .........................

        protected void BindNationalityDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT NationalityId, NationalityName FROM Nationality"; // Fetch ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlNationality.Items.Clear(); // Clear old items
                ddlNationality.Items.Add(new ListItem("--Select Nationality--", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["NationalityId"]); // Get ID
                    string name = reader["NationalityName"].ToString(); // Get Name
                    ddlNationality.Items.Add(new ListItem(name, id.ToString())); // Set ID as value
                }
            }
        }



        // Bind Mother Tongue Dropdown using IDs as values, following the format you requested
        protected void BindMotherTongueDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT MotherTongueId, MotherTongueName FROM MotherTongue"; // Fetch ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlMotherTongue.Items.Clear(); // Clear old items
                ddlMotherTongue.Items.Add(new ListItem("--Select Mother Tongue--", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["MotherTongueId"]); // Get ID
                    string name = reader["MotherTongueName"].ToString(); // Get Name
                    ddlMotherTongue.Items.Add(new ListItem(name, id.ToString())); // Set ID as value
                }
            }
        }

        // Bind Religion Dropdown using IDs as values, following the format you requested
        protected void BindReligionDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT ReligionId, ReligionName FROM Religion"; // Fetch ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlReligion.Items.Clear(); // Clear old items
                ddlReligion.Items.Add(new ListItem("--Select Religion--", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ReligionId"]); // Get ID
                    string name = reader["ReligionName"].ToString(); // Get Name
                    ddlReligion.Items.Add(new ListItem(name, id.ToString())); // Set ID as value
                }
            }
        }

        // Bind Nativity Dropdown using IDs as values, following the format you requested
        protected void BindNativityDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT NativityId, NativityName FROM Nativity"; // Fetch ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlNativity.Items.Clear(); // Clear old items
                ddlNativity.Items.Add(new ListItem("--Select Nativity--", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["NativityId"]); // Get ID
                    string name = reader["NativityName"].ToString(); // Get Name
                    ddlNativity.Items.Add(new ListItem(name, id.ToString())); // Set ID as value
                }
            }
        }

        // Bind Community Dropdown using IDs as values, following the format you requested
        protected void BindCommunityDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT CommunityId, CommunityName FROM Community"; // Fetch ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCommunity.Items.Clear(); // Clear old items
                ddlCommunity.Items.Add(new ListItem("--Select Community--", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["CommunityId"]); // Get ID
                    string name = reader["CommunityName"].ToString(); // Get Name
                    ddlCommunity.Items.Add(new ListItem(name, id.ToString())); // Set ID as value
                }
            }
        }


        protected void ddlCommunity_SelectedIndexChanged(object sender, EventArgs e)
        {
           
               

            if(ddlCommunity.SelectedValue.Trim() == "1")
            {
                BindCasteDropDown();

                commmunity_certificate_detail.Visible = false;

                txtCertificate.Text = "";
                txtCertificate.Enabled = false;
                txtCertificate.Visible = false;

                txtIssuedby.Text = "";
                txtIssuedby.Enabled = false;
                txtIssuedby.Visible = false;

                txtIssuedTaluk.Text = "";
                txtIssuedTaluk.Enabled = false;
                txtIssuedTaluk.Visible = false;

                ddlDistrict.SelectedValue = "";
                ddlDistrict.Enabled = false;
                ddlDistrict.Visible = false;

                txtDate.Text = "";
                txtDate.Enabled = false;
                txtDate.Visible = false;
            }
            else
            {
                BindCasteDropDown();
                commmunity_certificate_detail.Visible = true;

                txtCertificate.Text = "";
                txtCertificate.Enabled = true;
                txtCertificate.Visible = true;

                txtIssuedby.Text = "";
                txtIssuedby.Enabled = true;
                txtIssuedby.Visible = true;

                txtIssuedTaluk.Text = "";
                txtIssuedTaluk.Enabled = true;
                txtIssuedTaluk.Visible = true;

                ddlDistrict.SelectedValue = "";
                ddlDistrict.Enabled = true;
                ddlDistrict.Visible = true;

                txtDate.Text = "";
                txtDate.Enabled = true;
                txtDate.Visible = true;
            }


        }

        // Bind Caste Dropdown using IDs as values
        private void BindCasteDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT CasteId, CasteName, CommunityId FROM Caste WHERE CommunityId = @CommunityId"; // Fetch ID, CasteName, and CommunityName
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CommunityId", ddlCommunity.SelectedValue.Trim());
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCaste.Items.Clear(); // Clear existing items
                ddlCaste.Items.Add(new ListItem("-- Select Caste --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["CasteId"]); // Get ID
                    string casteName = reader["CasteName"].ToString().Trim(); // Get CasteName

                    ddlCaste.Items.Add(new ListItem(casteName, id.ToString())); // Set ID as value
                }
            }
        }

        // Bind District Dropdown using IDs as values
        protected void BindDistrictDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT DistrictId, DistrictName FROM District"; // Fetch ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlDistrict.Items.Clear(); // Clear existing items
                ddlDistrict.Items.Add(new ListItem("-- Select District --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["DistrictId"]); // Get ID
                    string district = reader["DistrictName"].ToString().Trim(); // Get DistrictName

                    ddlDistrict.Items.Add(new ListItem(district, id.ToString())); // Set ID as value
                }
            }
        }


        protected void NativityChange(object sender, EventArgs e)
        {
            // Check if the selected value in ddlNativity is "Others"
            if (ddlNativity.SelectedValue.Trim() == "2")
            {
                // Loop through all the items in ddlCommunity
                for (int i = ddlCommunity.Items.Count - 1; i >= 0; i--)
                {
                    // If the item's value is not "1", remove it
                    if (ddlCommunity.Items[i].Value != "1")
                    {
                        ddlCommunity.Items.RemoveAt(i);
                    }
                }

                ddlCommunity.SelectedValue = "1";

                BindCasteDropDown();

                commmunity_certificate_detail.Visible = false;

                txtCertificate.Text = "";
                txtCertificate.Enabled = false;
                txtCertificate.Visible = false;

                txtIssuedby.Text = "";
                txtIssuedby.Enabled = false;
                txtIssuedby.Visible = false;

                txtIssuedTaluk.Text = "";
                txtIssuedTaluk.Enabled = false;
                txtIssuedTaluk.Visible = false;

                ddlDistrict.SelectedValue = "";
                ddlDistrict.Enabled = false;
                ddlDistrict.Visible = false;

                txtDate.Text = "";
                txtDate.Enabled = false;
                txtDate.Visible = false;


            }
            else
            {
                BindCommunityDropDown(); // Rebind the community dropdown

                commmunity_certificate_detail.Visible = true;

                txtCertificate.Text = "";
                txtCertificate.Enabled = true;
                txtCertificate.Visible = true;

                txtIssuedby.Text = "";
                txtIssuedby.Enabled = true;
                txtIssuedby.Visible = true;

                txtIssuedTaluk.Text = "";
                txtIssuedTaluk.Enabled = true;
                txtIssuedTaluk.Visible = true;

                ddlDistrict.SelectedValue = "";
                ddlDistrict.Enabled = true;
                ddlDistrict.Visible = true;

                txtDate.Text = "";
                txtDate.Enabled = true;
                txtDate.Visible = true;
            }
        }



    }
}