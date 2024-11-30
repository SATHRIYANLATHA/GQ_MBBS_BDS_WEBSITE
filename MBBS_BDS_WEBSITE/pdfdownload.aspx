<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pdfdownload.aspx.cs" Inherits="mbbs_MBBS_BDS_WEBSITE.pdfdownload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <%-- Meta tag for responsiveness --%>
    <meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0"  />

<%-- CSS --%>

<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="fontawesome/css/all.css" rel="stylesheet" />
<link href="CSS/customstylesheet.css" rel="stylesheet" />
<link href="CSS/customstylesheet.css?v=1.1" rel="stylesheet" />

   <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/1.4.1/html2canvas.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.5.1/jspdf.umd.min.js"></script>



<%-- JS --%>

<script src="bootstrap/js/jquery-3.7.1.min.js"></script>
<script src="bootstrap/js/popper.min.js"></script>
 <script src="bootstrap/js/bootstrap.min.js"></script>
<script src="fontawesome/js/all.js"></script>

  

    

         <style>
      table, th, td {
    border: 1px solid rgba(0, 0, 0, 0.1) !important; /* Use transparency for a lighter look */
    border-collapse: collapse;
}

     

</style>
</head>
<body>
    <form id="form1" runat="server">
       

            <!-- watermark content -->


        <div class="content1">
            
            
                     <div class="row" style="font-size:10px">
                <div class="col-2">
                    <img src="pictures/logo.png" class="ps-2  pt-1 " style="width:50px;width:40px" />
                </div>

                <div class="col-8 mt-1 mb-1" style="text-align: center;color: #172e81;font-size:5px ">

                    <b >GOVERNMENT OF TAMILNADU</b> <br />
                    <b >SELECTION COMMITTEE, DIRECTORATE OF MEDICAL EDUCATION</b><br />
                    <b ><b>ADMISSION TO TAMILNADU MBBS/BDS </b></b><br />
                    <b >APPLICATION FORM FOR GOVT. QUOTA SEATS IN GOVT. COLLEGES AND</b><br />
                    <b >GOVT. QUOTA SEATS IN SELF-FINANCING COLLEGES FOR 2025-2026 SESSION</b><br />

                </div>

                <div class="col-2 ps-0">

                    <h3 class="pt-2 ">GQ</h3>

                </div>

            </div>

        <div class="row ms-2 me-1">
         <table style="font-size:6px;border: 1px solid black;width: 100%;color: #172e81;  " >
                    <tbody >
                        <tr >
                            <td style="width:60%;font-weight:bold;padding-left:20px;">Application No : <span style="font-size:6px" id="prino" runat="server">hello</span></td>
                            <td  style="width: 40%;text-align:center;"> <asp:Image ID="priimgBarcode" runat="server" AlternateText="barcode" style="width:100px;height:25px"  CssClass="pt-1 pb-1"/></td>
                        </tr>

                    </tbody>

                </table>
        </div>

        <div class="row ms-2 me-1">

             <table  style="font-size:6px;border: 1px solid black;width: 100%;border-bottom:hidden">
                <tbody>
                    <tr>
                        <td rowspan="2" style="text-align: center; padding-top: 7px; width: 5%">1</td>
                        <td style="width: 50%;padding:1px">HSC / EQUIVALENT REG/ROLL NUMBER</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%;padding:1px" id="pri1a" runat="server"></td>
                    </tr>
                    
                    <tr>
                        <td style="width:50%;padding:1px" >YEAR OF PASSING</td>
                        <td style="text-align:center;width:5%">:</td>
                        <td style="width:40%;padding:1px" id="pri1b" runat="server"></td>
                    </tr>

                    <tr>
                        <td  style="text-align: center; width: 5%">2</td>
                        <td style="width: 50%;padding:1px">NAME</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%;padding:1px" id="pri2" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">3</td>
                        <td style="width: 50%;padding:1px">PARENT NAME</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%;padding:1px" id="pri3" runat="server"></td>
                    </tr>

                </tbody>

            </table>

        </div>

        <div class="row ms-2 me-1">
            <table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">

                <tbody>
                    <tr style="border-top:hidden;">
                        <td style="text-align: center; width: 5%">4</td>
                        <td style="width: 50%;padding:1px">DATE OF BIRTH</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 25%;padding:1px" id="pri4" runat="server"></td>
                        <td style="width: 15%" rowspan="5">
                            <img src="pictures/logo.png"  style="height: 45px; width: 40px;"  alt="img" id="priuserimage" runat="server" /></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">5</td>
                        <td style="width: 50%;padding:1px">GENDER</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 25%;padding:1px" id="pri5" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">6</td>
                        <td style="width: 50%;padding:1px">NATIONALITY</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 25%;padding:1px" id="pri6" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">7</td>
                        <td style="width: 50%;padding:1px">RELIGION</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 25%;padding:1px" id="pri7" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">8</td>
                        <td style="width: 50%;padding:1px">MOTHER TONGUE</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 25%;padding:1px" id="pri8" runat="server"></td>
                    </tr>
                </tbody>

            </table>

        </div>



         <div class="row ms-2 me-1">
     <table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">

          

                <tbody>

                    <tr>
                        <td style="text-align: center; width: 5%;">9</td>
                        <td style="width: 50%;padding:1px">NATIVITY </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%;padding:1px" id="pri9" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%;">10</td>
                        <td style="width: 50%;padding:1px">COMMUNITY </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%;padding:1px" id="pri10" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%;">11</td>
                        <td style="width: 50%;padding:1px">EDUCATION DETAILS (STUDIED 6<sup>th</sup> STD TO 12<sup>th</sup> STD)</td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%;padding:1px" id="pri11" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="text-align: center; width: 5%">12</td>
                        <td style="width: 50%;padding:1px">SUB CASTE WITH CODE </td>
                        <td style="text-align: center; width: 5%">:</td>
                        <td style="width: 40%;padding:1px" id="pri12" runat="server"></td>
                    </tr>

                    <tr>
                        <td rowspan="2" style="text-align: center; padding-top: 7px; width: 5%">13</td>
                        <td style="width: 55%;padding:1px" colspan="2">CERTIFICATE NO : <span class="ps-1" id="pri13a" runat="server"></span></td>
                        <td style="width: 40%;padding:1px">ISSUED TALUK : <span class="ps-2" id="pri13c" runat="server"></span></td>
                    </tr>

                    <tr>
                        <td style="width: 55%;padding:1px" colspan="2">ISSUED BY : <span class="ps-2" id="pri13b" runat="server"></span></td>
                        <td style="width: 40%;padding:1px">ISSUED DATE  : <span class="ps-2" id="pri13d" runat="server"></span></td>
                    </tr>
                </tbody>

            </table>

        
             </div>



            <div class="row ms-2 me-1">
