<%@ Page Title="" Language="C#" MasterPageFile="~/MBBSBDS.Master" AutoEventWireup="true" CodeBehind="addinfo.aspx.cs" Inherits="MBBS_BDS_WEBSITE.addinfo" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

               <div style="box-shadow: 0px 0px 50px grey; padding-top: 1px; padding-bottom: 1px;" class="mt-2 ms-3 mb-2 me-3">

       <div class="border border-info ms-2 mt-1 me-2" style="border-radius: 5px;">

           <div class="ps-3 pt-1 pb-1 " style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;">
               <h5 style="color: #172e81">ADDITIONAL INFORMATION</h5>
           </div>


           <div class="container-fluid">


               <div class="row">

                   <div class="col-5">

                        <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">ARE YOU A FIRST GRADUATE APPLICANT</h6>

                   </div>

                   <div class="col-7 mt-3">


                       <asp:RadioButtonList ID="FirstGraduateOptions" runat="server" RepeatDirection="Horizontal">
                           <asp:ListItem Text="Yes" Value="Yes" Selected="True" ></asp:ListItem>
                           <asp:ListItem Text="No" Value="No" style="padding-left:10px;"></asp:ListItem>
                       </asp:RadioButtonList>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">PARENT OCCUPATION</h6>

                   </div>

                   <div class="col-7 mt-3">

                       <asp:DropDownList ID="ddlParentsOccupation" runat="server" Style="width: 35%; height: 30px;" CssClass="custom-textbox" required="required">
                           <asp:ListItem Value="" Disabled="True" Selected="True">Select </asp:ListItem>
                          
                       </asp:DropDownList>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">PARENT ANNUAL INCOME</h6>

                   </div>

                   <div class="col-7 mt-3">

                       <asp:DropDownList ID="ddlAnnualIncome" runat="server" Style="width: 35%; height: 30px;" CssClass="custom-textbox" required="required">
                           <asp:ListItem Value="" Disabled="True" Selected="True">Select </asp:ListItem>
                           
                       </asp:DropDownList>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3"> NATIVE STATE </h6>

                   </div>

                   <div class="col-7 mt-3">

                       <asp:DropDownList ID="ddlNativeState" runat="server" Style="width: 35%; height: 30px;" CssClass="custom-textbox" required="required" >

                           <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>
                         
                       </asp:DropDownList>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">NATIVE DISTRICT </h6>
                       <asp:HiddenField  ID="hdnNativeDistrict" runat="server"/>

                   </div>

                   <div class="col-7 mt-3">

                       <asp:DropDownList ID="ddlNativeDistrict" runat="server" Style="width: 35%;height:30px" CssClass="custom-textbox" required="required" >
                           <asp:ListItem Value="" Disabled="True" Selected="True">-- Select </asp:ListItem>
                          
                       </asp:DropDownList>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">IDENTIFICATION MARKS </h6>

                   </div>

                   <div class="col-7 mt-3">

                      <textarea id="IDENTMARKS" runat="server" style="width:300px;height:46px" class="custom-textbox" required="required"></textarea>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">AADHAR  NUMBER </h6>

                   </div>

                   <div class="col-7 mt-3">

                       <input id="AADHARNO" runat="server" style="width: 250px; height: 28px"  class="custom-textbox" required="required"/>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">  EMAIL ID </h6>

                   </div>

                   <div class="col-7 mt-3">

                       <input id="EMAILID" runat="server" style="width: 250px; height: 28px"  class="custom-textbox" required="required"/>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3"> PHONE NUMBER </h6>

                   </div>

                   <div class="col-7 mt-3">

                       <input id="PHONENO" runat="server" style="width: 250px; height: 28px"  class="custom-textbox" required="required"/>


                   </div>

               </div>


               <div class="row">

                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">ADDRESS  FOR CORRESPONDENCE </h6>

                   </div>

                   <div class="col-7 mt-3">

                       <textarea id="Text1" runat="server" style="width: 100%; height: 60px"  class="custom-textbox" required="required"></textarea>


                   </div>

               </div>


           </div>


           <div class=" d-flex justify-content-center align-items-center  mt-2" style="background-color: #dcebfb; box-sizing: border-box;">


              <asp:Button  ID="btnSaveContinue" runat="server" class="btn btn-primary mt-1 mb-1"  Text="Save & Continue " OnClick="btnSaveContinue_Click"></asp:Button>


           </div>



       </div>


</div>
   

</asp:Content>
