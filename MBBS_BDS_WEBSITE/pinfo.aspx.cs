using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MBBS_BDS_WEBSITE
{
    public partial class pinfo : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
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

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    String checkQuery = "SELECT COUNT(*) FROM PersonalInformation where LoginId = @LoginId";
                    SqlCommand checkcmd = new SqlCommand(checkQuery, con);
                    checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    int count = Convert.ToInt32(checkcmd.ExecuteScalar());
                    con.Close();

                    string query;

                    if (count > 0)
                    {
                        query = "UPDATE PersonalInformation SET NameOfTheParent=@NameOfTheParent,Nationality=@Nationality,MotherTongue=@MotherTongue,SchoolingStudied=@SchoolingStudied,Religion=@Religion,Nativity=@Nativity,Community=@Community,CasteWithSubCode=@CasteWithSubCode,CertificateNumber=@CertificateNumber,IssuedBy=@IssuedBy,IssuedTaluk=@IssuedTaluk,CommDistrict=@CommDistrict,IssuedDate=@IssuedDate WHERE LoginId=@LoginId";
                    }
                    else
                    {
                        query = "INSERT INTO PersonalInformation(LoginId,NameOfTheParent,Nationality,MotherTongue,SchoolingStudied,Religion,Nativity,Community,CasteWithSubCode,CertificateNumber,IssuedBy,IssuedTaluk,CommDistrict,IssuedDate) VALUES (@LoginId,@NameOfTheParent,@Nationality,@MotherTongue,@SchoolingStudied,@Religion,@Nativity,@Community,@CasteWithSubCode,@CertificateNumber,@IssuedBy,@IssuedTaluk,@CommDistrict,@IssuedDate)";
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
                    cmd.Parameters.AddWithValue("@CertificateNumber", txtCertificate.Text.Trim());
                    cmd.Parameters.AddWithValue("@IssuedBy", txtIssuedby.Text.Trim());
                    cmd.Parameters.AddWithValue("@IssuedTaluk", txtIssuedTaluk.Text.Trim());
                    cmd.Parameters.AddWithValue("@CommDistrict", ddlDistrict.SelectedValue.Trim());

                   // cmd.Parameters.AddWithValue("@IssuedDate", txtDate.Text.Trim());

                    // Convert and format the date
                    DateTime isuuedate = DateTime.ParseExact(txtDate.Text.Trim(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    string  formattedissueddate= isuuedate.ToString("dd-MM-yyyy"); // Convert to "DD-MM-YYYY" format
                    cmd.Parameters.AddWithValue("@IssuedDate", formattedissueddate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }

                // Set the session variable to mark the current step as complete
                Session["PersonalInformationComplete"] = true;

                setuserstatus();

                // Redirect to the next page (e.g., splres.aspx)
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
                            txtParent.Text = dr["NameOfTheParent"].ToString();

                            if (ddlNationality.Items.FindByValue(dr["Nationality"].ToString()) != null)
                            {
                                ddlNationality.SelectedValue = dr["Nationality"].ToString();
                            }

                            if (ddlMotherTongue.Items.FindByValue(dr["MotherTongue"].ToString()) != null)
                            {
                                ddlMotherTongue.SelectedValue = dr["MotherTongue"].ToString();
                            }

                            if (ddlSchooling.Items.FindByValue(dr["SchoolingStudied"].ToString().Trim()) != null)
                            {
                                ddlSchooling.SelectedValue = dr["SchoolingStudied"].ToString().Trim();
                            }

                            if (ddlReligion.Items.FindByValue(dr["Religion"].ToString()) != null)
                            {
                                ddlReligion.SelectedValue = dr["Religion"].ToString();
                            }

                            if (ddlNativity.Items.FindByValue(dr["Nativity"].ToString()) != null)
                            {
                                ddlNativity.SelectedValue = dr["Nativity"].ToString();
                            }

                            if (ddlCommunity.Items.FindByValue(dr["Community"].ToString()) != null)
                            {
                                ddlCommunity.SelectedValue = dr["Community"].ToString();
                                BindCasteDropDown();
                            }

                            if (ddlCaste.Items.FindByValue(dr["CasteWithSubCode"].ToString().Trim()) != null)
                            {
                                ddlCaste.SelectedValue = dr["CasteWithSubCode"].ToString().Trim();
                            }

                            txtCertificate.Text = dr["CertificateNumber"].ToString();

                            txtIssuedby.Text = dr["IssuedBy"].ToString();

                            txtIssuedTaluk.Text = dr["IssuedTaluk"].ToString();

                            if (ddlDistrict.Items.FindByValue(dr["CommDistrict"].ToString().Trim()) != null)
                            {
                                ddlDistrict.SelectedValue = dr["CommDistrict"].ToString().Trim();
                            }

                            DateTime issuedDate = Convert.ToDateTime(dr["IssuedDate"]);
                            // Format the date to "yyyy-MM-dd" as required by the input of type "Date"
                            txtDate.Text = issuedDate.ToString("yyyy-MM-dd");
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
                string query = "SELECT NationalityName FROM Nationality ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nationality = reader["NationalityName"].ToString();
                    ddlNationality.Items.Add(new ListItem(nationality));
                }
            }
        }

        protected void BindMotherTongueDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT MotherTongueName FROM MotherTongue";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string mothertongue = reader["MotherTongueName"].ToString();
                    ddlMotherTongue.Items.Add(new ListItem(mothertongue));
                }
            }
        }


        protected void BindReligionDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT ReligionName FROM Religion";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string religion = reader["ReligionName"].ToString();
                    ddlReligion.Items.Add(new ListItem(religion));
                }
            }
        }


        protected void BindNativityDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT NativityName FROM Nativity";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nativity = reader["NativityName"].ToString();
                    ddlNativity.Items.Add(new ListItem(nativity));
                }
            }
        }

        protected void BindCommunityDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT CommunityId, CommunityName FROM Community";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCommunity.Items.Clear();

                ddlCommunity.Items.Add(new ListItem("-- Select Community --", ""));

                while (reader.Read())
                {
                    string communityName = reader["CommunityName"].ToString();
                    string communityId = reader["CommunityId"].ToString();
                    ddlCommunity.Items.Add(new ListItem(communityName, communityId));
                }
            }
        }



        protected void ddlCommunity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCasteDropDown();
        }

        private void BindCasteDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT CasteName, CommunityName FROM Caste WHERE CommunityName = @CommunityName";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CommunityName", ddlCommunity.SelectedValue.Trim());
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCaste.Items.Clear();

                ddlCaste.Items.Add(new ListItem("-- Select Caste --", ""));

                while (reader.Read())
                {
                    string casteName = reader["CasteName"].ToString().Trim();
                   
                    ddlCaste.Items.Add(new ListItem(casteName, casteName));
                }
            }
        }


        protected void BindDistrictDropDown()
        {

            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT DistrictName FROM District ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string district = reader["DistrictName"].ToString().Trim();
                    ddlDistrict.Items.Add(new ListItem(district));
                }
            }
        }





    }
}