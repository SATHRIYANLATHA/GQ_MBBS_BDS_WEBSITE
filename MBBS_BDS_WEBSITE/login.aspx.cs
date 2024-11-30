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
    public partial class login : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Clear();
          
            try
            {

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM UserRegister where LoginId = '" + txtuserid.Text.Trim() + "' and UserPassword='" + txtPassword.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // Response.Write("<script> alert('login successfulllllll') </script>");
                            Session["UserName"] = dr.GetValue(0).ToString();
                            Session["DateOfBirth"] = dr.GetValue(4).ToString();
                            Session["HSCRollNumber"] = dr.GetValue(6).ToString();
                            Session["YearOfPassing"] = dr.GetValue(9).ToString();
                            Session["NEETRollNumber"] = dr.GetValue(7).ToString();
                            Session["Gender"] = dr.GetValue(2).ToString();
                            Session["LoginId"] = dr.GetValue(11).ToString();
                        }

                        userstatus();

                        // redirection according to the USER STATUS


                        redirection();

                    }
                    else
                    {
                        erroruseridpassword.InnerHtml = "invalid userid or password...!";
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void userstatus()
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

                    if (currentPageStatus == -1)
                    {
                        query = "INSERT INTO UserProgress (LoginId, PageStatus) VALUES (@LoginId, 0)";
                    }
                    else if (currentPageStatus == 0)
                    {
                        query = "UPDATE UserProgress SET PageStatus = 0 WHERE LoginId = @LoginId";

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



        protected void redirection()
        {
            try
            {
                string loginId = Session["LoginId"] as string;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT PageStatus FROM UserProgress where LoginId =@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (Convert.ToInt32(dr["PageStatus"]) == 0)
                            {
                                Response.Redirect("pinfo.aspx");
                            }
                            else if (Convert.ToInt32(dr["PageStatus"]) == 1)
                            {

                                Session["PersonalInformationComplete"] = true;

                                Response.Redirect("pinfo.aspx");

                            }
                            else if (Convert.ToInt32(dr["PageStatus"]) == 2)
                            {

                                Session["PersonalInformationComplete"] = true;
                                Session["SpecialReservationComplete"] = true;

                                Response.Redirect("pinfo.aspx");

                            }
                            else if (Convert.ToInt32(dr["PageStatus"]) == 3)
                            {

                                Session["PersonalInformationComplete"] = true;
                                Session["SpecialReservationComplete"] = true;
                                Session["AcademicAndSchoolingComplete"] = true;

                                Response.Redirect("pinfo.aspx");

                            }
                            else if (Convert.ToInt32(dr["PageStatus"]) == 4)
                            {

                                Session["PersonalInformationComplete"] = true;
                                Session["SpecialReservationComplete"] = true;
                                Session["AcademicAndSchoolingComplete"] = true;
                                Session["AdditionalInformationComplete"] = true;

                                Response.Redirect("pinfo.aspx");

                            }
                            else if (Convert.ToInt32(dr["PageStatus"]) == 5)
                            {

                                Session["PersonalInformationComplete"] = true;
                                Session["SpecialReservationComplete"] = true;
                                Session["AcademicAndSchoolingComplete"] = true;
                                Session["AdditionalInformationComplete"] = true;
                                Session["DocumentsUploadComplete"] = true;

                                Response.Redirect("pinfo.aspx");

                            }
                            else if (Convert.ToInt32(dr["PageStatus"]) == 6)
                            {

                                Session["PersonalInformationComplete"] = true;
                                Session["SpecialReservationComplete"] = true;
                                Session["AcademicAndSchoolingComplete"] = true;
                                Session["AdditionalInformationComplete"] = true;
                                Session["DocumentsUploadComplete"] = true;
                                Session["ApplicationPreviewComplete"] = true;

                                Response.Redirect("pinfo.aspx");

                            }
                            else if (Convert.ToInt32(dr["PageStatus"]) == 7)
                            {

                                Session["PersonalInformationComplete"] = true;
                                Session["SpecialReservationComplete"] = true;
                                Session["AcademicAndSchoolingComplete"] = true;
                                Session["AdditionalInformationComplete"] = true;
                                Session["DocumentsUploadComplete"] = true;
                                Session["ApplicationPreviewComplete"] = true;
                                Session["ApplicationSubmit"] = true;
                                Session["ApplicationAlreadySubmitted"] = true;

                                Response.Redirect("apppreview.aspx");

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





    }
}