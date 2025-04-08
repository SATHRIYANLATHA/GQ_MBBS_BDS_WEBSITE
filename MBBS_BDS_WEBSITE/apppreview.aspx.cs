using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;


namespace MBBS_BDS_WEBSITE
{
    public partial class apppreview : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["DBConnMbbsGovt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String loginId = Session["LoginId"] as string;

                load_session_one(loginId);
               

                loadapplicationnumber(loginId);

                load_1_5(loginId);
                load_6_13(loginId);
                load_14_18(loginId);
                load_19_23(loginId);
                load_25_34(loginId);

                load_userimage(loginId);
                load_signimage(loginId);

                load_studentmarkdetails(loginId);

                //load_physics_chemistry(loginId);
                //load_botany_zoology(loginId);
                //load_biology_mathematics(loginId);
                load_study_details(loginId);


                GenerateBarcode(loginId);




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


                if (Session["ApplicationSubmit"] != null && (bool)Session["ApplicationSubmit"] == true)
                {
                    appsubmit.Visible = true;
                    temppdf.Visible = false;
                    mainpdf.Visible = true;
                    if (Session["ApplicationAlreadySubmitted"] != null && (bool)Session["ApplicationAlreadySubmitted"] == true)
                    {
                        appsubmit.InnerHtml = "YOUR APPLICATION HAS BEEN ALREADY SUBMITTED";
                    }                  
                    btnSaveContinue.Visible = false;

                }
                else
                {
                    appsubmit.Visible = false;
                    btnSaveContinue.Visible = true;
                }

                if (Session["LoginId"] == null)
                {
                    Response.Redirect("error.aspx");
                }

               

            }
            
        }


        protected void GenerateBarcode(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT ur.UserName, ur.NEETRollNumber, a.ApplicationNumber " +
                                   "FROM UserRegister ur " +
                                   "JOIN Applications a ON ur.LoginId = a.LoginId " +
                                   "WHERE ur.LoginId = @LoginId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // Extract details from the database
                            string userName = dr["UserName"].ToString().Trim();
                            string neetRollNumber = dr["NEETRollNumber"].ToString().Trim();
                            string applicationNumber = dr["ApplicationNumber"].ToString().Trim();

                            // Barcode data is the application number
                            string barcodeData = String.Format("{0}", applicationNumber);


                            // Generate the barcode without human-readable text
                            BarcodeWriter barcodeWriter = new BarcodeWriter
                            {
                                Format = BarcodeFormat.CODE_128,
                                Options = new ZXing.Common.EncodingOptions
                                {
                                    Height = 50,  // Height of the barcode
                                    Width = 300,  // Width of the barcode
                                    Margin = 10   // Margin around the barcode
                                }
                            };

                            // Create a custom renderer to disable human-readable text
                            barcodeWriter.Renderer = new ZXing.Rendering.BitmapRenderer
                            {
                                Foreground = System.Drawing.Color.Black,    // Barcode lines color
                                Background = System.Drawing.Color.White,   // Background color
                                                                           // Disable text rendering
                                TextFont = new Font("Arial", 1)   // Small font size, essentially removes text
                            };

                            // Generate the barcode image
                            Bitmap barcodeBitmap = barcodeWriter.Write(barcodeData);

                            // Save the barcode image to a MemoryStream
                            using (MemoryStream ms = new MemoryStream())
                            {
                                barcodeBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                ms.Seek(0, SeekOrigin.Begin);

                                // Set the barcode image to the Image control
                                imgBarcode.ImageUrl = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray()));

                            }
                        }
                    }
                    else
                    {
                        // Handle case where no user is found
                        string barcodeData = "User not found";
                        BarcodeWriter barcodeWriter = new BarcodeWriter
                        {
                            Format = BarcodeFormat.CODE_128,
                            Options = new ZXing.Common.EncodingOptions
                            {
                                Height = 50,
                                Width = 300,
                                Margin = 10
                            }
                        };

                        Bitmap barcodeBitmap = barcodeWriter.Write(barcodeData);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            barcodeBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            ms.Seek(0, SeekOrigin.Begin);
                            imgBarcode.ImageUrl = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray()));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error generating barcode: " + ex.Message + "');</script>");
            }
        }


        protected void load_session_one(string loginId)
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

                            //   checkbox1.Checked = Convert.ToBoolean(dr["CHECKBOX1"]);

                            if (Convert.ToBoolean(dr["CHECKBOX1"]) == true)
                            {
                                Session["CHECKBOXONE"] = true;
                            }
                            else
                            {
                                Session["CHECKBOXONE"] = false;
                            }



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

      

        protected void loadapplicationnumber(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT * FROM Applications WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            appno.InnerHtml = dr["ApplicationNumber"].ToString().Trim();
                            

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

                            app1a.InnerHtml = dr["HSCRollNumber"].ToString().Trim().ToUpper();
                            app1b.InnerHtml = dr["QualifiedYear"].ToString().Trim().ToUpper();
                            app2.InnerHtml = dr["UserName"].ToString().Trim().ToUpper();
                            app4.InnerHtml = dr["DateOfBirth"].ToString().Trim().ToUpper();
                            app5.InnerHtml = dr["Gender"].ToString().Trim().ToUpper();

                            neetregno.InnerHtml = dr["NEETRegNumber"].ToString().Trim().ToUpper();
                            neetrollno.InnerHtml = dr["NEETRollNumber"].ToString().Trim().ToUpper();
                            neetmarks.InnerHtml = dr["NEETMarks"].ToString().Trim().ToUpper();



                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


       
        protected void load_14_18(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = @"
                SELECT 
                    spl.*, 
                    q.QualifyingExaminationName, 
                    b.BoardOfExaminationName, 
                    c.CourseName
                FROM SpecialReservation spl
                LEFT JOIN QualifyingExamination q ON spl.QualifyingExamination = q.QualifyingExaminationId
                LEFT JOIN BoardOfExamination b ON spl.BoardOfExamination = b.BoardOfExaminationId
                LEFT JOIN Courses c ON spl.NameOfTheCourse = c.CourseId
                WHERE spl.LoginId = @LoginId"; // Corrected alias for the LoginId

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // Set other fields
                            app14a.InnerHtml = dr["EXservicemen"].ToString().Trim().ToUpper();
                            app14b.InnerHtml = dr["DifferentlyAbledPerson"].ToString().Trim().ToUpper();
                            app14c.InnerHtml = dr["EminentSportsPerson"].ToString().Trim().ToUpper();
                            app15.InnerHtml = dr["QualifyingExaminationName"].ToString().Trim().ToUpper();
                            app16.InnerHtml = dr["HSCgroupcode"].ToString().Trim().ToUpper();

                            // Correctly display board of examination name
                            if (dr["BoardOfExamination"].ToString().Trim() == "14")
                            {
                                app17.InnerHtml = dr["BoardOfExaminationOthers"].ToString().Trim().ToUpper();
                            }
                            else
                            {
                                app17.InnerHtml = dr["BoardOfExaminationName"].ToString().Trim().ToUpper();
                            }

                            app18.InnerHtml = dr["CoursesUndergoingCompleted"].ToString().Trim().ToUpper();

                            // Handle Name of the Course (if "7", show "Other Course")
                            if (dr["NameOfTheCourse"].ToString().Trim() == "7")
                            {
                                app18a.InnerHtml = dr["NameOfTheOtherCourse"].ToString().Trim().ToUpper();
                            }
                            else
                            {
                                app18a.InnerHtml = dr["CourseName"].ToString().Trim().ToUpper(); // Corrected column name
                            }

                            app18b.InnerHtml = dr["YearOfCompletion"].ToString().Trim().ToUpper();

                            // If no courses are completed, set NA
                            if (dr["CoursesUndergoingCompleted"].ToString().Trim() == "No")
                            {
                                app18a.InnerHtml = "-- NA --";
                                app18b.InnerHtml = "-- NA --";
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




        protected void load_19_23(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = @"
                SELECT 
                    A.NumberOfHSCAttempt,
                    A.MediumOfInstruction,
                    A.CivicSchool,
                    A.CivicNative,
                    A.GovtSchool,
                    A.RTE,
                    M.MediumOfInstructionName,
                    C.CivicSchoolName,
                    N.CivicNativeName
                FROM AcademicAndSchooling A
                LEFT JOIN MediumOfInstruction M ON A.MediumOfInstruction = M.MediumOfInstructionId
                LEFT JOIN CivicSchool C ON A.CivicSchool = C.CivicSchoolId
                LEFT JOIN CivicNative N ON A.CivicNative = N.CivicNativeId
                WHERE A.LoginId = @LoginId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            app19.InnerHtml = dr["NumberOfHSCAttempt"].ToString().Trim().ToUpper();
                            app21.InnerHtml = dr["MediumOfInstructionName"].ToString().Trim().ToUpper();  // Fetching the descriptive name
                            app22.InnerHtml = dr["CivicSchoolName"].ToString().Trim().ToUpper();          // Fetching the descriptive name
                            app23.InnerHtml = dr["CivicNativeName"].ToString().Trim().ToUpper();          // Fetching the descriptive name

                            appgovtschool.InnerHtml = dr["GovtSchool"].ToString().Trim().ToUpper();
                            apprte.InnerHtml = dr["RTE"].ToString().Trim().ToUpper();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }

     

        //protected void load_physics_chemistry(string loginId)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(strcon))
        //        {
        //            // Corrected SQL query with proper joins
        //            string query = @"
        //        SELECT 
        //            pc.PHYSICSSUBJECT, 
        //            pc.RNPHY, 
        //            mop1.MonthNames AS MonthNamesPHY, 
        //            pc.YOPPHY, 
        //            marks1.MaxMark AS MaxMarkPHY, 
        //            pc.OBTMARKSPHY, 
        //            pc.CHEMISTRYSUBJECT, 
        //            pc.RNCHE, 
        //            mop2.MonthNames AS MonthNamesCHE, 
        //            pc.YOPCHE, 
        //            marks2.MaxMark AS MaxMarkCHE, 
        //            pc.OBTMARKSCHE
        //        FROM PhysicsChemistry pc
        //        LEFT JOIN Months mop1 ON pc.MOPPHY = mop1.MonthId
        //        LEFT JOIN Months mop2 ON pc.MOPCHE = mop2.MonthId
        //        LEFT JOIN MaxMarks marks1 ON pc.MAXMARKSPHY = marks1.MaxMarksId
        //        LEFT JOIN MaxMarks marks2 ON pc.MAXMARKSCHE = marks2.MaxMarksId
        //        WHERE pc.LoginId = @LoginId";

        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.AddWithValue("@LoginId", loginId);

        //            con.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();

        //            if (dr.HasRows)
        //            {
        //                while (dr.Read())
        //                {
        //                    // For Physics Subject Data
        //                    phy.InnerHtml = dr["PHYSICSSUBJECT"].ToString().Trim().ToUpper();
        //                    rnphy.InnerHtml = dr["RNPHY"].ToString().Trim().ToUpper();
        //                    mopphy.InnerHtml = dr["MonthNamesPHY"].ToString().Trim().ToUpper();
        //                    yopphy.InnerHtml = dr["YOPPHY"].ToString().Trim().ToUpper();
        //                    maxphy.InnerHtml = dr["MaxMarkPHY"].ToString().Trim().ToUpper();
        //                    obtphy.InnerHtml = dr["OBTMARKSPHY"].ToString().Trim().ToUpper();

        //                    // For Chemistry Subject Data
        //                    che.InnerHtml = dr["CHEMISTRYSUBJECT"].ToString().Trim().ToUpper();
        //                    rnche.InnerHtml = dr["RNCHE"].ToString().Trim().ToUpper();
        //                    mopche.InnerHtml = dr["MonthNamesCHE"].ToString().Trim().ToUpper();
        //                    yopche.InnerHtml = dr["YOPCHE"].ToString().Trim().ToUpper();
        //                    maxche.InnerHtml = dr["MaxMarkCHE"].ToString().Trim().ToUpper();
        //                    obtche.InnerHtml = dr["OBTMARKSCHE"].ToString().Trim().ToUpper();
        //                }
        //            }
        //            else
        //            {
        //                // Handle the case where no data is found (optional)
        //                Response.Write("<script> alert('No data found for the selected LoginId.') </script>");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert('" + ex.Message + "') </script>");
        //    }
        //}


        protected void load_studentmarkdetails(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // Corrected SQL query with all required fields
                    string query = @"
                SELECT 
                    smd.PHYSICSSUBJECT, 
                    smd.RNPHY, 
                    mop1.MonthNames AS MonthNamesPHY, 
                    smd.YOPPHY, 
                    marks1.MaxMark AS MaxMarkPHY, 
                    smd.OBTMARKSPHY, 
                    
                    smd.CHEMISTRYSUBJECT, 
                    smd.RNCHE, 
                    mop2.MonthNames AS MonthNamesCHE, 
                    smd.YOPCHE, 
                    marks2.MaxMark AS MaxMarkCHE, 
                    smd.OBTMARKSCHE, 
                    
                    smd.BOTANYSUBJECT, 
                    smd.RNBOT, 
                    mop3.MonthNames AS MonthNamesBOT, 
                    smd.YOPBOT, 
                    marks3.MaxMark AS MaxMarkBOT, 
                    smd.OBTMARKSBOT, 
                    
                    smd.ZOOLOGYSUBJECT, 
                    smd.RNZOO, 
                    mop4.MonthNames AS MonthNamesZOO, 
                    smd.YOPZOO, 
                    marks4.MaxMark AS MaxMarkZOO, 
                    smd.OBTMARKSZOO, 
                    
                    smd.BIOLOGYSUBJECT, 
                    smd.RNBIO, 
                    mop5.MonthNames AS MonthNamesBIO, 
                    smd.YOPBIO, 
                    marks5.MaxMark AS MaxMarkBIO, 
                    smd.OBTMARKSBIO, 
                    
                    smd.MATHSOTHERSSUBJECT, 
                    smd.RNMATOTH, 
                    mop6.MonthNames AS MonthNamesMATOTH, 
                    smd.YOPMATOTH, 
                    marks6.MaxMark AS MaxMarkMATOTH, 
                    smd.OBTMARKSMATOTH 
                    
                FROM StudentMarkDetails smd
                LEFT JOIN Months mop1 ON smd.MOPPHY = mop1.MonthId
                LEFT JOIN Months mop2 ON smd.MOPCHE = mop2.MonthId
                LEFT JOIN Months mop3 ON smd.MOPBOT = mop3.MonthId
                LEFT JOIN Months mop4 ON smd.MOPZOO = mop4.MonthId
                LEFT JOIN Months mop5 ON smd.MOPBIO = mop5.MonthId
                LEFT JOIN Months mop6 ON smd.MOPMATOTH = mop6.MonthId
                
                LEFT JOIN MaxMarks marks1 ON smd.MAXMARKSPHY = marks1.MaxMarksId
                LEFT JOIN MaxMarks marks2 ON smd.MAXMARKSCHE = marks2.MaxMarksId
                LEFT JOIN MaxMarks marks3 ON smd.MAXMARKSBOT = marks3.MaxMarksId
                LEFT JOIN MaxMarks marks4 ON smd.MAXMARKSZOO = marks4.MaxMarksId
                LEFT JOIN MaxMarks marks5 ON smd.MAXMARKSBIO = marks5.MaxMarksId
                LEFT JOIN MaxMarks marks6 ON smd.MAXMARKSMATOTH = marks6.MaxMarksId
                
                WHERE smd.LoginId = @LoginId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // Physics
                            phy.InnerHtml = dr["PHYSICSSUBJECT"].ToString().Trim().ToUpper();
                            rnphy.InnerHtml = dr["RNPHY"].ToString().Trim().ToUpper();
                            mopphy.InnerHtml = dr["MonthNamesPHY"].ToString().Trim().ToUpper();
                            yopphy.InnerHtml = dr["YOPPHY"].ToString().Trim().ToUpper();
                            maxphy.InnerHtml = dr["MaxMarkPHY"].ToString().Trim().ToUpper();
                            obtphy.InnerHtml = dr["OBTMARKSPHY"].ToString().Trim().ToUpper();

                            double dchk;
                            int ichk;
                            dchk = Convert.ToDouble(dr["OBTMARKSPHY"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                obtphy.InnerHtml = Convert.ToInt32(dr["OBTMARKSPHY"]).ToString();
                            else
                                obtphy.InnerHtml = Convert.ToDecimal(dr["OBTMARKSPHY"]).ToString();

                            // Chemistry
                            che.InnerHtml = dr["CHEMISTRYSUBJECT"].ToString().Trim().ToUpper();
                            rnche.InnerHtml = dr["RNCHE"].ToString().Trim().ToUpper();
                            mopche.InnerHtml = dr["MonthNamesCHE"].ToString().Trim().ToUpper();
                            yopche.InnerHtml = dr["YOPCHE"].ToString().Trim().ToUpper();
                            maxche.InnerHtml = dr["MaxMarkCHE"].ToString().Trim().ToUpper();
                            obtche.InnerHtml = dr["OBTMARKSCHE"].ToString().Trim().ToUpper();

                            dchk = Convert.ToDouble(dr["OBTMARKSCHE"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                obtche.InnerHtml = Convert.ToInt32(dr["OBTMARKSCHE"]).ToString();
                            else
                                obtche.InnerHtml = Convert.ToDecimal(dr["OBTMARKSCHE"]).ToString();

                            // Botany
                            bot.InnerHtml = dr["BOTANYSUBJECT"].ToString().Trim().ToUpper();
                            rnbot.InnerHtml = dr["RNBOT"].ToString().Trim().ToUpper();
                            mopbot.InnerHtml = dr["MonthNamesBOT"].ToString().Trim().ToUpper();
                            yopbot.InnerHtml = dr["YOPBOT"].ToString().Trim().ToUpper();
                            maxbot.InnerHtml = dr["MaxMarkBOT"].ToString().Trim().ToUpper();
                            obtbot.InnerHtml = dr["OBTMARKSBOT"].ToString().Trim().ToUpper();

                            dchk = Convert.ToDouble(dr["OBTMARKSBOT"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                obtbot.InnerHtml = Convert.ToInt32(dr["OBTMARKSBOT"]).ToString();
                            else
                                obtbot.InnerHtml = Convert.ToDecimal(dr["OBTMARKSBOT"]).ToString();

                            // Zoology
                            zoo.InnerHtml = dr["ZOOLOGYSUBJECT"].ToString().Trim().ToUpper();
                            rnzoo.InnerHtml = dr["RNZOO"].ToString().Trim().ToUpper();
                            mopzoo.InnerHtml = dr["MonthNamesZOO"].ToString().Trim().ToUpper();
                            yopzoo.InnerHtml = dr["YOPZOO"].ToString().Trim().ToUpper();
                            maxzoo.InnerHtml = dr["MaxMarkZOO"].ToString().Trim().ToUpper();
                            obtzoo.InnerHtml = dr["OBTMARKSZOO"].ToString().Trim().ToUpper();

                            dchk = Convert.ToDouble(dr["OBTMARKSZOO"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                obtzoo.InnerHtml = Convert.ToInt32(dr["OBTMARKSZOO"]).ToString();
                            else
                                obtzoo.InnerHtml = Convert.ToDecimal(dr["OBTMARKSZOO"]).ToString();

                            // Biology
                            bio.InnerHtml = dr["BIOLOGYSUBJECT"].ToString().Trim().ToUpper();
                            rnbio.InnerHtml = dr["RNBIO"].ToString().Trim().ToUpper();
                            mopbio.InnerHtml = dr["MonthNamesBIO"].ToString().Trim().ToUpper();
                            yopbio.InnerHtml = dr["YOPBIO"].ToString().Trim().ToUpper();
                            maxbio.InnerHtml = dr["MaxMarkBIO"].ToString().Trim().ToUpper();
                            obtbio.InnerHtml = dr["OBTMARKSBIO"].ToString().Trim().ToUpper();

                            dchk = Convert.ToDouble(dr["OBTMARKSBIO"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                obtbio.InnerHtml = Convert.ToInt32(dr["OBTMARKSBIO"]).ToString();
                            else
                                obtbio.InnerHtml = Convert.ToDecimal(dr["OBTMARKSBIO"]).ToString();

                            // Maths/Others
                            matoth.InnerHtml = dr["MATHSOTHERSSUBJECT"].ToString().Trim().ToUpper();
                            rnmatoth.InnerHtml = dr["RNMATOTH"].ToString().Trim().ToUpper();
                            mopmatoth.InnerHtml = dr["MonthNamesMATOTH"].ToString().Trim().ToUpper();
                            yopmatoth.InnerHtml = dr["YOPMATOTH"].ToString().Trim().ToUpper();
                            maxmatoth.InnerHtml = dr["MaxMarkMATOTH"].ToString().Trim().ToUpper();
                            obtmatoth.InnerHtml = dr["OBTMARKSMATOTH"].ToString().Trim().ToUpper();

                            dchk = Convert.ToDouble(dr["OBTMARKSMATOTH"]);
                            ichk = Convert.ToInt32(dchk);
                            if (ichk == dchk)
                                obtmatoth.InnerHtml = Convert.ToInt32(dr["OBTMARKSMATOTH"]).ToString();
                            else
                                obtmatoth.InnerHtml = Convert.ToDecimal(dr["OBTMARKSMATOTH"]).ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script> alert('No data found for the selected LoginId.') </script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }



        //protected void load_botany_zoology(string loginId)
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
        //                    bot.InnerHtml = dr["BOTANYSUBJECT"].ToString().Trim().ToUpper();
        //                    rnbot.InnerHtml = dr["RNBOT"].ToString().Trim().ToUpper();
        //                    mopbot.InnerHtml = dr["MOPBOT"].ToString().Trim().ToUpper();
        //                    yopbot.InnerHtml = dr["YOPBOT"].ToString().Trim().ToUpper();
        //                    maxbot.InnerHtml = dr["MAXMARKSBOT"].ToString().Trim().ToUpper();
        //                    obtbot.InnerHtml = dr["OBTMARKSBOT"].ToString().Trim().ToUpper();

        //                    zoo.InnerHtml = dr["ZOOLOGYSUBJECT"].ToString().Trim().ToUpper();
        //                    rnzoo.InnerHtml = dr["RNZOO"].ToString().Trim().ToUpper();
        //                    mopzoo.InnerHtml = dr["MOPZOO"].ToString().Trim().ToUpper();
        //                    yopzoo.InnerHtml = dr["YOPZOO"].ToString().Trim().ToUpper();
        //                    maxzoo.InnerHtml = dr["MAXMARKSZOO"].ToString().Trim().ToUpper();
        //                    obtzoo.InnerHtml = dr["OBTMARKSZOO"].ToString().Trim().ToUpper();




        //                }
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert('" + ex.Message + "') </script>");
        //    }
        //}


        //protected void load_biology_mathematics(string loginId)
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
        //                    bio.InnerHtml = dr["BIOLOGYSUBJECT"].ToString().Trim().ToUpper();
        //                    rnbio.InnerHtml = dr["RNBIO"].ToString().Trim().ToUpper();
        //                    mopbio.InnerHtml = dr["MOPBIO"].ToString().Trim().ToUpper();
        //                    yopbio.InnerHtml = dr["YOPBIO"].ToString().Trim().ToUpper();
        //                    maxbio.InnerHtml = dr["MAXMARKSBIO"].ToString().Trim().ToUpper();
        //                    obtbio.InnerHtml = dr["OBTMARKSBIO"].ToString().Trim().ToUpper();

        //                    matoth.InnerHtml = dr["MATHSOTHERSSUBJECT"].ToString().Trim().ToUpper();
        //                    rnmatoth.InnerHtml = dr["RNMATOTH"].ToString().Trim().ToUpper();
        //                    mopmatoth.InnerHtml = dr["MOPMATOTH"].ToString().Trim().ToUpper();
        //                    yopmatoth.InnerHtml = dr["YOPMATOTH"].ToString().Trim().ToUpper();
        //                    maxmatoth.InnerHtml = dr["MAXMARKSMATOTH"].ToString().Trim().ToUpper();
        //                    obtmatoth.InnerHtml = dr["OBTMARKSMATOTH"].ToString().Trim().ToUpper();



                           

        //                }
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert('" + ex.Message + "') </script>");
        //    }
        //}


        protected void load_study_details(string loginId)
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

                            yop6.InnerHtml = dr["YOP6"].ToString().Trim().ToUpper();
                            nots6.InnerHtml = dr["NOTS6"].ToString().Trim().ToUpper();
                            s6.InnerHtml = dr["STATE6"].ToString().Trim().ToUpper();
                            d6.InnerHtml = dr["DISTRICT6"].ToString().Trim().ToUpper();

                            yop7.InnerHtml = dr["YOP7"].ToString().Trim().ToUpper();
                            nots7.InnerHtml = dr["NOTS7"].ToString().Trim().ToUpper();
                            s7.InnerHtml = dr["STATE7"].ToString().Trim().ToUpper();
                            d7.InnerHtml = dr["DISTRICT7"].ToString().Trim().ToUpper();

                            yop8.InnerHtml = dr["YOP8"].ToString().Trim().ToUpper();
                            nots8.InnerHtml = dr["NOTS8"].ToString().Trim().ToUpper();
                            s8.InnerHtml = dr["STATE8"].ToString().Trim().ToUpper();
                            d8.InnerHtml = dr["DISTRICT8"].ToString().Trim().ToUpper();

                            yop9.InnerHtml = dr["YOP9"].ToString().Trim().ToUpper();
                            nots9.InnerHtml = dr["NOTS9"].ToString().Trim().ToUpper();
                            s9.InnerHtml = dr["STATE9"].ToString().Trim().ToUpper();
                            d9.InnerHtml = dr["DISTRICT9"].ToString().Trim().ToUpper();

                            yop10.InnerHtml = dr["YOP10"].ToString().Trim().ToUpper();
                            nots10.InnerHtml = dr["NOTS10"].ToString().Trim().ToUpper();
                            s10.InnerHtml = dr["STATE10"].ToString().Trim().ToUpper();
                            d10.InnerHtml = dr["DISTRICT10"].ToString().Trim().ToUpper();

                            yop11.InnerHtml = dr["YOP11"].ToString().Trim().ToUpper();
                            nots11.InnerHtml = dr["NOTS11"].ToString().Trim().ToUpper();
                            s11.InnerHtml = dr["STATE11"].ToString().Trim().ToUpper();
                            d11.InnerHtml = dr["DISTRICT11"].ToString().Trim().ToUpper();

                            yop12.InnerHtml = dr["YOP12"].ToString().Trim().ToUpper();
                            nots12.InnerHtml = dr["NOTS12"].ToString().Trim().ToUpper();
                            s12.InnerHtml = dr["STATE12"].ToString().Trim().ToUpper();
                            d12.InnerHtml = dr["DISTRICT12"].ToString().Trim().ToUpper();










                           




                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void load_6_13(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = @"
                SELECT 
                    p.*, 
                    n.NationalityName, 
                    r.ReligionName, 
                    m.MotherTongueName, 
                    nat.NativityName, 
                    c.CommunityName, 
                    caste.CasteName
                FROM PersonalInformation p
                LEFT JOIN Nationality n ON p.Nationality = n.NationalityId
                LEFT JOIN Religion r ON p.Religion = r.ReligionId
                LEFT JOIN MotherTongue m ON p.MotherTongue = m.MotherTongueId
                LEFT JOIN Nativity nat ON p.Nativity = nat.NativityId
                LEFT JOIN Community c ON p.Community = c.CommunityId
                LEFT JOIN Caste caste ON p.CasteWithSubCode = caste.CasteId
                WHERE p.LoginId = @LoginId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            app3.InnerHtml = dr["NameOfTheParent"].ToString().Trim().ToUpper();
                            app6.InnerHtml = dr["NationalityName"].ToString().Trim().ToUpper();
                            app7.InnerHtml = dr["ReligionName"].ToString().Trim().ToUpper();
                            app8.InnerHtml = dr["MotherTongueName"].ToString().Trim().ToUpper();
                            app9.InnerHtml = dr["NativityName"].ToString().Trim().ToUpper();
                            app10.InnerHtml = dr["CommunityName"].ToString().Trim().ToUpper();
                            app12.InnerHtml = dr["CasteName"].ToString().Trim().ToUpper();

                            if (dr["Community"].ToString().Trim() == "1")
                            {
                                app13a.InnerHtml = "-- NA --";
                                app13b.InnerHtml = "-- NA --";
                                app13c.InnerHtml = "-- NA --";
                                app13d.InnerHtml = "-- NA --";
                            }
                            else
                            {
                                app13a.InnerHtml = dr["CertificateNumber"].ToString().Trim().ToUpper();
                                app13b.InnerHtml = dr["IssuedTaluk"].ToString().Trim().ToUpper();
                                app13c.InnerHtml = dr["IssuedBy"].ToString().Trim().ToUpper();
                                app13d.InnerHtml = dr["IssuedDate"].ToString().Trim().ToUpper();
                            }

                            app11.InnerHtml = dr["SchoolingStudied"].ToString().Trim().ToUpper();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }



        protected void load_25_34(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = @"
            SELECT 
                ai.LoginId,
                ai.FGApplicant,
                po.ParentsOccupationName, 
                inco.AnnualIncomeRange, 
                s.StateName AS NativeStateName, 
                d.DistrictName AS NativeDistrictName,
                ai.IdentificationMarks,
                ai.AadharNumber,
                ai.EmailId,
                ai.PhoneNumber,
                ai.AddressForCorrespondence
            FROM AdditionalInformation ai
            LEFT JOIN ParentsOccupation po ON ai.ParentOccupation = po.ParentsOccupationId
            LEFT JOIN AnnualIncome inco ON ai.ParentAnnualIncome = inco.AnnualIncomeId
            LEFT JOIN States s ON ai.NativeState = s.StateId
            LEFT JOIN District d ON ai.NativeDistrict = d.DistrictId
            WHERE ai.LoginId = @LoginId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            app25.InnerHtml = dr["FGApplicant"].ToString().Trim().ToUpper();
                            app26.InnerHtml = dr["ParentsOccupationName"].ToString().Trim().ToUpper();
                            app27.InnerHtml = dr["AnnualIncomeRange"].ToString().Trim().ToUpper();
                            app28.InnerHtml = dr["AddressForCorrespondence"].ToString().Trim().ToUpper();
                            app29.InnerHtml = dr["NativeDistrictName"].ToString().Trim().ToUpper();
                            app30.InnerHtml = dr["NativeStateName"].ToString().Trim().ToUpper();
                            app31.InnerHtml = dr["IdentificationMarks"].ToString().Trim().ToUpper();
                            app32.InnerHtml = dr["AadharNumber"].ToString().Trim().ToUpper();
                            app33.InnerHtml = dr["EmailId"].ToString().Trim().ToUpper();
                            app34.InnerHtml = dr["PhoneNumber"].ToString().Trim().ToUpper();
                        }
                    }
                    else
                    {
                        Response.Write("<script> alert('No data found for this LoginId') </script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message.Replace("'", "\\'") + "') </script>");
            }
        }




        protected void load_userimage(string loginId)
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
                        userimage.Src = ResolveUrl("~/pictures/logo.png"); // Set a default image if no file found

                       
                    }




                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void load_signimage(string loginId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT PathOfTheFile FROM SignatureOfTheApplicantFilesUpload WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    string imagePath = cmd.ExecuteScalar() as string;
                    con.Close();

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        signimage.Src = ResolveUrl(imagePath); // Set the image `src` attribute

                       

                    }
                    else
                    {
                        signimage.Src = ResolveUrl("~/pictures/logo.png"); // Set a default image if no file found


                        
                    }




                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


        protected void btnGoToSubmitPage_Click(object sender, EventArgs e)
        {
            Session["ApplicationPreviewComplete"] = true;

            setuserstatus();

            Response.Redirect("AppSubmit.aspx");
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

                    if (currentPageStatus <= 6)
                    {
                        query = "UPDATE UserProgress SET PageStatus = 6 WHERE LoginId = @LoginId";

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

    }
}