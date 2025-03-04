using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MBBS_BDS_WEBSITE
{
    public partial class MBBS : System.Web.UI.MasterPage
    {
      


            protected void Page_Load(object sender, EventArgs e)
            {
                Registerheadandvisible(); // head content for register page and hiding the register button

                loginfooterhide(); // hiding the footer if its loginpage 



            }

            protected void lbHome_Click(object sender, EventArgs e)
            {
                Response.Redirect("home.aspx");
            }

            protected void lbLogin_Click(object sender, EventArgs e)
            {
                Response.Redirect("login.aspx"); // Redirect to login page
            }

            protected void lbRegister_Click(object sender, EventArgs e)
            {
                Response.Redirect("register.aspx");
            }

            protected void Registerheadandvisible()
            {
                if (Request.Url.AbsolutePath.EndsWith("register.aspx"))
                {
                    lbRegister.Visible = false;
                    headcontent.InnerHtml = "<b> GOVERNMENT OF TAMIL NADU </b>  <br /> " +
                        "<b> SELECTION COMMITTEE, DIRECTORATE OF MEDICAL EDUCATION </b> <br />" +
                        "<b style='font-weight:900'>ADMISSION TO TAMILNADU MBBS/BDS </b>  <br />" +
                        "<b> APPLICATION FORM FOR GOVT. QUOTA SEATS IN GOVT. COLLEGES AND </b> <br />" +
                        "<b>GOVT. QUOTA SEATS IN SELF-FINANCING COLLEGES FOR 2025-2026 SESSION </b> ";
                }
                else
                {
                    lbRegister.Visible = true;
                }

            }

            protected void loginfooterhide()
            {

                if (Request.Url.AbsolutePath.EndsWith("login.aspx"))
                {
                    footer.Visible = false;
                    // Hide footer on login page
                }
                else
                {
                    footer.Visible = true; // Show footer on other pages
                }
            }


      }
  }
