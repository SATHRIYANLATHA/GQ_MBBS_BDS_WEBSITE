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
    public partial class MBBSBDS : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
          {
            if (!IsPostBack)
             {

                if (Session["LoginId"] != null)
                  {
                      headname.InnerHtml = Session["UserName"].ToString();
                  }


                if (Session["PersonalInformationComplete"] != null && (bool)Session["PersonalInformationComplete"])
                {
                    lbSpecialReservation.Attributes["class"] = lbSpecialReservation.Attributes["class"].Replace("disabled", "").Trim();
                  
                }

                if (Session["SpecialReservationComplete"] != null && (bool)Session["SpecialReservationComplete"])
                {
                    lbAcademicSchooling.Attributes["class"] = lbAcademicSchooling.Attributes["class"].Replace("disabled", "").Trim();
                   
                }

                if (Session["AcademicAndSchoolingComplete"] != null && (bool)Session["AcademicAndSchoolingComplete"])
                {
                    lbAdditionalInformation.Attributes["class"] = lbAdditionalInformation.Attributes["class"].Replace("disabled", "").Trim();
                   
                }

                if (Session["AdditionalInformationComplete"] != null && (bool)Session["AdditionalInformationComplete"])
                {
                    lbDocumentsUpload.Attributes["class"] = lbDocumentsUpload.Attributes["class"].Replace("disabled", "").Trim();
                    
                }


                if (Session["DocumentsUploadComplete"] != null && (bool)Session["DocumentsUploadComplete"])
                {
                    lbApplicationPreview.Attributes["class"] = lbApplicationPreview.Attributes["class"].Replace("disabled", "").Trim();                          

                }

                if (Session["ApplicationPreviewComplete"] != null && (bool)Session["ApplicationPreviewComplete"])
                {
                    lbAppSubmit.Attributes["class"] = lbAppSubmit.Attributes["class"].Replace("disabled", "").Trim();

                }

                



                // Set check icon visibility based on session variables
                personalInfoCheck.Visible = Session["PersonalInformationComplete"] != null && (bool)Session["PersonalInformationComplete"];
                specialResCheck.Visible = Session["SpecialReservationComplete"] != null && (bool)Session["SpecialReservationComplete"];
                academicSchoolingCheck.Visible = Session["AcademicAndSchoolingComplete"] != null && (bool)Session["AcademicAndSchoolingComplete"];
                additionalInfoCheck.Visible = Session["AdditionalInformationComplete"] != null && (bool)Session["AdditionalInformationComplete"];
                documentsUploadCheck.Visible = Session["DocumentsUploadComplete"] != null && (bool)Session["DocumentsUploadComplete"];
                applicationPreviewCheck.Visible = Session["ApplicationPreviewComplete"] != null && (bool)Session["ApplicationPreviewComplete"];



                if (Session["ApplicationSubmit"] != null && (bool)Session["ApplicationSubmit"])
                {
                    lbPersonalInformation.Visible = false;
                    lbSpecialReservation.Visible = false;
                    lbAcademicSchooling.Visible = false;
                    lbAdditionalInformation.Visible = false;
                    lbDocumentsUpload.Visible = false;
                    lbAppSubmit.Visible = false;

                    applicationPreviewCheck.Visible = false;

                }


                checkErrorPage();
            }
           
        }

        protected void lbPersonalInformtion_Click(object sender, EventArgs e)
        {
            Response.Redirect("pinfo.aspx");
        }

        protected void lbSpecialReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("splres.aspx");
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("home.aspx");
        }

        protected void lbAcademicSchooling_Click(object sender, EventArgs e)
        {
            Response.Redirect("sos.aspx");
        }

        protected void lbAdditionalInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("addinfo.aspx");
        }

        protected void lbDocumentsUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("upload.aspx");
        }

        protected void lbApplicationPreview_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppSubmit.aspx");
        }

        protected void checkErrorPage()
        {
            if (Request.Url.AbsolutePath.EndsWith("error.aspx"))
            {
                Particulars.Visible = false;
               
            }
            else
            {
                Particulars.Visible = true;
            }
        }
    }
}