<table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">
    
                     <tbody>

                         <tr>
                             <td style="text-align: center; width: 5%;"></td>
                             <td style="color: #172e81;width: 95%; font-weight: 600;padding:1px" colspan="3">NEET DETAILS </td>
                         </tr>

                         <tr>
                             <td style="text-align: center; width: 5%">a)</td>
                             <td style="width: 50%;padding:1px">REGISTER NUMBER </td>
                             <td style="text-align: center; width: 5%">:</td>
                             <td style="width: 40%;padding:1px" id="prineetregno" runat="server"></td>
                         </tr>

                         <tr>
                             <td style="text-align: center; width: 5%">a)</td>
                             <td style="width: 50%; padding: 1px">ROLL NUMBER </td>
                             <td style="text-align: center; width: 5%">:</td>
                             <td style="width: 40%; padding: 1px" id="prineetrollno" runat="server"></td>
                         </tr>

                         <tr>
                             <td style="text-align: center; width: 5%">b)</td>
                             <td style="width: 50%;padding:1px">NEET MARKS  </td>
                             <td style="text-align: center; width: 5%">:</td>
                             <td style="width: 40%;padding:1px" id="prineetmarks" runat="server"></td>
                         </tr>
                     </tbody>
              </table>

                </div>


                    <div class="row ms-2 me-1 ">
