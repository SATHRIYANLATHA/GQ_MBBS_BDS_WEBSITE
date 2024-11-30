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
    public partial class splres : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQualifyingExaminationDropDown(); // dropdown for qualifying examination ...
                BindBoardOfExaminationDropDown(); // dropdown for board of examination ...

                String loginId = Session["LoginId"] as string;
                loaduserdetails(loginId);
            }
        }

        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            try
            {
                String LoginId = Session["LoginId"] as string;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    String checkQuery = "SELECT COUNT(*) FROM SpecialReservation where LoginId = @LoginId";
                    SqlCommand checkcmd = new SqlCommand(checkQuery, con);
                    checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    int count = Convert.ToInt32(checkcmd.ExecuteScalar());
                    con.Close();

                    string query;

                    if (count > 0)
                    {
                        query = "UPDATE SpecialReservation SET EminentSportsPerson=@EminentSportsPerson,EXservicemen=@EXservicemen,DifferentlyAbledPerson=@DifferentlyAbledPerson,QualifyingExamination=@QualifyingExamination,HSCgroupcode=@HSCgroupcode,HSCgroupcodeOthers=@HSCgroupcodeOthers,BoardOfExamination=@BoardOfExamination,BoardOfExaminationOthers=@BoardOfExaminationOthers,CoursesUndergoingCompleted=@CoursesUndergoingCompleted,NameOfTheCourse=@NameOfTheCourse,NameOfTheOtherCourse=@NameOfTheOtherCourse,YearOfCompletion=@YearOfCompletion WHERE LoginId=@LoginId";
                    }
                    else
                    {
                        query = "INSERT INTO SpecialReservation(LoginId,EminentSportsPerson,EXservicemen,DifferentlyAbledPerson,QualifyingExamination,HSCgroupcode,HSCgroupcodeOthers,BoardOfExamination,BoardOfExaminationOthers,CoursesUndergoingCompleted,NameOfTheCourse,NameOfTheOtherCourse,YearOfCompletion) VALUES (@LoginId,@EminentSportsPerson,@EXservicemen,@DifferentlyAbledPerson,@QualifyingExamination,@HSCgroupcode,@HSCgroupcodeOthers,@BoardOfExamination,@BoardOfExaminationOthers,@CoursesUndergoingCompleted,@NameOfTheCourse,@NameOfTheOtherCourse,@YearOfCompletion)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@LoginId", LoginId);
                    cmd.Parameters.AddWithValue("@EminentSportsPerson", EminentSportsOptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@EXservicemen", ExServicemenOptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@DifferentlyAbledPerson", DifferentlyAbledPersonOptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@QualifyingExamination", ddlQualifyingExamination.SelectedValue.Trim());


                    cmd.Parameters.AddWithValue("@HSCgroupcode", HscGroupOptions.SelectedValue.Trim());

                    if(HscGroupOptions.SelectedValue.Trim() == "No")
                    {
                        txthscgroup.Text = "";
                    }
                    cmd.Parameters.AddWithValue("@HSCgroupcodeOthers", txthscgroup.Text.Trim());




                    cmd.Parameters.AddWithValue("@BoardOfExamination", ddlBoardOfExamination.SelectedValue.Trim());

                    if(ddlBoardOfExamination.SelectedValue.Trim() != "Others")
                    {
                        boardofexamothers.Text = "";
                    }
                    cmd.Parameters.AddWithValue("@BoardOfExaminationOthers", boardofexamothers.Text.Trim());



                    cmd.Parameters.AddWithValue("@CoursesUndergoingCompleted", ProfessionalCourseOptions.SelectedValue.Trim());

                    if(ProfessionalCourseOptions.SelectedValue.Trim() == "No")
                    {
                        ddlcourselist.SelectedValue = "";
                        othercourse.Text = "";
                        yoc.Text = "";
                    }

                    cmd.Parameters.AddWithValue("@NameOfTheCourse", ddlcourselist.SelectedValue.Trim());

                    if(ddlcourselist.SelectedValue.Trim() != "Others")
                    {
                        othercourse.Text = "";
                    }

                    cmd.Parameters.AddWithValue("@NameOfTheOtherCourse", othercourse.Text.Trim());
                    cmd.Parameters.AddWithValue("@YearOfCompletion", yoc.Text.Trim());


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }


                Session["SpecialReservationComplete"] = true;

                setuserstatus();

                // Redirect to the next page (e.g., sos.aspx)
                Response.Redirect("sos.aspx");
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
                    string query = "SELECT * FROM SpecialReservation WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {


                            if (EminentSportsOptions.Items.FindByValue(dr["EminentSportsPerson"].ToString().Trim()) != null)
                            {
                                EminentSportsOptions.SelectedValue = dr["EminentSportsPerson"].ToString().Trim();

                            }


                            if (ExServicemenOptions.Items.FindByValue(dr["EXservicemen"].ToString().Trim()) != null)
                            {
                                ExServicemenOptions.SelectedValue = dr["EXservicemen"].ToString().Trim();

                            }



                            if (DifferentlyAbledPersonOptions.Items.FindByValue(dr["DifferentlyAbledPerson"].ToString().Trim()) != null)
                            {
                                DifferentlyAbledPersonOptions.SelectedValue = dr["DifferentlyAbledPerson"].ToString().Trim();

                            }



                            if (ddlQualifyingExamination.Items.FindByValue(dr["QualifyingExamination"].ToString().Trim()) != null)
                            {
                                ddlQualifyingExamination.SelectedValue = dr["QualifyingExamination"].ToString().Trim();
                            }


                            if (HscGroupOptions.Items.FindByValue(dr["HSCgroupcode"].ToString().Trim()) != null)
                            {
                                HscGroupOptions.SelectedValue = dr["HSCgroupcode"].ToString().Trim();

                            }

                            txthscgroup.Text = dr["HSCgroupcodeOthers"].ToString().Trim();


                            if (ddlBoardOfExamination.Items.FindByValue(dr["BoardOfExamination"].ToString().Trim()) != null)
                            {
                                ddlBoardOfExamination.SelectedValue = dr["BoardOfExamination"].ToString().Trim();

                            }

                            boardofexamothers.Text = dr["BoardOfExaminationOthers"].ToString().Trim();


                            if (ProfessionalCourseOptions.Items.FindByValue(dr["CoursesUndergoingCompleted"].ToString().Trim()) != null)
                            {
                                ProfessionalCourseOptions.SelectedValue = dr["CoursesUndergoingCompleted"].ToString().Trim();

                            }

                            if (ddlcourselist.Items.FindByValue(dr["NameOfTheCourse"].ToString().Trim()) != null)
                            {
                                ddlcourselist.SelectedValue = dr["NameOfTheCourse"].ToString().Trim();

                            }

                            othercourse.Text = dr["NameOfTheOtherCourse"].ToString().Trim();

                            yoc.Text = dr["YearOfCompletion"].ToString().Trim();

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

                    if (currentPageStatus <= 2)
                    {
                        query = "UPDATE UserProgress SET PageStatus = 2 WHERE LoginId = @LoginId";

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


        // ...............: DROPDOWNS :...................

        protected void BindQualifyingExaminationDropDown()
        {

            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT QualifyingExaminationName FROM QualifyingExamination ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string qualifyingexamination = reader["QualifyingExaminationName"].ToString().Trim();
                    ddlQualifyingExamination.Items.Add(new ListItem(qualifyingexamination));
                }
            }
        }

        protected void BindBoardOfExaminationDropDown()
        {

            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT BoardOfExaminationName FROM  BoardOfExamination";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string boardofexamination = reader["BoardOfExaminationName"].ToString().Trim();
                    ddlBoardOfExamination.Items.Add(new ListItem(boardofexamination));
                }
            }
        }

    }
}