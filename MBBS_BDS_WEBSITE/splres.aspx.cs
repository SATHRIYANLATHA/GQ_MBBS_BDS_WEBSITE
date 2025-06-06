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
        String strcon = ConfigurationManager.ConnectionStrings["DBConnMbbsGovt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQualifyingExaminationDropDown(); // dropdown for qualifying examination ...
                BindCoursesDropDown(); // dropdown for courses ...
                BindBoardOfExaminationDropDown(); // dropdown for board of examination ...


                String loginId = Session["LoginId"] as string;
                loaduserdetails(loginId);

                if (Session["LoginId"] == null)
                {
                    Response.Redirect("error.aspx");
                }
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
                    String checkQuery = "SELECT COUNT(*) FROM SpecialReservation WHERE LoginId = @LoginId";
                    SqlCommand checkcmd = new SqlCommand(checkQuery, con);
                    checkcmd.Parameters.AddWithValue("@LoginId", LoginId);

                    con.Open();
                    int count = Convert.ToInt32(checkcmd.ExecuteScalar());
                    con.Close();

                    string query;

                    if (count > 0)
                    {
                        query = "UPDATE SpecialReservation SET EminentSportsPerson=@EminentSportsPerson, EXservicemen=@EXservicemen, DifferentlyAbledPerson=@DifferentlyAbledPerson, QualifyingExamination=@QualifyingExamination, HSCgroupcode=@HSCgroupcode, HSCgroupcodeOthers=@HSCgroupcodeOthers, BoardOfExamination=@BoardOfExamination, BoardOfExaminationOthers=@BoardOfExaminationOthers, CoursesUndergoingCompleted=@CoursesUndergoingCompleted, NameOfTheCourse=@NameOfTheCourse, NameOfTheOtherCourse=@NameOfTheOtherCourse, YearOfCompletion=@YearOfCompletion, ModifiedAt=getdate(), ModifiedUserID=@ModifiedUserID WHERE LoginId=@LoginId";
                    }
                    else
                    {
                        query = "INSERT INTO SpecialReservation(LoginId, EminentSportsPerson, EXservicemen, DifferentlyAbledPerson, QualifyingExamination, HSCgroupcode, HSCgroupcodeOthers, BoardOfExamination, BoardOfExaminationOthers, CoursesUndergoingCompleted, NameOfTheCourse, NameOfTheOtherCourse, YearOfCompletion, ModifiedAt, ModifiedUserID) VALUES (@LoginId, @EminentSportsPerson, @EXservicemen, @DifferentlyAbledPerson, @QualifyingExamination, @HSCgroupcode, @HSCgroupcodeOthers, @BoardOfExamination, @BoardOfExaminationOthers, @CoursesUndergoingCompleted, @NameOfTheCourse, @NameOfTheOtherCourse, @YearOfCompletion, getdate(), @ModifiedUserID)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@LoginId", LoginId);
                    cmd.Parameters.AddWithValue("@EminentSportsPerson", EminentSportsOptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@EXservicemen", ExServicemenOptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@DifferentlyAbledPerson", DifferentlyAbledPersonOptions.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@QualifyingExamination", ddlQualifyingExamination.SelectedValue.Trim());

                    cmd.Parameters.AddWithValue("@HSCgroupcode", HscGroupOptions.SelectedValue.Trim());

                    if (HscGroupOptions.SelectedValue.Trim() == "No")
                    {
                        txthscgroup.Text = "";
                    }
                    cmd.Parameters.AddWithValue("@HSCgroupcodeOthers", txthscgroup.Text.Trim());

                    cmd.Parameters.AddWithValue("@BoardOfExamination", ddlBoardOfExamination.SelectedValue.Trim());

                    if (ddlBoardOfExamination.SelectedValue.Trim() != "14")
                    {
                        boardofexamothers.Text = "";
                    }
                    cmd.Parameters.AddWithValue("@BoardOfExaminationOthers", boardofexamothers.Text.Trim());

                    cmd.Parameters.AddWithValue("@CoursesUndergoingCompleted", ProfessionalCourseOptions.SelectedValue.Trim());

                    if (ProfessionalCourseOptions.SelectedValue.Trim() == "No")
                    {
                        ddlcourselist.SelectedValue = "";
                        othercourse.Text = "";
                        yoc.Text = "";
                    }

                    cmd.Parameters.AddWithValue("@NameOfTheCourse", ddlcourselist.SelectedValue.Trim());

                    if (ddlcourselist.SelectedValue.Trim() != "7")
                    {
                        othercourse.Text = "";
                    }

                    cmd.Parameters.AddWithValue("@NameOfTheOtherCourse", othercourse.Text.Trim());
                    cmd.Parameters.AddWithValue("@YearOfCompletion", yoc.Text.Trim());

                

                    cmd.Parameters.AddWithValue("@ModifiedUserID", LoginId);


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



                            // Load Qualifying Examination
                            string qualifyingExamination = dr["QualifyingExamination"].ToString().Trim();
                            if (ddlQualifyingExamination.Items.FindByValue(qualifyingExamination) != null)
                            {
                                ddlQualifyingExamination.SelectedValue = qualifyingExamination;
                            }



                            if (HscGroupOptions.Items.FindByValue(dr["HSCgroupcode"].ToString().Trim()) != null)
                            {
                                HscGroupOptions.SelectedValue = dr["HSCgroupcode"].ToString().Trim();

                            }

                            txthscgroup.Text = dr["HSCgroupcodeOthers"].ToString().Trim();

                            // Load Board of Examination
                            string boardExamination = dr["BoardOfExamination"].ToString().Trim();
                            if (ddlBoardOfExamination.Items.FindByValue(boardExamination) != null)
                            {
                                ddlBoardOfExamination.SelectedValue = boardExamination;
                            }

                            boardofexamothers.Text = dr["BoardOfExaminationOthers"].ToString().Trim();


                            if (ProfessionalCourseOptions.Items.FindByValue(dr["CoursesUndergoingCompleted"].ToString().Trim()) != null)
                            {
                                ProfessionalCourseOptions.SelectedValue = dr["CoursesUndergoingCompleted"].ToString().Trim();

                            }

                            // Load Course Name
                            string courseName = dr["NameOfTheCourse"].ToString().Trim();
                            if (ddlcourselist.Items.FindByValue(courseName) != null)
                            {
                                ddlcourselist.SelectedValue = courseName;
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

        protected void BindBoardOfExaminationDropDown()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT BoardOfExaminationId, BoardOfExaminationName FROM BoardOfExamination";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlBoardOfExamination.Items.Clear();
                ddlBoardOfExamination.Items.Add(new ListItem("-- Select --", ""));

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["BoardOfExaminationId"]);
                    string boardOfExamination = reader["BoardOfExaminationName"].ToString().Trim().ToUpper();

                    ddlBoardOfExamination.Items.Add(new ListItem(boardOfExamination, id.ToString()));
                }
            }
        }

        protected void BindCoursesDropDown()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT CourseId, CourseName FROM Courses";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlcourselist.Items.Clear();  // Clear existing items
                    ddlcourselist.Items.Add(new ListItem("-- Select --", ""));  // Default item

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["CourseId"]);
                        string courselist = reader["CourseName"].ToString().Trim().ToUpper();

                        ddlcourselist.Items.Add(new ListItem(courselist, id.ToString()));
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-specific exceptions
                string errorMessage = "SQL Error: " + sqlEx.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                string errorMessage = "Error: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);
            }
        }




    }
}