<table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">

     <tbody>
                      <tr>
                          <td style="text-align: center; width: 5%;">14</td>
                          <td style="color: #172e81;width: 95%; font-weight: 600;padding:1px" colspan="3">SPECIAL RESERVATION INFORMATION </td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">a)</td>
                          <td style="width: 50%;padding:1px">EX - SERVICEMEN  </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri14a" runat="server"></td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">b)</td>
                          <td style="width: 50%;padding:1px">DIFFERENTLY ABLED PERSON  </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri14b" runat="server"></td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">c)</td>
                          <td style="width: 50%;padding:1px">SPORTS PERSON </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri14c" runat="server"></td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">15</td>
                          <td style="width: 50%;padding:1px">QUALIFYING EXAMINATION  </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri15" runat="server"></td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">16</td>
                          <td style="width: 50%;padding:1px">HSC GROUP & GROUP CODE (TN STATE ONLY)   </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri16" runat="server"></td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">17</td>
                          <td style="width: 50%;padding:1px">NAME OF THE BOARD OF EXAMINATION   </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri17" runat="server"></td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">18</td>
                          <td style="width: 50%;padding:1px">UNDERGOING/ COMPLETED ANY PROFESSIONAL COURSES</td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri18" runat="server">- NA -</td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">a)</td>
                          <td style="width: 50%;padding:1px">IF YES, MENTION NAME OF THE COURSE   </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri18a" runat="server">- NA -</td>
                      </tr>

                      <tr>
                          <td style="text-align: center; width: 5%">b)</td>
                          <td style="width: 50%;padding:1px">YEAR OF COMPLETION OF COURSE   </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri18b" runat="server">- NA -</td>
                      </tr>
        
                      <tr>
                          <td style="text-align: center; width: 5%">19</td>
                          <td style="width: 50%;padding:1px">PASSED ALL THE SUBJECTS OF HSC/ EQUIVALENT EXAM IN NO. OF ATTEMPTS   </td>
                          <td style="text-align: center; width: 5%">:</td>
                          <td style="width: 40%;padding:1px" id="pri19" runat="server"></td>
                      </tr>

                     <tr>
                         <td style="text-align: center; width: 5%"></td>
                         <td style="width: 50%; padding: 1px">DID YOU STUDIED 6<sup>th</sup> TO 12<sup>th</sup> STANDARD IN TAMILNADU GOVERNMENT SCHOOL  </td>
                         <td style="text-align: center; width: 5%">:</td>
                         <td style="width: 40%; padding: 1px" id="prigovtschool" runat="server"></td>
                     </tr>


                     <tr>
                         <td style="text-align: center; width: 5%"></td>
                         <td style="width: 50%; padding: 1px">DID YOU STUDIED 6<sup>th</sup> TO 12<sup>th</sup> STANDARD IN TAMILNADU UNDER RTE  </td>
                         <td style="text-align: center; width: 5%">:</td>
                         <td style="width: 40%; padding: 1px" id="prirte" runat="server"></td>
                     </tr>

     </tbody>

    </table>
</div>

        </div>
        


        <div class="content2">
            
             
                                        <div class="row ms-2 me-1  ">
                                           
<table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">

     <tbody>

                     <tr>
                         <td style="width: 5%; text-align: center">20 </td>
                         <td style="color: #172e81;width: 95%; font-weight: 600;padding:2px;" colspan="3">MARKS OBTAINED IN HSC (ACADEMIC/ EQUIVALENT) EXAMINATION</td>

                     </tr>

                 </tbody>


    </table>
     </div>



         <div class="row ms-2 me-1  ">
