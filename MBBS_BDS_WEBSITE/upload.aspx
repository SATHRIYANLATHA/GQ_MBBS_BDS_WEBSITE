<%@ Page Title="" Language="C#" MasterPageFile="~/mbbs/MBBSBDS.Master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="mbbs_MBBS_BDS_WEBSITE.upload" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="box-shadow: 0px 0px 50px grey; padding-top: 1px; padding-bottom: 1px;" class="mt-2 ms-3 mb-2 me-3">

 <div class="border border-info ms-2 mt-1 me-2" style="border-radius: 5px;">

     <div class="ps-3 pt-1 pb-1 " style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;">
         <h5 style="color: #172e81"> DOCUMENTS UPLOAD  </h5>
     </div>


     <!--  1  -->

     <div class="border border-dark mt-3" id="R1" runat="server">

         <div class="container-fluid">

             <div class="row" >

                 <div class="col-6 pt-1 pb-1">
                     <h6 style="color: #172e81">LEFT THUMB IMPRESSION  </h6>
                     <span style="background-color: pink; font-size: small">Image 40mm X 60mm JPG format and filesize should be between </span>
                     <br />
                     <span style="background-color: pink; font-size: small">10KB and 50KB</span>

                     <br />
                     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Target="_blank"
                         Text="[VIEW IMAGE]" Style="color: blue; font-size: small;" Visible="false"></asp:HyperLink>
                 </div>

                 <div class="col-6 pt-1 ">



                     <asp:FileUpload ID="FileUpload1" runat="server" />
                     <asp:LinkButton ID="LinkButton1" runat="server" Text="Upload"
                         OnClick="btnLeftThumbImpressionUploadFile_Click"
                         Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                     <p id="success1" runat="server" class="mt-4 ms-4" style="color:green" visible="false"> </p>
                     <p id="error1" runat="server" class="mt-4 ms-4"  style="color:red" visible="false"> hello hii</p>

                 </div>

             </div>


         </div>

     </div>



     <!--  2  -->


      <div class="border border-dark " id="R2" runat="server">

     <div class="container-fluid" >

         <div class="row">

             <div class="col-6 pt-1 pb-1">
                 <h6 style="color: #172e81">LATEST PASSPORT SIZE PHOTO  </h6>
                 <span style="background-color: pink; font-size: small">Image 35mm X 45mm JPG format and filesize should be between </span>
                 <br />
                 <span style="background-color: pink; font-size: small">10KB and 100KB</span>
                 
                 <br />
                 <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Target="_blank"
                     Text="[VIEW IMAGE]" Style="color: blue; font-size: small;" Visible="false">
                 </asp:HyperLink>
             </div>

             <div class="col-6 pt-1 ">

                 <asp:FileUpload ID="FileUpload2" runat="server" />
                  <asp:LinkButton ID="LinkButton2" runat="server" Text="Upload"
                        OnClick="btnPassPortSizePhotoUploadFile_Click"
     Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                 <p id="success2" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                 <p id="error2" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

             </div>

         </div>


     </div>

 </div>





     <!-- 3  -->
          <div class="border border-dark " id="R3" runat="server">

    <div class="container-fluid" >

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">POST CARD SIZE PHOTO </h6>
                <span style="background-color: pink; font-size: small">Image 140mm X 90mm JPG format and filesize should be between </span>
                <br />
                <span style="background-color: pink; font-size: small">100KB and 300KB</span>
                
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW IMAGE]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload3" runat="server" />
                 <asp:LinkButton ID="LinkButton3" runat="server" Text="Upload"
                       OnClick="btnPostCardSizePhotoUploadFile_Click"
    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                <p id="success3" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error3" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>



     <!-- 4 -->
                      <div class="border border-dark " id="R4" runat="server"  style="display:none;" >

    <div class="container-fluid" >

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">EX-SERVICEMAN </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>
               
                
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload4" runat="server" />
                 <asp:LinkButton ID="LinkButton4" runat="server" Text="Upload"
                       OnClick="btnExServicemenUploadFile_Click"
    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                <p id="success4" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error4" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>


     


     <!-- 5 -->
                           <div class="border border-dark " id="R5" runat="server"  style="display:none;" >

    <div class="container-fluid" >

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">EMINENT SPORTS PERSON </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>
               
                
                <br />
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload5" runat="server" />
                 <asp:LinkButton ID="LinkButton5" runat="server" Text="Upload"
                       OnClick="btnEminentSportsPersonUploadFile_Click"
    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                <p id="success5" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error5" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>



     <!-- 6  -->

             <div class="border border-dark " id="R6" runat="server" style="display: none;">

                 <div class="container-fluid">

                     <div class="row">

                         <div class="col-6 pt-1 pb-1">
                             <h6 style="color: #172e81">DIFFERENTLY ABLED PERSON </h6>
                             <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                             <br />
                             <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="#" Target="_blank"
                                 Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                             </asp:HyperLink>
                         </div>

                         <div class="col-6 pt-1 ">

                             <asp:FileUpload ID="FileUpload6" runat="server" />
                             <asp:LinkButton ID="LinkButton6" runat="server" Text="Upload"
                                 OnClick="btnDifferentlyAbledPersonUploadFile_Click"
                                 Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                             <p id="success6" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                             <p id="error6" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

                         </div>

                     </div>


                 </div>

             </div>



        <!-- 18  -->

           <div class="border border-dark " id="R18" runat="server" style="display: none;">

               <div class="container-fluid">

                   <div class="row">

                       <div class="col-6 pt-1 pb-1">
                           <h6 style="color: #172e81">FG APPLICANT CERTIFICATE </h6>
                           <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                           <br />
                           <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="#" Target="_blank"
                               Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                           </asp:HyperLink>
                       </div>

                       <div class="col-6 pt-1 ">

                           <asp:FileUpload ID="FileUpload18" runat="server" />
                           <asp:LinkButton ID="LinkButton18" runat="server" Text="Upload"
                               OnClick="btnFGapplicantCertificateUploadFile_Click"
                               Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                           <p id="success18" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                           <p id="error18" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

                       </div>

                   </div>


               </div>

           </div>


     <!-- 7 -->

             <div class="border border-dark " id="R7" runat="server" >

     <div class="container-fluid">

         <div class="row">

             <div class="col-6 pt-1 pb-1">
                 <h6 style="color: #172e81">SSLC MARK SHEET </h6>
                 <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                 <br />
                 <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="#" Target="_blank"
                     Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                 </asp:HyperLink>
             </div>

             <div class="col-6 pt-1 ">

                 <asp:FileUpload ID="FileUpload7" runat="server" />
                 <asp:LinkButton ID="LinkButton7" runat="server" Text="Upload"
                        OnClick="btnSSLCMarkSheetUploadFile_Click"
                     Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                 <p id="success7" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                 <p id="error7" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

             </div>

         </div>


     </div>

 </div>


     <!-- 8 -->

                        <div class="border border-dark " id="R8" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">HSC MARK SHEET </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload8" runat="server" />
                <asp:LinkButton ID="LinkButton8" runat="server" Text="Upload"
                        OnClick="btnHSCMarkSheetUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success8" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error8" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>




     <!-- 9  -->

                             <div class="border border-dark " id="R9" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">NEET SCORE CARD </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload9" runat="server" />
                <asp:LinkButton ID="LinkButton9" runat="server" Text="Upload"
                        OnClick="btnNEETScoreCardUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success9" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error9" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>



     <!-- 10 -->
                             <div class="border border-dark " id="R10" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">TRANSFER CERTIFICATE </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload10" runat="server" />
                <asp:LinkButton ID="LinkButton10" runat="server" Text="Upload"
                       OnClick="btnTransferCertificateUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success10" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error10" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>



     <!-- 11 -->

                                     <div class="border border-dark " id="R11" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">SCHOOL BONAFIDE CERTIFICATE </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload11" runat="server" />
                <asp:LinkButton ID="LinkButton11" runat="server" Text="Upload"
                       OnClick="btnBonafideCertificateUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success11" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error11" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>


     <!-- 12 -->
                                  <div class="border border-dark " id="R12" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">COMMUNITY CERTIFICATE </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload12" runat="server" />
                <asp:LinkButton ID="LinkButton12" runat="server" Text="Upload"
                        OnClick="btnCommunityCertificateUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success12" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error12" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>



     <!-- 13 -->

             <div class="border border-dark " id="R13" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">NATIVITY CERTIFICATE </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload13" runat="server" />
                <asp:LinkButton ID="LinkButton13" runat="server" Text="Upload"
                       OnClick="btnNativityCertificateUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success13" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error13" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>



     <!-- 14 -->

        <div class="border border-dark " id="R14" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81"> PARENT COMMUNITY CERTIFICATE </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload14" runat="server" />
                <asp:LinkButton ID="LinkButton14" runat="server" Text="Upload"
                       OnClick="btnParentCommunityCertificateUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success14" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error14" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>




     
     <!-- 15 -->

             <div class="border border-dark " id="R15" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81"> PARENT STUDY CERTIFICATE (10<sup>TH</sup>/12<sup>TH</sup>/DEGREE)</h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload15" runat="server" />
                <asp:LinkButton ID="LinkButton15" runat="server" Text="Upload"
                       OnClick="btnParentStudyCertificateUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success15" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error15" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>





     <!-- 16 -->

                <div class="border border-dark " id="R16" runat="server" >

    <div class="container-fluid">

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81"> PARENT ADDRESS PROOF(DL/VOTER ID/ETC.,) </h6>
                <span style="background-color: pink; font-size: small">File in PDF format and file size should not exceeds 3MB </span>


                <br />
                <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW PDF]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload16" runat="server" />
                <asp:LinkButton ID="LinkButton16" runat="server" Text="Upload"
                       OnClick="btnParentAddressProofUploadFile_Click"
                    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />
                        
                <p id="success16" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error16" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>


          <!-- 17  -->
          <div class="border border-dark " id="R17" runat="server">

    <div class="container-fluid" >

        <div class="row">

            <div class="col-6 pt-1 pb-1">
                <h6 style="color: #172e81">SIGNATURE OF THE APPLICANT </h6>
                <span style="background-color: pink; font-size: small">Image 140mm X 90mm JPG format and filesize should be between </span>
                <br />
                <span style="background-color: pink; font-size: small">10KB and 300KB</span>
                
                <br />
                <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="#" Target="_blank"
                    Text="[VIEW IMAGE]" Style="color: blue; font-size: small;" Visible="false">
                </asp:HyperLink>
            </div>

            <div class="col-6 pt-1 ">

                <asp:FileUpload ID="FileUpload17" runat="server" />
                 <asp:LinkButton ID="LinkButton17" runat="server" Text="Upload"
                       OnClick="btnSignatureOfTheApplicantUploadFile_Click"
    Style="display: inline-block; padding: 5px 10px; border: 1px solid; text-align: center; cursor: pointer; text-decoration: none; color: black; background-color: #f0f0f0; border-radius: 4px;" />

                <p id="success17" runat="server" class="mt-4 ms-4" style="color: green" visible="false"></p>
                <p id="error17" runat="server" class="mt-4 ms-4" style="color: red" visible="false"></p>

            </div>

        </div>


    </div>

</div>





     <!--  Button Save and Continue  -->


     <div class=" d-flex justify-content-center align-items-center  mt-2" style="background-color: #dcebfb; box-sizing: border-box;flex-direction: column;">


         <div> <h6 id="docup" runat="server" style="color:red" class="mt-2" visible="false"></h6></div>
        

         <asp:LinkButton ID="btnSaveContinue" runat="server"
             OnClick="btnSaveContinue_Click"
             Text="Save & Continue"
             Style="display: inline-block; padding: 8px 15px; background-color: #007bff; color: white; border: 1px solid #007bff; border-radius: 4px; text-align: center; text-decoration: none; cursor: pointer; font-weight: bold;"  CssClass="mt-1 mb-1"/>


     </div>



    </div>
</div>

</asp:Content>
 