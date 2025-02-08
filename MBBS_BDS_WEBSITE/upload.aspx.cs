using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mbbs_MBBS_BDS_WEBSITE
{
    public partial class upload : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                load_session();

                // EX SERVICEMEN SESSION 

                if (Session["splone"] != null && (bool)Session["splone"] == true)
                {
                    R4.Attributes["style"] = "display:block;";
                }
                else
                {
                    R4.Attributes["style"] = "display:none;";
                }

                // EMINENT SPORTS PERSON SESSION

                if (Session["spltwo"] != null && (bool)Session["spltwo"] == true)
                {
                    R5.Attributes["style"] = "display:block;";
                }
                else
                {
                    R5.Attributes["style"] = "display:none;";
                }

                // DIFFEREN PERSON SESSION

                if (Session["splthree"] != null && (bool)Session["splthree"] == true)
                {
                    R6.Attributes["style"] = "display:block;";
                }
                else
                {
                    R6.Attributes["style"] = "display:none;";
                }



                LoadLeftThumbImpression();  // 1
                LoadPassPortSizePhoto(); // 2
                LoadPostCardSizePhoto(); // 3
                LoadExServicemen();  // 4
                LoadEminentSportsPerson();// 5
                LoadDifferentlyAbledPerson(); // 6
                LoadSSLCMarkSheet(); // 7
                LoadHSCMarkSheet();  // 8
                LoadNEETScoreCard(); // 9
                LoadTransferCertificate(); // 10
                LoadBonafideCertificate(); // 11
                LoadCommunityCertificate(); // 12
                LoadNativityCertificate(); // 13
                LoadParentCommunityCertificate(); // 14
                LoadParentStudyCertificate(); // 15
                LoadParentAddressProof(); // 16
                LoadSignatureOfTheApplicant(); // 17

            }

        }

        protected void load_session()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

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


                            if ((dr["EXservicemen"].ToString().Trim()) == "Yes")
                            {
                                Session["splone"] = true;
                            }
                            else
                            {
                                Session["splone"] = false;
                            }


                            if ((dr["EminentSportsPerson"].ToString().Trim()) == "Yes")
                            {
                                Session["spltwo"] = true;
                            }
                            else
                            {
                                Session["spltwo"] = false;
                            }

                            if ((dr["DifferentlyAbledPerson"].ToString().Trim()) == "Yes")
                            {
                                Session["splthree"] = true;
                            }
                            else
                            {
                                Session["splthree"] = false;
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


        //..........LEFT THUMB IMPRESSION..............  1


        private void LoadLeftThumbImpression()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path for LeftThumb
                            string leftThumbFilePath = string.Format("{0}{1}_LeftThumb", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM LeftThumbImpressionFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success1.Visible = true;
                                error1.Visible = false;
                                success1.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink1.NavigateUrl = ResolveUrl(filePath);
                                HyperLink1.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink1.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink1.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error1.Visible = true;
                error1.InnerHtml = "Error loading user details: " + ex.Message;
                success1.Visible = false;
                HyperLink1.Visible = false;
            }
        }


        protected void btnLeftThumbImpressionUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload1.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload1.PostedFile.ContentType;
                    if (fileContentType == "image/jpeg" &&
                        FileUpload1.PostedFile.ContentLength >= 10240 && // Minimum 10KB
                        FileUpload1.PostedFile.ContentLength <= 51200)  // Maximum 50KB
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension (either .jpeg or .png)
                                string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                                string fileName = string.Format("{0}_LeftThumbImpression{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        error1.Visible = true;
                                        error1.InnerHtml = "Error deleting existing file: " + ex.Message;
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload1.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM LeftThumbImpressionFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE LeftThumbImpressionFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO LeftThumbImpressionFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success1.Visible = true;
                                success1.InnerHtml = "File uploaded successfully.";
                                error1.Visible = false;
                                HyperLink1.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink1.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error1.Visible = true;
                                error1.InnerHtml = "Application number not found.";
                                success1.Visible = false;
                                HyperLink1.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success1.Visible = false;
                        error1.Visible = true;
                        error1.InnerHtml = "Invalid file type or size. Please upload a JPG file between 10KB and 50KB.";
                        HyperLink1.Visible = false;
                    }
                }
                else
                {
                    error1.Visible = true;
                    error1.InnerHtml = "Please select a file to upload.";
                    success1.Visible = false;
                    HyperLink1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error1.Visible = true;
                error1.InnerHtml = "File upload failed: " + ex.Message;
                HyperLink1.Visible = false;
            }
        }





        //.................:   PASS PORT SIZE PHOTO ............................2


        private void LoadPassPortSizePhoto()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_PassPortSizePhoto", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM PassPortSizePhotoFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success2.Visible = true;
                                error2.Visible = false;
                                success2.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink2.NavigateUrl = ResolveUrl(filePath);
                                HyperLink2.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink2.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink2.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error2.Visible = true;
                error2.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success2.Visible = false;
                HyperLink2.Visible = false;
            }
        }

        protected void btnPassPortSizePhotoUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload2.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload2.PostedFile.ContentType;
                    if (fileContentType == "image/jpeg" &&
                        FileUpload2.PostedFile.ContentLength >= 10240 && // Minimum 10KB
                        FileUpload2.PostedFile.ContentLength <= 102400)  // Maximum 50KB
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload2.FileName).ToLower();
                                string fileName = string.Format("{0}_PassPortSizePhoto{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        error2.Visible = true;
                                        error2.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload2.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM PassPortSizePhotoFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE PassPortSizePhotoFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO PassPortSizePhotoFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success2.Visible = true;
                                success2.InnerHtml = "File uploaded successfully.";
                                error2.Visible = false;
                                HyperLink2.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink2.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error2.Visible = true;
                                error2.InnerHtml = "Application number not found.";
                                success2.Visible = false;
                                HyperLink2.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success2.Visible = false;
                        error2.Visible = true;
                        error2.InnerHtml = "Invalid file type or size. Please upload a JPG file between 10KB and 100KB";
                        HyperLink2.Visible = false;
                    }
                }
                else
                {
                    error2.Visible = true;
                    error2.InnerHtml = "Please select a file to upload.";
                    success2.Visible = false;
                    HyperLink2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error2.Visible = true;
                error2.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink2.Visible = false;
            }
        }




        // //.................:   POST CARD SIZE PHOTO ............................3

        private void LoadPostCardSizePhoto()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path
                            string leftThumbFilePath = string.Format("{0}{1}_PostCardSizePhoto", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM PostCardSizePhotoFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success3.Visible = true;
                                error3.Visible = false;
                                success3.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink3.NavigateUrl = ResolveUrl(filePath);
                                HyperLink3.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink3.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink3.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error3.Visible = true;
                error3.InnerHtml = "Error loading user details: " + ex.Message;
                success3.Visible = false;
                HyperLink3.Visible = false;
            }
        }
        protected void btnPostCardSizePhotoUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload3.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload3.PostedFile.ContentType;
                    if (fileContentType == "image/jpeg" &&
                        FileUpload3.PostedFile.ContentLength >= 102400 && // Minimum 10KB
                        FileUpload3.PostedFile.ContentLength <= 307200)  // Maximum 50KB
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload3.FileName).ToLower();
                                string fileName = string.Format("{0}_PostCardSizePhoto{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error3.Visible = true;
                                        error3.InnerHtml = "Error deleting existing file: " + ex.Message;
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload3.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM PostCardSizePhotoFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE PostCardSizePhotoFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO PostCardSizePhotoFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success3.Visible = true;
                                success3.InnerHtml = "File uploaded successfully.";
                                error3.Visible = false;
                                HyperLink3.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink3.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error3.Visible = true;
                                error3.InnerHtml = "Application number not found.";
                                success3.Visible = false;
                                HyperLink3.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success3.Visible = false;
                        error3.Visible = true;
                        error3.InnerHtml = "Invalid file type or size. Please upload a JPG file between 100KB and 300KB";
                        HyperLink3.Visible = false;
                    }
                }
                else
                {
                    error3.Visible = true;
                    error3.InnerHtml = "Please select a file to upload.";
                    success3.Visible = false;
                    HyperLink3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error3.Visible = true;
                error3.InnerHtml = "File upload failed: " + ex.Message;
                HyperLink3.Visible = false;
            }
        }





        //..................... EX SERVICEMEN ............................4
        private void LoadExServicemen()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_ExServicemen", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM ExServicemenFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success4.Visible = true;
                                error4.Visible = false;
                                success4.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink4.NavigateUrl = ResolveUrl(filePath);
                                HyperLink4.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink4.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink4.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink4.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error4.Visible = true;
                error4.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success4.Visible = false;
                HyperLink4.Visible = false;
            }
        }

        protected void btnExServicemenUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload4.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload4.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload4.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload4.FileName).ToLower();
                                string fileName = string.Format("{0}_ExServicemen{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        error4.Visible = true;
                                        error4.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload4.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM ExServicemenFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE ExServicemenFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO ExServicemenFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success4.Visible = true;
                                success4.InnerHtml = "File uploaded successfully.";
                                error4.Visible = false;
                                HyperLink4.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink4.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error4.Visible = true;
                                error4.InnerHtml = "Application number not found.";
                                success4.Visible = false;
                                HyperLink4.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success4.Visible = false;
                        error4.Visible = true;
                        error4.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink4.Visible = false;
                    }
                }
                else
                {
                    error4.Visible = true;
                    error4.InnerHtml = "Please select a file to upload.";
                    success4.Visible = false;
                    HyperLink4.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error4.Visible = true;
                error4.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink4.Visible = false;
            }
        }





        //..................... EMINENT SPORTS PERSON  ............................5
        private void LoadEminentSportsPerson()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            string leftThumbFilePath = string.Format("{0}{1}_EminentSportsPerson", folderPath, applicationNumber);

                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM EminentSportsPersonFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success5.Visible = true;
                                error5.Visible = false;
                                success5.InnerHtml = "File already uploaded.";
                                HyperLink5.NavigateUrl = ResolveUrl(filePath);
                                HyperLink5.Visible = true;
                            }
                            else
                            {
                                HyperLink5.Visible = false;
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink5.Visible = false;
                        }
                    }
                }
                else
                {
                    HyperLink5.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error5.Visible = true;
                error5.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success5.Visible = false;
                HyperLink5.Visible = false;
            }
        }

        protected void btnEminentSportsPersonUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload5.HasFile)
                {
                    string fileContentType = FileUpload5.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" && FileUpload5.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                string fileExtension = Path.GetExtension(FileUpload5.FileName).ToLower();
                                string fileName = string.Format("{0}_EminentSportsPerson{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        error5.Visible = true;
                                        error5.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                FileUpload5.SaveAs(filePath);

                                string checkQuery = "SELECT COUNT(*) FROM EminentSportsPersonFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query = count > 0
                                    ? "UPDATE EminentSportsPersonFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId"
                                    : "INSERT INTO EminentSportsPersonFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success5.Visible = true;
                                success5.InnerHtml = "File uploaded successfully.";
                                error5.Visible = false;
                                HyperLink5.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink5.Visible = true;
                            }
                            else
                            {
                                error5.Visible = true;
                                error5.InnerHtml = "Application number not found.";
                                success5.Visible = false;
                                HyperLink5.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success5.Visible = false;
                        error5.Visible = true;
                        error5.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink5.Visible = false;
                    }
                }
                else
                {
                    error5.Visible = true;
                    error5.InnerHtml = "Please select a file to upload.";
                    success5.Visible = false;
                    HyperLink5.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error5.Visible = true;
                error5.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink5.Visible = false;
            }
        }




        //...................... DIFFERENTLY ABLED PERSON .........................6
        private void LoadDifferentlyAbledPerson()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path
                            string leftThumbFilePath = string.Format("{0}{1}_DifferentlyAbledPerson", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM DifferentlyAbledPersonFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success6.Visible = true;
                                error6.Visible = false;
                                success6.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink6.NavigateUrl = ResolveUrl(filePath);
                                HyperLink6.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink6.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink6.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink6.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error6.Visible = true;
                error6.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success6.Visible = false;
                HyperLink6.Visible = false;
            }
        }

        protected void btnDifferentlyAbledPersonUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload6.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload6.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload6.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension (e.g., .jpeg)
                                string fileExtension = Path.GetExtension(FileUpload6.FileName).ToLower();
                                string fileName = string.Format("{0}_DifferentlyAbledPerson{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        error6.Visible = true;
                                        error6.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload6.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM DifferentlyAbledPersonFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE DifferentlyAbledPersonFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO DifferentlyAbledPersonFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success6.Visible = true;
                                success6.InnerHtml = "File uploaded successfully.";
                                error6.Visible = false;
                                HyperLink6.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink6.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error6.Visible = true;
                                error6.InnerHtml = "Application number not found.";
                                success6.Visible = false;
                                HyperLink6.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success6.Visible = false;
                        error6.Visible = true;
                        error6.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink6.Visible = false;
                    }
                }
                else
                {
                    error6.Visible = true;
                    error6.InnerHtml = "Please select a file to upload.";
                    success6.Visible = false;
                    HyperLink6.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error6.Visible = true;
                error6.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink6.Visible = false;
            }
        }



        //....................... SSLC MARK SHEET ...............................7
        private void LoadSSLCMarkSheet()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path
                            string leftThumbFilePath = string.Format("{0}{1}_SSLCMarkSheet", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM SSLCMarkSheetFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success7.Visible = true;
                                error7.Visible = false;
                                success7.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink7.NavigateUrl = ResolveUrl(filePath);
                                HyperLink7.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink7.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink7.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink7.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error7.Visible = true;
                error7.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success7.Visible = false;
                HyperLink7.Visible = false;
            }
        }

        protected void btnSSLCMarkSheetUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload7.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload7.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload7.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload7.FileName).ToLower();
                                string fileName = string.Format("{0}_SSLCMarkSheet{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        error7.Visible = true;
                                        error7.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload7.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM SSLCMarkSheetFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE SSLCMarkSheetFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO SSLCMarkSheetFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success7.Visible = true;
                                success7.InnerHtml = "File uploaded successfully.";
                                error7.Visible = false;
                                HyperLink7.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink7.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error7.Visible = true;
                                error7.InnerHtml = "Application number not found.";
                                success7.Visible = false;
                                HyperLink7.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success7.Visible = false;
                        error7.Visible = true;
                        error7.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink7.Visible = false;
                    }
                }
                else
                {
                    error7.Visible = true;
                    error7.InnerHtml = "Please select a file to upload.";
                    success7.Visible = false;
                    HyperLink7.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error7.Visible = true;
                error7.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink7.Visible = false;
            }
        }



        //...................... HSC MARK SHEET ..............................8      
        private void LoadHSCMarkSheet()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_HSCMarkSheet", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM HSCMarkSheetFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success8.Visible = true;
                                error8.Visible = false;
                                success8.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink8.NavigateUrl = ResolveUrl(filePath);
                                HyperLink8.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink8.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink8.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink8.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error8.Visible = true;
                error8.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success8.Visible = false;
                HyperLink8.Visible = false;
            }
        }

        protected void btnHSCMarkSheetUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload8.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload8.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload8.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload8.FileName).ToLower();
                                string fileName = string.Format("{0}_HSCMarkSheet{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error8.Visible = true;
                                        error8.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload8.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM HSCMarkSheetFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE HSCMarkSheetFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO HSCMarkSheetFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success8.Visible = true;
                                success8.InnerHtml = "File uploaded successfully.";
                                error8.Visible = false;
                                HyperLink8.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink8.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error8.Visible = true;
                                error8.InnerHtml = "Application number not found.";
                                success8.Visible = false;
                                HyperLink8.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success8.Visible = false;
                        error8.Visible = true;
                        error8.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink8.Visible = false;
                    }
                }
                else
                {
                    error8.Visible = true;
                    error8.InnerHtml = "Please select a file to upload.";
                    success8.Visible = false;
                    HyperLink8.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error8.Visible = true;
                error8.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink8.Visible = false;
            }
        }




        //.......................NEET SCORE CARD.............................9
        private void LoadNEETScoreCard()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_NEETScoreCard", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM NEETScoreCardFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success9.Visible = true;
                                error9.Visible = false;
                                success9.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink9.NavigateUrl = ResolveUrl(filePath);
                                HyperLink9.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink9.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink9.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error9.Visible = true;
                error9.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success9.Visible = false;
                HyperLink9.Visible = false;
            }
        }

        protected void btnNEETScoreCardUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload9.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload9.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload9.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload9.FileName).ToLower();
                                string fileName = string.Format("{0}_NEETScoreCard{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error9.Visible = true;
                                        error9.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload9.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM NEETScoreCardFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE NEETScoreCardFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO NEETScoreCardFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success9.Visible = true;
                                success9.InnerHtml = "File uploaded successfully.";
                                error9.Visible = false;
                                HyperLink9.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink9.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error9.Visible = true;
                                error9.InnerHtml = "Application number not found.";
                                success9.Visible = false;
                                HyperLink9.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success9.Visible = false;
                        error9.Visible = true;
                        error9.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink9.Visible = false;
                    }
                }
                else
                {
                    error9.Visible = true;
                    error9.InnerHtml = "Please select a file to upload.";
                    success9.Visible = false;
                    HyperLink9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error9.Visible = true;
                error9.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink9.Visible = false;
            }
        }




        //.....................TRANSFER CERTIFICATE..........................10
        private void LoadTransferCertificate()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_TransferCertificate", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM TransferCertificateFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success10.Visible = true;
                                error10.Visible = false;
                                success10.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink10.NavigateUrl = ResolveUrl(filePath);
                                HyperLink10.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink10.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink10.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink10.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error10.Visible = true;
                error10.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success10.Visible = false;
                HyperLink10.Visible = false;
            }
        }

        protected void btnTransferCertificateUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload10.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload10.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload10.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload10.FileName).ToLower();
                                string fileName = string.Format("{0}_TransferCertificate{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error10.Visible = true;
                                        error10.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload10.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM TransferCertificateFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE TransferCertificateFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO TransferCertificateFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success10.Visible = true;
                                success10.InnerHtml = "File uploaded successfully.";
                                error10.Visible = false;
                                HyperLink10.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink10.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error10.Visible = true;
                                error10.InnerHtml = "Application number not found.";
                                success10.Visible = false;
                                HyperLink10.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success10.Visible = false;
                        error10.Visible = true;
                        error10.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink10.Visible = false;
                    }
                }
                else
                {
                    error10.Visible = true;
                    error10.InnerHtml = "Please select a file to upload.";
                    success10.Visible = false;
                    HyperLink10.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error10.Visible = true;
                error10.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink10.Visible = false;
            }
        }



        //.....................SCHOOL BONAFIDE  CERTIFICATE..........................11
        private void LoadBonafideCertificate()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_SchoolBonafide", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM BonafideCertificateFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success11.Visible = true;
                                error11.Visible = false;
                                success11.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink11.NavigateUrl = ResolveUrl(filePath);
                                HyperLink11.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink11.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink11.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink11.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error11.Visible = true;
                error11.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success11.Visible = false;
                HyperLink11.Visible = false;
            }
        }

        protected void btnBonafideCertificateUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload11.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload11.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload11.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload11.FileName).ToLower();
                                string fileName = string.Format("{0}_SchoolBonafide{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error11.Visible = true;
                                        error11.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload11.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM BonafideCertificateFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE BonafideCertificateFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO BonafideCertificateFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success11.Visible = true;
                                success11.InnerHtml = "File uploaded successfully.";
                                error11.Visible = false;
                                HyperLink11.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink11.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error11.Visible = true;
                                error11.InnerHtml = "Application number not found.";
                                success11.Visible = false;
                                HyperLink11.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success11.Visible = false;
                        error11.Visible = true;
                        error11.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink11.Visible = false;
                    }
                }
                else
                {
                    error11.Visible = true;
                    error11.InnerHtml = "Please select a file to upload.";
                    success11.Visible = false;
                    HyperLink11.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error11.Visible = true;
                error11.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink11.Visible = false;
            }
        }


        //.....................COMMUNITY  CERTIFICATE..........................12
        private void LoadCommunityCertificate()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = string.Format("SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId");
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path
                            string leftThumbFilePath = string.Format("{0}{1}_CommunityCertificate", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = string.Format("SELECT NameOfTheFile, PathOfTheFile FROM CommunityCertificateFilesUpload WHERE LoginId = @LoginId");
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success12.Visible = true;
                                error12.Visible = false;
                                success12.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink12.NavigateUrl = ResolveUrl(filePath);
                                HyperLink12.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink12.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink12.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink12.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error12.Visible = true;
                error12.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success12.Visible = false;
                HyperLink12.Visible = false;
            }
        }

        protected void btnCommunityCertificateUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload12.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload12.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload12.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = string.Format("SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId");
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload12.FileName).ToLower();
                                string fileName = string.Format("{0}_CommunityCertificate{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error12.Visible = true;
                                        error12.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload12.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = string.Format("SELECT COUNT(*) FROM CommunityCertificateFilesUpload WHERE LoginId = @LoginId");
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = string.Format("UPDATE CommunityCertificateFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId");
                                }
                                else
                                {
                                    query = string.Format("INSERT INTO CommunityCertificateFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)");
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success12.Visible = true;
                                success12.InnerHtml = "File uploaded successfully.";
                                error12.Visible = false;
                                HyperLink12.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink12.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error12.Visible = true;
                                error12.InnerHtml = "Application number not found.";
                                success12.Visible = false;
                                HyperLink12.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success12.Visible = false;
                        error12.Visible = true;
                        error12.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink12.Visible = false;
                    }
                }
                else
                {
                    error12.Visible = true;
                    error12.InnerHtml = "Please select a file to upload.";
                    success12.Visible = false;
                    HyperLink12.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error12.Visible = true;
                error12.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink12.Visible = false;
            }
        }





        //.....................  NATIVITY CERTIFICATE..........................13
        private void LoadNativityCertificate()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = string.Format("SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId");
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_NativityCertificate", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = string.Format("SELECT NameOfTheFile, PathOfTheFile FROM NativityCertificateFilesUpload WHERE LoginId = @LoginId");
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success13.Visible = true;
                                error13.Visible = false;
                                success13.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink13.NavigateUrl = ResolveUrl(filePath);
                                HyperLink13.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink13.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink13.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink13.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error13.Visible = true;
                error13.InnerHtml = "Error loading user details: " + ex.Message;
                success13.Visible = false;
                HyperLink13.Visible = false;
            }
        }

        protected void btnNativityCertificateUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload13.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload13.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload13.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = string.Format("SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId");
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload13.FileName).ToLower();
                                string fileName = string.Format("{0}_NativityCertificate{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error13.Visible = true;
                                        error13.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload13.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = string.Format("SELECT COUNT(*) FROM NativityCertificateFilesUpload WHERE LoginId = @LoginId");
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = string.Format("UPDATE NativityCertificateFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId");
                                }
                                else
                                {
                                    query = string.Format("INSERT INTO NativityCertificateFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)");
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success13.Visible = true;
                                success13.InnerHtml = "File uploaded successfully.";
                                error13.Visible = false;
                                HyperLink13.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink13.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error13.Visible = true;
                                error13.InnerHtml = "Application number not found.";
                                success13.Visible = false;
                                HyperLink13.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success13.Visible = false;
                        error13.Visible = true;
                        error13.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink13.Visible = false;
                    }
                }
                else
                {
                    error13.Visible = true;
                    error13.InnerHtml = "Please select a file to upload.";
                    success13.Visible = false;
                    HyperLink13.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error13.Visible = true;
                error13.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink13.Visible = false;
            }
        }





        //.......................... PARENT COMMUNITY CERTIFICATE ................... 14
        private void LoadParentCommunityCertificate()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_ParentCommunity", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM ParentCommunityCertificateFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success14.Visible = true;
                                error14.Visible = false;
                                success14.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink14.NavigateUrl = ResolveUrl(filePath);
                                HyperLink14.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink14.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink14.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink14.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error14.Visible = true;
                error14.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success14.Visible = false;
                HyperLink14.Visible = false;
            }
        }

        protected void btnParentCommunityCertificateUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload14.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload14.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload14.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload14.FileName).ToLower();
                                string fileName = string.Format("{0}_ParentCommunity{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error14.Visible = true;
                                        error14.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload14.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM ParentCommunityCertificateFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE ParentCommunityCertificateFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO ParentCommunityCertificateFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success14.Visible = true;
                                success14.InnerHtml = "File uploaded successfully.";
                                error14.Visible = false;
                                HyperLink14.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink14.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error14.Visible = true;
                                error14.InnerHtml = "Application number not found.";
                                success14.Visible = false;
                                HyperLink14.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success14.Visible = false;
                        error14.Visible = true;
                        error14.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink14.Visible = false;
                    }
                }
                else
                {
                    error14.Visible = true;
                    error14.InnerHtml = "Please select a file to upload.";
                    success14.Visible = false;
                    HyperLink14.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error14.Visible = true;
                error14.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink14.Visible = false;
            }
        }



        //............................PARENT STUDY CERTIFICATE...........................15
        private void LoadParentStudyCertificate()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_ParentStudyCertificate", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM ParentStudyCertificateFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success15.Visible = true;
                                error15.Visible = false;
                                success15.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink15.NavigateUrl = ResolveUrl(filePath);
                                HyperLink15.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink15.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink15.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink15.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error15.Visible = true;
                error15.InnerHtml = "Error loading user details: " + ex.Message;
                success15.Visible = false;
                HyperLink15.Visible = false;
            }
        }

        protected void btnParentStudyCertificateUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload15.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload15.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload15.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload15.FileName).ToLower();
                                string fileName = string.Format("{0}_ParentStudyCertificate{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error15.Visible = true;
                                        error15.InnerHtml = "Error deleting existing file: " + ex.Message;
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload15.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM ParentStudyCertificateFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE ParentStudyCertificateFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO ParentStudyCertificateFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success15.Visible = true;
                                success15.InnerHtml = "File uploaded successfully.";
                                error15.Visible = false;
                                HyperLink15.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink15.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error15.Visible = true;
                                error15.InnerHtml = "Application number not found.";
                                success15.Visible = false;
                                HyperLink15.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success15.Visible = false;
                        error15.Visible = true;
                        error15.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink15.Visible = false;
                    }
                }
                else
                {
                    error15.Visible = true;
                    error15.InnerHtml = "Please select a file to upload.";
                    success15.Visible = false;
                    HyperLink15.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error15.Visible = true;
                error15.InnerHtml = "File upload failed: " + ex.Message;
                HyperLink15.Visible = false;
            }
        }





        //..........................PARENT ADDRESS PROOF ..................................16
        private void LoadParentAddressProof()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path 
                            string leftThumbFilePath = string.Format("{0}{1}_ParentAddressProof", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM ParentAddressProofFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success16.Visible = true;
                                error16.Visible = false;
                                success16.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink16.NavigateUrl = ResolveUrl(filePath);
                                HyperLink16.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink16.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink16.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink16.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error16.Visible = true;
                error16.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success16.Visible = false;
                HyperLink16.Visible = false;
            }
        }

        protected void btnParentAddressProofUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload16.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload16.PostedFile.ContentType;
                    if (fileContentType == "application/pdf" &&
                        FileUpload16.PostedFile.ContentLength <= 3145728)
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension ( .jpeg )
                                string fileExtension = Path.GetExtension(FileUpload16.FileName).ToLower();
                                string fileName = string.Format("{0}_ParentAddressProof{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error16.Visible = true;
                                        error16.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload16.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM ParentAddressProofFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE ParentAddressProofFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO ParentAddressProofFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success16.Visible = true;
                                success16.InnerHtml = "File uploaded successfully.";
                                error16.Visible = false;
                                HyperLink16.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink16.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error16.Visible = true;
                                error16.InnerHtml = "Application number not found.";
                                success16.Visible = false;
                                HyperLink16.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success16.Visible = false;
                        error16.Visible = true;
                        error16.InnerHtml = "Invalid file type or size. Please upload a PDF file within 3 MB.";
                        HyperLink16.Visible = false;
                    }
                }
                else
                {
                    error16.Visible = true;
                    error16.InnerHtml = "Please select a file to upload.";
                    success16.Visible = false;
                    HyperLink16.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error16.Visible = true;
                error16.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink16.Visible = false;
            }
        }




        // //.................:  SIGNATURE OF THE APPLICANT ............................17


        private void LoadSignatureOfTheApplicant()
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId))
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        // Query to get the ApplicationNumber for the given LoginId
                        string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                        SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                        appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                        con.Open();
                        object result = appNumberCmd.ExecuteScalar();
                        string applicationNumber = result != null ? result.ToString() : string.Empty;

                        con.Close();

                        if (!string.IsNullOrEmpty(applicationNumber))
                        {
                            // Construct the folder path for the specific application number
                            string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Construct the file path for LeftThumb
                            string leftThumbFilePath = string.Format("{0}{1}_SignatureApplicant", folderPath, applicationNumber);

                            // Query to get file details for the given LoginId
                            string fileQuery = "SELECT NameOfTheFile, PathOfTheFile FROM SignatureOfTheApplicantFilesUpload WHERE LoginId = @LoginId";
                            SqlCommand fileCmd = new SqlCommand(fileQuery, con);
                            fileCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            SqlDataReader reader = fileCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string fileName = reader["NameOfTheFile"].ToString();
                                string filePath = reader["PathOfTheFile"].ToString();

                                success17.Visible = true;
                                error17.Visible = false;
                                success17.InnerHtml = "File already uploaded.";
                                // Set the link to view the image
                                HyperLink17.NavigateUrl = ResolveUrl(filePath);
                                HyperLink17.Visible = true; // Make the link visible
                            }
                            else
                            {
                                HyperLink17.Visible = false; // Hide the link if no file is uploaded
                            }

                            reader.Close();
                        }
                        else
                        {
                            HyperLink17.Visible = false; // Hide the link if ApplicationNumber is not found
                        }
                    }
                }
                else
                {
                    HyperLink17.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error17.Visible = true;
                error17.InnerHtml = string.Format("Error loading user details: {0}", ex.Message);
                success17.Visible = false;
                HyperLink17.Visible = false;
            }
        }


        protected void btnSignatureOfTheApplicantUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Session["LoginId"] as string;

                if (!string.IsNullOrEmpty(loginId) && FileUpload17.HasFile)
                {
                    // Validate file type and size
                    string fileContentType = FileUpload17.PostedFile.ContentType;
                    if (fileContentType == "image/jpeg" &&
                        FileUpload17.PostedFile.ContentLength >= 102400 && // Minimum 10KB
                        FileUpload17.PostedFile.ContentLength <= 307200)  // Maximum 50KB
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            // Query to get the ApplicationNumber for the given LoginId
                            string appNumberQuery = "SELECT ApplicationNumber FROM Applications WHERE LoginId = @LoginId";
                            SqlCommand appNumberCmd = new SqlCommand(appNumberQuery, con);
                            appNumberCmd.Parameters.AddWithValue("@LoginId", loginId);

                            con.Open();
                            object result = appNumberCmd.ExecuteScalar();
                            string applicationNumber = result != null ? result.ToString() : string.Empty;

                            con.Close();

                            if (!string.IsNullOrEmpty(applicationNumber))
                            {
                                // Construct the folder path for the specific application number
                                string folderPath = Server.MapPath(string.Format("~/UploadedFiles/{0}/", applicationNumber));
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                // Get the file extension (either .jpeg or .png)
                                string fileExtension = Path.GetExtension(FileUpload17.FileName).ToLower();
                                string fileName = string.Format("{0}_SignatureApplicant{1}", applicationNumber, fileExtension);
                                string filePath = Path.Combine(folderPath, fileName);

                                // Delete the existing file, if it exists
                                if (File.Exists(filePath))
                                {
                                    try
                                    {
                                        // Attempt to delete the existing file
                                        File.Delete(filePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log or handle the error if the file could not be deleted
                                        error17.Visible = true;
                                        error17.InnerHtml = string.Format("Error deleting existing file: {0}", ex.Message);
                                        return;
                                    }
                                }

                                // Save the new file and overwrite the old one
                                FileUpload17.SaveAs(filePath);

                                // Check if the file already exists in the database
                                string checkQuery = "SELECT COUNT(*) FROM SignatureOfTheApplicantFilesUpload WHERE LoginId = @LoginId";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                                checkCmd.Parameters.AddWithValue("@LoginId", loginId);

                                con.Open();
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                con.Close();

                                string query;
                                if (count > 0)
                                {
                                    query = "UPDATE SignatureOfTheApplicantFilesUpload SET NameOfTheFile = @FileName, PathOfTheFile = @FilePath WHERE LoginId = @LoginId";
                                }
                                else
                                {
                                    query = "INSERT INTO SignatureOfTheApplicantFilesUpload (LoginId, NameOfTheFile, PathOfTheFile) VALUES (@LoginId, @FileName, @FilePath)";
                                }

                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@LoginId", loginId);
                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FilePath", string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                success17.Visible = true;
                                success17.InnerHtml = "File uploaded successfully.";
                                error17.Visible = false;
                                HyperLink17.NavigateUrl = ResolveUrl(string.Format("~/UploadedFiles/{0}/{1}", applicationNumber, fileName));
                                HyperLink17.Visible = true; // Show the [VIEW IMAGE] link after uploading
                            }
                            else
                            {
                                error17.Visible = true;
                                error17.InnerHtml = "Application number not found.";
                                success17.Visible = false;
                                HyperLink17.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        success17.Visible = false;
                        error17.Visible = true;
                        error17.InnerHtml = "Invalid file type or size. Please upload a JPG file between 100KB and 300KB.";
                        HyperLink17.Visible = false;
                    }
                }
                else
                {
                    error17.Visible = true;
                    error17.InnerHtml = "Please select a file to upload.";
                    success17.Visible = false;
                    HyperLink17.Visible = false;
                }
            }
            catch (Exception ex)
            {
                error17.Visible = true;
                error17.InnerHtml = string.Format("File upload failed: {0}", ex.Message);
                HyperLink17.Visible = false;
            }
        }







        // ................REDIRECT BUTTON..................

        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            // Check if R4 is displayed on the page by inspecting its style attribute
            bool isR4Visible = R4.Attributes["style"] != null && !R4.Attributes["style"].Contains("display:none");
            bool isR5Visible = R5.Attributes["style"] != null && !R5.Attributes["style"].Contains("display:none");
            bool isR6Visible = R6.Attributes["style"] != null && !R6.Attributes["style"].Contains("display:none");

            // If R4 is visible, include HyperLink4 in the checks; if not, only check other hyperlinks
            if (HyperLink1.Visible && HyperLink2.Visible && HyperLink3.Visible &&
                (!isR4Visible || (isR4Visible && HyperLink4.Visible)) &&
                (!isR5Visible || (isR5Visible && HyperLink5.Visible)) &&
                (!isR6Visible || (isR6Visible && HyperLink6.Visible)) &&
                HyperLink7.Visible && HyperLink8.Visible && HyperLink9.Visible &&
                HyperLink10.Visible && HyperLink11.Visible && HyperLink12.Visible &&
                HyperLink13.Visible && HyperLink14.Visible && HyperLink15.Visible &&
                HyperLink16.Visible && HyperLink17.Visible)
            {
                docup.Visible = false;
                Session["DocumentsUploadComplete"] = true;

                setuserstatus();               

                Response.Redirect("apppreview.aspx");
            }
            else
            {
                docup.Visible = true;
                docup.InnerHtml = "Please upload all the required documents.";
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

                    if (currentPageStatus <= 5)
                    {
                        query = "UPDATE UserProgress SET PageStatus = 5 WHERE LoginId = @LoginId";

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