<table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">

     <thead style="color: #172e81; font-weight: 600; text-align: center;">
                    <tr>
                        <td style="padding:2px;">SUBJECTS</td>
                        <td style="padding:2px;">REGISTER NUMBER </td>
                        <td style="padding:2px;">MONTH OF PASSING </td>
                        <td style="padding:2px;">YEAR OF PASSING</td>
                        <td style="padding:2px;">MAXIMUM MARKS</td>
                        <td style="padding:2px;">OBTAINED MARKS</td>
                    </tr>
                </thead>
                 <tbody style="text-align: center;">

                     <tr style="border-bottom:hidden">
                         <th scope="row" id="priphy" runat="server" style="padding:1px;">hi</th>
                         <td id="prirnphy" runat="server" style="padding:1px;">hi</td>
                         <td id="primopphy" runat="server" style="padding:1px;">hi</td>
                         <td id="priyopphy" runat="server" style="padding:1px;">hi</td>
                         <td id="primaxphy" runat="server" style="padding:1px;">hi</td>
                         <td id="priobtphy" runat="server" style="padding:1px;">hi</td>
                     </tr>
                     <tr style="border-bottom:hidden">
                         <th scope="row" id="priche" runat="server" style="padding:1px;">hello</th>
                         <td id="prirnche" runat="server" style="padding:1px;">hello</td>
                         <td id="primopche" runat="server" style="padding:1px;">hello</td>
                         <td id="priyopche" runat="server" style="padding:1px;">hello</td>
                         <td id="primaxche" runat="server" style="padding:1px;">hello</td>
                         <td id="priobtche" runat="server" style="padding:1px;">hello</td>
                     </tr>
                     <tr id="priBOTANY" runat="server" visible="false" style="border-bottom:hidden">
                         <th scope="row" id="pribot" runat="server" style="padding:1px;"></th>
                         <td id="prirnbot" runat="server" style="padding:1px;"></td>
                         <td id="primopbot" runat="server" style="padding:1px;"></td>
                         <td id="priyopbot" runat="server" style="padding:1px;"></td>
                         <td id="primaxbot" runat="server" style="padding:1px;"></td>
                         <td id="priobtbot" runat="server" style="padding:1px;"></td>
                     </tr>
                     <tr id="priZOOLOGY" runat="server" visible="false" style="border-bottom:hidden">
                         <th scope="row" id="prizoo" runat="server" style="padding:1px;"></th>
                         <td id="prirnzoo" runat="server" style="padding:1px;"></td>
                         <td id="primopzoo" runat="server" style="padding:1px;"></td>
                         <td id="priyopzoo" runat="server" style="padding:1px;" ></td>
                         <td id="primaxzoo" runat="server" style="padding:1px;"></td>
                         <td id="priobtzoo" runat="server" style="padding:1px;"></td>
                     </tr>
                     <tr id="priBIOLOGY" runat="server" visible="false" style="border-bottom:hidden">
                         <th scope="row" id="pribio" runat="server" style="padding:1px;"></th>
                         <td id="prirnbio" runat="server" style="padding:1px;"></td>
                         <td id="primopbio" runat="server" style="padding:1px;"></td>
                         <td id="priyopbio" runat="server" style="padding:1px;"></td>
                         <td id="primaxbio" runat="server" style="padding:1px;"></td>
                         <td id="priobtbio" runat="server" style="padding:1px;"></td>
                     </tr>
                     <tr id="priMATHSOTHERS" runat="server" visible="false" style="border-bottom:hidden">
                         <th scope="row" id="primatoth" runat="server" style="padding:1px;"></th>
                         <td id="prirnmatoth" runat="server" style="padding:1px;"></td>
                         <td id="primopmatoth" runat="server" style="padding:1px;"></td>
                         <td id="priyopmatoth" runat="server" style="padding:1px;"></td>
                         <td id="primaxmatoth" runat="server" style="padding:1px;"></td>
                         <td id="priobtmatoth" runat="server" style="padding:1px;"></td>
                     </tr>


                 </tbody>




    </table>
         </div>



        
             <div class="row ms-2 me-1  ">
