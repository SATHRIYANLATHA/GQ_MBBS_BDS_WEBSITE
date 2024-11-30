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

namespace mbbs_MBBS_BDS_WEBSITE
{
    public partial class pdfdownload : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            String loginId = Session["LoginId"] as string;

            load_session_one(loginId);
            load_session_two(loginId);

            loadapplicationnumber(loginId);

            load_1_5(loginId);
            load_6_13(loginId);
            load_14_18(loginId);
            load_19_23(loginId);
            load_25_34(loginId);

            load_userimage(loginId);
            load_signimage(loginId);

            load_physics_chemistry(loginId);
            load_botany_zoology(loginId);
            load_biology_mathematics(loginId);
            load_study_details(loginId);


            GenerateBarcode(loginId);





            if (Session["CHECKBOXONE"] != null && (bool)Session["CHECKBOXONE"] == true)
            {
                priBOTANY.Visible = true;
                priZOOLOGY.Visible = true;
            }
            else
            {
                priBOTANY.Visible = false;
                priZOOLOGY.Visible = false;
            }

            if (Session["CHECKBOXTWO"] != null && (bool)Session["CHECKBOXTWO"] == true)
            {
                priBIOLOGY.Visible = true;
                priMATHSOTHERS.Visible = true;
            }
            else
            {
                priBIOLOGY.Visible = false;
                priMATHSOTHERS.Visible = false;
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
                                priimgBarcode.ImageUrl = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray()));

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
                            priimgBarcode.ImageUrl = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray()));

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
                            prino.InnerHtml = dr["ApplicationNumber"].ToString().Trim();


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

                            pri1a.InnerHtml = dr["HSCRollNumber"].ToString().Trim().ToUpper();
                            pri1b.InnerHtml = dr["QualifiedYear"].ToString().Trim().ToUpper();
                            pri2.InnerHtml = dr["UserName"].ToString().Trim().ToUpper();
                            pri4.InnerHtml = dr["DateOfBirth"].ToString().Trim().ToUpper();
                            pri5.InnerHtml = dr["Gender"].ToString().Trim().ToUpper();

                            prineetregno.InnerHtml = dr["NEETRollNumber"].ToString().Trim().ToUpper();
                            prineetrollno.InnerHtml = dr["NEETRegNumber"].ToString().Trim().ToUpper();
                            prineetmarks.InnerHtml = dr["NEETMarks"].ToString().Trim().ToUpper();

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
                    string query = "SELECT * FROM PersonalInformation WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            pri3.InnerHtml = dr["NameOfTheParent"].ToString().Trim().ToUpper();
                            pri6.InnerHtml = dr["Nationality"].ToString().Trim().ToUpper();
                            pri7.InnerHtml = dr["Religion"].ToString().Trim().ToUpper().ToUpper();
                            pri8.InnerHtml = dr["MotherTongue"].ToString().Trim().ToUpper();
                            pri9.InnerHtml = dr["Nativity"].ToString().Trim().ToUpper();
                            pri10.InnerHtml = dr["Community"].ToString().Trim().ToUpper();
                            pri11.InnerHtml = dr["SchoolingStudied"].ToString().Trim().ToUpper();

                            string casteWithSubCode = dr["CasteWithSubCode"].ToString().Trim().ToUpper();
                            int index = casteWithSubCode.IndexOf('(');
                            if (index > 0)
                            {
                                casteWithSubCode = casteWithSubCode.Substring(0, index).Trim();
                            }
                            pri12.InnerHtml = casteWithSubCode;

                            pri13a.InnerHtml = dr["CertificateNumber"].ToString().Trim().ToUpper();
                            pri13b.InnerHtml = dr["IssuedTaluk"].ToString().Trim().ToUpper();
                            pri13c.InnerHtml = dr["IssuedBy"].ToString().Trim().ToUpper();
                            pri13d.InnerHtml = dr["IssuedDate"].ToString().Trim().ToUpper();

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
                    string query = "SELECT * FROM SpecialReservation WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            pri14a.InnerHtml = dr["EXservicemen"].ToString().Trim().ToUpper();
                            pri14b.InnerHtml = dr["DifferentlyAbledPerson"].ToString().Trim().ToUpper();
                            pri14c.InnerHtml = dr["EminentSportsPerson"].ToString().Trim().ToUpper();
                            pri15.InnerHtml = dr["QualifyingExamination"].ToString().Trim().ToUpper();
                            pri16.InnerHtml = dr["HSCgroupcode"].ToString().Trim().ToUpper();
                            pri17.InnerHtml = dr["BoardOfExamination"].ToString().Trim().ToUpper();
                            pri18.InnerHtml = dr["CoursesUndergoingCompleted"].ToString().Trim().ToUpper();

                            if (dr["NameOfTheCourse"].ToString().Trim() == "Others")
                            {
                                pri18a.InnerHtml = dr["NameOfTheOtherCourse"].ToString().Trim().ToUpper();
                            }
                            else
                            {
                                pri18a.InnerHtml = dr["NameOfTheCourse"].ToString().Trim().ToUpper();
                            }

                            pri18b.InnerHtml = dr["YearOfCompletion"].ToString().Trim().ToUpper();



                            if (dr["CoursesUndergoingCompleted"].ToString().Trim() == "No")
                            {
                                pri18a.InnerHtml = "-- NA --";
                                pri18b.InnerHtml = "-- NA --";
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
                    string query = "SELECT * FROM AcademicAndSchooling WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            pri19.InnerHtml = dr["NumberOfHSCAttempt"].ToString().Trim().ToUpper();
                            pri21.InnerHtml = dr["MediumOfInstruction"].ToString().Trim().ToUpper();
                            pri22.InnerHtml = dr["CivicSchool"].ToString().Trim().ToUpper();
                            pri23.InnerHtml = dr["CivicNative"].ToString().Trim().ToUpper();

                            prigovtschool.InnerHtml = dr["GovtSchool"].ToString().Trim().ToUpper();
                            prirte.InnerHtml = dr["RTE"].ToString().Trim().ToUpper();

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
                            priphy.InnerHtml = dr["PHYSICSSUBJECT"].ToString().Trim().ToUpper();
                            prirnphy.InnerHtml = dr["RNPHY"].ToString().Trim().ToUpper();
                            primopphy.InnerHtml = dr["MOPPHY"].ToString().Trim().ToUpper();
                            priyopphy.InnerHtml = dr["YOPPHY"].ToString().Trim().ToUpper();
                            primaxphy.InnerHtml = dr["MAXMARKSPHY"].ToString().Trim().ToUpper();
                            priobtphy.InnerHtml = dr["OBTMARKSPHY"].ToString().Trim().ToUpper();

                            priche.InnerHtml = dr["CHEMISTRYSUBJECT"].ToString().Trim().ToUpper();
                            prirnche.InnerHtml = dr["RNCHE"].ToString().Trim().ToUpper();
                            primopche.InnerHtml = dr["MOPCHE"].ToString().Trim().ToUpper();
                            priyopche.InnerHtml = dr["YOPCHE"].ToString().Trim().ToUpper();
                            primaxche.InnerHtml = dr["MAXMARKSCHE"].ToString().Trim().ToUpper();
                            priobtche.InnerHtml = dr["OBTMARKSCHE"].ToString().Trim().ToUpper();

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
                            pribot.InnerHtml = dr["BOTANYSUBJECT"].ToString().Trim().ToUpper();
                            prirnbot.InnerHtml = dr["RNBOT"].ToString().Trim().ToUpper();
                            primopbot.InnerHtml = dr["MOPBOT"].ToString().Trim().ToUpper();
                            priyopbot.InnerHtml = dr["YOPBOT"].ToString().Trim().ToUpper();
                            primaxbot.InnerHtml = dr["MAXMARKSBOT"].ToString().Trim().ToUpper();
                            priobtbot.InnerHtml = dr["OBTMARKSBOT"].ToString().Trim().ToUpper();

                            prizoo.InnerHtml = dr["ZOOLOGYSUBJECT"].ToString().Trim().ToUpper();
                            prirnzoo.InnerHtml = dr["RNZOO"].ToString().Trim().ToUpper();
                            primopzoo.InnerHtml = dr["MOPZOO"].ToString().Trim().ToUpper();
                            priyopzoo.InnerHtml = dr["YOPZOO"].ToString().Trim().ToUpper();
                            primaxzoo.InnerHtml = dr["MAXMARKSZOO"].ToString().Trim().ToUpper();
                            priobtzoo.InnerHtml = dr["OBTMARKSZOO"].ToString().Trim().ToUpper();

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
                            pribio.InnerHtml = dr["BIOLOGYSUBJECT"].ToString().Trim().ToUpper();
                            prirnbio.InnerHtml = dr["RNBIO"].ToString().Trim().ToUpper();
                            primopbio.InnerHtml = dr["MOPBIO"].ToString().Trim().ToUpper();
                            priyopbio.InnerHtml = dr["YOPBIO"].ToString().Trim().ToUpper();
                            primaxbio.InnerHtml = dr["MAXMARKSBIO"].ToString().Trim().ToUpper();
                            priobtbio.InnerHtml = dr["OBTMARKSBIO"].ToString().Trim().ToUpper();

                            primatoth.InnerHtml = dr["MATHSOTHERSSUBJECT"].ToString().Trim().ToUpper();
                            prirnmatoth.InnerHtml = dr["RNMATOTH"].ToString().Trim().ToUpper();
                            primopmatoth.InnerHtml = dr["MOPMATOTH"].ToString().Trim().ToUpper();
                            priyopmatoth.InnerHtml = dr["YOPMATOTH"].ToString().Trim().ToUpper();
                            primaxmatoth.InnerHtml = dr["MAXMARKSMATOTH"].ToString().Trim().ToUpper();
                            priobtmatoth.InnerHtml = dr["OBTMARKSMATOTH"].ToString().Trim().ToUpper();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
            }
        }


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

                            priyop6.InnerHtml = dr["YOP6"].ToString().Trim().ToUpper();
                            prinots6.InnerHtml = dr["NOTS6"].ToString().Trim().ToUpper();
                            pris6.InnerHtml = dr["STATE6"].ToString().Trim().ToUpper();
                            prid6.InnerHtml = dr["DISTRICT6"].ToString().Trim().ToUpper();

                            priyop7.InnerHtml = dr["YOP7"].ToString().Trim().ToUpper();
                            prinots7.InnerHtml = dr["NOTS7"].ToString().Trim().ToUpper();
                            pris7.InnerHtml = dr["STATE7"].ToString().Trim().ToUpper();
                            prid7.InnerHtml = dr["DISTRICT7"].ToString().Trim().ToUpper();

                            priyop8.InnerHtml = dr["YOP8"].ToString().Trim().ToUpper();
                            prinots8.InnerHtml = dr["NOTS8"].ToString().Trim().ToUpper();
                            pris8.InnerHtml = dr["STATE8"].ToString().Trim().ToUpper();
                            prid8.InnerHtml = dr["DISTRICT8"].ToString().Trim().ToUpper();

                            priyop9.InnerHtml = dr["YOP9"].ToString().Trim().ToUpper();
                            prinots9.InnerHtml = dr["NOTS9"].ToString().Trim().ToUpper();
                            pris9.InnerHtml = dr["STATE9"].ToString().Trim().ToUpper();
                            prid9.InnerHtml = dr["DISTRICT9"].ToString().Trim().ToUpper();

                            priyop10.InnerHtml = dr["YOP10"].ToString().Trim().ToUpper();
                            prinots10.InnerHtml = dr["NOTS10"].ToString().Trim().ToUpper();
                            pris10.InnerHtml = dr["STATE10"].ToString().Trim().ToUpper();
                            prid10.InnerHtml = dr["DISTRICT10"].ToString().Trim().ToUpper();

                            priyop11.InnerHtml = dr["YOP11"].ToString().Trim().ToUpper();
                            prinots11.InnerHtml = dr["NOTS11"].ToString().Trim().ToUpper();
                            pris11.InnerHtml = dr["STATE11"].ToString().Trim().ToUpper();
                            prid11.InnerHtml = dr["DISTRICT11"].ToString().Trim().ToUpper();

                            priyop12.InnerHtml = dr["YOP12"].ToString().Trim().ToUpper();
                            prinots12.InnerHtml = dr["NOTS12"].ToString().Trim().ToUpper();
                            pris12.InnerHtml = dr["STATE12"].ToString().Trim().ToUpper();
                            prid12.InnerHtml = dr["DISTRICT12"].ToString().Trim().ToUpper();

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
                    string query = "SELECT * FROM AdditionalInformation WHERE LoginId=@LoginId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoginId", loginId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            pri25.InnerHtml = dr["FGApplicant"].ToString().Trim().ToUpper();
                            pri26.InnerHtml = dr["ParentOccupation"].ToString().Trim().ToUpper();
                            pri27.InnerHtml = dr["ParentAnnualIncome"].ToString().Trim().ToUpper();
                            pri28.InnerHtml = dr["AddressForCorrespondence"].ToString().Trim().ToUpper();
                            pri29.InnerHtml = dr["NativeDistrict"].ToString().Trim().ToUpper();
                            pri30.InnerHtml = dr["NativeState"].ToString().Trim().ToUpper();
                            pri31.InnerHtml = dr["IdentificationMarks"].ToString().Trim().ToUpper();
                            pri32.InnerHtml = dr["AadharNumber"].ToString().Trim().ToUpper();
                            pri33.InnerHtml = dr["EmailId"].ToString().Trim().ToUpper();
                            pri34.InnerHtml = dr["PhoneNumber"].ToString().Trim().ToUpper();

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "') </script>");
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
                        priuserimage.Src = ResolveUrl(imagePath); // Set the image `src` attribute
                    }
                    else
                    {
                        priuserimage.Src = ResolveUrl("~/pictures/logo.png"); // Set a default image if no file found
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
                        prisignimage.Src = ResolveUrl(imagePath); // Set the image `src` attribute
                    }
                    else
                    {
                        prisignimage.Src = ResolveUrl("~/pictures/logo.png"); // Set a default image if no file found
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