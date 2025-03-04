<%@ Page Title="" Language="C#" MasterPageFile="~/MBBSBDS.Master" AutoEventWireup="true" CodeBehind="apppreview.aspx.cs" Inherits="MBBS_BDS_WEBSITE.apppreview" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.2/html2pdf.bundle.min.js"></script> 
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.2/html2pdf.bundle.js"></script>
       
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/1.4.1/html2canvas.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.5.1/jspdf.umd.min.js"></script>


    <script>
        function TEMPdownloadAppPrintAsPDF() {
            // Create an iframe to load the pdfdownload.aspx page
            var iframe = document.createElement('iframe');
            iframe.style.position = 'absolute';
            iframe.style.left = '-9999px'; // Hide the iframe offscreen
            iframe.src = 'pdfdownload.aspx';  // URL of the page to be downloaded as PDF
            document.body.appendChild(iframe);

            // Wait for the iframe to fully load
            iframe.onload = function () {
                var iframeDocument = iframe.contentWindow.document;

                // Ensure content1 and content2 are available
                var content1 = iframeDocument.querySelector('.content1');
                var content2 = iframeDocument.querySelector('.content2');
                var spanElement = iframeDocument.querySelector('#prino');

                if (content1 && content2 && spanElement) {
                    // Get the innerHTML of the span and construct the file name
                    var spanText = spanElement.innerHTML.trim(); // Get the text and trim any extra spaces
                    var fileName = spanText + "_TEMP_APPL.pdf"; // Construct the file name

                    // Add watermark to content1
                    var watermark1 = document.createElement('div');
                    watermark1.innerText = 'NOT YET SUBMITTED';
                    watermark1.style.position = 'absolute';
                    watermark1.style.top = '50%';
                    watermark1.style.left = '50%';
                    watermark1.style.transform = 'translate(-50%, -50%) rotate(-45deg)';
                    watermark1.style.fontSize = '40px';
                    watermark1.style.color = 'rgba(150, 150, 150, 0.3)';
                    watermark1.style.fontWeight = 'bold';
                    watermark1.style.pointerEvents = 'none'; // Ensure the watermark is not interactive
                    content1.style.position = 'relative'; // Ensure the parent is relatively positioned
                    content1.appendChild(watermark1);

                    // Add watermark to content2
                    var watermark2 = document.createElement('div');
                    watermark2.innerText = 'NOT YET SUBMITTED';
                    watermark2.style.position = 'absolute';
                    watermark2.style.top = '50%';
                    watermark2.style.left = '50%';
                    watermark2.style.transform = 'translate(-50%, -50%) rotate(-45deg)';
                    watermark2.style.fontSize = '40px';
                    watermark2.style.color = 'rgba(150, 150, 150, 0.3)';
                    watermark2.style.fontWeight = 'bold';
                    watermark2.style.pointerEvents = 'none'; // Ensure the watermark is not interactive
                    content2.style.position = 'relative'; // Ensure the parent is relatively positioned
                    content2.appendChild(watermark2);

                    // Create a canvas to capture content1
                    html2canvas(content1, {
                        useCORS: true,   // Use cross-origin resource sharing if necessary
                        scale: 3,        // Adjust the scale for quality
                        logging: true,   // Enable logging for debugging
                    }).then(canvas1 => {
                        const imgData1 = canvas1.toDataURL("image/png");
                        const pdf = new jspdf.jsPDF("p", "mm", "a4");

                        // Define page size and margins
                        const marginTop = 5;  // Top margin in mm
                        const marginBottom = 10;  // Bottom margin in mm
                        const pageWidth = 210;  // A4 width in mm
                        const pageHeight = 297;  // A4 height in mm
                        const contentHeight = pageHeight - marginTop - marginBottom; // Height available for content

                        const imgWidth = pageWidth;
                        const imgHeight = (canvas1.height * imgWidth) / canvas1.width;

                        // Add the first page with content1
                        pdf.addImage(imgData1, "PNG", 0, marginTop, imgWidth, contentHeight);

                        // Wait for content2 to be fully rendered before capturing
                        setTimeout(function () {
                            // Now capture content2 and add it to the second page
                            html2canvas(content2, {
                                useCORS: true,
                                scale: 3,
                                logging: true,
                            }).then(canvas2 => {
                                const imgData2 = canvas2.toDataURL("image/png");

                                // Add a new page and add the second content
                                pdf.addPage();
                                pdf.addImage(imgData2, "PNG", 0, marginTop, imgWidth, contentHeight);

                                // Save the PDF with the constructed file name
                                pdf.save(fileName);

                                // Remove the iframe after generating the PDF
                                document.body.removeChild(iframe);
                            }).catch(error => {
                                console.error("Error capturing content2:", error);
                                alert("Failed to capture content2. Please try again.");
                                document.body.removeChild(iframe);
                            });
                        }, 500);  // Adjust the timeout as necessary to allow content2 to fully render
                    }).catch(error => {
                        console.error("Error capturing content1:", error);
                        alert("Failed to capture content1. Please try again.");
                        document.body.removeChild(iframe);
                    });
                } else {
                    console.error("Content1, Content2, or the span element not found");
                    alert("Required content not found on the page. Please check if the content is available.");
                    document.body.removeChild(iframe);
                }
            };
        }


        function MAINdownloadAppPrintAsPDF() {
            // Create an iframe to load the pdfdownload.aspx page
            var iframe = document.createElement('iframe');
            iframe.style.position = 'absolute';
            iframe.style.left = '-9999px'; // Hide the iframe offscreen
            iframe.src = 'pdfdownload.aspx';  // URL of the page to be downloaded as PDF
            document.body.appendChild(iframe);

            // Wait for the iframe to fully load
            iframe.onload = function () {
                var iframeDocument = iframe.contentWindow.document;

                // Ensure content1 and content2 are available
                var content1 = iframeDocument.querySelector('.content1');
                var content2 = iframeDocument.querySelector('.content2');
                var spanElement = iframeDocument.querySelector('#prino');

                if (content1 && content2 && spanElement) {
                    // Get the innerHTML of the span and construct the file name
                    var spanText = spanElement.innerHTML.trim(); // Get the text and trim any extra spaces
                    var fileName = spanText + "_APPL.pdf"; // Construct the file name

                    

                    // Create a canvas to capture content1
                    html2canvas(content1, {
                        useCORS: true,   // Use cross-origin resource sharing if necessary
                        scale: 3,        // Adjust the scale for quality
                        logging: true,   // Enable logging for debugging
                    }).then(canvas1 => {
                        const imgData1 = canvas1.toDataURL("image/png");
                        const pdf = new jspdf.jsPDF("p", "mm", "a4");

                        // Define page size and margins
                        const marginTop = 5;  // Top margin in mm
                        const marginBottom = 10;  // Bottom margin in mm
                        const pageWidth = 210;  // A4 width in mm
                        const pageHeight = 297;  // A4 height in mm
                        const contentHeight = pageHeight - marginTop - marginBottom; // Height available for content

                        const imgWidth = pageWidth;
                        const imgHeight = (canvas1.height * imgWidth) / canvas1.width;

                        // Add the first page with content1
                        pdf.addImage(imgData1, "PNG", 0, marginTop, imgWidth, contentHeight);

                        // Wait for content2 to be fully rendered before capturing
                        setTimeout(function () {
                            // Now capture content2 and add it to the second page
                            html2canvas(content2, {
                                useCORS: true,
                                scale: 3,
                                logging: true,
                            }).then(canvas2 => {
                                const imgData2 = canvas2.toDataURL("image/png");

                                // Add a new page and add the second content
                                pdf.addPage();
                                pdf.addImage(imgData2, "PNG", 0, marginTop, imgWidth, contentHeight);

                                // Save the PDF with the constructed file name
                                pdf.save(fileName);

                                // Remove the iframe after generating the PDF
                                document.body.removeChild(iframe);
                            }).catch(error => {
                                console.error("Error capturing content2:", error);
                                alert("Failed to capture content2. Please try again.");
                                document.body.removeChild(iframe);
                            });
                        }, 500);  // Adjust the timeout as necessary to allow content2 to fully render
                    }).catch(error => {
                        console.error("Error capturing content1:", error);
                        alert("Failed to capture content1. Please try again.");
                        document.body.removeChild(iframe);
                    });
                } else {
                    console.error("Content1, Content2, or the span element not found");
                    alert("Required content not found on the page. Please check if the content is available.");
                    document.body.removeChild(iframe);
                }
            };
        }


















    </script>
    <style>
        table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
}
    </style>
    
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="box-shadow: 0px 0px 50px grey; padding-top: 1px; padding-bottom: 1px;" class="mt-2 ms-3 mb-2 me-3">
        
        <h2 style="color:green;text-align:center" id="appsubmit" runat="server" visible="false">YOUR APPLICATION HAS BEEN  SUBMITTED </h2>

        <!-- table heading -->
          <div class="border border-info ms-2 mt-1 me-2" style="border-radius: 5px;">

        <div class="container-fluid">
            <div class="row">
                <div class="col-2">
                    <img src="pictures/logo.png" class="ps-2 pt-3 pb-1 " />
                </div>

                <div class="col-8 mt-1 mb-1" style="text-align: center; color: white">

                    <h6 style="color: #172e81;">GOVERNMENT OF TAMILNADU</h6>
                    <h6 style="color: #172e81;">SELECTION COMMITTEE, DIRECTORATE OF MEDICAL EDUCATION</h6>
                    <h6 style="color: #172e81;"><b>ADMISSION TO TAMILNADU MBBS/BDS </b></h6>
                    <h6 style="color: #172e81;">APPLICATION FORM FOR GOVT. QUOTA SEATS IN GOVT. COLLEGES AND</h6>
                    <h6 style="color: #172e81;">GOVT. QUOTA SEATS IN SELF-FINANCING COLLEGES FOR 2025-2026 SESSION</h6>

                </div>

                <div class="col-2 d-flex justify-content-center align-items-center" style="text-align: center;">

                    <h1>GQ</h1>

                </div>

            </div>

        </div>

        </div>

        <!-- table contents -->
        <div class="border border-info ms-2  me-2" style="border-radius: 5px;">
     

            <table class="table table-bordered border-dark" style="margin: 0;">
                <thead>
                    <tr>
                        <th  style="width: 60%;color: #172e81;">Application No : <span style="font-size:23px" id="appno" runat="server"></span></th>
                         <th  style="width: 40%;text-align:center;"> <asp:Image ID="imgBarcode" runat="server" AlternateText="" style="width:200px;height:50px" /></th>
                         
                    </tr>
                </thead>
            </table>


            <table class="table table-bordered border-dark" style="margin: 0;">

                <tbody style="color:#172e81; font-weight:600">
                    <tr>
                        <td rowspan="2" style="text-align:center;padding-top:24px;width:5%" >1</td>
                        <td style="width:50%">HSC / EQUIVALENT REG/ROLL NUMBER</td>
                        <td style="text-align:center;width:5%">:</td>
                        <td style="width:40%" id="app1a" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width:50%" >YEAR OF PASSING</td>
                        <td style="text-align:center;width:5%">:</td>
                        <td style="width:40%" id="app1b" runat="server"></td>
                    </tr>

                    <tr>
                        <td  style="text-align: center; width: 5%">2</td>
                        <td style="width: 50%">NAME</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app2" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">3</td>
                        <td style="width: 50%">PARENT NAME</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app3" runat="server"></td>
                    </tr>

                </tbody>

            </table>


            <table class="table table-bordered border-dark" style="margin: 0;border-top:hidden">
                <tbody style="color: #172e81; font-weight: 600">

                    <tr>
                        <td style="text-align: center; width: 5%">4</td>
                        <td style="width: 50%">DATE OF BIRTH</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 20%" id="app4" runat="server"></td>
                        <td style="width: 20%" rowspan="5"><img src="pictures/logo.png" class="mt-2" style="height:150px;width:150px;" alt="img" id="userimage" runat="server"/></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">5</td>
                        <td style="width: 50%">GENDER</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 20%" id="app5" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">6</td>
                        <td style="width: 50%">NATIONALITY</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 20%" id="app6" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">7</td>
                        <td style="width: 50%">RELIGION</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 20%" id="app7" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">8</td>
                        <td style="width: 50%">MOTHER TONGUE</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 20%" id="app8" runat="server"></td>
                    </tr>

                </tbody>
            </table>

            <table class="table table-bordered border-dark" style="margin:0;">
                <tbody style=" color:#172e81;font-weight: 600;border-top:hidden;">
                    <tr >
                        <td  style="text-align: center; width: 5%; ">9</td>
                        <td style="width: 50%">NATIVITY </td>
                        <td style="text-align:center;width:5%">:</td>
                        <td style="width: 40%" id="app9" runat="server"> </td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%;">10</td>
                        <td style="width: 50%">COMMUNITY </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app10" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%;">11</td>
                        <td style="width: 50%" > EDUCATION DETAILS (STUDIED 6<sup>TH</sup> STD TO 12<sup>TH</sup> STD )</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app11" runat="server"></td>
                    </tr>



                    <tr>
                        <td  style="text-align: center; width: 5%">12</td>
                        <td style="width: 50%">SUB CASTE WITH CODE </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app12" runat="server"></td>
                    </tr>

                    <tr>
                        <td rowspan="2" style="text-align: center;padding-top : 25px; width: 5%">13</td>
                        <td style="width: 55%" colspan="2"> CERTIFICATE NO : <span class="ps-1" id="app13a" runat="server" ></span></td>
                        <td style="width: 40%"> ISSUED TALUK : <span class="ps-2" id="app13c" runat="server"></span></td>
                    </tr>

                    <tr>
                        <td style="width: 55%" colspan="2">ISSUED BY : <span class="ps-5" id="app13b" runat="server"></span></td>
                        <td style="width: 40%">ISSUED DATE  : <span class="ps-4" id="app13d" runat="server"></span></td>
                    </tr>

                    

                </tbody>
            </table>

    </div>


         <div class="border border-info ms-2  me-2" style="border-radius: 5px;">
     <table class="table table-bordered border-dark" style="margin:0;">
         <tbody style="color:#172e81;font-weight: 600;border-top:hidden;" >
             <tr>
                 <td style="text-align: center;width:5%;"></td>
                 <td style="width:95%;font-weight:800;" colspan="3">NEET DETAILS </td>
             </tr>

             <tr>
                 <td style="text-align: center; width: 5%">a)</td>
                 <td style="width: 50%">REGISTER NUMBER </td>
                 <td style="text-align: center; width: 5%">:</td>
                 <td style="width: 40%" id="neetregno" runat="server"></td>
             </tr>

             <tr>
                 <td style="text-align: center; width: 5%">b)</td>
                 <td style="width: 50%">ROLL NUMBER </td>
                 <td style="text-align: center; width: 5%">:</td>
                 <td style="width: 40%" id="neetrollno" runat="server"></td>
             </tr>

             <tr>
                 <td style="text-align: center; width: 5%">c)</td>
                 <td style="width: 50%">  NEET MARKS  </td>
                 <td style="text-align: center; width: 5%">:</td>
                 <td style="width: 40%" id="neetmarks" runat="server"></td>
             </tr>

             </tbody>
         </table>
     </div>









        <div class="border border-info ms-2  me-2" style="border-radius: 5px;">
            <table class="table table-bordered border-dark" style="margin:0;">
                <tbody style="color:#172e81;font-weight: 600;border-top:hidden;" >
                    <tr>
                        <td style="text-align: center;width:5%;">14</td>
                        <td style="width:95%;font-weight:800;" colspan="3">SPECIAL RESERVATION INFORMATION </td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">a)</td>
                        <td style="width: 50%">EX - SERVICEMEN  </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app14a" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">b)</td>
                        <td style="width: 50%">  DIFFERENTLY ABLED PERSON  </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app14b" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">c)</td>
                        <td style="width: 50%"> SPORTS PERSON </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app14c" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">15</td>
                        <td style="width: 50%">QUALIFYING EXAMINATION  </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app15" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">16</td>
                        <td style="width: 50%"> 	HSC GROUP & GROUP CODE (TN STATE ONLY)   </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app16" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">17</td>
                        <td style="width: 50%">NAME OF THE BOARD OF EXAMINATION   </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app17" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">18</td>
                        <td style="width: 50%">	UNDERGOING/ COMPLETED ANY PROFESSIONAL COURSES</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app18" runat="server">- NA -</td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">a)</td>
                        <td style="width: 50%">IF YES, MENTION NAME OF THE COURSE   </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app18a" runat="server">- NA -</td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">b)</td>
                        <td style="width: 50%">YEAR OF COMPLETION OF COURSE   </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app18b" runat="server">- NA -</td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">19</td>
                        <td style="width: 50%">	PASSED ALL THE SUBJECTS OF HSC/ EQUIVALENT EXAM IN NO. OF ATTEMPTS   </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="app19" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%"></td>
                        <td style="width: 50%">DID YOU STUDIED 6<sup>th</sup> TO 12<sup>th</sup> STANDARD IN TAMILNADU GOVERNMENT SCHOOL   </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="appgovtschool" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%"></td>
                        <td style="width: 50%">DID YOU STUDIED 6<sup>th</sup> TO 12<sup>th</sup> STANDARD IN TAMILNADU UNDER RTE   </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%" id="apprte" runat="server"></td>
                    </tr>

                </tbody>

            </table>

      </div>
        <div class="border border-info ms-2  me-2" style="border-radius: 5px;">

            <table class="table table-bordered border-dark" style="margin:0;">

                <tbody style=" color:#172e81;border-top:hidden;font-weight:600">
                    <tr>
                        <td style="width:5%;text-align:center">20 </td>
                        <td style="width:95%;font-weight: 800;" colspan="3">MARKS OBTAINED IN HSC (ACADEMIC/ EQUIVALENT) EXAMINATION</td>
                        
                    </tr>
                </tbody>

            </table>

            <table class="table" style="margin: 0;">

               <thead style="color:#172e81;font-weight: 800;text-align:center;" >
                   <tr>
                       <td >SUBJECTS</td>
                       <td>REGISTER NUMBER </td>
                       <td>MONTH OF PASSING </td>
                       <td>YEAR OF PASSING</td>
                       <td>MAXIMUM MARKS</td>
                       <td>OBTAINED MARKS</td>
                   </tr>
               </thead>

                <tbody style="color:#172e81;font-weight: 600;border-top:thin;text-align:center;">

                    <tr>
                        <th scope="row" id="phy" runat="server"></th>
                        <td id="rnphy" runat="server"></td>
                        <td id="mopphy" runat="server"></td>
                        <td id="yopphy" runat="server"></td>
                        <td id="maxphy" runat="server"></td>
                        <td id="obtphy" runat="server"></td>
                    </tr>
                    <tr>
                        <th scope="row" id="che" runat="server"></th>
                        <td id="rnche" runat="server"></td>
                        <td id="mopche" runat="server"></td>
                        <td id="yopche" runat="server"></td>
                        <td id="maxche" runat="server"></td>
                        <td id="obtche" runat="server"></td>
                    </tr>
                    <tr id="BOTANY" runat="server" visible="false">
                        <th scope="row" id="bot" runat="server"></th>
                        <td id="rnbot" runat="server"></td>
                        <td id="mopbot" runat="server"></td>
                        <td id="yopbot" runat="server"></td>
                        <td id="maxbot" runat="server"></td>
                        <td id="obtbot" runat="server"></td>
                    </tr>
                    <tr id="ZOOLOGY" runat="server" visible="false">
                        <th scope="row" id="zoo" runat="server"></th>
                        <td id="rnzoo" runat="server"></td>
                        <td id="mopzoo" runat="server"></td>
                        <td id="yopzoo" runat="server"></td>
                        <td id="maxzoo" runat="server"></td>
                        <td id="obtzoo" runat="server"></td>
                    </tr>
                    <tr id="BIOLOGY" runat="server" visible="false">
                        <th scope="row" id="bio" runat="server"></th>
                        <td id="rnbio" runat="server"></td>
                        <td id="mopbio" runat="server"></td>
                        <td id="yopbio" runat="server"></td>
                        <td id="maxbio" runat="server"></td>
                        <td id="obtbio" runat="server"></td>
                    </tr>
                    <tr id="MATHSOTHERS" runat="server" visible="false">
                        <th scope="row" id="matoth" runat="server"></th>
                        <td id="rnmatoth" runat="server"></td>
                        <td id="mopmatoth" runat="server"></td>
                        <td id="yopmatoth" runat="server"></td>
                        <td id="maxmatoth" runat="server"></td>
                        <td id="obtmatoth" runat="server"></td>
                    </tr>
                </tbody>

            </table>

