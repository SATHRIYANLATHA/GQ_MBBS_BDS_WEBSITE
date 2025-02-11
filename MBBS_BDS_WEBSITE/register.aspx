<%@ Page Title="" Language="C#" MasterPageFile="~/mbbs/MBBS.Master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="mbbs_MBBS_BDS_WEBSITE.register"  MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />

    <style>
       .otp-container {
            display: flex;
            justify-content: center;
            gap: 10px;
        }

        .otp-input {
            width: 40px;
            height: 50px;
            text-align: center;
            font-size: 24px;
            border: 2px solid #ccc;
            border-radius: 5px;
            outline: none;
            transition: border-color 0.3s;
            -moz-appearance: textfield; /* Remove spinner in Firefox */
            appearance: textfield; /* Remove spinner in other browsers */
        }

        .otp-input::-webkit-inner-spin-button,
        .otp-input::-webkit-outer-spin-button {
            -webkit-appearance: none; /* Remove spinner in WebKit browsers */
            margin: 0;
        }

        .otp-input:focus {
            border-color: #007bff;
        }
    </style>

    <script type="text/javascript">



        $(function () {
            $("#<%= txtDOB.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                maxDate: 0, // Disable future dates
                yearRange: '1970:' + new Date().getFullYear().toString(),
                onSelect: function (dateText, inst) {
                    // Additional logic when a date is selected
                    if ($("#<%= txtDOB.ClientID %>").val() !== "") {
                        fnSetBorder("<%= txtDOB.ClientID %>", 0);
                    }
                }
            });
        });

        // Example function to set border (customize as needed)
        function fnSetBorder(elementId, borderStyle) {
            document.getElementById(elementId).style.border = borderStyle === 0 ? "1px solid #ccc" : "2px solid red";
        }



       
        function PasswordChecking() {
            const password = document.getElementById('<%= txtPassword.ClientID %>').value;
          const passwordvalidation = document.getElementById("passwordvalidation");
          const passwordstrength = document.getElementById("passwordstrength");
          const weak = document.getElementById("weak");
          const normal = document.getElementById("normal");
          const strong = document.getElementById('<%= strong.ClientID %>');
           const errorpass = document.getElementById("errorpass");

            const hdnPasswordStrength = document.getElementById('<%= hdnPasswordStrength.ClientID %>');

            if (password.length == 0) {
                passwordvalidation.style.display = "none";
                hdnPasswordStrength.value = "none";
            } else if (password.length >= 6) {
                const hasLower = /[a-z]/.test(password);
                const hasUpper = /[A-Z]/.test(password);
                const hasSpecial = /[^a-zA-Z0-9]/.test(password);

                if ((hasLower && !hasUpper && !hasSpecial) || (!hasLower && hasUpper && !hasSpecial) || (!hasLower && hasUpper && hasSpecial)) {
                    passwordvalidation.style.display = "block";
                    errorpass.innerHTML = "your password is weak";
                    errorpass.style.color = "red";
                    passwordstrength.innerHTML = "WEAK";
                    weak.style.display = "block";
                    normal.style.display = "none";
                    strong.style.display = "none";
                    hdnPasswordStrength.value = "weak";
                } else if ((hasLower && hasUpper && !hasSpecial) || (hasLower && !hasUpper && hasSpecial) || (!hasLower && hasUpper && hasSpecial)) {
                    passwordvalidation.style.display = "block";
                    errorpass.innerHTML = "your password is normal";
                    errorpass.style.color = "orange";
                    passwordstrength.innerHTML = "NORMAL";
                    weak.style.display = "block";
                    normal.style.display = "block";
                    strong.style.display = "none";
                    hdnPasswordStrength.value = "normal";
                } else if (hasLower && hasUpper && hasSpecial) {
                    passwordvalidation.style.display = "block";
                    errorpass.innerHTML = "your password is strong";
                    errorpass.style.color = "green";
                    passwordstrength.innerHTML = "STRONG";
                    weak.style.display = "block";
                    normal.style.display = "block";
                    strong.style.display = "block";
                    hdnPasswordStrength.value = "strong";
                }
            } else {
                passwordvalidation.style.display = "block";
                errorpass.style.color = "red";
                errorpass.innerHTML = "password must be at least 6 letters long";
                passwordstrength.innerHTML = "";
                weak.style.display = "none";
                normal.style.display = "none";
                strong.style.display = "none";
                hdnPasswordStrength.value = "invalid";
            }
        }



        function EmailChecking() {
            const email = document.getElementById('<%= txtEmail.ClientID %>').value;
            const erroremail = document.getElementById('<%= emailError.ClientID %>');

            const hdnEmailValid = document.getElementById('<%= hdnEmailValid.ClientID %>');

            const emailRegex = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;

            if (emailRegex.test(email)) {
                erroremail.style.display = "none";
                hdnEmailValid.value = "valid";
            } else {
                erroremail.style.display = "block";
                erroremail.innerHTML = "Enter a valid email id";
                hdnEmailValid.value = "invalid";
            }
             
        }



        function MobileChecking() {
            const mobileNumber = document.getElementById('<%= txtMobileNumber.ClientID %>').value;
            const mobileError = document.getElementById('<%= mobileError.ClientID %>');

            const hdnMobileValid = document.getElementById('<%= hdnMobileValid.ClientID %>');

            const mobileRegex = /^\d{10}$/;

            if (mobileRegex.test(mobileNumber)) {
                mobileError.style.display = "none";
                hdnMobileValid.value = "valid";
            } else {
                mobileError.style.display = "block";
                mobileError.innerHTML = "Enter a valid  mobile number ";
                hdnMobileValid.value = "invalid";
            }
            
        }



        function resetFormFields() {
            // Clear all textboxes
            document.getElementById('<%= txtName.ClientID %>').value = "";
            document.getElementById('<%= txtEmail.ClientID %>').value = "";
            document.getElementById('<%= txtMobileNumber.ClientID %>').value = "";
            document.getElementById('<%= txtDOB.ClientID %>').value = "";
            document.getElementById('<%= txtHsc.ClientID %>').value = "";
            document.getElementById('<%= txtNeet.ClientID %>').value = "";
            document.getElementById('<%= txtreg.ClientID %>').value = "";
            document.getElementById('<%= txtNeetMarks.ClientID %>').value = "";
            document.getElementById('<%= txtLoginid.ClientID %>').value = "";
            document.getElementById('<%= txtPassword.ClientID %>').value = "";
            document.getElementById('<%= txtConfpassword.ClientID %>').value = "";

            // Clear radio button lists
            var rdGender = document.getElementsByName('<%= rdGender.UniqueID %>');
            for (var i = 0; i < rdGender.length; i++) {
                rdGender[i].checked = false;
            }

            var rdPlusonepassed = document.getElementsByName('<%= rdPlusonepassed.UniqueID %>');
            for (var i = 0; i < rdPlusonepassed.length; i++) {
                rdPlusonepassed[i].checked = (rdPlusonepassed[i].value === "Yes"); // Default to "Yes"
            }

            // Reset dropdown lists to the first option
            document.getElementById('<%= ddlQualifyingExamination.ClientID %>').selectedIndex = 0;
            document.getElementById('<%= ddlQualifiedYear.ClientID %>').selectedIndex = 0;

            return false; // Prevent the form from submitting
        }





    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h5 class="d-flex justify-content-center align-items-center mt-3" style="color:darkblue"><b>USER REGISTRATION</b></h5>


    <div class="container-fluid mt-4">
        <div class="row">

            <div class="col-2 text-center">
                <div class="border-bottom w100p">
                </div>
            </div>

            <!--CENTER CONTENT-->


            <div class="col-8">

                <div id="beforelogin" runat="server" Visible="true">

                <!-- PANEL 1 -->


                <div class="panel ">
                    <div class="panel-heading p-1 ps-3" style="background-color: #3d6d8c; color: white; border-radius: 5px;">Personal Information</div>


                    <div class="panel-body ps-4 pt-4 pb-4" style="border: 1px solid #3d6d8c; border-color: #3d6d8c; border-radius: 5px;">

                        <div class="row ">

                            <div class="col-6 ">

                                <h6 style="color: darkblue">Name ( As in 12th Mark Sheet)</h6>
                                <asp:TextBox ID="txtName" runat="server" placeholder="Name" Style="width: 70%;" class="custom-textbox mb-2" required="required" ></asp:TextBox>
                               





                                <h6 style="color: darkblue">Email</h6>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email..." Style="width: 70%;" class="custom-textbox mb-2"
                                    onkeyup="EmailChecking()"  required="required"  ></asp:TextBox>
                                <br />
                               <p id="emailError" runat="server" style="font-size: small; color: red;"></p>

                                <asp:HiddenField ID="hdnEmailValid" runat="server" />



                                <h6 style="color: darkblue">Gender</h6>

                                <asp:RadioButtonList ID="rdGender" runat="server" RepeatDirection="Horizontal" CssClass="custom-textbox"  required="required" >
                                    <asp:ListItem  Value="Male" style="padding-left: 10px;" Selected="True">&nbsp;Male</asp:ListItem>
                                    <asp:ListItem  Value="Female" style="padding-left: 10px;">&nbsp;Female</asp:ListItem>
                                    <asp:ListItem  Value="Others" style="padding-left: 10px;">&nbsp;Others</asp:ListItem>                                  
                                </asp:RadioButtonList>
                               

                               

                            </div>

                            <div class="col-6">


                                <h6 style="color: darkblue">Mobile</h6>
                                <div>
                                    <b style="color: darkblue">(+91) </b>
                                  <asp:TextBox ID="txtMobileNumber" runat="server" type="number" Placeholder="Mobile Number" Style="width: 70%;" class="custom-textbox mb-2" onkeyup="MobileChecking()" required="required" ></asp:TextBox>

                                </div>
                                <asp:HiddenField ID="hdnMobileValid" runat="server" />
                               <p id="mobileError" runat="server" style="font-size: small; color: red; "></p>



                                <h6 style="color: darkblue">Date Of Birth</h6>
                                <asp:TextBox ID="txtDOB" runat="server" placeholder="Pick the Date"  Style="width: 70%;" class="custom-textbox mb-2" required="required"  ></asp:TextBox>
                               


                            </div>


                        </div>





                    </div>
                </div>


                <!-- PANEL 2 -->

                <div class="panel ">
                    <div class="panel-heading p-1 ps-3" style="background-color: #3d6d8c; color: white; border-radius: 5px;">Educational Information</div>

                    <div class="panel-body ps-4 pt-4 pb-4" style="border: 1px solid #3d6d8c; border-color: #3d6d8c; border-radius: 5px;">

                        <div class="row ">


                            <div class="col-6">


                                <h6 style="color: darkblue">Whether +1 Passed</h6>

                                <asp:RadioButtonList ID="rdPlusonepassed" runat="server" RepeatDirection="Horizontal" required="required"  >
                                    <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No" style="padding-left: 10px;"></asp:ListItem>
                                </asp:RadioButtonList>

                              



                                <h6 style="color: darkblue" class="mt-2">HSC Roll Number</h6>
                                <asp:TextBox ID="txtHsc" runat="server" placeholder="HSC Roll No" Style="width: 50%;" class="custom-textbox mb-2" required="required"  ></asp:TextBox>
                                





                            </div>

                            <div class="col-6">

                                <h6 style="color: darkblue">Qualifying Examination</h6>
                                <asp:DropDownList ID="ddlQualifyingExamination" runat="server" Style="width: 50%;" class="custom-textbox mb-2" required="required"  >
                                    <asp:ListItem Value="" Disabled="True" Selected="True">-- Examination --</asp:ListItem>

                                </asp:DropDownList>
                                


                                <h6 style="color: darkblue">Qualified Year</h6>
                                <asp:DropDownList ID="ddlQualifiedYear" runat="server" Style="width: 50%;" class="custom-textbox mb-2" required="required"  >
                                    <asp:ListItem Value="" Disabled="True" Selected="True">-- Select Year --</asp:ListItem>
                                    <asp:ListItem Value="2006">2006</asp:ListItem>
                                    <asp:ListItem Value="2007">2007</asp:ListItem>
                                    <asp:ListItem Value="2008">2008</asp:ListItem>
                                    <asp:ListItem Value="2009">2009</asp:ListItem>
                                    <asp:ListItem Value="2010">2010</asp:ListItem>
                                    <asp:ListItem Value="2011">2011</asp:ListItem>
                                    <asp:ListItem Value="2012">2012</asp:ListItem>
                                    <asp:ListItem Value="2013">2013</asp:ListItem>
                                    <asp:ListItem Value="2014">2014</asp:ListItem>
                                    <asp:ListItem Value="2015">2015</asp:ListItem>
                                    <asp:ListItem Value="2016">2016</asp:ListItem>
                                    <asp:ListItem Value="2017">2017</asp:ListItem>
                                    <asp:ListItem Value="2018">2018</asp:ListItem>
                                    <asp:ListItem Value="2019">2019</asp:ListItem>
                                    <asp:ListItem Value="2020">2020</asp:ListItem>
                                    <asp:ListItem Value="2021">2021</asp:ListItem>
                                    <asp:ListItem Value="2022">2022</asp:ListItem>
                                    <asp:ListItem Value="2023">2023</asp:ListItem>
                                    <asp:ListItem Value="2024">2024</asp:ListItem>
                                </asp:DropDownList>
                                

                               

                            </div>


                        </div>
                    </div>

                </div>



                     <!-- PANEL 3 -->

             <div class="panel ">
     <div class="panel-heading p-1 ps-3" style="background-color: #3d6d8c; color: white; border-radius: 5px;">NEET Information</div>

     <div class="panel-body ps-4 pt-4 pb-4" style="border: 1px solid #3d6d8c; border-color: #3d6d8c; border-radius: 5px;">

         <div class="row ">


             <div class="col-4">

                 <h6 style="color: darkblue">NEET Roll Number</h6>
                 <asp:TextBox ID="txtNeet" runat="server" placeholder="NEET Roll No" Style="width: 50%;" class="custom-textbox mb-2" required="required"  ></asp:TextBox>

             </div>

             <div class="col-4">

                 <h6 style="color: darkblue">NEET REG Number</h6>
                  <asp:TextBox ID="txtreg" runat="server" placeholder="NEET Reg No" Style="width: 50%;" class="custom-textbox mb-2"  required="required" ></asp:TextBox>

             </div>


             <div class="col-4">

                  <h6 style="color: darkblue">NEET Marks</h6>
                    <asp:TextBox ID="txtNeetMarks" runat="server" placeholder="NEET  Marks" Style="width: 50%;" class="custom-textbox mb-2"  required="required" ></asp:TextBox>
                                

             </div>




         </div>
     </div>

 </div>





                   

                <!-- PANEL 4 -->

                <div class="panel ">
                    <div class="panel-heading p-1 ps-3" style="background-color: #3d6d8c; color: white; border-radius: 5px;">Login Information</div>

                    <div class="panel-body ps-4 pt-4 pb-4" style="border: 1px solid #3d6d8c; border-color: #3d6d8c; border-radius: 5px;">

                        <div class="row ">




                            <div class="col-4">
                                <h6 style="color: darkblue">Login ID</h6>
                                <asp:TextBox ID="txtLoginid" runat="server" placeholder=" Login Id" Style="width: 70%;" class="custom-textbox mb-2" required="required"  ></asp:TextBox>
                               <p style="color:red;font-size:small" id="errorLoginID" runat="server"> </p>
                            </div>

                            <div class="col-4">
                                <h6 style="color: darkblue">Password</h6>
                                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" Style="width: 70%;" class="custom-textbox mb-2"  onkeyup="PasswordChecking()" required="required" ></asp:TextBox>





                                <div id="passwordvalidation" style="display: none">
                                    <span class="text-muted mb-2">Password Strength : <span id="passwordstrength" class="text-muted"></span></span>
                                    <br />
                                    <div style="display: flex; justify-content: space-around; width: 100%; ">
                                        <span style="border: 5px solid red; border-radius: 50%; display: none; width: 33.3%;" id="weak" ></span>
                                        <span style="border: 5px solid orange; border-radius: 50%; display: none; width: 33.3%; " id="normal"></span>
                                        <span style="border: 5px solid green; border-radius: 50%; display: none; width: 33.3%; " id="strong" runat="server"></span>
                                    </div>
                                    <p id="errorpass" style="font-size: small;"></p>
                                </div>

                                <asp:HiddenField ID="hdnPasswordStrength" runat="server" />

                                 <p style="color:red;font-size:small" id="errorPassword" runat="server"> </p>
                            </div>

                            <div class="col-4">
                                <h6 style="color: darkblue">Confirm Password</h6>
                                <asp:TextBox ID="txtConfpassword" runat="server" placeholder=" Confirm Password" TextMode="Password" Style="width: 70%;" class="custom-textbox mb-2"  required="required" ></asp:TextBox>
                                
                            </div>

                        </div>

                        <div class="ms-5" style="color: green; padding-left: 230px;">
                            <span class="text-small d-block" style="font-size: 0.8em;">> Password length between 6 to 12 characters</span>
                            <span class="text-small d-block" style="font-size: 0.8em;">> Password should contain Lower + Upper alphabets, numbers , special characters</span>
                        </div>



                    </div>
                </div>



                <!-- PANEL 5 -->

                <div class="panel mb-4">
                    <div class="panel-heading p-1 ps-3" style="background-color: #3d6d8c; color: white;">

                        <div class="d-flex justify-content-center">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary"  OnClick="btnSubmit_Click" />
                            &nbsp;
                             <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-secondary" OnClientClick="return resetFormFields();"/>
                        </div>
                    </div>
                </div>

                    </div>

         



                <div id="afterlogin" runat="server" Visible="false">
                    <div>
                     <h6 style="color: darkblue">Hi   <span id="regusername" runat="server" style="color:deeppink"></span> you have been successfully registered</h6> <br />
                    </div>
                    <a href="login.aspx">CLICK HERE TO LOGIN</a>


                </div>



            </div>


               
         <div class="col-2 text-center">
                <div class="border-bottom w100p">
                </div>
            </div>

            </div>



       

        </div>

  

</asp:Content>
