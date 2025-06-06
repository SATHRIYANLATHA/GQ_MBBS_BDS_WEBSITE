<%@ Page Title="" Language="C#" MasterPageFile="~/mbbs/MBBSBDS.Master" AutoEventWireup="true" CodeFile="AppSubmit.aspx.cs" Inherits="mbbs_MBBS_BDS_WEBSITE.AppSubmit" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function confirmSubmission() {
            // Ask for confirmation only once
            if (!confirm("Are you sure you want to proceed to submission? You won’t be able to make changes afterward.")) {
                return false;
            }

            // Disable future confirmation and proceed to download PDF
            var submitBtn = document.getElementById('<%= SUBMIT.ClientID %>');
    submitBtn.setAttribute("onclick", ""); // Remove any onclick event
    submitBtn.onclick = null;

    dummyMAINdownloadAppPrintAsPDF();
    return false; // Prevent default button action
}

function dummyMAINdownloadAppPrintAsPDF() {
    var iframe = document.createElement('iframe');
    iframe.style.position = 'absolute';
    iframe.style.left = '-9999px';
    iframe.src = 'pdfdownload.aspx';
    document.body.appendChild(iframe);

    iframe.onload = function () {
        var iframeDocument = iframe.contentWindow.document;
        var content1 = iframeDocument.querySelector('.content1');
        var content2 = iframeDocument.querySelector('.content2');
        var spanElement = iframeDocument.querySelector('#prino'); // Application Number Element

        if (content1 && content2 && spanElement) {
            var appNumber = spanElement.innerHTML.trim(); // ✅ Extract Application Number
            var fileName = appNumber + "_Application.pdf"; // ✅ Dynamic File Name

            html2canvas(content1, { useCORS: true, scale: 3 }).then(canvas1 => {
                const imgData1 = canvas1.toDataURL("image/png");
                const pdf = new jspdf.jsPDF("p", "mm", "a4");
                pdf.addImage(imgData1, "PNG", 0, 5, 210, 280);

                setTimeout(() => {
                    html2canvas(content2, { useCORS: true, scale: 3 }).then(canvas2 => {
                        const imgData2 = canvas2.toDataURL("image/png");
                        pdf.addPage();
                        pdf.addImage(imgData2, "PNG", 0, 5, 210, 280);

                        var pdfBlob = pdf.output("blob");  // Convert PDF to Blob

                        // ✅ Upload PDF to backend with Application Number
                        var formData = new FormData();
                        formData.append("pdfFile", pdfBlob, fileName);
                        formData.append("appNumber", appNumber); // ✅ Send Application Number

                        fetch("pdfdownload.aspx", {
                            method: "POST",
                            body: formData
                        })
                        .then(response => response.text())
                        .then(result => {
                            console.log(result);
                            pdf.save(fileName); // ✅ Save as {ApplicationNumber}_Application.pdf

                            // ✅ Trigger submit button AFTER PDF is processed
                            setTimeout(() => {
                                var submitBtn = document.getElementById('<%= SUBMIT.ClientID %>');
                                submitBtn.setAttribute("onclick", ""); // Remove onclick attribute
                                submitBtn.onclick = null; // Ensure no JS events

                                submitBtn.click(); // ✅ Perform final submission
                            }, 1000); // Small delay to allow PDF saving
                        })
                            .catch(error => console.error("Upload error:", error));

                        document.body.removeChild(iframe);
                    });
                }, 500);
            });
                }
            };
        }


    </script>

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
    OnClientClick="return confirmSubmission();">
</asp:Button>

</div>




        </div>

        </div>

</asp:Content>
