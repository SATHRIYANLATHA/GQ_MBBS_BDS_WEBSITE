
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
    public partial class sos : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["DBConnMbbsGovt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMediumOfInstructionDropDown(); // dropdown for medium of instruction
                BindCivicSchoolDropDown(); // dropdown for civic school
                BindCivicNativeDropDown(); // dropdown for civic native

                BindMaxMarksDropDown(); // DROPDOWN FOR MAX MARKS 
                BindMonthsDropDown(); // DROPDOWN FOR MONTHS

                BindStateDropDown(STATE6); // dropdown for states
                BindStateDropDown(STATE7);
                BindStateDropDown(STATE8);
                BindStateDropDown(STATE9);
                BindStateDropDown(STATE10);
                BindStateDropDown(STATE11);
                BindStateDropDown(STATE12);
                BindStateDropDown(STATEneet);



                String loginId = Session["LoginId"] as string;
                loadotherdetails(loginId);
                loadstudydetails(loginId);
                loadStudentMarkDetails(loginId);
                //loadphysicschemistry(loginId);
                //loadbotanyzoology(loginId);
                //loadbiologymathsothers(loginId);

                if (Session["LoginId"] == null)
                {
                    Response.Redirect("error.aspx");
                }


            }
        }


      



        protected void loadotherdetails(string loginId)
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

                            if (ddlNumberOfAttempts.Items.FindByValue(dr["NumberOfHSCAttempt"].ToString().Trim()) != null)
                            {
                                ddlNumberOfAttempts.SelectedValue = dr["NumberOfHSCAttempt"].ToString().Trim();
                            }


                            if (ddlMediumOfInstruction.Items.FindByValue(dr["MediumOfInstruction"].ToString().Trim()) != null)
                            {
                                ddlMediumOfInstruction.SelectedValue = dr["MediumOfInstruction"].ToString().Trim();
                            }


                            if (ddlCivicSchool.Items.FindByValue(dr["CivicSchool"].ToString().Trim()) != null)
                            {
                                ddlCivicSchool.SelectedValue = dr["CivicSchool"].ToString().Trim();
                            }


                            if (ddlCivicNative.Items.FindByValue(dr["CivicNative"].ToString().Trim()) != null)
                            {
                                ddlCivicNative.SelectedValue = dr["CivicNative"].ToString().Trim();
                            }


                            if (NEETATTEMPT.Items.FindByValue(dr["NumberOfNEETAttempt"].ToString().Trim()) != null)
                            {
                                NEETATTEMPT.SelectedValue = dr["NumberOfNEETAttempt"].ToString().Trim();
                            }



                            if (NeetCoachingOptions.Items.FindByValue(dr["NEETCoaching"].ToString().Trim()) != null)
                            {
                                NeetCoachingOptions.SelectedValue = dr["NEETCoaching"].ToString().Trim();
                            }


                            if (STATEneet.Items.FindByValue(dr["NEETstate"].ToString().Trim()) != null)
                            {
                                STATEneet.SelectedValue = dr["NEETstate"].ToString().Trim();
                            }

                            neetaddress.Text = dr["NEETaddress"].ToString().Trim();

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

                            // .................. 6 ..............

                            YOP6.Value = dr["YOP6"].ToString().Trim();

                            NOTS6.Value = dr["NOTS6"].ToString().Trim();

                            if (STATE6.Items.FindByValue(dr["STATE6"].ToString().Trim()) != null)
                            {
                                STATE6.SelectedValue = dr["STATE6"].ToString().Trim();
                            }

                            string district6Value = dr["DISTRICT6"].ToString().Trim();
                            HiddenDistrict6.Value = district6Value; // Set the value in the hidden field




                            // .................. 7 ..............

                            YOP7.Value = dr["YOP7"].ToString().Trim();

                            NOTS7.Value = dr["NOTS7"].ToString().Trim();

                            if (STATE7.Items.FindByValue(dr["STATE7"].ToString().Trim()) != null)
                            {
                                STATE7.SelectedValue = dr["STATE7"].ToString().Trim();
                            }


                            string district7Value = dr["DISTRICT7"].ToString().Trim();
                            HiddenDistrict7.Value = district7Value;


                            // .................. 8 ..............

                            YOP8.Value = dr["YOP8"].ToString().Trim();

                            NOTS8.Value = dr["NOTS8"].ToString().Trim();

                            if (STATE8.Items.FindByValue(dr["STATE8"].ToString().Trim()) != null)
                            {
                                STATE8.SelectedValue = dr["STATE8"].ToString().Trim();
                            }

                            string district8Value = dr["DISTRICT8"].ToString().Trim();
                            HiddenDistrict8.Value = district8Value;


                            // .................. 9 ..............

                            YOP9.Value = dr["YOP9"].ToString().Trim();

                            NOTS9.Value = dr["NOTS9"].ToString().Trim();

                            if (STATE9.Items.FindByValue(dr["STATE9"].ToString().Trim()) != null)
                            {
                                STATE9.SelectedValue = dr["STATE9"].ToString().Trim();
                            }

                            string district9Value = dr["DISTRICT9"].ToString().Trim();
                            HiddenDistrict9.Value = district9Value;


                            // .................. 10 ..............

                            YOP10.Value = dr["YOP10"].ToString().Trim();

                            NOTS10.Value = dr["NOTS10"].ToString().Trim();

                            if (STATE10.Items.FindByValue(dr["STATE10"].ToString().Trim()) != null)
                            {
                                STATE10.SelectedValue = dr["STATE10"].ToString().Trim();
                            }

                            string district10Value = dr["DISTRICT10"].ToString().Trim();
                            HiddenDistrict10.Value = district10Value;

                            // .................. 11 ..............

                            YOP11.Value = dr["YOP11"].ToString().Trim();

                            NOTS11.Value = dr["NOTS11"].ToString().Trim();

                            if (STATE11.Items.FindByValue(dr["STATE11"].ToString().Trim()) != null)
                            {
                                STATE11.SelectedValue = dr["STATE11"].ToString().Trim();
                            }

                            string district11Value = dr["DISTRICT11"].ToString().Trim();
                            HiddenDistrict11.Value = district11Value;


                            // .................. 12 ..............

                            YOP12.Value = dr["YOP12"].ToString().Trim();

                            NOTS12.Value = dr["NOTS12"].ToString().Trim();

                            if (STATE12.Items.FindByValue(dr["STATE12"].ToString().Trim()) != null)
                            {
                                STATE12.SelectedValue = dr["STATE12"].ToString().Trim();
                            }

                            string district12Value = dr["DISTRICT12"].ToString().Trim();
                            HiddenDistrict12.Value = district12Value;

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        //protected void loadphysicschemistry(string loginId)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(strcon))
        //        {
        //            string query = "SELECT * FROM PhysicsChemistry WHERE LoginId=@LoginId";
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.AddWithValue("@LoginId", loginId);

        //            con.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();

        //            if (dr.HasRows)
        //            {
        //                while (dr.Read())
        //                {

        //                    // PHYSICS .......

        //                    PHYSICSSUBJECT.InnerHtml = dr["PHYSICSSUBJECT"].ToString().Trim();

        //                    RNPHY.Value = dr["RNPHY"].ToString().Trim();

        //                    if (MOPPHY.Items.FindByValue(dr["MOPPHY"].ToString().Trim()) != null)
        //                    {
        //                        MOPPHY.SelectedValue = dr["MOPPHY"].ToString().Trim();
        //                    }

        //                    YOPPHY.Value = dr["YOPPHY"].ToString().Trim();

        //                    if (MAXMARKSPHY.Items.FindByValue(dr["MAXMARKSPHY"].ToString().Trim()) != null)
        //                    {
        //                        MAXMARKSPHY.SelectedValue = dr["MAXMARKSPHY"].ToString().Trim();
        //                    }

        //                    OBTMARKSPHY.Value = dr["OBTMARKSPHY"].ToString().Trim();


        //                    // CHEMISTRY.......

        //                    CHEMISTRYSUBJECT.InnerHtml = dr["CHEMISTRYSUBJECT"].ToString().Trim();

        //                    RNCHE.Value = dr["RNCHE"].ToString().Trim();

        //                    if (MOPCHE.Items.FindByValue(dr["MOPCHE"].ToString().Trim()) != null)
        //                    {
        //                        MOPCHE.SelectedValue = dr["MOPCHE"].ToString().Trim();
        //                    }

        //                    YOPCHE.Value = dr["YOPCHE"].ToString().Trim();

        //                    if (MAXMARKSCHE.Items.FindByValue(dr["MAXMARKSCHE"].ToString().Trim()) != null)
        //                    {
        //                        MAXMARKSCHE.SelectedValue = dr["MAXMARKSCHE"].ToString().Trim();
        //                    }

        //                    OBTMARKSCHE.Value = dr["OBTMARKSCHE"].ToString().Trim();


        //                }
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert('" + ex.Message + "') </script>");
        //    }
        //}

        //protected void loadbotanyzoology(string loginId)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(strcon))
        //        {
        //            string query = "SELECT * FROM BotanyZoology WHERE LoginId=@LoginId";
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.AddWithValue("@LoginId", loginId);

        //            con.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();

        //            if (dr.HasRows)
        //            {
        //                while (dr.Read())
        //                {

        //                    checkbox1.Checked = Convert.ToBoolean(dr["CHECKBOX1"]);

        //                    // PHYSICS .......


        //                    BOTANYSUBJECT.InnerHtml = dr["BOTANYSUBJECT"].ToString().Trim();

        //                    RNBOT.Value = dr["RNBOT"].ToString().Trim();

        //                    if (MOPBOT.Items.FindByValue(dr["MOPBOT"].ToString().Trim()) != null)
        //                    {
        //                        MOPBOT.SelectedValue = dr["MOPBOT"].ToString().Trim();
        //                    }

        //                    YOPBOT.Value = dr["YOPBOT"].ToString().Trim();

        //                    if (MAXMARKSBOT.Items.FindByValue(dr["MAXMARKSBOT"].ToString().Trim()) != null)
        //                    {
        //                        MAXMARKSBOT.SelectedValue = dr["MAXMARKSBOT"].ToString().Trim();
        //                    }

        //                    OBTMARKSBOT.Value = dr["OBTMARKSBOT"].ToString().Trim();




        //                    // CHEMISTRY.......

        //                    ZOOLOGYSUBJECT.InnerHtml = dr["ZOOLOGYSUBJECT"].ToString().Trim();

        //                    RNZOO.Value = dr["RNZOO"].ToString().Trim();

        //                    if (MOPZOO.Items.FindByValue(dr["MOPZOO"].ToString().Trim()) != null)
        //                    {
        //                        MOPZOO.SelectedValue = dr["MOPZOO"].ToString().Trim();
        //                    }

        //                    YOPZOO.Value = dr["YOPZOO"].ToString().Trim();

        //                    if (MAXMARKSZOO.Items.FindByValue(dr["MAXMARKSZOO"].ToString().Trim()) != null)
        //                    {
        //                        MAXMARKSZOO.SelectedValue = dr["MAXMARKSZOO"].ToString().Trim();
        //                    }

        //                    OBTMARKSZOO.Value = dr["OBTMARKSZOO"].ToString().Trim();


        //                }
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert('" + ex.Message + "') </script>");
        //    }
        //}

        //protected void loadbiologymathsothers(string loginId)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(strcon))
        //        {
        //            string query = "SELECT * FROM BiologyMathsOthers WHERE LoginId=@LoginId";
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.AddWithValue("@LoginId", loginId);

        //            con.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();

        //            if (dr.HasRows)
        //            {
        //                while (dr.Read())
        //                {

        //                    checkbox2.Checked = Convert.ToBoolean(dr["CHECKBOX2"]);

        //                    // PHYSICS .......


        //                    BIOLOGYSUBJECT.InnerHtml = dr["BIOLOGYSUBJECT"].ToString().Trim();

        //                    RNBIO.Value = dr["RNBIO"].ToString().Trim();

        //                    if (MOPBIO.Items.FindByValue(dr["MOPBIO"].ToString().Trim()) != null)
        //                    {
        //                        MOPBIO.SelectedValue = dr["MOPBIO"].ToString().Trim();
        //                    }

        //                    YOPBIO.Value = dr["YOPBIO"].ToString().Trim();

        //                    if (MAXMARKSBIO.Items.FindByValue(dr["MAXMARKSBIO"].ToString().Trim()) != null)
        //                    {
        //                        MAXMARKSBIO.SelectedValue = dr["MAXMARKSBIO"].ToString().Trim();
        //                    }

        //                    OBTMARKSBIO.Value = dr["OBTMARKSBIO"].ToString().Trim();




        //                    // CHEMISTRY.......

        //                    if (MATHSOTHERSSUBJECT.Items.FindByValue(dr["MATHSOTHERSSUBJECT"].ToString().Trim()) != null)
        //                    {
        //                        MATHSOTHERSSUBJECT.SelectedValue = dr["MATHSOTHERSSUBJECT"].ToString().Trim();
        //                    }

        //                    RNMATOTH.Value = dr["RNMATOTH"].ToString().Trim();

        //                    if (MOPMATOTH.Items.FindByValue(dr["MOPMATOTH"].ToString().Trim()) != null)
        //                    {
        //                        MOPMATOTH.SelectedValue = dr["MOPMATOTH"].ToString().Trim();
        //                    }

        //                    YOPMATOTH.Value = dr["YOPMATOTH"].ToString().Trim();

        //                    if (MAXMARKSMATOTH.Items.FindByValue(dr["MAXMARKSMATOTH"].ToString().Trim()) != null)
        //                    {
        //                        MAXMARKSMATOTH.SelectedValue = dr["MAXMARKSMATOTH"].ToString().Trim();
        //                    }

        //                    OBTMARKSMATOTH.Value = dr["OBTMARKSMATOTH"].ToString().Trim();


        //                }
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert('" + ex.Message + "') </script>");
        //    }
        //}


        protected void loadStudentMarkDetails(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM StudentMarkDetails WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            // PHYSICS .......

                            PHYSICSSUBJECT.InnerHtml = dr["PHYSICSSUBJECT"].ToString().Trim();

                            RNPHY.Value = dr["RNPHY"].ToString().Trim();

                            if (MOPPHY.Items.FindByValue(dr["MOPPHY"].ToString().Trim()) != null)
                            {
                                MOPPHY.SelectedValue = dr["MOPPHY"].ToString().Trim();
                            }

                            YOPPHY.Value = dr["YOPPHY"].ToString().Trim();

                            if (MAXMARKSPHY.Items.FindByValue(dr["MAXMARKSPHY"].ToString().Trim()) != null)
                            {
                                MAXMARKSPHY.SelectedValue = dr["MAXMARKSPHY"].ToString().Trim();
                            }


                            OBTMARKSPHY.Value = Convert.ToInt32(dr["OBTMARKSPHY"]).ToString();
                           
                            double dchk;
                            int ichk;
                            dchk = Convert.ToDouble(dr["OBTMARKSPHY"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                OBTMARKSPHY.Value = Convert.ToInt32(dr["OBTMARKSPHY"]).ToString();
                            else
                                OBTMARKSPHY.Value = Convert.ToDecimal(dr["OBTMARKSPHY"]).ToString();


                            // CHEMISTRY.......

                            CHEMISTRYSUBJECT.InnerHtml = dr["CHEMISTRYSUBJECT"].ToString().Trim();

                            RNCHE.Value = dr["RNCHE"].ToString().Trim();

                            if (MOPCHE.Items.FindByValue(dr["MOPCHE"].ToString().Trim()) != null)
                            {
                                MOPCHE.SelectedValue = dr["MOPCHE"].ToString().Trim();
                            }

                            YOPCHE.Value = dr["YOPCHE"].ToString().Trim();

                            if (MAXMARKSCHE.Items.FindByValue(dr["MAXMARKSCHE"].ToString().Trim()) != null)
                            {
                                MAXMARKSCHE.SelectedValue = dr["MAXMARKSCHE"].ToString().Trim();
                            }

                            OBTMARKSCHE.Value = Convert.ToInt32(dr["OBTMARKSCHE"]).ToString();
                            
                             
                            dchk = Convert.ToDouble(dr["OBTMARKSCHE"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                OBTMARKSCHE.Value = Convert.ToInt32(dr["OBTMARKSCHE"]).ToString();
                            else
                                OBTMARKSCHE.Value = Convert.ToDecimal(dr["OBTMARKSCHE"]).ToString();


                            checkbox1.Checked = Convert.ToBoolean(dr["CHECKBOX1"]);

                            // PHYSICS .......


                            BOTANYSUBJECT.InnerHtml = dr["BOTANYSUBJECT"].ToString().Trim();

                            RNBOT.Value = dr["RNBOT"].ToString().Trim();

                            if (MOPBOT.Items.FindByValue(dr["MOPBOT"].ToString().Trim()) != null)
                            {
                                MOPBOT.SelectedValue = dr["MOPBOT"].ToString().Trim();
                            }

                            YOPBOT.Value = dr["YOPBOT"].ToString().Trim();

                            if (MAXMARKSBOT.Items.FindByValue(dr["MAXMARKSBOT"].ToString().Trim()) != null)
                            {
                                MAXMARKSBOT.SelectedValue = dr["MAXMARKSBOT"].ToString().Trim();
                            }

                            OBTMARKSBOT.Value = Convert.ToInt32(dr["OBTMARKSBOT"]).ToString();

                            dchk = Convert.ToDouble(dr["OBTMARKSBOT"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                OBTMARKSBOT.Value = Convert.ToInt32(dr["OBTMARKSBOT"]).ToString();
                            else
                                OBTMARKSBOT.Value = Convert.ToDecimal(dr["OBTMARKSBOT"]).ToString();



                            // CHEMISTRY.......

                            ZOOLOGYSUBJECT.InnerHtml = dr["ZOOLOGYSUBJECT"].ToString().Trim();

                            RNZOO.Value = dr["RNZOO"].ToString().Trim();

                            if (MOPZOO.Items.FindByValue(dr["MOPZOO"].ToString().Trim()) != null)
                            {
                                MOPZOO.SelectedValue = dr["MOPZOO"].ToString().Trim();
                            }

                            YOPZOO.Value = dr["YOPZOO"].ToString().Trim();

                            if (MAXMARKSZOO.Items.FindByValue(dr["MAXMARKSZOO"].ToString().Trim()) != null)
                            {
                                MAXMARKSZOO.SelectedValue = dr["MAXMARKSZOO"].ToString().Trim();
                            }

                            OBTMARKSZOO.Value = Convert.ToInt32(dr["OBTMARKSZOO"]).ToString();
                            dchk = Convert.ToDouble(dr["OBTMARKSZOO"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                OBTMARKSZOO.Value = Convert.ToInt32(dr["OBTMARKSZOO"]).ToString();
                            else
                                OBTMARKSZOO.Value = Convert.ToDecimal(dr["OBTMARKSZOO"]).ToString();



                            checkbox2.Checked = Convert.ToBoolean(dr["CHECKBOX2"]);

                            // PHYSICS .......


                            BIOLOGYSUBJECT.InnerHtml = dr["BIOLOGYSUBJECT"].ToString().Trim();

                            RNBIO.Value = dr["RNBIO"].ToString().Trim();

                            if (MOPBIO.Items.FindByValue(dr["MOPBIO"].ToString().Trim()) != null)
                            {
                                MOPBIO.SelectedValue = dr["MOPBIO"].ToString().Trim();
                            }

                            YOPBIO.Value = dr["YOPBIO"].ToString().Trim();

                            if (MAXMARKSBIO.Items.FindByValue(dr["MAXMARKSBIO"].ToString().Trim()) != null)
                            {
                                MAXMARKSBIO.SelectedValue = dr["MAXMARKSBIO"].ToString().Trim();
                            }

                            OBTMARKSBIO.Value = Convert.ToInt32(dr["OBTMARKSBIO"]).ToString();
                            dchk = Convert.ToDouble(dr["OBTMARKSBIO"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                OBTMARKSBIO.Value = Convert.ToInt32(dr["OBTMARKSBIO"]).ToString();
                            else
                                OBTMARKSBIO.Value = Convert.ToDecimal(dr["OBTMARKSBIO"]).ToString();




                            // CHEMISTRY.......

                            if (MATHSOTHERSSUBJECT.Items.FindByValue(dr["MATHSOTHERSSUBJECT"].ToString().Trim()) != null)
                            {
                                MATHSOTHERSSUBJECT.SelectedValue = dr["MATHSOTHERSSUBJECT"].ToString().Trim();
                            }

                            RNMATOTH.Value = dr["RNMATOTH"].ToString().Trim();

                            if (MOPMATOTH.Items.FindByValue(dr["MOPMATOTH"].ToString().Trim()) != null)
                            {
                                MOPMATOTH.SelectedValue = dr["MOPMATOTH"].ToString().Trim();
                            }

                            YOPMATOTH.Value = dr["YOPMATOTH"].ToString().Trim();

                            if (MAXMARKSMATOTH.Items.FindByValue(dr["MAXMARKSMATOTH"].ToString().Trim()) != null)
                            {
                                MAXMARKSMATOTH.SelectedValue = dr["MAXMARKSMATOTH"].ToString().Trim();
                            }

                            OBTMARKSMATOTH.Value = Convert.ToInt32(dr["OBTMARKSMATOTH"]).ToString();
                            dchk = Convert.ToDouble(dr["OBTMARKSMATOTH"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                OBTMARKSMATOTH.Value = Convert.ToInt32(dr["OBTMARKSMATOTH"]).ToString();
                            else
                                OBTMARKSMATOTH.Value = Convert.ToDecimal(dr["OBTMARKSMATOTH"]).ToString();



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
            OtherDetails();
            StudyDetails();

            try
            {
                StudentMarkDetails();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }

            Session["AcademicAndSchoolingComplete"] = true;

            setuserstatus();

            Response.Redirect("addinfo.aspx");

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

                    if (currentPageStatus <= 3)
                    {
                        query = "UPDATE UserProgress SET PageStatus = 3 WHERE LoginId = @LoginId";

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

        protected void OtherDetails()
        {
            try
            {
                String LoginId = Session["LoginId"] as string;
                

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    String checkQuery = "SELECT COUNT(*) FROM AcademicAndSchooling where LoginId = @LoginId";
                    SqlCommand checkcmd = new SqlCommand(checkQuery, con);
                    checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    int count = Convert.ToInt32(checkcmd.ExecuteScalar());
                    con.Close();

                    string query;

                    if (count > 0)
                    {
                        query = "UPDATE AcademicAndSchooling SET NumberOfHSCAttempt=@NumberOfHSCAttempt,MediumOfInstruction=@MediumOfInstruction,CivicSchool=@CivicSchool,CivicNative=@CivicNative,NumberOfNEETAttempt=@NumberOfNEETAttempt,NEETCoaching=@NEETCoaching,NEETstate=@NEETstate,NEETaddress=@NEETaddress,GovtSchool=@GovtSchool,RTE=@RTE,ModifiedAt=getdate(), ModifiedUserID=@ModifiedUserID WHERE LoginId=@LoginId";
                    }
                    else
                    {
                        query = "INSERT INTO AcademicAndSchooling(LoginId,NumberOfHSCAttempt,MediumOfInstruction,CivicSchool,CivicNative,NumberOfNEETAttempt,NEETCoaching,NEETstate,NEETaddress,GovtSchool,RTE,ModifiedAt,ModifiedUserID) VALUES (@LoginId,@NumberOfHSCAttempt,@MediumOfInstruction,@CivicSchool,@CivicNative,@NumberOfNEETAttempt,@NEETCoaching,@NEETstate,@NEETaddress,@GovtSchool,@RTE,getdate(), @ModifiedUserID)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@LoginId", LoginId);
                    cmd.Parameters.AddWithValue("@NumberOfHSCAttempt", ddlNumberOfAttempts.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@GovtSchool", govtschooloptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@RTE", rteoptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@MediumOfInstruction", ddlMediumOfInstruction.SelectedValue);
                    cmd.Parameters.AddWithValue("@CivicSchool", ddlCivicSchool.SelectedValue);
                    cmd.Parameters.AddWithValue("@CivicNative", ddlCivicNative.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@NumberOfNEETAttempt", NEETATTEMPT.SelectedValue.Trim());

                    cmd.Parameters.AddWithValue("@NEETCoaching", NeetCoachingOptions.SelectedValue.Trim());

                    if(NeetCoachingOptions.SelectedValue.Trim() == "No")
                    {
                        STATEneet.SelectedValue = "";
                        neetaddress.Text = "";
                    }
                    cmd.Parameters.AddWithValue("@NEETstate", STATEneet.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@NEETaddress", neetaddress.Text.Trim());
                   
                    cmd.Parameters.AddWithValue("@ModifiedUserID", LoginId);



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                   



                }


            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void StudyDetails()
        {
            try
            {
                String LoginId = Session["LoginId"] as string;
               

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    String checkQuery = "SELECT COUNT(*) FROM StudyDetails where LoginId = @LoginId";
                    SqlCommand checkcmd = new SqlCommand(checkQuery, con);
                    checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    int count = Convert.ToInt32(checkcmd.ExecuteScalar());
                    con.Close();

                    string query;

                    if (count > 0)
                    {
                        query = "UPDATE StudyDetails SET YOP6=@YOP6,NOTS6=@NOTS6,STATE6=@STATE6,DISTRICT6=@DISTRICT6,YOP7=@YOP7,NOTS7=@NOTS7,STATE7=@STATE7,DISTRICT7=@DISTRICT7,YOP8=@YOP8,NOTS8=@NOTS8,STATE8=@STATE8,DISTRICT8=@DISTRICT8,YOP9=@YOP9,NOTS9=@NOTS9,STATE9=@STATE9,DISTRICT9=@DISTRICT9,YOP10=@YOP10,NOTS10=@NOTS10,STATE10=@STATE10,DISTRICT10=@DISTRICT10,YOP11=@YOP11,NOTS11=@NOTS11,STATE11=@STATE11,DISTRICT11=@DISTRICT11,YOP12=@YOP12,NOTS12=@NOTS12,STATE12=@STATE12,DISTRICT12=@DISTRICT12,ModifiedAt=getdate(),ModifiedUserID=@ModifiedUserID WHERE LoginId=@LoginId";
                    }
                    else
                    {
                        query = "INSERT INTO StudyDetails(LoginId,YOP6,NOTS6,STATE6,DISTRICT6,YOP7,NOTS7,STATE7,DISTRICT7,YOP8,NOTS8,STATE8,DISTRICT8,YOP9,NOTS9,STATE9,DISTRICT9,YOP10,NOTS10,STATE10,DISTRICT10,YOP11,NOTS11,STATE11,DISTRICT11,YOP12,NOTS12,STATE12,DISTRICT12,ModifiedAt,ModifiedUserID) VALUES(@LoginId,@YOP6,@NOTS6,@STATE6,@DISTRICT6,@YOP7,@NOTS7,@STATE7,@DISTRICT7,@YOP8,@NOTS8,@STATE8,@DISTRICT8,@YOP9,@NOTS9,@STATE9,@DISTRICT9,@YOP10,@NOTS10,@STATE10,@DISTRICT10,@YOP11,@NOTS11,@STATE11,@DISTRICT11,@YOP12,@NOTS12,@STATE12,@DISTRICT12,getdate(),@ModifiedUserID)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@LoginId", LoginId);

                    cmd.Parameters.AddWithValue("@YOP6", YOP6.Value.Trim());
                    cmd.Parameters.AddWithValue("@NOTS6", NOTS6.Value.Trim());
                    cmd.Parameters.AddWithValue("@STATE6", STATE6.SelectedValue.Trim());
                    string district6 = HiddenDistrict6.Value;  // Get the value from the hidden field

                    if (string.IsNullOrEmpty(district6))
                    {
                        Console.WriteLine("District6 is empty!");  // Log if it's empty
                    }
                    else
                    {
                        Console.WriteLine("District6 selected: " + district6);  // Log the selected district value
                    }

                    // Proceed with saving the district value to the database
                    cmd.Parameters.AddWithValue("@DISTRICT6", district6);




                    cmd.Parameters.AddWithValue("@YOP7", YOP7.Value.Trim());
                    cmd.Parameters.AddWithValue("@NOTS7", NOTS7.Value.Trim());
                    cmd.Parameters.AddWithValue("@STATE7", STATE7.SelectedValue.Trim());
                    string district7 = HiddenDistrict7.Value;  // Get the value from the hidden field

                    if (string.IsNullOrEmpty(district7))
                    {
                        Console.WriteLine("District7 is empty!");  // Log if it's empty
                    }
                    else
                    {
                        Console.WriteLine("District7 selected: " + district7);  // Log the selected district value
                    }

                    // Proceed with saving the district value to the database
                    cmd.Parameters.AddWithValue("@DISTRICT7", district7);




                    cmd.Parameters.AddWithValue("@YOP8", YOP8.Value.Trim());
                    cmd.Parameters.AddWithValue("@NOTS8", NOTS8.Value.Trim());
                    cmd.Parameters.AddWithValue("@STATE8", STATE8.SelectedValue.Trim());
                    string district8 = HiddenDistrict8.Value;  // Get the value from the hidden field

                    if (string.IsNullOrEmpty(district8))
                    {
                        Console.WriteLine("District8 is empty!");  // Log if it's empty
                    }
                    else
                    {
                        Console.WriteLine("District8 selected: " + district8);  // Log the selected district value
                    }

                    // Proceed with saving the district value to the database
                    cmd.Parameters.AddWithValue("@DISTRICT8", district8);





                    cmd.Parameters.AddWithValue("@YOP9", YOP9.Value.Trim());
                    cmd.Parameters.AddWithValue("@NOTS9", NOTS9.Value.Trim());
                    cmd.Parameters.AddWithValue("@STATE9", STATE9.SelectedValue.Trim());
                    string district9 = HiddenDistrict9.Value;  // Get the value from the hidden field

                    if (string.IsNullOrEmpty(district9))
                    {
                        Console.WriteLine("District9 is empty!");  // Log if it's empty
                    }
                    else
                    {
                        Console.WriteLine("District9 selected: " + district9);  // Log the selected district value
                    }

                    // Proceed with saving the district value to the database
                    cmd.Parameters.AddWithValue("@DISTRICT9", district9);




                    cmd.Parameters.AddWithValue("@YOP10", YOP10.Value.Trim());
                    cmd.Parameters.AddWithValue("@NOTS10", NOTS10.Value.Trim());
                    cmd.Parameters.AddWithValue("@STATE10", STATE10.SelectedValue.Trim());
                    string district10 = HiddenDistrict10.Value;  // Get the value from the hidden field

                    if (string.IsNullOrEmpty(district10))
                    {
                        Console.WriteLine("District10 is empty!");  // Log if it's empty
                    }
                    else
                    {
                        Console.WriteLine("District10 selected: " + district10);  // Log the selected district value
                    }

                    // Proceed with saving the district value to the database
                    cmd.Parameters.AddWithValue("@DISTRICT10", district10);




                    cmd.Parameters.AddWithValue("@YOP11", YOP11.Value.Trim());
                    cmd.Parameters.AddWithValue("@NOTS11", NOTS11.Value.Trim());
                    cmd.Parameters.AddWithValue("@STATE11", STATE11.SelectedValue.Trim());
                    string district11 = HiddenDistrict11.Value;  // Get the value from the hidden field

                    if (string.IsNullOrEmpty(district11))
                    {
                        Console.WriteLine("District11 is empty!");  // Log if it's empty
                    }
                    else
                    {
                        Console.WriteLine("District11 selected: " + district11);  // Log the selected district value
                    }

                    // Proceed with saving the district value to the database
                    cmd.Parameters.AddWithValue("@DISTRICT11", district11);




                    cmd.Parameters.AddWithValue("@YOP12", YOP12.Value.Trim());
                    cmd.Parameters.AddWithValue("@NOTS12", NOTS12.Value.Trim());
                    cmd.Parameters.AddWithValue("@STATE12", STATE12.SelectedValue.Trim());
                    string district12 = HiddenDistrict12.Value;  // Get the value from the hidden field

                    if (string.IsNullOrEmpty(district12))
                    {
                        Console.WriteLine("District12 is empty!");  // Log if it's empty
                    }
                    else
                    {
                        Console.WriteLine("District12 selected: " + district12);  // Log the selected district value
                    }

                    // Proceed with saving the district value to the database
                    cmd.Parameters.AddWithValue("@DISTRICT12", district12);

                  

                    cmd.Parameters.AddWithValue("@ModifiedUserID", LoginId);




                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                 

                }


            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        //protected void PhysicsChemistry()
        //{
        //    try
        //    {
        //        String LoginId = Session["LoginId"] as string;
        //        string modifiedAt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");


        //        using (SqlConnection con = new SqlConnection(strcon))
        //        {


        //            if (checkbox1.Checked)
        //            {
        //                RNBIO.Value = "";
        //                MOPBIO.SelectedValue = "";
        //                YOPBIO.Value = "";
        //                MAXMARKSBIO.SelectedValue = "";
        //                OBTMARKSBIO.Value = "";

        //                RNMATOTH.Value = "";
        //                MOPMATOTH.SelectedValue = "";
        //                YOPMATOTH.Value = "";
        //                MAXMARKSMATOTH.SelectedValue = "";
        //                OBTMARKSMATOTH.Value = "";

        //            }
        //            else if (checkbox2.Checked)
        //            {

        //                RNBOT.Value = "";
        //                MOPBOT.SelectedValue = "";
        //                YOPBOT.Value = "";
        //                MAXMARKSBOT.SelectedValue = "";
        //                OBTMARKSBOT.Value = "";

        //                RNZOO.Value = "";
        //                MOPZOO.SelectedValue = "";
        //                YOPZOO.Value = "";
        //                MAXMARKSZOO.SelectedValue = "";
        //                OBTMARKSZOO.Value = "";
        //            }


        //            String checkQuery = "SELECT COUNT(*) FROM PhysicsChemistry where LoginId = @LoginId";
        //            SqlCommand checkcmd = new SqlCommand(checkQuery, con);
        //            checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

        //            con.Open();
        //            int count = Convert.ToInt32(checkcmd.ExecuteScalar());
        //            con.Close();

        //            string query;

        //            if (count > 0)
        //            {
        //                query = "UPDATE PhysicsChemistry SET RNPHY=@RNPHY,PHYSICSSUBJECT=@PHYSICSSUBJECT,MOPPHY=@MOPPHY,YOPPHY=@YOPPHY,MAXMARKSPHY=@MAXMARKSPHY,OBTMARKSPHY=@OBTMARKSPHY,CHEMISTRYSUBJECT=@CHEMISTRYSUBJECT,RNCHE=@RNCHE,MOPCHE=@MOPCHE,YOPCHE=@YOPCHE,MAXMARKSCHE=@MAXMARKSCHE,OBTMARKSCHE=@OBTMARKSCHE,ModifiedAt=@ModifiedAt WHERE LoginId=@LoginId";
        //            }
        //            else
        //            {
        //                query = "INSERT INTO PhysicsChemistry(LoginId,PHYSICSSUBJECT,RNPHY,MOPPHY,YOPPHY,MAXMARKSPHY,OBTMARKSPHY,CHEMISTRYSUBJECT,RNCHE,MOPCHE,YOPCHE,MAXMARKSCHE,OBTMARKSCHE,ModifiedAt) VALUES(@LoginId,@PHYSICSSUBJECT,@RNPHY,@MOPPHY,@YOPPHY,@MAXMARKSPHY,@OBTMARKSPHY,@CHEMISTRYSUBJECT,@RNCHE,@MOPCHE,@YOPCHE,@MAXMARKSCHE,@OBTMARKSCHE,@ModifiedAt)";
        //            }

        //            SqlCommand cmd = new SqlCommand(query, con);

        //            cmd.Parameters.AddWithValue("@LoginId", LoginId);

        //            cmd.Parameters.AddWithValue("@PHYSICSSUBJECT", PHYSICSSUBJECT.InnerHtml.Trim());
        //            cmd.Parameters.AddWithValue("@RNPHY", RNPHY.Value.Trim());
        //            cmd.Parameters.AddWithValue("@MOPPHY", MOPPHY.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@YOPPHY", YOPPHY.Value.Trim());
        //            cmd.Parameters.AddWithValue("@MAXMARKSPHY", MAXMARKSPHY.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@OBTMARKSPHY", OBTMARKSPHY.Value.Trim());

        //            cmd.Parameters.AddWithValue("@CHEMISTRYSUBJECT", CHEMISTRYSUBJECT.InnerHtml.Trim());
        //            cmd.Parameters.AddWithValue("@RNCHE", RNCHE.Value.Trim());
        //            cmd.Parameters.AddWithValue("@MOPCHE", MOPCHE.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@YOPCHE", YOPCHE.Value.Trim());
        //            cmd.Parameters.AddWithValue("@MAXMARKSCHE", MAXMARKSCHE.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@OBTMARKSCHE", OBTMARKSCHE.Value.Trim());

        //            cmd.Parameters.AddWithValue("@ModifiedAt", modifiedAt);


        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();       

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert('" + ex.Message + "') </script>");
        //    }
        //}


        //protected void BotanyZoology()
        //{
        //        try
        //        {
        //            String LoginId = Session["LoginId"] as string;
        //        string modifiedAt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");


        //        using (SqlConnection con = new SqlConnection(strcon))
        //            {


        //            if (checkbox1.Checked)
        //            {
        //                RNBIO.Value = "";
        //                MOPBIO.SelectedValue = "";
        //                YOPBIO.Value = "";
        //                MAXMARKSBIO.SelectedValue = "";
        //                OBTMARKSBIO.Value = "";

        //                RNMATOTH.Value = "";
        //                MOPMATOTH.SelectedValue = "";
        //                YOPMATOTH.Value = "";
        //                MAXMARKSMATOTH.SelectedValue = "";
        //                OBTMARKSMATOTH.Value = "";

        //            }
        //            else if (checkbox2.Checked)
        //            {

        //                RNBOT.Value = "";
        //                MOPBOT.SelectedValue = "";
        //                YOPBOT.Value = "";
        //                MAXMARKSBOT.SelectedValue = "";
        //                OBTMARKSBOT.Value = "";

        //                RNZOO.Value = "";
        //                MOPZOO.SelectedValue = "";
        //                YOPZOO.Value = "";
        //                MAXMARKSZOO.SelectedValue = "";
        //                OBTMARKSZOO.Value = "";
        //            }

        //            String checkQuery = "SELECT COUNT(*) FROM BotanyZoology where LoginId = @LoginId";
        //                SqlCommand checkcmd = new SqlCommand(checkQuery, con);
        //                checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

        //                con.Open();
        //                int count = Convert.ToInt32(checkcmd.ExecuteScalar());
        //                con.Close();

        //                string query;

        //                if (count > 0)
        //                {
        //                    query = "UPDATE BotanyZoology SET CHECKBOX1=@CHECKBOX1,BOTANYSUBJECT=@BOTANYSUBJECT,RNBOT=@RNBOT,MOPBOT=@MOPBOT,YOPBOT=@YOPBOT,MAXMARKSBOT=@MAXMARKSBOT,OBTMARKSBOT=@OBTMARKSBOT,ZOOLOGYSUBJECT=@ZOOLOGYSUBJECT,RNZOO=@RNZOO,MOPZOO=@MOPZOO,YOPZOO=@YOPZOO,MAXMARKSZOO=@MAXMARKSZOO,OBTMARKSZOO=@OBTMARKSZOO,ModifiedAt=@ModifiedAt WHERE LoginId=@LoginId";
        //                }
        //                else
        //                {
        //                    query = "INSERT INTO BotanyZoology(LoginId,CHECKBOX1,BOTANYSUBJECT,RNBOT,MOPBOT,YOPBOT,MAXMARKSBOT,OBTMARKSBOT,ZOOLOGYSUBJECT,RNZOO,MOPZOO,YOPZOO,MAXMARKSZOO,OBTMARKSZOO,ModifiedAt) VALUES(@LoginId,@CHECKBOX1,@BOTANYSUBJECT,@RNBOT,@MOPBOT,@YOPBOT,@MAXMARKSBOT,@OBTMARKSBOT,@ZOOLOGYSUBJECT,@RNZOO,@MOPZOO,@YOPZOO,@MAXMARKSZOO,@OBTMARKSZOO,@ModifiedAt)";
        //                }

        //                SqlCommand cmd = new SqlCommand(query, con);

        //                cmd.Parameters.AddWithValue("@LoginId", LoginId);

        //                cmd.Parameters.AddWithValue("@CHECKBOX1", checkbox1.Checked);

        //                cmd.Parameters.AddWithValue("@BOTANYSUBJECT", BOTANYSUBJECT.InnerHtml.Trim());
        //                cmd.Parameters.AddWithValue("@RNBOT", RNBOT.Value.Trim());
        //                cmd.Parameters.AddWithValue("@MOPBOT", MOPBOT.SelectedValue.Trim());
        //                cmd.Parameters.AddWithValue("@YOPBOT", YOPBOT.Value.Trim());
        //                cmd.Parameters.AddWithValue("@MAXMARKSBOT", MAXMARKSBOT.SelectedValue.Trim());
        //                cmd.Parameters.AddWithValue("@OBTMARKSBOT", OBTMARKSBOT.Value.Trim());

        //                cmd.Parameters.AddWithValue("@ZOOLOGYSUBJECT", ZOOLOGYSUBJECT.InnerHtml.Trim());
        //                cmd.Parameters.AddWithValue("@RNZOO", RNZOO.Value.Trim());
        //                cmd.Parameters.AddWithValue("@MOPZOO", MOPZOO.SelectedValue.Trim());
        //                cmd.Parameters.AddWithValue("@YOPZOO", YOPZOO.Value.Trim());
        //                cmd.Parameters.AddWithValue("@MAXMARKSZOO", MAXMARKSZOO.SelectedValue.Trim());
        //                cmd.Parameters.AddWithValue("@OBTMARKSZOO", OBTMARKSZOO.Value.Trim());

        //                cmd.Parameters.AddWithValue("@ModifiedAt", modifiedAt);


        //            con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();

        //            }

        //        }

        //        catch (Exception ex)
        //        {
        //            Response.Write("<script> alert('" + ex.Message + "') </script>");
        //        }
        // }


        //protected void BioloyMathsOthers()
        //{
        //    try
        //    {
        //        String LoginId = Session["LoginId"] as string;
        //        string modifiedAt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");


        //        using (SqlConnection con = new SqlConnection(strcon))
        //        {

        //            if (checkbox1.Checked)
        //            {
        //                RNBIO.Value = "";
        //                MOPBIO.SelectedValue = "";
        //                YOPBIO.Value = "";
        //                MAXMARKSBIO.SelectedValue = "";
        //                OBTMARKSBIO.Value = "";

        //                RNMATOTH.Value = "";
        //                MOPMATOTH.SelectedValue = "";
        //                YOPMATOTH.Value = "";
        //                MAXMARKSMATOTH.SelectedValue = "";
        //                OBTMARKSMATOTH.Value = "";

        //            }
        //            else if (checkbox2.Checked)
        //            {

        //                RNBOT.Value = "";
        //                MOPBOT.SelectedValue = "";
        //                YOPBOT.Value = "";
        //                MAXMARKSBOT.SelectedValue = "";
        //                OBTMARKSBOT.Value = "";

        //                RNZOO.Value = "";
        //                MOPZOO.SelectedValue = "";
        //                YOPZOO.Value = "";
        //                MAXMARKSZOO.SelectedValue = "";
        //                OBTMARKSZOO.Value = "";
        //            }

        //            String checkQuery = "SELECT COUNT(*) FROM BiologyMathsOthers where LoginId = @LoginId";
        //            SqlCommand checkcmd = new SqlCommand(checkQuery, con);
        //            checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

        //            con.Open();
        //            int count = Convert.ToInt32(checkcmd.ExecuteScalar());
        //            con.Close();

        //            string query;

        //            if (count > 0)
        //            {
        //                query = "UPDATE BiologyMathsOthers SET CHECKBOX2=@CHECKBOX2,BIOLOGYSUBJECT=@BIOLOGYSUBJECT,RNBIO=@RNBIO,MOPBIO=@MOPBIO,YOPBIO=@YOPBIO,MAXMARKSBIO=@MAXMARKSBIO,OBTMARKSBIO=@OBTMARKSBIO,MATHSOTHERSSUBJECT=@MATHSOTHERSSUBJECT,RNMATOTH=@RNMATOTH,MOPMATOTH=@MOPMATOTH,YOPMATOTH=@YOPMATOTH,MAXMARKSMATOTH=@MAXMARKSMATOTH,OBTMARKSMATOTH=@OBTMARKSMATOTH,ModifiedAt=@ModifiedAt WHERE LoginId=@LoginId";
        //            }
        //            else
        //            {
        //                query = "INSERT INTO BiologyMathsOthers(LoginId,CHECKBOX2,BIOLOGYSUBJECT,RNBIO,MOPBIO,YOPBIO,MAXMARKSBIO,OBTMARKSBIO,MATHSOTHERSSUBJECT,RNMATOTH,MOPMATOTH,YOPMATOTH,MAXMARKSMATOTH,OBTMARKSMATOTH,ModifiedAt) VALUES(@LoginId,@CHECKBOX2,@BIOLOGYSUBJECT,@RNBIO,@MOPBIO,@YOPBIO,@MAXMARKSBIO,@OBTMARKSBIO,@MATHSOTHERSSUBJECT,@RNMATOTH,@MOPMATOTH,@YOPMATOTH,@MAXMARKSMATOTH,@OBTMARKSMATOTH,@ModifiedAt)";
        //            }

        //            SqlCommand cmd = new SqlCommand(query, con);

        //            cmd.Parameters.AddWithValue("@LoginId", LoginId);

        //            cmd.Parameters.AddWithValue("@CHECKBOX2", checkbox2.Checked);

        //            cmd.Parameters.AddWithValue("@BIOLOGYSUBJECT", BIOLOGYSUBJECT.InnerHtml.Trim());
        //            cmd.Parameters.AddWithValue("@RNBIO", RNBIO.Value.Trim());
        //            cmd.Parameters.AddWithValue("@MOPBIO", MOPBIO.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@YOPBIO", YOPBIO.Value.Trim());
        //            cmd.Parameters.AddWithValue("@MAXMARKSBIO", MAXMARKSBIO.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@OBTMARKSBIO", OBTMARKSBIO.Value.Trim());

        //            cmd.Parameters.AddWithValue("@MATHSOTHERSSUBJECT", MATHSOTHERSSUBJECT.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@RNMATOTH", RNMATOTH.Value.Trim());
        //            cmd.Parameters.AddWithValue("@MOPMATOTH", MOPMATOTH.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@YOPMATOTH", YOPMATOTH.Value.Trim());
        //            cmd.Parameters.AddWithValue("@MAXMARKSMATOTH", MAXMARKSMATOTH.SelectedValue.Trim());
        //            cmd.Parameters.AddWithValue("@OBTMARKSMATOTH", OBTMARKSMATOTH.Value.Trim());

        //            cmd.Parameters.AddWithValue("@ModifiedAt", modifiedAt);


        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert('" + ex.Message + "') </script>");
        //    }
        //}



        //........................ DROPDOWNS .....................

        protected void BindMediumOfInstructionDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT MediumOfInstructionId, MediumOfInstructionName FROM MediumOfInstruction";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlMediumOfInstruction.Items.Clear(); // Clear existing items
                ddlMediumOfInstruction.Items.Add(new ListItem("-- Select Medium --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["MediumOfInstructionId"]); // Get ID
                    string name = reader["MediumOfInstructionName"].ToString().Trim(); // Get Name

                    ddlMediumOfInstruction.Items.Add(new ListItem(name, id.ToString())); // Set ID as value
                }

                reader.Close(); // Close reader
            }
        }

        protected void BindCivicSchoolDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT CivicSchoolId, CivicSchoolName FROM CivicSchool";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCivicSchool.Items.Clear(); // Clear existing items
                ddlCivicSchool.Items.Add(new ListItem("-- Select Civic School --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["CivicSchoolId"]); // Get ID
                    string name = reader["CivicSchoolName"].ToString().Trim(); // Get Name

                    ddlCivicSchool.Items.Add(new ListItem(name, id.ToString())); // Set ID as value
                }

                reader.Close();
            }
        }

        protected void BindCivicNativeDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT CivicNativeId, CivicNativeName FROM CivicNative";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCivicNative.Items.Clear(); // Clear existing items
                ddlCivicNative.Items.Add(new ListItem("-- Select Civic Native --", "")); // Default option

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["CivicNativeId"]); // Get ID
                    string name = reader["CivicNativeName"].ToString().Trim(); // Get Name

                    ddlCivicNative.Items.Add(new ListItem(name, id.ToString())); // Set ID as value
                }

                reader.Close();
            }
        }


        protected void BindStateDropDown(DropDownList ddlState)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT StateName FROM States";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlState.Items.Clear(); // Clear existing items
                ddlState.Items.Add(new ListItem("-- Select --", "")); // Add default item

                while (reader.Read())
                {
                    string stateName = reader["StateName"].ToString().Trim();
                    ddlState.Items.Add(new ListItem(stateName));
                }
            }
        }


        protected void BindMaxMarksDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT MaxMarksId, MaxMark FROM MaxMarks"; // Fetch ID & Marks
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Clear existing items
                MAXMARKSPHY.Items.Clear();
                MAXMARKSCHE.Items.Clear();
                MAXMARKSBOT.Items.Clear();
                MAXMARKSZOO.Items.Clear();
                MAXMARKSBIO.Items.Clear();
                MAXMARKSMATOTH.Items.Clear();

                // Add default option
                MAXMARKSPHY.Items.Add(new ListItem("-- Select --", ""));
                MAXMARKSCHE.Items.Add(new ListItem("-- Select --", ""));
                MAXMARKSBOT.Items.Add(new ListItem("-- Select --", ""));
                MAXMARKSZOO.Items.Add(new ListItem("-- Select --", ""));
                MAXMARKSBIO.Items.Add(new ListItem("-- Select --", ""));
                MAXMARKSMATOTH.Items.Add(new ListItem("-- Select --", ""));

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["MaxMarksId"]); // Get ID
                    string marks = reader["MaxMark"].ToString().Trim(); // Get Marks

                    // Set ID as value for both dropdowns
                    MAXMARKSPHY.Items.Add(new ListItem(marks, id.ToString()));
                    MAXMARKSCHE.Items.Add(new ListItem(marks, id.ToString()));
                    MAXMARKSBOT.Items.Add(new ListItem(marks, id.ToString()));
                    MAXMARKSZOO.Items.Add(new ListItem(marks, id.ToString()));
                    MAXMARKSBIO.Items.Add(new ListItem(marks, id.ToString()));
                    MAXMARKSMATOTH.Items.Add(new ListItem(marks, id.ToString()));
                }
            }
        }

        protected void BindMonthsDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT MonthId, MonthNames FROM Months"; // Fetch ID & Name
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Clear existing items
                MOPPHY.Items.Clear();
                MOPCHE.Items.Clear();
                MOPBOT.Items.Clear();
                MOPZOO.Items.Clear();
                MOPBIO.Items.Clear();
                MOPMATOTH.Items.Clear();

                // Add default option
                MOPPHY.Items.Add(new ListItem("-- Select --", ""));
                MOPCHE.Items.Add(new ListItem("-- Select --", ""));
                MOPBOT.Items.Add(new ListItem("-- Select --", ""));
                MOPZOO.Items.Add(new ListItem("-- Select --", ""));
                MOPBIO.Items.Add(new ListItem("-- Select --", ""));
                MOPMATOTH.Items.Add(new ListItem("-- Select --", ""));

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["MonthId"]); // Get ID
                    string month = reader["MonthNames"].ToString().Trim(); // Get Month Name

                    MOPPHY.Items.Add(new ListItem(month, id.ToString())); // Set ID as value
                    MOPCHE.Items.Add(new ListItem(month, id.ToString())); // Set ID as value
                    MOPBOT.Items.Add(new ListItem(month, id.ToString())); // Set ID as value
                    MOPZOO.Items.Add(new ListItem(month, id.ToString())); // Set ID as value
                    MOPBIO.Items.Add(new ListItem(month, id.ToString())); // Set ID as value
                    MOPMATOTH.Items.Add(new ListItem(month, id.ToString())); // Set ID as value
                }
            }
        }


        // storing student mark details along with their application number 

        protected void StudentMarkDetails()
        {
            try
            {
                String LoginId = Session["LoginId"] as string;
              

                using (SqlConnection con = new SqlConnection(strcon))
                {

                    if (checkbox1.Checked)
                    {
                        RNBIO.Value = "";
                        MOPBIO.SelectedValue = "";
                        YOPBIO.Value = "";
                        MAXMARKSBIO.SelectedValue = "";
                        OBTMARKSBIO.Value = "0";

                        RNMATOTH.Value = "";
                        MOPMATOTH.SelectedValue = "";
                        YOPMATOTH.Value = "";
                        MAXMARKSMATOTH.SelectedValue = "";
                        OBTMARKSMATOTH.Value = "0";

                    }else if (checkbox2.Checked)
                    {

                        RNBOT.Value = "";
                        MOPBOT.SelectedValue = "";
                        YOPBOT.Value = "";
                        MAXMARKSBOT.SelectedValue = "";
                        OBTMARKSBOT.Value = "0";

                        RNZOO.Value = "";
                        MOPZOO.SelectedValue = "";
                        YOPZOO.Value = "";
                        MAXMARKSZOO.SelectedValue = "";
                        OBTMARKSZOO.Value = "0";
                    }


                    // Step 1: Retrieve ApplicationNumber from Applications table
                    String getAppNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                    SqlCommand getAppNumberCmd = new SqlCommand(getAppNumberQuery, con);
                    getAppNumberCmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    String ApplicationNumber = (String)getAppNumberCmd.ExecuteScalar();
                    con.Close();

                    // Check if ApplicationNumber was retrieved
                    if (string.IsNullOrEmpty(ApplicationNumber))
                    {
                        Response.Write("<script>alert('ApplicationNumber not found for the provided LoginId.')</script>");
                        return;
                    }

                    // Step 2: Check if StudentMarkDetails already exists for the LoginId
                    String checkQuery = "SELECT COUNT(*) FROM StudentMarkDetails WHERE LoginId = @LoginId";
                    SqlCommand checkcmd = new SqlCommand(checkQuery, con);
                    checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    int count = Convert.ToInt32(checkcmd.ExecuteScalar());
                    con.Close();

                    // Step 3: Prepare the appropriate query
                    string query;
                    if (count > 0)
                    {
                        query = "UPDATE StudentMarkDetails SET ApplicationNumber = @ApplicationNumber," +
                            "RNPHY=@RNPHY,PHYSICSSUBJECT=@PHYSICSSUBJECT,MOPPHY=@MOPPHY,YOPPHY=@YOPPHY,MAXMARKSPHY=@MAXMARKSPHY,OBTMARKSPHY=@OBTMARKSPHY,CHEMISTRYSUBJECT=@CHEMISTRYSUBJECT,RNCHE=@RNCHE,MOPCHE=@MOPCHE,YOPCHE=@YOPCHE,MAXMARKSCHE=@MAXMARKSCHE,OBTMARKSCHE=@OBTMARKSCHE," +
                            "CHECKBOX1=@CHECKBOX1,BOTANYSUBJECT=@BOTANYSUBJECT,RNBOT=@RNBOT,MOPBOT=@MOPBOT,YOPBOT=@YOPBOT,MAXMARKSBOT=@MAXMARKSBOT,OBTMARKSBOT=@OBTMARKSBOT,ZOOLOGYSUBJECT=@ZOOLOGYSUBJECT,RNZOO=@RNZOO,MOPZOO=@MOPZOO,YOPZOO=@YOPZOO,MAXMARKSZOO=@MAXMARKSZOO,OBTMARKSZOO=@OBTMARKSZOO," +
                            "CHECKBOX2=@CHECKBOX2,BIOLOGYSUBJECT=@BIOLOGYSUBJECT,RNBIO=@RNBIO,MOPBIO=@MOPBIO,YOPBIO=@YOPBIO,MAXMARKSBIO=@MAXMARKSBIO,OBTMARKSBIO=@OBTMARKSBIO,MATHSOTHERSSUBJECT=@MATHSOTHERSSUBJECT,RNMATOTH=@RNMATOTH,MOPMATOTH=@MOPMATOTH,YOPMATOTH=@YOPMATOTH,MAXMARKSMATOTH=@MAXMARKSMATOTH,OBTMARKSMATOTH=@OBTMARKSMATOTH,ModifiedAt=getdate(),ModifiedUserID=@ModifiedUserID" +
                            " WHERE LoginId = @LoginId";
                    }
                    else
                    {
                        query = "INSERT INTO StudentMarkDetails" +
                            " (LoginId, ApplicationNumber," +
                            "PHYSICSSUBJECT,RNPHY,MOPPHY,YOPPHY,MAXMARKSPHY,OBTMARKSPHY,CHEMISTRYSUBJECT,RNCHE,MOPCHE,YOPCHE,MAXMARKSCHE,OBTMARKSCHE," +
                            "CHECKBOX1,BOTANYSUBJECT,RNBOT,MOPBOT,YOPBOT,MAXMARKSBOT,OBTMARKSBOT,ZOOLOGYSUBJECT,RNZOO,MOPZOO,YOPZOO,MAXMARKSZOO,OBTMARKSZOO," +
                            "CHECKBOX2,BIOLOGYSUBJECT,RNBIO,MOPBIO,YOPBIO,MAXMARKSBIO,OBTMARKSBIO,MATHSOTHERSSUBJECT,RNMATOTH,MOPMATOTH,YOPMATOTH,MAXMARKSMATOTH,OBTMARKSMATOTH," +
                            "ModifiedAt,ModifiedUserID)" +
                            " VALUES " +
                            "(@LoginId, @ApplicationNumber," +
                            "@PHYSICSSUBJECT,@RNPHY,@MOPPHY,@YOPPHY,@MAXMARKSPHY,@OBTMARKSPHY,@CHEMISTRYSUBJECT,@RNCHE,@MOPCHE,@YOPCHE,@MAXMARKSCHE,@OBTMARKSCHE," +
                            "@CHECKBOX1,@BOTANYSUBJECT,@RNBOT,@MOPBOT,@YOPBOT,@MAXMARKSBOT,@OBTMARKSBOT,@ZOOLOGYSUBJECT,@RNZOO,@MOPZOO,@YOPZOO,@MAXMARKSZOO,@OBTMARKSZOO," +
                            "@CHECKBOX2,@BIOLOGYSUBJECT,@RNBIO,@MOPBIO,@YOPBIO,@MAXMARKSBIO,@OBTMARKSBIO,@MATHSOTHERSSUBJECT,@RNMATOTH,@MOPMATOTH,@YOPMATOTH,@MAXMARKSMATOTH,@OBTMARKSMATOTH," +
                            "getdate(),@ModifiedUserID)";
                    }

                    // Step 4: Prepare the SqlCommand for INSERT or UPDATE
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@LoginId", LoginId);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);

                    cmd.Parameters.AddWithValue("@PHYSICSSUBJECT", PHYSICSSUBJECT.InnerHtml.Trim());
                    cmd.Parameters.AddWithValue("@RNPHY", RNPHY.Value.Trim());
                    cmd.Parameters.AddWithValue("@MOPPHY", MOPPHY.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@YOPPHY", YOPPHY.Value.Trim());
                    cmd.Parameters.AddWithValue("@MAXMARKSPHY", MAXMARKSPHY.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@OBTMARKSPHY", Convert.ToDouble (OBTMARKSPHY.Value.Trim())); //OBTMARKSPHY.Value.Trim()
                    
                    cmd.Parameters.AddWithValue("@CHEMISTRYSUBJECT", CHEMISTRYSUBJECT.InnerHtml.Trim());
                    cmd.Parameters.AddWithValue("@RNCHE", RNCHE.Value.Trim());
                    cmd.Parameters.AddWithValue("@MOPCHE", MOPCHE.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@YOPCHE", YOPCHE.Value.Trim());
                    cmd.Parameters.AddWithValue("@MAXMARKSCHE", MAXMARKSCHE.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@OBTMARKSCHE", Convert.ToDouble(OBTMARKSCHE.Value.Trim()));

                    cmd.Parameters.AddWithValue("@CHECKBOX1", checkbox1.Checked);

                    cmd.Parameters.AddWithValue("@BOTANYSUBJECT", BOTANYSUBJECT.InnerHtml.Trim());
                    cmd.Parameters.AddWithValue("@RNBOT", RNBOT.Value.Trim());
                    cmd.Parameters.AddWithValue("@MOPBOT", MOPBOT.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@YOPBOT", YOPBOT.Value.Trim());
                    cmd.Parameters.AddWithValue("@MAXMARKSBOT", MAXMARKSBOT.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@OBTMARKSBOT", Convert.ToDouble(OBTMARKSBOT.Value.Trim()));

                    cmd.Parameters.AddWithValue("@ZOOLOGYSUBJECT", ZOOLOGYSUBJECT.InnerHtml.Trim());
                    cmd.Parameters.AddWithValue("@RNZOO", RNZOO.Value.Trim());
                    cmd.Parameters.AddWithValue("@MOPZOO", MOPZOO.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@YOPZOO", YOPZOO.Value.Trim());
                    cmd.Parameters.AddWithValue("@MAXMARKSZOO", MAXMARKSZOO.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@OBTMARKSZOO", Convert.ToDouble(OBTMARKSZOO.Value.Trim()));

                    cmd.Parameters.AddWithValue("@CHECKBOX2", checkbox2.Checked);

                    cmd.Parameters.AddWithValue("@BIOLOGYSUBJECT", BIOLOGYSUBJECT.InnerHtml.Trim());
                    cmd.Parameters.AddWithValue("@RNBIO", RNBIO.Value.Trim());
                    cmd.Parameters.AddWithValue("@MOPBIO", MOPBIO.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@YOPBIO", YOPBIO.Value.Trim());
                    cmd.Parameters.AddWithValue("@MAXMARKSBIO", MAXMARKSBIO.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@OBTMARKSBIO", Convert.ToDouble(OBTMARKSBIO.Value.Trim()));

                    cmd.Parameters.AddWithValue("@MATHSOTHERSSUBJECT", MATHSOTHERSSUBJECT.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@RNMATOTH", RNMATOTH.Value.Trim());
                    cmd.Parameters.AddWithValue("@MOPMATOTH", MOPMATOTH.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@YOPMATOTH", YOPMATOTH.Value.Trim());
                    cmd.Parameters.AddWithValue("@MAXMARKSMATOTH", MAXMARKSMATOTH.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@OBTMARKSMATOTH", Convert.ToDouble(OBTMARKSMATOTH.Value.Trim()));

                 
                    
                    cmd.Parameters.AddWithValue("@ModifiedUserID", LoginId);

                    // Step 5: Execute the query
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }

        }





    }
}