</div>
        <div class="border border-info ms-2  me-2" style="border-radius: 5px;">
            <table class="table table-bordered border-dark" style="margin:0;">

                <tbody style="color:#172e81;font-weight: 600;">

                    <tr>
                        <td style="width:5%;text-align:center" >21</td>
                        <td style="width:50%">MEDIUM OF THE INSTRUCATION</td>
                        <td style="width:5%;text-align:center">:</td>
                        <td style="width:40%" id="app21" runat="server"></td>
                    </tr>

                    
                    <tr>
                        <td style="width:5%;text-align:center" >22</td>
                        <td style="width:50%">CIVIC SCHOOL</td>
                        <td style="width:5%;text-align:center">:</td>
                        <td style="width:40%" id="app22" runat="server"></td>
                    </tr>

                    
                    <tr>
                        <td style="width:5%;text-align:center" >23</td>
                        <td style="width:50%">CIVIC NATIVE</td>
                        <td style="width:5%;text-align:center">:</td>
                        <td style="width:40%" id="app23" runat="server"></td>
                    </tr>
                </tbody>

            </table>

</div>

        <div class="border border-info ms-2  me-2" style="border-radius: 5px;">
            <table class="table table-bordered border-dark" style="margin: 0;">

                <tbody style="color: #172e81; border-top: hidden; font-weight: 600">
                    <tr>
                        <td style="width: 5%; text-align: center">24 </td>
                        <td style="width: 95%; font-weight: 800;" colspan="3">ACADEMIC DETAILS</td>
                    </tr>
                </tbody>

            </table>



            <table class="table" style="margin: 0;">

                <thead style="color: #172e81; font-weight: 800; text-align: center;">
                    <tr>
                        <td>CLASS</td>
                        <td>YEAR OF PASSING  </td>
                        <td>NAME OF THE SCHOOL </td>
                        <td>STATE</td>
                        <td>DISTRICT</td>
                    </tr>
                </thead>

                <tbody style="color: #172e81; font-weight: 600; border-top: thin; text-align: center;">

                    <tr>
                        <th scope="row">VI</th>
                        <td id="yop6" runat="server"></td>
                        <td id="nots6" runat="server"></td>
                        <td id="s6" runat="server"></td>
                        <td id="d6" runat="server"></td>

                    </tr>
                    <tr>
                        <th scope="row">VII</th>
                        <td id="yop7" runat="server"></td>
                        <td id="nots7" runat="server"></td>
                        <td id="s7" runat="server"></td>
                        <td id="d7" runat="server"></td>

                    </tr>
                    <tr>
                        <th scope="row">VIII</th>
                        <td id="yop8" runat="server"></td>
                        <td id="nots8" runat="server"></td>
                        <td id="s8" runat="server"></td>
                        <td id="d8" runat="server"></td>

                    </tr>
                    <tr>
                        <th scope="row">IX</th>
                        <td id="yop9" runat="server"></td>
                        <td id="nots9" runat="server"></td>
                        <td id="s9" runat="server"></td>
                        <td id="d9" runat="server"></td>

                    </tr>

                    <tr>
                        <th scope="row">X</th>
                        <td id="yop10" runat="server"></td>
                        <td id="nots10" runat="server"></td>
                        <td id="s10" runat="server"></td>
                        <td id="d10" runat="server"></td>

                    </tr>
                    <tr>
                        <th scope="row">XI</th>
                        <td id="yop11" runat="server"></td>
                        <td id="nots11" runat="server"></td>
                        <td id="s11" runat="server"></td>
                        <td id="d11" runat="server"></td>

                    </tr>
                    <tr>
                        <th scope="row">XII</th>
                        <td id="yop12" runat="server"></td>
                        <td id="nots12" runat="server"></td>
                        <td id="s12" runat="server"></td>
                        <td id="d12" runat="server"></td>

                    </tr>
                </tbody>

            </table>


            </div>

        <div class="border border-info ms-2  me-2" style="border-radius: 5px;">

            <table class="table table-bordered border-dark" style="margin:0;">

                <tbody style="color: #172e81; font-weight: 600;">

                    <tr>
                        <td style="width: 5%; text-align: center">25</td>
                        <td style="width: 50%">ARE YOU A FIRST GRADUATE APPLICANT</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app25" runat="server"></td>
                    </tr>


                    <tr>
                        <td style="width: 5%; text-align: center">26</td>
                        <td style="width: 50%">PARENT OCCUPATION</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app26" runat="server"></td>
                    </tr>


                    <tr>
                        <td style="width: 5%; text-align: center">27</td>
                        <td style="width: 50%">PARENT ANNUAL INCOME</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app27" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">28</td>
                        <td style="width: 50%">ADDRESS FOR CORRESPONDENCE</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app28" runat="server"></td>
                    </tr>


                    <tr>
                        <td style="width: 5%; text-align: center">29</td>
                        <td style="width: 50%">NATIVE DISTRICT</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app29" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">30</td>
                        <td style="width: 50%">NATIVE STATE</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app30" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">31</td>
                        <td style="width: 50%">IDENTIFICATION MARKS</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app31" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">32</td>
                        <td style="width: 50%">AADHAR NUMBER </td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app32" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">33</td>
                        <td style="width: 50%"> EMAIL ID</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app33" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">34</td>
                        <td style="width: 50%">PHONE NUMBER  </td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%" id="app34" runat="server"></td>
                    </tr>
                </tbody>

            </table>

        </div>


                 


                <div class="border border-info ms-2  me-2" style="border-radius: 5px;">

    <div class="container-fluid  ">
        <div class="row">

            <table class="table"  style="color:#172e81; font-weight:600;border-spacing: 0 15px; ">
                
                <tbody>
                   
                    <tr>
                        <th scope="row"></th>
                        <td style="font-size:small;text-align: justify"><b> * &nbsp;&nbsp;&nbsp;&nbsp;I do hereby solemnly affirm that the statement made and information furnished in my application form and in all the
 enclosures thereto submitted by me are true. Should it however be found that any information furnished therein is untrue in
 particulars, or there has been suppression of facts. I realize that I am liable for criminal prosecution and I also agree to forego
 my seat in the College at any time during the course of my study.  <br /> <br />
                            *&nbsp;&nbsp;&nbsp;&nbsp; If I failed to produce any necessary documents at any stages of counselling / admission or any wrong information furnished in
 the application form, I aware that the selection committee has rights to disqualify me and remove from this year admission 
 and merit list.</b>
                        </td>
                        <td></td>

                   

                </tbody>

             
            </table>


            <div>
                <div class="row">

                    <div class="col-2">
                        <h6 style="color:#172e81">Place :</h6>
                        <h6 style="color:#172e81">Date :</h6>
                    </div>

                    <div class="col-6">
                        <hr  class="mt-4"/>
                       <h6 style="color:#172e81;" class="text-center" id="temppdf" runat="server"> -- Download Temporary Application as PDF  -- <i class="fa fa-file-pdf" style="cursor:pointer;"  onclick="TEMPdownloadAppPrintAsPDF()"></i> </h6>
                        <h6 style="color:#172e81" class="text-center" id="mainpdf" runat="server" visible="false"> -- Download Application as PDF -- <i class="fa fa-file-pdf" style="cursor:pointer;" onclick="MAINdownloadAppPrintAsPDF()"></i></h6>
                    </div>

                    <div class="col-4">
                        <img  src="" alt="" style="height:30px; width:200px;" id="signimage" runat="server"/>

                        <h6 style="color:#172e81">( Signature of the applicant )</h6>
                    </div>

                </div>
            </div>

           

        </div>
    </div>
</div>




         <div class="d-flex justify-content-center align-items-center mb-3" style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;">


     <asp:Button  ID="btnSaveContinue" runat="server" class="btn btn-primary mt-1 mb-1" Text=" Go To Submit Page " OnClick="btnGoToSubmitPage_Click"></asp:Button>
     
 
 </div>



    </div>










    <!-- PDF DOWNLOAD PAGE -->





   


</asp:Content>


                       




