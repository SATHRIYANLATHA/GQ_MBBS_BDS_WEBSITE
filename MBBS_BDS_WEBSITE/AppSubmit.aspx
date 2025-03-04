<%@ Page Title="" Language="C#" MasterPageFile="~/MBBSBDS.Master" AutoEventWireup="true" CodeBehind="AppSubmit.aspx.cs" Inherits="MBBS_BDS_WEBSITE.AppSubmit" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="box-shadow: 0px 0px 50px grey; padding-top: 1px; padding-bottom: 1px;" class="mt-2 ms-3 mb-2 me-3">

        <div class="border border-info ms-2 mt-1 me-2 pt-4 pb-4 ps-3 pe-3" style="border-radius: 5px; ">

            <center><h3 style="color: red;"><b>APPLICATION SUBMISSION</b></h3></center>

            <h6 style="color:#172e81;text-align:justify;">
               * &nbsp;&nbsp;&nbsp;&nbsp;Please carefully review all the details and information you have submitted,
                along with any documents you have provided. 
                By clicking the "Submit" button below, you are formally declaring that 
                all the information and documents you have provided are accurate, complete, 
                and true to the best of your knowledge. It is your responsibility to ensure that every detail is correct
                and that you have uploaded all necessary and relevant documentation.

            </h6>

            <h6 style="color:#172e81;text-align: justify">
                * &nbsp;&nbsp;&nbsp;&nbsp;Once you confirm your submission by clicking the final "Submit" button,
                you will no longer have the option to edit or change any of the provided information. 
                This submission will be considered final and binding, and any inaccuracies
                or missing information could impact the processing of your application. 
                Therefore, please take a moment to double-check all the fields and documents before proceeding.

            </h6>

            <h6 style="color:#172e81;text-align: justify">
               * &nbsp;&nbsp;&nbsp;&nbsp; If you are absolutely sure that everything is correct,
                proceed with the submission. Remember, once submitted, 
                no further modifications or updates will be allowed. 
                By submitting, you acknowledge that any false or misleading 
                information may result in disqualification or other consequences 
                as determined by the reviewing authorities. Thank you for your attention and understanding.

            </h6>



                   <div class="d-flex justify-content-center align-items-center mb-3" style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;">
    <asp:Button 
        ID="SUBMIT" 
        runat="server" 
        class="btn btn-primary mt-1 mb-1" 
        Text="SUBMIT" 
        OnClick="SUBMIT_CLICK" 
        OnClientClick="return confirm('Are you sure you want to proceed to  submission ? You won’t be able to make changes afterward.');">
    </asp:Button>
</div>




        </div>

        </div>

</asp:Content>
