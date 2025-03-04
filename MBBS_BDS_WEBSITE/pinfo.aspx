<%@ Page Title="" Language="C#" MasterPageFile="~/MBBSBDS.Master" AutoEventWireup="true" CodeBehind="pinfo.aspx.cs" Inherits="MBBS_BDS_WEBSITE.pinfo" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
 <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
 <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />

    <script type="text/javascript">


        $(function () {
            $("#<%= txtDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                maxDate: 0, // Disable future dates
                yearRange: '1970:' + new Date().getFullYear().toString(),
                onSelect: function (dateText, inst) {
                    // Additional logic when a date is selected
                    if ($("#<%= txtDate.ClientID %>").val() !== "") {
                        fnSetBorder("<%= txtDate.ClientID %>", 0);
                    }
                }
            });
        });

        // Example function to set border (customize as needed)
        function fnSetBorder(elementId, borderStyle) {
            document.getElementById(elementId).style.border = borderStyle === 0 ? "1px solid #ccc" : "2px solid red";
        }

    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="box-shadow: 0px 0px 50px grey; padding-top: 1px; padding-bottom: 1px;" class="mt-2 ms-3 mb-2 me-3">

     <div class="border border-info ms-2 mt-1 me-2" style="border-radius: 5px;">

         <div class="ps-3 pt-1 pb-1 " style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;">
             <h5 style="color: #172e81">PERSONAL INFORMATION</h5>
         </div>
   

                    <div>
               <div class="container-fluid">
                   <div class="row">

                       <div class="col-6">


                           <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">NAME OF THE APPLICANT</h6>
                            <b id="username" runat="server"></b> 

                           
                           <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">HSC/EQUIVALENT ROLL NO</h6>
                            <b id="hscrollno" runat="server"></b> 

                           
                           <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">NEET ROLL NO</h6>
                            <b id="neetrollno" runat="server"></b> 


                           <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">NAME OF THE PARENT / GUARDIAN</h6>
                            <asp:TextBox ID="txtParent" runat="server" placeholder="Name of the Parent/Guardian" style="width:60%;" class="custom-textbox mb-2" required="required" ></asp:TextBox>


                            <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">NATIONALITY</h6>
                           
                               <asp:DropDownList ID="ddlNationality" runat="server" Style="width: 60%;" class="custom-textbox mb-2" required="required" >
                                   <asp:ListItem Value="" Disabled="True" Selected="True">-- Select Nationality --</asp:ListItem>
                                  
                               </asp:DropDownList>


                            <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">MOTHER TONGUE</h6>
                               <asp:DropDownList ID="ddlMotherTongue" runat="server" Style="width: 60%;" class="custom-textbox mb-2"  required="required">
                                   <asp:ListItem Value="" Disabled="True" Selected="True">-- Select Mother Tongue --</asp:ListItem>
                                 
                               </asp:DropDownList>




                       </div>


                       <div class="col-6">


                           <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">DATE OF BIRTH</h6>
                           <b id="dateofbirth" runat="server"></b>


                           <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">YEAR OF PASSING</h6>
                           <b id="yearofpassing" runat="server"></b>


                           <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">GENDER</h6>
                           <b id="gender" runat="server"></b>

                            <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">SCHOOLING  STUDIED (6<sup>th</sup> STD TO 12<sup>th</sup> STD)</h6>
                           <asp:DropDownList ID="ddlSchooling" runat="server" Style="width: 50%;" class="custom-textbox mb-2 " required="required">
                               <asp:ListItem Value="" Disabled="True" Selected="True">-- Select Schooling --</asp:ListItem>
                               <asp:ListItem Value="TamilNadu">TamilNadu</asp:ListItem>
                               <asp:ListItem Value="Party TamilNadu">Party TamilNadu</asp:ListItem>
                               <asp:ListItem Value="Other States/Countries">Other States/Countries</asp:ListItem>
                           </asp:DropDownList>



                            <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">RELIGION</h6>
                           <asp:DropDownList ID="ddlReligion" runat="server" Style="width: 50%;" class="custom-textbox mb-2" required="required" >
                               <asp:ListItem Value="" Disabled="True" Selected="True">-- Select Religion --</asp:ListItem>
                              
                           </asp:DropDownList>


                            <h6 style="color:#172e81;margin-bottom: 4px;" class="pt-3">NATIVITY</h6>
                           <asp:DropDownList ID="ddlNativity" runat="server" Style="width: 50%;" class="custom-textbox mb-2" required="required"  AutoPostBack="true" OnSelectedIndexChanged="NativityChange">
                               <asp:ListItem Value="" Disabled="True" Selected="True">-- Select Nativity --</asp:ListItem>
                              
                           </asp:DropDownList>


                       </div>

                   </div>
               </div>



           </div>



           <!-- COMMUNITY INFORMATION -->
           
           <div  class="border border-info mt-3" style="border-radius:5px;">
               <div class="ps-3 pt-1 pb-1 " style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;" >
                   <h5 style="color: #172e81">COMMUNITY INFORMATION</h5>
               </div>

               <div class="container-fluid">
                   <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">COMMUNITY</h6>
                   <asp:DropDownList ID="ddlCommunity" runat="server" Style="width: 30%;" class="custom-textbox mb-2"
                       AutoPostBack="true"  OnSelectedIndexChanged="ddlCommunity_SelectedIndexChanged"  required="required">
                       <asp:ListItem Value="" Disabled="True" Selected="True">-- Select Community --</asp:ListItem>
                   </asp:DropDownList>

                   <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">SUB CASTE WITH CODE</h6>
                   <asp:DropDownList ID="ddlCaste" runat="server" Style="width: 100%;"  class="custom-textbox mb-2" required="required" >
                       <asp:ListItem Value="" Disabled="True" Selected="True">-- Select Caste --</asp:ListItem>
                   </asp:DropDownList>
               </div>


               <div class="d-flex justify-content-around container-fluid " id="commmunity_certificate_detail" runat="server">

                   <div>
                        <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">CERTIFICATE NO</h6>
                       <asp:TextBox ID="txtCertificate" runat="server" placeholder="Certificate No." style="width:80%;" class="custom-textbox mb-2" required="required" ></asp:TextBox>
                   </div>

                   <div>
                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">ISSUED BY</h6>
                       <asp:TextBox ID="txtIssuedby" runat="server" placeholder="Issued By" Style="width: 80%;" class=" custom-textbox mb-2" required="required"></asp:TextBox>
                   </div>

                   <div>
                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">ISSUED TALUK</h6>
                       <asp:TextBox ID="txtIssuedTaluk" runat="server" placeholder="Issued Taluk" Style="width: 80%;" class="custom-textbox mb-2"  required="required"></asp:TextBox>
                   </div>

                   <div>
                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">COMM DISTRICT</h6>
                       <asp:DropDownList ID="ddlDistrict" runat="server" Style="width: 100%;height:30px"  class="custom-textbox mb-2" required="required">
                           <asp:ListItem Value="" Disabled="True" Selected="True">-- District --</asp:ListItem>
                          
                       </asp:DropDownList>

                       
                   </div>

                   <div class="ms-4">
                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">ISSUED DATE</h6>
                       <asp:TextBox ID="txtDate" runat="server" placeholder=" Pick the Date"  style="width:60%;" class="custom-textbox mb-2"  required="required" ></asp:TextBox>
                   </div>

               </div>







           </div>


           <div class="d-flex justify-content-center align-items-center mb-3" style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;">
          

               <asp:Button  ID="btnSaveContinue" runat="server" class="btn btn-primary mt-1 mb-1" Text="Save & Continue " OnClick="btnSaveContinue_Click"></asp:Button>
               
           
           </div>


       </div>



</div>


</asp:Content>
