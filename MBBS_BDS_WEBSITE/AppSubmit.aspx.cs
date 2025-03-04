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
    public partial class AppSubmit : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["DBConnMbbsGovt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoginId"] == null)
                {
                    Response.Redirect("error.aspx");
                }
            }
        }

        protected void SUBMIT_CLICK(object sender, EventArgs e)
        {
            Session["ApplicationSubmit"] = true;
            setuserstatus();

            Response.Redirect("apppreview.aspx");
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

                    if (currentPageStatus <= 7)
                    {
                        query = "UPDATE UserProgress SET PageStatus = 7 WHERE LoginId = @LoginId";

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