<table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">
      <tbody>
                     <tr>
                         <td style="width: 5%; text-align: center">21</td>
                         <td style="width: 50%;padding:1px">MEDIUM OF THE INSTRUCATION</td>
                         <td style="width: 5%; text-align: center">:</td>
                         <td style="width: 40%;padding:1px" id="pri21" runat="server"></td>
                     </tr>

          
                     <tr>
                         <td style="width: 5%; text-align: center">22</td>
                         <td style="width: 50%;padding:1px">CIVIC SCHOOL</td>
                         <td style="width: 5%; text-align: center">:</td>
                         <td style="width: 40%;padding:1px" id="pri22" runat="server"></td>
                     </tr>


                     <tr>
                         <td style="width: 5%; text-align: center">23</td>
                         <td style="width: 50%;padding:1px">CIVIC NATIVE</td>
                         <td style="width: 5%; text-align: center">:</td>
                         <td style="width: 40%;padding:1px" id="pri23" runat="server"></td>
                     </tr>
                 </tbody>

    </table>
                 </div>



                     <div class="row ms-2 me-1  ">
<table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">

    <thead >
                    <tr>
    <td style="width: 5%; text-align: center">24 </td>
    <td style="width: 95%; color: #172e81;font-weight: 600;padding:2px;" colspan="3">ACADEMIC DETAILS</td>
</tr>
                   </thead>  

    </table>
            </div>


     <div class="row ms-2 me-1  ">
<table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">

    <thead style="color: #172e81; font-weight: 600; text-align: center;">
                    <tr>
                        <td style="padding:2px;">CLASS</td>
                        <td style="padding:2px;">YEAR OF PASSING  </td>
                        <td style="padding:2px;">NAME OF THE SCHOOL </td>
                        <td style="padding:2px;">STATE</td>
                        <td style="padding:2px;">DISTRICT</td>
                    </tr>
                </thead>

                <tbody  style="text-align: center;">

                    <tr>
                        <th scope="row" style="color: #172e81;font-weight:bold;padding:1px;" >VI</th>
                        <td id="priyop6" runat="server" style="padding:1px;"></td>
                        <td id="prinots6" runat="server" style="padding:1px;"></td>
                        <td id="pris6" runat="server" style="padding:1px;"></td>
                        <td id="prid6" runat="server" style="padding:1px;"></td>
                    </tr>

                    <tr>
                        <th scope="row" style="color: #172e81;font-weight:bold;padding:1px;">VII</th>
                        <td id="priyop7" runat="server" style="padding:1px;"></td>
                        <td id="prinots7" runat="server" style="padding:1px;"></td>
                        <td id="pris7" runat="server" style="padding:1px;"></td>
                        <td id="prid7" runat="server" style="padding:1px;"></td>
                    </tr>

                    <tr>
                        <th scope="row" style="color: #172e81;font-weight:bold;padding:2px;">VIII</th>
                        <td id="priyop8" runat="server" style="padding:1px;"></td>
                        <td id="prinots8" runat="server" style="padding:1px;"></td>
                        <td id="pris8" runat="server" style="padding:1px;"></td>
                        <td id="prid8" runat="server" style="padding:1px;"></td>
                    </tr>

                    <tr>
                        <th scope="row" style="color: #172e81;font-weight:bold;padding:1px;" >IX</th>
                        <td id="priyop9" runat="server" style="padding:1px;"></td>
                        <td id="prinots9" runat="server" style="padding:1px;"></td>
                        <td id="pris9" runat="server" style="padding:1px;"></td>
                        <td id="prid9" runat="server" style="padding:1px;"></td>
                    </tr>

                    <tr>
                        <th scope="row" style="color: #172e81;font-weight:bold;padding:1px;">X</th>
                        <td id="priyop10" runat="server" style="padding:1px;"></td>
                        <td id="prinots10" runat="server" style="padding:1px;"></td>
                        <td id="pris10" runat="server" style="padding:1px;"></td>
                        <td id="prid10" runat="server" style="padding:1px;"></td>
                    </tr>

                    <tr>
                        <th scope="row" style="color: #172e81;font-weight:bold;padding:1px;">XI</th>
                        <td id="priyop11" runat="server" style="padding:1px;"></td>
                        <td id="prinots11" runat="server" style="padding:1px;"></td>
                        <td id="pris11" runat="server" style="padding:1px;"></td>
                        <td id="prid11" runat="server" style="padding:1px;"></td>
                    </tr>

                    <tr>
                        <th scope="row" style="color: #172e81;font-weight:bold;padding:1px;">XII</th>
                        <td id="priyop12" runat="server" style="padding:1px;"></td>
                        <td id="prinots12" runat="server" style="padding:1px;"></td>
                        <td id="pris12" runat="server" style="padding:1px;"></td>
                        <td id="prid12" runat="server" style="padding:1px;"></td>
                    </tr>

                </tbody>

    </table>
        </div>



             <div class="row ms-2 me-1  ">
