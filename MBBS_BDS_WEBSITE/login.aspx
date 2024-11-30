<%@ Page Title="" Language="C#" MasterPageFile="~/MBBS.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MBBS_BDS_WEBSITE.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
         function resetFormFields()
         {
             document.getElementById('<%= txtuserid.ClientID %>').value = "";
             document.getElementById('<%= txtPassword.ClientID %>').value = "";
             document.getElementById('<%= erroruseridpassword.ClientID %>').style.display = "none";



             return false; // Prevent the form from submitting
         }
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="d-flex justify-content-center align-items-center">
        <h4 class="mt-4" style="color: darkblue"><b>Welcome to the 2025-2026 Academic Year</b></h4>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4 text-center">
                <div class="border-bottom w100p">
                    <h5><b style="color: darkblue">Quick Links</b></h5>
                </div>
            </div>



            <div class="col-md-4 mt-3">
                <div class="text-center text-white" style="background-color: #3d6d8c; margin-bottom: 0;">
                    <h5 class="mb-0"><b >USER LOGIN</b></h5>
                </div>

              

                <!-- USER CONTENT DISPLAY -->

                 <div class="border border-info" >
                     

                     <div class=" container mt-4" id="usercontentdisplay">

                         <h6>User Id</h6>
                         <asp:TextBox  ID="txtuserid" runat="server"  CssClass="form-control" style="width:100%" placeholder=" User ID"></asp:TextBox>
                         
                         <br />

                         <h6>Password</h6>
                          <asp:TextBox  ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" style="width:100%" placeholder="Password"></asp:TextBox>
                         
                         <p id="erroruseridpassword" runat="server" style="color:red;font-size:small" class="mb-2 mt-2 "></p>

                         <div class="mt-2 mb-4 d-flex justify-content-center">

                             <asp:Button ID="btnLogin" runat="server" Text="LOGIN" class="btn btn-primary " OnClick="btnLogin_Click" /> &nbsp;
                             <asp:Button ID="btnClear" runat="server" Text="CLEAR" class="btn btn-secondary" OnClientClick="return resetFormFields();" />

                         </div>

                     </div>

                    
                   


                </div>

            </div>



        <div class="col-md-4 text-center">
            <div class="border-bottom w100p">
                <h5><b style="color: darkblue">Announcements</b></h5>
            </div>
        </div>
    </div>

    </div>



    
       
</asp:Content>
