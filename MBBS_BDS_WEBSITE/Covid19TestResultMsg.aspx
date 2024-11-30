<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="Covid19TestResultMsg.aspx.cs" Inherits="Covid19TestResultMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Fixing header -->
    <script src="jquery/3.4.1/jquery.slim.min.js"></script>
    <script src="bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
    <link href="bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />

    <link href="CustomCss/StyleSheet.css" rel="stylesheet" />
    <link href="CustomCss/Loader.css" rel="stylesheet" />
    <style>
        .padlft20 {
            padding-left: 20px;
        }

        .txtrightAlign {
            text-align: right;
        }

        .UsrupdFile {
            position: relative;
            overflow: hidden;
            margin: 10px;
        }

            .UsrupdFile input.upload {
                position: absolute;
                top: 0;
                right: 0;
                margin: 0;
                padding: 0;
                font-size: 20px;
                cursor: pointer;
                opacity: 0;
                filter: alpha(opacity=0);
            }
    </style>

    <title></title>
</head>
<body style="background-color: #28a74517;">
    <form id="form1" runat="server">
        <div runat="server" visible="true" id="Div1" class="container">
            <div style="padding-top: 10px; padding-bottom: 10px; width: 100%; text-align: left; font-family: ui-sans-serif; font-size: 20px; color: #1b00ff; font-weight: 700;">COVID19 MEDICAL TEST RESULT</div>
        </div>

        <div runat="server" visible="true" id="input_panel" class="container">
            <div class="panel-group" style="margin-bottom: 10px">
                <div class="panel panel-info">
                    <div class="panel-heading" style="font-size: 20px; background-color: #28a74569">
                        <span style="padding: 20px">Excel Upload</span>
                    </div>
                    <div class="panel-body">

                        <div class="row">

                            <div class="col 4">
                                <asp:FileUpload ID="UsrupdFile" Style="height: 100%" class="btn btn-secondary" runat="server" />
                                <span style="color: red; display: none" id="err_txtName"></span>
                            </div>
                            <div class="col 4" style="text-align: right">
                                <asp:Button ID="buttImport" Style="height: 100%" class="btn btn-primary" OnClick="buttImport_Click" runat="server" Text="Upload" />

                            </div>
                        </div>
                        <div class="row padlft20">
                            <asp:Label ID="labupderror" Style="color: #2d00ff" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--   <div class="panel panel-info">
                    <div class="panel-heading" style="font-size:20px;background-color:#28a74569">
                        <span style="padding: 20px">Excel Upload File Instructions</span>
                    </div>
                        </div>--%>


                <br />

                <div class="panel panel-info" id="panel_excelerrormsg" runat="server" visible="false">
                    <div class="panel-heading text-left ml-auto" style="font-size: 20px; background-color: #28a7454a">
                        <span style="padding: 20px; color: red">Please correct the below errors in the excel file and upload again</span>
                    </div>
                    <div class="panel-body">
                        <div class="row pl-4 p-1">
                            <asp:Label ID="lab_excelerrormsg" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <br />
                <div class="panel panel-info">
                    <div class="panel-heading text-center ml-auto" style="font-size: 20px; background-color: #28a7454a">
                        <span style="padding: 20px">File Upload Instructions</span>
                    </div>


                    <div class="panel-body">
                        <div class=" row pl-4 p-1">
                            <div>Upload file should be in the format of &nbsp;<b> .xls</b> &nbsp;or &nbsp;<b> .xlsx</b></div>
                            <div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="UploadedDocuments/COVID19_SMSTEMPLATE.xlsx" style="cursor: pointer; color: blue"> <u>Download Sample File</u></a></div>
                        </div>
                        <div class="row pl-4 p-1">
                            First Row should be the Header Row                            
                        </div>
                        <div class="row pl-4 p-1">
                            1) First Column should be the LAB No and its alpha numeric, lenght should not exceed 20 characters
                        </div>
                        <div class="row pl-4 p-1">
                            2) Second Column should be the Patient Name
                        </div>
                        <div class="row pl-4 p-1">
                            3) Third Column should be the Age and Gender, example 45/M
                        </div>
                        <div class="row pl-4 p-1">
                            4) Fourth Column should be the Address, length should not exceed 300 characters.
                        </div>
                        <div class="row pl-4 p-1">
                            5) Fifth Column should be the Mobile number and it should be a number of length 10 digits
                        </div>
                        <div class="row pl-4 p-1">
                            6) Sixth Column should be the Name of the Hospital
                        </div>
                        <div class="row pl-4 p-1">
                            7) Seventh Column should be the Date of Receiving, in the format of dd.mm.yyyy
                        </div>
                        <div class="row pl-4 p-1">
                            8) Eight Column should be the Date of Dispatch, in the format of dd.mm.yyyy
                        </div>
                        <div class="row pl-4 p-1">
                            9) Ninth Column should be Result and it should be text Positive or Negative
                        </div>
                        <div class="row pl-4 p-1">
                            10) Tenth Column should be SRF ID and it should be a alphanumeric
                        </div>

                    </div>
                </div>



            </div>
            

        </div>

         

        <div runat="server" visible="false" id="result_panel" class="container">
            <div><b>Uploaded File Name </b>: <%=upldfilename%> </div>
            <div><b>No of Records in the File </b>: <%=noofrecords%><br />
            </div>
            <div class="panel-group" style="margin-top: 20px">


                <div style="font-size: 20px; width: 100%;">
                    <div style="text-align: center; margin-left: 20px; color: red">
                        <asp:Label ID="lab_successmsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <div class="panel-heading" style="font-size: 20px; width: 100%; background-color: #28a74569">
                    <div class="row">
                        <span style="margin-left: 20px">Processed Data</span>
                    </div>
                </div>

                <div class="row  ml-0 mr-0" style="overflow: auto; max-height: 400px;">
                    <asp:GridView ID="GridView1" runat="server">
                        <%--  <columns>
                                <asp:BoundField HeaderText="LAB NO" DataField="ColumnName" />
                                </columns>--%>
                    </asp:GridView>

                </div>
                <div class="row" style="text-align: center">
                    <div class="col-12" style="margin-top: 20px">
                        <asp:Button ID="btn_SendSMS" class="btn btn-primary" OnClick="btn_SendSMS_Click" runat="server" Text="Save & Send SMS to All" />
                        <asp:Button ID="btn_Back" class="btn btn-secondary" OnClick="btn_Back_Click" runat="server" Text="Back<<" />
                    </div>
                </div>
                 
                <asp:HiddenField ID="hdn_xlrawdata" runat="server" />
                <asp:HiddenField ID="hdn_upldfilename" runat="server" />
                <asp:HiddenField ID="hdn_noofrecords" runat="server" Value="0" />

                 
            </div>

        </div>

 

    </form>
</body>
</html>
