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
    public partial class hello : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            String loginId = Session["LoginId"] as string;

            load_session_one(loginId);
            load_session_two(loginId);

            load_1_5(loginId);
            load_6_12(loginId);
            load_13_17(loginId);
            load_18_22(loginId);

            load_physics_chemistry(loginId);
            load_botany_zoology(loginId);
            load_biology_mathematics(loginId);
            loadstudydetails(loginId);

            load_23_32(loginId);
            load_image(loginId);



            if (Session["CHECKBOXONE"] != null && (bool)Session["CHECKBOXONE"] == true)
            {
                BOTANY.Visible = true;
                ZOOLOGY.Visible = true;
            }
            else
            {
                BOTANY.Visible = false;
                ZOOLOGY.Visible = false;
            }

            if (Session["CHECKBOXTWO"] != null && (bool)Session["CHECKBOXTWO"] == true)
            {
                BIOLOGY.Visible = true;
                MATHSOTHERS.Visible = true;
            }
            else
            {
                BIOLOGY.Visible = false;
                MATHSOTHERS.Visible = false;
            }


        }

        protected void load_session_one(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM BotanyZoology WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            //   checkbox1.Checked = Convert.ToBoolean(dr["CHECKBOX1"]);

                            if (Convert.ToBoolean(dr["CHECKBOX1"]) == true)
                            {
                                Session["CHECKBOXONE"] = true;
                            }
                            else
                            {
                                Session["CHECKBOXONE"] = false;
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

        protected void load_session_two(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM BiologyMathsOthers WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            //   checkbox1.Checked = Convert.ToBoolean(dr["CHECKBOX1"]);

                            if (Convert.ToBoolean(dr["CHECKBOX2"]) == true)
                            {
                                Session["CHECKBOXTWO"] = true;
                            }
                            else
                            {
                                Session["CHECKBOXTWO"] = false;
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
        protected void load_1_5(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM UserRegister WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            app1a.InnerHtml = dr["HSCRollNumber"].ToString().Trim();
                            app1b.InnerHtml = dr["QualifiedYear"].ToString().Trim();
                            app2.InnerHtml = dr["UserName"].ToString().Trim();
                            app4.InnerHtml = dr["DateOfBirth"].ToString().Trim();
                            app5.InnerHtml = dr["Gender"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void load_6_12(string loginId)
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

                            app3.InnerHtml = dr["NameOfTheParent"].ToString().Trim();
                            app6.InnerHtml = dr["Nationality"].ToString().Trim();
                            app7.InnerHtml = dr["Religion"].ToString().Trim();
                            app8.InnerHtml = dr["MotherTongue"].ToString().Trim();
                            app9.InnerHtml = dr["Nativity"].ToString().Trim();
                            app10.InnerHtml = dr["SchoolingStudied"].ToString().Trim();
                            app11.InnerHtml = dr["Community"].ToString().Trim();
                            app12.InnerHtml = dr["CasteWithSubCode"].ToString().Trim();
                            app12a.InnerHtml = dr["CertificateNumber"].ToString().Trim();
                            app12b.InnerHtml = dr["IssuedTaluk"].ToString().Trim();
                            app12c.InnerHtml = dr["IssuedBy"].ToString().Trim();
                            app12d.InnerHtml = dr["IssuedDate"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }



        protected void load_13_17(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM SpecialReservation WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            app13a.InnerHtml = dr["EXservicemen"].ToString().Trim();
                            app13b.InnerHtml = dr["DifferentlyAbledPerson"].ToString().Trim();
                            app14.InnerHtml = dr["QualifyingExamination"].ToString().Trim();
                            app15.InnerHtml = dr["HSCgroupcode"].ToString().Trim();
                            app16.InnerHtml = dr["BoardOfExamination"].ToString().Trim();
                            app17.InnerHtml = dr["CoursesUndergoingCompleted"].ToString().Trim();

                            if (dr["NameOfTheCourse"].ToString().Trim() == "Others")
                            {
                                app17a.InnerHtml = dr["NameOfTheOtherCourse"].ToString().Trim();
                            }
                            else
                            {
                                app17a.InnerHtml = dr["NameOfTheCourse"].ToString().Trim();
                            }

                            app17b.InnerHtml = dr["YearOfCompletion"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void load_18_22(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM AcademicAndSchooling WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            app18.InnerHtml = dr["NumberOfHSCAttempt"].ToString().Trim();
                            app20.InnerHtml = dr["MediumOfInstruction"].ToString().Trim();
                            app21.InnerHtml = dr["CivicSchool"].ToString().Trim();
                            app22.InnerHtml = dr["CivicNative"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }



        protected void load_physics_chemistry(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM PhysicsChemistry WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            phy.InnerHtml = dr["PHYSICSSUBJECT"].ToString().Trim();
                            rnphy.InnerHtml = dr["RNPHY"].ToString().Trim();
                            mopphy.InnerHtml = dr["MOPPHY"].ToString().Trim();
                            yopphy.InnerHtml = dr["YOPPHY"].ToString().Trim();
                            maxphy.InnerHtml = dr["MAXMARKSPHY"].ToString().Trim();
                            obtphy.InnerHtml = dr["OBTMARKSPHY"].ToString().Trim();

                            che.InnerHtml = dr["CHEMISTRYSUBJECT"].ToString().Trim();
                            rnche.InnerHtml = dr["RNCHE"].ToString().Trim();
                            mopche.InnerHtml = dr["MOPCHE"].ToString().Trim();
                            yopche.InnerHtml = dr["YOPCHE"].ToString().Trim();
                            maxche.InnerHtml = dr["MAXMARKSCHE"].ToString().Trim();
                            obtche.InnerHtml = dr["OBTMARKSCHE"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }



        protected void load_botany_zoology(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM BotanyZoology WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bot.InnerHtml = dr["BOTANYSUBJECT"].ToString().Trim();
                            rnbot.InnerHtml = dr["RNBOT"].ToString().Trim();
                            mopbot.InnerHtml = dr["MOPBOT"].ToString().Trim();
                            yopbot.InnerHtml = dr["YOPBOT"].ToString().Trim();
                            maxbot.InnerHtml = dr["MAXMARKSBOT"].ToString().Trim();
                            obtbot.InnerHtml = dr["OBTMARKSBOT"].ToString().Trim();

                            zoo.InnerHtml = dr["ZOOLOGYSUBJECT"].ToString().Trim();
                            rnzoo.InnerHtml = dr["RNZOO"].ToString().Trim();
                            mopzoo.InnerHtml = dr["MOPZOO"].ToString().Trim();
                            yopzoo.InnerHtml = dr["YOPZOO"].ToString().Trim();
                            maxzoo.InnerHtml = dr["MAXMARKSZOO"].ToString().Trim();
                            obtzoo.InnerHtml = dr["OBTMARKSZOO"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void load_biology_mathematics(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM BiologyMathsOthers WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bio.InnerHtml = dr["BIOLOGYSUBJECT"].ToString().Trim();
                            rnbio.InnerHtml = dr["RNBIO"].ToString().Trim();
                            mopbio.InnerHtml = dr["MOPBIO"].ToString().Trim();
                            yopbio.InnerHtml = dr["YOPBIO"].ToString().Trim();
                            maxbio.InnerHtml = dr["MAXMARKSBIO"].ToString().Trim();
                            obtbio.InnerHtml = dr["OBTMARKSBIO"].ToString().Trim();

                            matoth.InnerHtml = dr["MATHSOTHERSSUBJECT"].ToString().Trim();
                            rnmatoth.InnerHtml = dr["RNMATOTH"].ToString().Trim();
                            mopmatoth.InnerHtml = dr["MOPMATOTH"].ToString().Trim();
                            yopmatoth.InnerHtml = dr["YOPMATOTH"].ToString().Trim();
                            maxmatoth.InnerHtml = dr["MAXMARKSMATOTH"].ToString().Trim();
                            obtmatoth.InnerHtml = dr["OBTMARKSMATOTH"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void loadstudydetails(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM StudyDetails WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            yop6.InnerHtml = dr["YOP6"].ToString().Trim();
                            nots6.InnerHtml = dr["NOTS6"].ToString().Trim();
                            s6.InnerHtml = dr["STATE6"].ToString().Trim();
                            d6.InnerHtml = dr["DISTRICT6"].ToString().Trim();

                            yop7.InnerHtml = dr["YOP7"].ToString().Trim();
                            nots7.InnerHtml = dr["NOTS7"].ToString().Trim();
                            s7.InnerHtml = dr["STATE7"].ToString().Trim();
                            d7.InnerHtml = dr["DISTRICT7"].ToString().Trim();

                            yop8.InnerHtml = dr["YOP8"].ToString().Trim();
                            nots8.InnerHtml = dr["NOTS8"].ToString().Trim();
                            s8.InnerHtml = dr["STATE8"].ToString().Trim();
                            d8.InnerHtml = dr["DISTRICT8"].ToString().Trim();

                            yop9.InnerHtml = dr["YOP9"].ToString().Trim();
                            nots9.InnerHtml = dr["NOTS9"].ToString().Trim();
                            s9.InnerHtml = dr["STATE9"].ToString().Trim();
                            d9.InnerHtml = dr["DISTRICT9"].ToString().Trim();

                            yop10.InnerHtml = dr["YOP10"].ToString().Trim();
                            nots10.InnerHtml = dr["NOTS10"].ToString().Trim();
                            s10.InnerHtml = dr["STATE10"].ToString().Trim();
                            d10.InnerHtml = dr["DISTRICT10"].ToString().Trim();

                            yop11.InnerHtml = dr["YOP11"].ToString().Trim();
                            nots11.InnerHtml = dr["NOTS11"].ToString().Trim();
                            s11.InnerHtml = dr["STATE11"].ToString().Trim();
                            d11.InnerHtml = dr["DISTRICT11"].ToString().Trim();

                            yop12.InnerHtml = dr["YOP12"].ToString().Trim();
                            nots12.InnerHtml = dr["NOTS12"].ToString().Trim();
                            s12.InnerHtml = dr["STATE12"].ToString().Trim();
                            d12.InnerHtml = dr["DISTRICT12"].ToString().Trim();




                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void load_23_32(string loginId)
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

                            app23.InnerHtml = dr["FGApplicant"].ToString().Trim();
                            app24.InnerHtml = dr["ParentOccupation"].ToString().Trim();
                            app25.InnerHtml = dr["ParentAnnualIncome"].ToString().Trim();
                            app26.InnerHtml = dr["AddressForCorrespondence"].ToString().Trim();
                            app27.InnerHtml = dr["NativeDistrict"].ToString().Trim();
                            app28.InnerHtml = dr["NativeState"].ToString().Trim();
                            app29.InnerHtml = dr["IdentificationMarks"].ToString().Trim();
                            app30.InnerHtml = dr["AadharNumber"].ToString().Trim();
                            app31.InnerHtml = dr["EmailId"].ToString().Trim();
                            app32.InnerHtml = dr["PhoneNumber"].ToString().Trim();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void load_image(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT PathOfTheFile FROM PassPortSizePhotoFilesUpload WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    string imagePath = cmd.ExecuteScalar() as string;
                    con.Close();

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        userimage.Src = ResolveUrl(imagePath); // Set the image `src` attribute
                    }
                    else
                    {
                        userimage.Src = ResolveUrl("~/pictures/logo1.png"); // Set a default image if no file found
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