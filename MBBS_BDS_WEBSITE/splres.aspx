<%@ Page Title="" Language="C#" MasterPageFile="~/MBBSBDS.Master" AutoEventWireup="true" CodeBehind="splres.aspx.cs" Inherits="MBBS_BDS_WEBSITE.splres"  MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function toggleSportsProof() {
            // Get the selected RadioButton value
            var sportsOptions = document.querySelector('input[name="<%= EminentSportsOptions.UniqueID %>"]:checked'); // Get selected RadioButton
            var sportsProof = document.getElementById('<%= sportsproof.ClientID %>'); // Get sportsproof paragraph

            // Check if a radio button is selected and its value
            if (sportsOptions && sportsOptions.value === "Yes") {
                sportsProof.style.display = 'block'; // Show the paragraph
            } else {
                sportsProof.style.display = 'none'; // Hide the paragraph
            }      
        }

        function toggleServicemenProof() {
            var servicemenOptions = document.querySelector('input[name="<%= ExServicemenOptions.UniqueID %>"]:checked'); 
             var servicemenProof = document.getElementById('<%= servicemenproof.ClientID %>');

             if (servicemenOptions && servicemenOptions.value === "Yes") {
                 servicemenProof.style.display = 'block';
             } else {
                 servicemenProof.style.display = 'none';
             }
        }

        function toggleDifferentlyAbledProof() {
            var diffableOptions = document.querySelector('input[name="<%= DifferentlyAbledPersonOptions.UniqueID %>"]:checked'); 
             var diffableProof = document.getElementById('<%= diffableproof.ClientID %>');

             if (diffableOptions && diffableOptions.value === "Yes") {
                 diffableProof.style.display = 'block';
             } else {
                 diffableProof.style.display = 'none';
             }
        }

        function toggleHscGroupTextBox() {
            var hscGroupOptions = document.querySelector('input[name="<%= HscGroupOptions.UniqueID %>"]:checked'); // Get selected RadioButton
             var hscGroupTextBox = document.getElementById('<%= txthscgroup.ClientID %>'); // Get the TextBox

             if (hscGroupOptions && hscGroupOptions.value === "Yes") {
                 hscGroupTextBox.style.display = 'block'; // Show the TextBox
                 hscGroupTextBox.setAttribute('required', 'required');
             } else {
                 hscGroupTextBox.style.display = 'none'; // Hide the TextBox
                 hscGroupTextBox.value = "";
                 hscGroupTextBox.removeAttribute('required');

             }
        }

        function toggleBoardOfExamOthers() {
            var boardExamOptions = document.getElementById('<%= ddlBoardOfExamination.ClientID %>'); // Get the DropDownList
            var boardExamTextBox = document.getElementById('<%= boardofexamothers.ClientID %>'); // Get the TextBox

            // Check if "Others" is selected
            if (boardExamOptions.value === "14") {
                boardExamTextBox.style.display = 'block'; // Show the TextBox
                boardExamTextBox.setAttribute('required', 'required');
            } else {
                boardExamTextBox.style.display = 'none'; // Hide the TextBox
                boardExamTextBox.value = "";
                boardExamTextBox.removeAttribute('required');
            }
        }

        function toggleCoursesCompleted() {
            var profcourseoptions = document.querySelector('input[name="<%= ProfessionalCourseOptions.UniqueID %>"]:checked'); // Get selected RadioButton
            var profcourseborder = document.getElementById('<%= profcourse.ClientID %>'); // Get the TextBox

            var ddlcourselist = document.getElementById('<%= ddlcourselist.ClientID %>');
            var yoc = document.getElementById('<%= yoc.ClientID %>');

             if (profcourseoptions && profcourseoptions.value === "Yes") {
                 profcourseborder.style.display = 'block'; // Show the TextBox
                 ddlcourselist.setAttribute('required', 'required');
                 yoc.setAttribute('required', 'required');
             } else {
                 profcourseborder.style.display = 'none'; // Hide the TextBox
                 ddlcourselist.value = "";
                 yoc.value = "";
                 ddlcourselist.removeAttribute('required');
                 yoc.removeAttribute('required');
             }
         }

        function toggleothercoursebox() {
            var courseoptions = document.getElementById('<%= ddlcourselist.ClientID %>'); // Get the DropDownList
             var othercoursetextbox = document.getElementById('<%= othercourse.ClientID %>'); // Get the TextBox

             // Check if "Others" is selected
             if (courseoptions.value === "7") {
                 othercoursetextbox.style.display = 'block'; // Show the TextBox
                 othercoursetextbox.setAttribute('required', 'required');
             } else {
                 othercoursetextbox.style.display = 'none'; // Hide the TextBox
                 othercoursetextbox.value = "";
                 othercoursetextbox.removeAttribute('required');
             }
         }



        window.onload = function () { 
            toggleSportsProof();
            toggleServicemenProof();
            toggleDifferentlyAbledProof();
            toggleHscGroupTextBox();
            toggleBoardOfExamOthers();
            toggleCoursesCompleted();
            toggleothercoursebox();
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="box-shadow: 0px 0px 50px grey; padding-top: 1px; padding-bottom: 1px;" class="mt-2 ms-3 mb-2 me-3">

        <div class="border border-info ms-2 mt-1 me-2" style="border-radius: 5px;">

            <div class="ps-3 pt-1 pb-1 " style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;">
                <h5 style="color: #172e81">SPECIAL RESERVATION</h5>
            </div>


             <div class="container-fluid ">

               <div class="row ">


                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">EMINENT SPORTS PERSON</h6>

                   </div>

                   <div class="col-7 mt-3">
                       
                       <asp:RadioButtonList ID="EminentSportsOptions" runat="server" RepeatDirection="Horizontal"  EnableViewState="true"
                           AutoPostBack="false" onchange="toggleSportsProof();">                        
                           <asp:ListItem Text="Yes" Value="Yes" style="padding-left: 10px;"></asp:ListItem>
                           <asp:ListItem Text="No" Value="No" Selected="True" style="padding-left: 10px;"></asp:ListItem>
                       </asp:RadioButtonList>

                       <p id="sportsproof" runat="server" class="ps-3" style="display: none;">( evidence should be produced )</p>
                       
                   </div>


               </div>


                   <div class="row ">


                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">EX-SERVICEMEN  </h6>

                   </div>

                   <div class="col-7 mt-3">
                       
                       <asp:RadioButtonList ID="ExServicemenOptions" runat="server" RepeatDirection="Horizontal"  EnableViewState="true"
                          AutoPostBack="false" onchange="toggleServicemenProof();">
                           <asp:ListItem Text="Yes" Value="Yes" style="padding-left: 10px;"></asp:ListItem>
                           <asp:ListItem Text="No" Value="No" Selected="True" style="padding-left: 10px;"></asp:ListItem>
                       </asp:RadioButtonList>

                       <p id="servicemenproof" runat="server" class="ps-3" style="display:none;">( evidence should be produced )</p> 

                   </div>


               </div>



                 <div class="row">
                   <div class="col-5">
                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">DIFFERENTLY ABLED PERSON</h6>
                   </div>

                   <div class="col-7 mt-3">
                       <asp:RadioButtonList ID="DifferentlyAbledPersonOptions" runat="server" RepeatDirection="Horizontal" required="required" AutoPostBack="false" EnableViewState="true"
                           onchange="toggleDifferentlyAbledProof();">
                           <asp:ListItem Text="Yes" Value="Yes" style="padding-left: 10px;"></asp:ListItem>
                           <asp:ListItem Text="No" Value="No" Selected="True" style="padding-left: 10px;"></asp:ListItem>
                       </asp:RadioButtonList>

                       <p id="diffableproof" runat="server" class="ps-3" style="display: none;">( evidence should be produced )</p>
                       
                   </div>
               </div>



                 <div class="row ">


                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">QUALIFYING EXAMINATION </h6>

                   </div>

                   <div class="col-7 mt-3">
                       <asp:DropDownList ID="ddlQualifyingExamination" runat="server" Style="width: 40%; height: 30px" CssClass="custom-textbox ms-3" required="required"  EnableViewState="true">
                           <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  --</asp:ListItem>
                          
                       </asp:DropDownList>


                   </div>


               </div>


                  <div class="row">
                   <div class="col-5">
                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">HSC GROUP & GROUP CODE (TN STATE ONLY)</h6>
                   </div>

                   <div class="col-7 mt-3">
                       <asp:RadioButtonList ID="HscGroupOptions" runat="server" RepeatDirection="Horizontal"  AutoPostBack="false" EnableViewState="true"
                           onchange="toggleHscGroupTextBox();">                         
                           <asp:ListItem Text="Yes" Value="Yes" style="padding-left: 10px;"></asp:ListItem>
                           <asp:ListItem Text="No" Value="No" Selected="True" style="padding-left: 10px;"></asp:ListItem>
                       </asp:RadioButtonList>

                       <asp:TextBox ID="txthscgroup" runat="server" Style="width: 20%;display:none" class="custom-textbox mb-2 ms-3" ></asp:TextBox>
                       
                   </div>
               </div>


             <div class="row ">


                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">NAME OF THE BOARD OF EXAMINATION </h6>

                   </div>

                   <div class="col-7 mt-3">
                       <asp:DropDownList ID="ddlBoardOfExamination" runat="server" Style="width: 40%; height: 30px" CssClass="custom-textbox ms-3" required="required" EnableViewState="true"
                           AutoPostBack="false"  onchange="toggleBoardOfExamOthers();">
                           <asp:ListItem Value="" Disabled="True" Selected="True">-- Select --</asp:ListItem>

                       </asp:DropDownList>

                       <br />

                       <asp:TextBox ID="boardofexamothers" runat="server" Style="width: 70%;display:none;" class="custom-textbox mb-2 ms-3 mt-2" ></asp:TextBox>

                   </div>


               </div>



                 <div class="row  mb-3">


                   <div class="col-5">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">UNDERGOING/ COMPLETED ANY PROFESSIONAL COURSES</h6>

                   </div>

                   <div class="col-7 mt-3">
                       <asp:RadioButtonList ID="ProfessionalCourseOptions" runat="server" RepeatDirection="Horizontal"    EnableViewState="true"
                           AutoPostBack="false" onchange="toggleCoursesCompleted();">
                           <asp:ListItem Text="Yes" Value="Yes"  style="padding-left: 10px;"></asp:ListItem>
                           <asp:ListItem Text="No" Value="No" Selected="True"  style="padding-left: 10px;"></asp:ListItem>
                       </asp:RadioButtonList>

                       <div class="border border-info" id="profcourse" runat="server" style="display:none">

                           <div class="row">

                               <div class="col-5">
                                   <h6 style="color: #172e81;" class="ps-3 mt-3 "  >Name of the course </h6>
                               </div>

                               <div class="col-7 mt-3">
                                  

                                   <asp:DropDownList ID="ddlcourselist" runat="server" AutoPostBack="false" onchange="toggleothercoursebox();"  Style="width: 40%; height: 30px" CssClass="custom-textbox ms-3"   EnableViewState="true"></asp:DropDownList>


                                    <asp:TextBox ID="othercourse" runat="server" style="width:60%;display:none" class="custom-textbox mb-2 mt-2"    ></asp:TextBox>
                               </div>
                           </div>

                           <div class="row ">

                               <div class="col-5">
                                   <h6 style="color: #172e81;" class="ps-3 mt-3 "  >Year of completion </h6>
                               </div>

                               <div class="col-7">
                                   <asp:TextBox ID="yoc" runat="server" style="width:60%;" class="custom-textbox mb-2 mt-2"    EnableViewState="true" ></asp:TextBox>
                               </div>

                           </div>

                       </div>


                   </div>


               </div>









</div>

        </div>

          <div class=" d-flex justify-content-center align-items-center mb-3 ms-2 me-2" style="background-color: #dcebfb; box-sizing: border-box; ">


            <asp:Button  ID="btnSaveContinue" runat="server" class="btn btn-primary mt-1 mb-1"  Text="Save & Continue " OnClick="btnSaveContinue_Click"></asp:Button>


       </div>

    </div>

</asp:Content>