<table  style="font-size:6px;border: 1px solid black;width: 100%;border-top:hidden;">

     <tbody>
                    <tr>
                        <td style="width: 5%; text-align: center">25</td>
                        <td style="width: 50%;padding:1px">ARE YOU A FIRST GRADUATE APPLICANT</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri25" runat="server"></td>
                    </tr>


                    <tr>
                        <td style="width: 5%; text-align: center">26</td>
                        <td style="width: 50%;padding:1px">PARENT OCCUPATION</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri26" runat="server"></td>
                    </tr>


                    <tr>
                        <td style="width: 5%; text-align: center">27</td>
                        <td style="width: 50%;padding:1px">PARENT ANNUAL INCOME</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri27" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">28</td>
                        <td style="width: 50%;padding:1px">ADDRESS FOR CORRESPONDENCE</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri28" runat="server"></td>
                    </tr>


                    <tr>
                        <td style="width: 5%; text-align: center">29</td>
                        <td style="width: 50%;padding:1px">NATIVE DISTRICT</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri29" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">30</td>
                        <td style="width: 50%;padding:1px">NATIVE STATE</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri30" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">31</td>
                        <td style="width: 50%;padding:1px">IDENTIFICATION MARKS</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri31" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">32</td>
                        <td style="width: 50%;padding:1px">AADHAR NUMBER </td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri32" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">33</td>
                        <td style="width: 50%;padding:1px">EMAIL ID</td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri33" runat="server"></td>
                    </tr>

                    <tr>
                        <td style="width: 5%; text-align: center">34</td>
                        <td style="width: 50%;padding:1px">PHONE NUMBER  </td>
                        <td style="width: 5%; text-align: center">:</td>
                        <td style="width: 40%;padding:1px" id="pri34" runat="server"></td>
                    </tr>
                </tbody>

    </table>
            </div>

        
                     <div class="row ms-2 me-1  ">
<table  style="font-size:3px;border: 1px solid black;width: 100%;border-top:hidden;">

     <tbody>
                   
                    <tr>
                        <th scope="row"></th>
                        <td style="text-align: justify" class="pb-1 mb-1" ><b> * &nbsp;&nbsp;&nbsp;&nbsp;I do hereby solemnly affirm that the statement made and information furnished in my application form and in all the
 enclosures thereto submitted by me are true. Should it however be found that any information furnished therein is untrue in
 particulars, or there has been suppression of facts. I realize that I am liable for criminal prosecution and I also agree to forego
 my seat in the College at any time during the course of my study.  <br /> <br />
                            *&nbsp;&nbsp;&nbsp;&nbsp; If I failed to produce any necessary documents at any stages of counselling / admission or any wrong information furnished in
 the application form, I aware that the selection committee has rights to disqualify me and remove from this year admission 
 and merit list.</b>
                        </td>
                        <td></td>

                   </tr>
                </tbody>

    </table>
     </div>

        <div class="border border-dark ms-2 me-1" style=" border: 1px solid rgba(0, 0, 0, 0.1) !important; border-collapse: collapse;">
          <div class="row " style="font-size:10px" >
              <div class="col-2" style="font-size:6px">
                  <h6 style="color:#172e81;font-size:6px">Place :</h6>
             <h6 style="color:#172e81;font-size:6px">Date :</h6>
              </div>

              <div class="col-6">

              </div>

              <div class="col-4 mt-1 pe-1">
                  <img src="pictures/logo.png"  style="height:15px; width: 60px;"  alt="img" id="prisignimage" runat="server" />
                  <h6 style="color:#172e81;font-size:6px" >( Signature of the applicant )</h6>
              </div>

              </div>

            </div>

        </div>
                           

    </form>
</body>
</html>
