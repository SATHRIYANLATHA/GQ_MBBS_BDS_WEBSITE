<%@ Page Title=""  EnableEventValidation="false" Language="C#" MasterPageFile="~/MBBSBDS.Master" AutoEventWireup="true" CodeBehind="sos.aspx.cs" Inherits="MBBS_BDS_WEBSITE.sos" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /* For Chrome, Safari, Edge, Opera */
input[type="number"]::-webkit-inner-spin-button,
input[type="number"]::-webkit-outer-spin-button {
    -webkit-appearance: none;
    margin: 0;
}

/* For Firefox */
input[type="number"] {
    -moz-appearance: textfield;
}

    </style>

    <script type="text/javascript">
        function toggleCheckbox(clickedCheckbox) {
            var checkbox1 = document.getElementById('<%= checkbox1.ClientID %>');
            var checkbox2 = document.getElementById('<%= checkbox2.ClientID %>');

            // Ensure at least one checkbox is checked
            if (checkbox1.checked && clickedCheckbox === checkbox2) {
                checkbox1.checked = false;
            } else if (checkbox2.checked && clickedCheckbox === checkbox1) {
                checkbox2.checked = false;
            }

            // Always check one checkbox
            if (!checkbox1.checked && !checkbox2.checked) {
                clickedCheckbox.checked = true;
            }

            boxchecking(); // Call to update the state of other controls
        }

        function boxchecking() {
            var checkbox1 = document.getElementById('<%= checkbox1.ClientID %>');
            var checkbox2 = document.getElementById('<%= checkbox2.ClientID %>');


            var RNBOT = document.getElementById('<%= RNBOT.ClientID %>');
            var MOPBOT = document.getElementById('<%= MOPBOT.ClientID %>');
            var YOPBOT = document.getElementById('<%= YOPBOT.ClientID %>');
            var MAXMARKSBOT = document.getElementById('<%= MAXMARKSBOT.ClientID %>');
            var OBTMARKSBOT = document.getElementById('<%= OBTMARKSBOT.ClientID %>');

            var RNZOO = document.getElementById('<%= RNZOO.ClientID %>');
            var MOPZOO = document.getElementById('<%= MOPZOO.ClientID %>');
            var YOPZOO = document.getElementById('<%= YOPZOO.ClientID %>');
            var MAXMARKSZOO = document.getElementById('<%= MAXMARKSZOO.ClientID %>');
            var OBTMARKSZOO = document.getElementById('<%= OBTMARKSZOO.ClientID %>');


            var RNBIO = document.getElementById('<%= RNBIO.ClientID %>');
            var MOPBIO = document.getElementById('<%= MOPBIO.ClientID %>');
            var YOPBIO = document.getElementById('<%= YOPBIO.ClientID %>');
            var MAXMARKSBIO = document.getElementById('<%= MAXMARKSBIO.ClientID %>');
            var OBTMARKSBIO = document.getElementById('<%= OBTMARKSBIO.ClientID %>');

            var RNMATOTH = document.getElementById('<%= RNMATOTH.ClientID %>');
            var MOPMATOTH = document.getElementById('<%= MOPMATOTH.ClientID %>');
            var YOPMATOTH = document.getElementById('<%= YOPMATOTH.ClientID %>');
            var MAXMARKSMATOTH = document.getElementById('<%= MAXMARKSMATOTH.ClientID %>');
            var OBTMARKSMATOTH = document.getElementById('<%= OBTMARKSMATOTH.ClientID %>');

            if (checkbox1.checked) {

                RNBOT.removeAttribute('disabled');
                MOPBOT.removeAttribute('disabled');
                YOPBOT.removeAttribute('disabled');
                MAXMARKSBOT.removeAttribute('disabled');
                OBTMARKSBOT.removeAttribute('disabled');

                RNZOO.removeAttribute('disabled');
                MOPZOO.removeAttribute('disabled');
                YOPZOO.removeAttribute('disabled');
                MAXMARKSZOO.removeAttribute('disabled');
                OBTMARKSZOO.removeAttribute('disabled');

                RNBIO.value = "";
                RNBIO.setAttribute('disabled', 'disabled');

                MOPBIO.value = "";
                MOPBIO.setAttribute('disabled', 'disabled');

                YOPBIO.value = "";
                YOPBIO.setAttribute('disabled', 'disabled');

                MAXMARKSBIO.value = "";
                MAXMARKSBIO.setAttribute('disabled', 'disabled');

                OBTMARKSBIO.value = "";
                OBTMARKSBIO.setAttribute('disabled', 'disabled');



                RNMATOTH.value = "";
                RNMATOTH.setAttribute('disabled', 'disabled');

                MOPMATOTH.value = "";
                MOPMATOTH.setAttribute('disabled', 'disabled');

                YOPMATOTH.value = "";
                YOPMATOTH.setAttribute('disabled', 'disabled');
                
                MAXMARKSMATOTH.value = "";
                MAXMARKSMATOTH.setAttribute('disabled', 'disabled');

                OBTMARKSMATOTH.value = "";
                OBTMARKSMATOTH.setAttribute('disabled', 'disabled');

                

            }
            if (checkbox2.checked) {

                RNBIO.removeAttribute('disabled');
                MOPBIO.removeAttribute('disabled');
                YOPBIO.removeAttribute('disabled');
                MAXMARKSBIO.removeAttribute('disabled');
                OBTMARKSBIO.removeAttribute('disabled');

                RNMATOTH.removeAttribute('disabled');
                MOPMATOTH.removeAttribute('disabled');
                YOPMATOTH.removeAttribute('disabled');
                MAXMARKSMATOTH.removeAttribute('disabled');
                OBTMARKSMATOTH.removeAttribute('disabled');

                RNBOT.value = "";
                RNBOT.setAttribute('disabled', 'disabled');

                MOPBOT.value = "";
                MOPBOT.setAttribute('disabled', 'disabled');

                YOPBOT.value = "";
                YOPBOT.setAttribute('disabled', 'disabled');

                MAXMARKSBOT.value = "";
                MAXMARKSBOT.setAttribute('disabled', 'disabled');

                OBTMARKSBOT.value = "";
                OBTMARKSBOT.setAttribute('disabled', 'disabled');


                RNZOO.value = "";
                RNZOO.setAttribute('disabled', 'disabled');

                MOPZOO.value = "";
                MOPZOO.setAttribute('disabled', 'disabled');

                YOPZOO.value = "";
                YOPZOO.setAttribute('disabled', 'disabled');

                MAXMARKSZOO.value = "";
                MAXMARKSZOO.setAttribute('disabled', 'disabled');

                OBTMARKSZOO.value = "";
                OBTMARKSZOO.setAttribute('disabled', 'disabled');


            }
           
        }

        function registernumbercopy() {

            var checkbox1 = document.getElementById('<%= checkbox1.ClientID %>');
            var checkbox2 = document.getElementById('<%= checkbox2.ClientID %>');

            var RNPHY = document.getElementById('<%= RNPHY.ClientID %>').value;
            var RNCHE = document.getElementById('<%= RNCHE.ClientID %>');
            var RNBOT = document.getElementById('<%= RNBOT.ClientID %>');
            var RNZOO = document.getElementById('<%= RNZOO.ClientID %>');
            var RNBIO = document.getElementById('<%= RNBIO.ClientID %>');
            var RNMATOTH = document.getElementById('<%= RNMATOTH.ClientID %>');

            if (checkbox1.checked) {
                RNCHE.value = RNPHY;
                RNBOT.value = RNPHY;
                RNZOO.value = RNPHY;
                RNBIO.value = "";
                RNMATOTH.value = "";
            }
            else if (checkbox2.checked) {
                RNCHE.value = RNPHY;
                RNBOT.value = "";
                RNZOO.value = "";
                RNBIO.value = RNPHY;
                RNMATOTH.value = RNPHY;

            }
        }

        function monthofpassedcopy() {

            var checkbox1 = document.getElementById('<%= checkbox1.ClientID %>');
            var checkbox2 = document.getElementById('<%= checkbox2.ClientID %>');

            var MOPPHY = document.getElementById('<%= MOPPHY.ClientID %>').value;
            var MOPCHE = document.getElementById('<%= MOPCHE.ClientID %>');
            var MOPBOT = document.getElementById('<%= MOPBOT.ClientID %>');
            var MOPZOO = document.getElementById('<%= MOPZOO.ClientID %>');
            var MOPBIO = document.getElementById('<%= MOPBIO.ClientID %>');
            var MOPMATOTH = document.getElementById('<%= MOPMATOTH.ClientID %>');

            if (checkbox1.checked) {
                MOPCHE.value = MOPPHY;
                MOPBOT.value = MOPPHY;
                MOPZOO.value = MOPPHY;
                MOPBIO.value = "";
                MOPMATOTH.value = "";
            }
            else if (checkbox2.checked) {
                MOPCHE.value = MOPPHY;
                MOPBOT.value = "";
                MOPZOO.value = "";
                MOPBIO.value = MOPPHY;
                MOPMATOTH.value = MOPPHY;

            }

        }


        function yearofpassedcopy() {
            var checkbox1 = document.getElementById('<%= checkbox1.ClientID %>');
            var checkbox2 = document.getElementById('<%= checkbox2.ClientID %>');

            var YOPPHY = document.getElementById('<%= YOPPHY.ClientID %>').value;
            var YOPCHE = document.getElementById('<%= YOPCHE.ClientID %>');
            var YOPBOT = document.getElementById('<%= YOPBOT.ClientID %>');
            var YOPZOO = document.getElementById('<%= YOPZOO.ClientID %>');
            var YOPBIO = document.getElementById('<%= YOPBIO.ClientID %>');
            var YOPMATOTH = document.getElementById('<%= YOPMATOTH.ClientID %>');


            if (checkbox1.checked) {
                YOPCHE.value = YOPPHY;
                YOPBOT.value = YOPPHY;
                YOPZOO.value = YOPPHY;
                YOPBIO.value = "";
                YOPMATOTH.value = "";
            }
            else if (checkbox2.checked) {
                YOPCHE.value = YOPPHY;
                YOPBOT.value = "";
                YOPZOO.value = "";
                YOPBIO.value = YOPPHY;
                YOPMATOTH.value = YOPPHY;

            }
        }


        function schoolyopcopy() {
            var YOP6 = parseInt( document.getElementById('<%= YOP6.ClientID %>').value,10);
            var YOP7 = document.getElementById('<%= YOP7.ClientID %>');
            var YOP8 = document.getElementById('<%= YOP8.ClientID %>');
            var YOP9 = document.getElementById('<%= YOP9.ClientID %>');
            var YOP10 = document.getElementById('<%= YOP10.ClientID %>');
            var YOP11= document.getElementById('<%= YOP11.ClientID %>');
            var YOP12 = document.getElementById('<%= YOP12.ClientID %>');

            YOP7.value = YOP6 +1;
            YOP8.value = YOP6 + 2;
            YOP9.value = YOP6 + 3;
            YOP10.value = YOP6 + 4;
            YOP11.value = YOP6 + 5;
            YOP12.value = YOP6 + 6;

        }

        function schoolnamecopy() {
            var NOTS6 = document.getElementById('<%= NOTS6.ClientID %>').value;
            var NOTS7 = document.getElementById('<%= NOTS7.ClientID %>');
            var NOTS8 = document.getElementById('<%= NOTS8.ClientID %>');
            var NOTS9 = document.getElementById('<%= NOTS9.ClientID %>');
            var NOTS10 = document.getElementById('<%= NOTS10.ClientID %>');
            var NOTS11= document.getElementById('<%= NOTS11.ClientID %>');
            var NOTS12 = document.getElementById('<%= NOTS12.ClientID %>');

            NOTS7.value = NOTS6;
            NOTS8.value = NOTS6;
            NOTS9.value = NOTS6;
            NOTS10.value = NOTS6;
            NOTS11.value = NOTS6;
            NOTS12.value = NOTS6;

        }

        function schoolstatecopy() {
            var STATE6 = document.getElementById('<%= STATE6.ClientID %>').value;
            var STATE7 = document.getElementById('<%= STATE7.ClientID %>');
            var STATE8 = document.getElementById('<%= STATE8.ClientID %>');
            var STATE9 = document.getElementById('<%= STATE9.ClientID %>');
            var STATE10 = document.getElementById('<%= STATE10.ClientID %>');
            var STATE11= document.getElementById('<%= STATE11.ClientID %>');
            var STATE12 = document.getElementById('<%= STATE12.ClientID %>');

            STATE7.value = STATE6;
            STATE8.value = STATE6;
            STATE9.value = STATE6;
            STATE10.value = STATE6;
            STATE11.value = STATE6;
            STATE12.value = STATE6;

            updateDistrictDropdown6(STATE6);
            updateDistrictDropdown7(STATE6);
            updateDistrictDropdown8(STATE6);
            updateDistrictDropdown9(STATE6);
            updateDistrictDropdown10(STATE6);
            updateDistrictDropdown11(STATE6);
            updateDistrictDropdown12(STATE6);

        }

        function schooldistrictcopy() {
            var DISTRICT6 = document.getElementById('<%= DISTRICT6.ClientID %>').value;
          var DISTRICT7 = document.getElementById('<%= DISTRICT7.ClientID %>');
          var DISTRICT8 = document.getElementById('<%= DISTRICT8.ClientID %>');
          var DISTRICT9 = document.getElementById('<%= DISTRICT9.ClientID %>');
          var DISTRICT10 = document.getElementById('<%= DISTRICT10.ClientID %>');
          var DISTRICT11 = document.getElementById('<%= DISTRICT11.ClientID %>');
          var DISTRICT12 = document.getElementById('<%= DISTRICT12.ClientID %>');

            DISTRICT7.value = DISTRICT6;
            DISTRICT8.value = DISTRICT6;
            DISTRICT9.value = DISTRICT6;
            DISTRICT10.value = DISTRICT6;
            DISTRICT11.value = DISTRICT6;
            DISTRICT12.value = DISTRICT6;


            document.getElementById('<%= HiddenDistrict6.ClientID %>').value = DISTRICT6;
            document.getElementById('<%= HiddenDistrict7.ClientID %>').value = DISTRICT7.value;
            document.getElementById('<%= HiddenDistrict8.ClientID %>').value = DISTRICT8.value;
            document.getElementById('<%= HiddenDistrict9.ClientID %>').value = DISTRICT9.value;
            document.getElementById('<%= HiddenDistrict10.ClientID %>').value = DISTRICT10.value;
            document.getElementById('<%= HiddenDistrict11.ClientID %>').value = DISTRICT11.value;
            document.getElementById('<%= HiddenDistrict12.ClientID %>').value = DISTRICT12.value;

         
        }



        function toggleneetcoach() {
            var neetcoachingyes = document.querySelector('input[name="<%= NeetCoachingOptions.UniqueID %>"]:checked'); // Get selected RadioButton
            var neetcoachyes = document.getElementById('<%= neetcoachyes.ClientID %>'); // Get the TextBox

            var STATEneet = document.getElementById('<%= STATEneet.ClientID %>');
            var neetaddress = document.getElementById('<%= neetaddress.ClientID %>');

            if (neetcoachingyes && neetcoachingyes.value === "Yes") {
                neetcoachyes.style.display = 'block'; // Show the TextBox
                STATEneet.setAttribute('required', 'required');
                neetaddress.setAttribute('required', 'required');

             } else {
                neetcoachyes.style.display = 'none'; // Hide the TextBox
                STATEneet.value = "";
                neetaddress.value = "";
                STATEneet.removeAttribute('required');
                neetaddress.removeAttribute('required');
             }
         }

       

           
               
   

        
    </script>


    <script>
        // Districts for Tamil Nadu
        const tamilNaduDistricts = [
            "Ariyalur", "Chengalpattu", "Chennai", "Coimbatore", "Cuddalore",
            "Dharmapuri", "Dindigul", "Erode", "Kallakurichi", "Kanchipuram",
            "Kanyakumari", "Karur", "Krishnagiri", "Madurai", "Mayiladuthurai",
            "Nagappattinam", "Namakkal", "Perambalur", "Pudukkottai",
            "Ramanathapuram", "Ranipet", "Salem", "Sivagangai", "Tenkasi",
            "Thanjavur", "The Nilgiris", "Theni", "Thirupattur", "Thoothukudi",
            "Tiruchirappalli", "Tirunelveli", "Tiruppur", "Tiruvallur",
            "Tiruvannamalai", "Tiruvarur", "Vellore", "Viluppuram", "Virudhunagar","Others"
        ];
        const tamilNaduDistrictsOthers = [
            "Others"
        ]

        function updateDistrictDropdown6(selectedState) {
            console.log("Selected State:", selectedState);  // Debugging line to check state

            var districtDropdown = document.getElementById('<%= DISTRICT6.ClientID %>');
            districtDropdown.innerHTML = '<option value="" disabled selected>-- Select --</option>';

            if (selectedState === "TAMIL NADU") {
                tamilNaduDistricts.forEach(district => {
                    const option = document.createElement("option");
                    option.value = district;
                    option.textContent = district;
                    districtDropdown.appendChild(option);
                });
            } else {
                tamilNaduDistrictsOthers.forEach(district => {
                    const option = document.createElement("option");
                    option.value = district;
                    option.textContent = district;
                    districtDropdown.appendChild(option);
                });
            }
        }

        function storeDistrict6Value(dropdown) {
            var districtValue = dropdown.value; // Get the selected district value
            document.getElementById('<%= HiddenDistrict6.ClientID %>').value = districtValue; // Store it in the hidden field
        }

        function updateDistrictDropdown7(selectedState) {
            var districtDropdown = document.getElementById('<%= DISTRICT7.ClientID %>');
             districtDropdown.innerHTML = '<option value="" disabled selected>-- Select --</option>';

             // Add districts based on state selection
             if (selectedState === "TAMIL NADU") {
                 tamilNaduDistricts.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             if (selectedState != "TAMIL NADU") {
                 tamilNaduDistrictsOthers.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             // If state is empty or other, dropdown remains empty
        }


        function storeDistrict7Value(dropdown) {
            var districtValue = dropdown.value; // Get the selected district value
            document.getElementById('<%= HiddenDistrict7.ClientID %>').value = districtValue; // Store it in the hidden field
        }

        function updateDistrictDropdown8(selectedState) {
            var districtDropdown = document.getElementById('<%= DISTRICT8.ClientID %>');
             districtDropdown.innerHTML = '<option value="" disabled selected>-- Select --</option>';

             // Add districts based on state selection
             if (selectedState === "TAMIL NADU") {
                 tamilNaduDistricts.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             if (selectedState != "TAMIL NADU") {
                 tamilNaduDistrictsOthers.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             // If state is empty or other, dropdown remains empty
        }


        function storeDistrict8Value(dropdown) {
            var districtValue = dropdown.value; // Get the selected district value
            document.getElementById('<%= HiddenDistrict8.ClientID %>').value = districtValue; // Store it in the hidden field
        }

        function updateDistrictDropdown9(selectedState) {
            var districtDropdown = document.getElementById('<%= DISTRICT9.ClientID %>');
             districtDropdown.innerHTML = '<option value="" disabled selected>-- Select --</option>';

             // Add districts based on state selection
             if (selectedState === "TAMIL NADU") {
                 tamilNaduDistricts.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             if (selectedState != "TAMIL NADU") {
                 tamilNaduDistrictsOthers.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             // If state is empty or other, dropdown remains empty
        }


        function storeDistrict9Value(dropdown) {
            var districtValue = dropdown.value; // Get the selected district value
            document.getElementById('<%= HiddenDistrict9.ClientID %>').value = districtValue; // Store it in the hidden field
        }

        function updateDistrictDropdown10(selectedState) {
            var districtDropdown = document.getElementById('<%= DISTRICT10.ClientID %>');
             districtDropdown.innerHTML = '<option value="" disabled selected>-- Select --</option>';

             // Add districts based on state selection
             if (selectedState === "TAMIL NADU") {
                 tamilNaduDistricts.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             if (selectedState != "TAMIL NADU") {
                 tamilNaduDistrictsOthers.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             // If state is empty or other, dropdown remains empty
        }


        function storeDistrict10Value(dropdown) {
            var districtValue = dropdown.value; // Get the selected district value
            document.getElementById('<%= HiddenDistrict10.ClientID %>').value = districtValue; // Store it in the hidden field
        }

        function updateDistrictDropdown11(selectedState) {
            var districtDropdown = document.getElementById('<%= DISTRICT11.ClientID %>');
             districtDropdown.innerHTML = '<option value="" disabled selected>-- Select --</option>';

             // Add districts based on state selection
             if (selectedState === "TAMIL NADU") {
                 tamilNaduDistricts.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             if (selectedState != "TAMIL NADU") {
                 tamilNaduDistrictsOthers.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             // If state is empty or other, dropdown remains empty
        }


        function storeDistrict11Value(dropdown) {
            var districtValue = dropdown.value; // Get the selected district value
            document.getElementById('<%= HiddenDistrict11.ClientID %>').value = districtValue; // Store it in the hidden field
        }

        function updateDistrictDropdown12(selectedState) {
            var districtDropdown = document.getElementById('<%= DISTRICT12.ClientID %>');
             districtDropdown.innerHTML = '<option value="" disabled selected>-- Select --</option>';

             // Add districts based on state selection
             if (selectedState === "TAMIL NADU") {
                 tamilNaduDistricts.forEach(district => {
                     const option = document.createElement("option");
                     option.value.trim = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             if (selectedState != "TAMIL NADU") {
                 tamilNaduDistrictsOthers.forEach(district => {
                     const option = document.createElement("option");
                     option.value = district;
                     option.textContent = district;
                     districtDropdown.appendChild(option);
                 });
             }
             // If state is empty or other, dropdown remains empty
        }


        function storeDistrict12Value(dropdown) {
            var districtValue = dropdown.value; // Get the selected district value
            document.getElementById('<%= HiddenDistrict12.ClientID %>').value = districtValue; // Store it in the hidden field
        }






        window.onload = function () {
            toggleCheckbox();
            boxchecking();
            toggleneetcoach();

            const STATE6 = document.getElementById('<%= STATE6.ClientID %>').value;
            const hiddenDistrict6 = document.getElementById('<%= HiddenDistrict6.ClientID %>').value;    // Get the district value from the hidden field


            const STATE7 = document.getElementById('<%= STATE7.ClientID %>').value;
            const hiddenDistrict7 = document.getElementById('<%= HiddenDistrict7.ClientID %>').value; 

            const STATE8 = document.getElementById('<%= STATE8.ClientID %>').value;
            const hiddenDistrict8 = document.getElementById('<%= HiddenDistrict8.ClientID %>').value; 

            const STATE9 = document.getElementById('<%= STATE9.ClientID %>').value;
            const hiddenDistrict9 = document.getElementById('<%= HiddenDistrict9.ClientID %>').value; 

            const STATE10 = document.getElementById('<%= STATE10.ClientID %>').value;
            const hiddenDistrict10 = document.getElementById('<%= HiddenDistrict10.ClientID %>').value; 

            const STATE11 = document.getElementById('<%= STATE11.ClientID %>').value;
            const hiddenDistrict11 = document.getElementById('<%= HiddenDistrict11.ClientID %>').value; 

            const STATE12 = document.getElementById('<%= STATE12.ClientID %>').value;
            const hiddenDistrict12 = document.getElementById('<%= HiddenDistrict12.ClientID %>').value; 
           

    // Update the district dropdown based on the selected state
            updateDistrictDropdown6(STATE6);
            updateDistrictDropdown7(STATE7);
            updateDistrictDropdown8(STATE8);
            updateDistrictDropdown9(STATE9);
            updateDistrictDropdown10(STATE10);
            updateDistrictDropdown11(STATE11);
            updateDistrictDropdown12(STATE12);

    // After the dropdown is populated, set the selected value from the hidden field
            const DISTRICT6 = document.getElementById('<%= DISTRICT6.ClientID %>');
            const DISTRICT7 = document.getElementById('<%= DISTRICT7.ClientID %>');
            const DISTRICT8 = document.getElementById('<%= DISTRICT8.ClientID %>');
            const DISTRICT9 = document.getElementById('<%= DISTRICT9.ClientID %>');
            const DISTRICT10 = document.getElementById('<%= DISTRICT10.ClientID %>');
            const DISTRICT11 = document.getElementById('<%= DISTRICT11.ClientID %>');
            const DISTRICT12 = document.getElementById('<%= DISTRICT12.ClientID %>');


            if (hiddenDistrict6) {
                DISTRICT6.value = hiddenDistrict6; // Set the value of the dropdown to the hidden field value
            }
            if (hiddenDistrict7) {
                DISTRICT7.value = hiddenDistrict7; // Set the value of the dropdown to the hidden field value
            }
            if (hiddenDistrict8) {
                DISTRICT8.value = hiddenDistrict8; // Set the value of the dropdown to the hidden field value
            }
            if (hiddenDistrict9) {
                DISTRICT9.value = hiddenDistrict9; // Set the value of the dropdown to the hidden field value
            }
            if (hiddenDistrict10) {
                DISTRICT10.value = hiddenDistrict10; // Set the value of the dropdown to the hidden field value
            }
            if (hiddenDistrict11) {
                DISTRICT11.value = hiddenDistrict11; // Set the value of the dropdown to the hidden field value
            }
            if (hiddenDistrict12) {
                DISTRICT12.value = hiddenDistrict12; // Set the value of the dropdown to the hidden field value
            }
        };

        function checkmarksPhysics() {
            var dropdown = document.getElementById('<%= MAXMARKSPHY.ClientID %>');
    var maxmark = parseInt(dropdown.options[dropdown.selectedIndex].text, 10); // Get text, not value

            var obtmarkInput = document.getElementById('<%= OBTMARKSPHY.ClientID %>');
            var obtmark = parseInt(obtmarkInput.value, 10);

            if (!isNaN(maxmark) && !isNaN(obtmark) && obtmark > maxmark) { // Change to ">"
                obtmarkInput.value = ""; // Clear input field
            }
        }


        function checkmarksChemistry() {
            var dropdown = document.getElementById('<%= MAXMARKSCHE.ClientID %>');
var maxmark = parseInt(dropdown.options[dropdown.selectedIndex].text, 10); // Get text, not value

                var obtmarkInput = document.getElementById('<%= OBTMARKSCHE.ClientID %>');
                var obtmark = parseInt(obtmarkInput.value, 10);

                if (!isNaN(maxmark) && !isNaN(obtmark) && obtmark > maxmark) { // Change to ">"
                    obtmarkInput.value = ""; // Clear input field
                }
            }

        function checkmarksBotany() {
            var dropdown = document.getElementById('<%= MAXMARKSBOT.ClientID %>');
var maxmark = parseInt(dropdown.options[dropdown.selectedIndex].text, 10); // Get text, not value

                        var obtmarkInput = document.getElementById('<%= OBTMARKSBOT.ClientID %>');
                        var obtmark = parseInt(obtmarkInput.value, 10);

                        if (!isNaN(maxmark) && !isNaN(obtmark) && obtmark > maxmark) { // Change to ">"
                            obtmarkInput.value = ""; // Clear input field
                        }
        }

        function checkmarksZoology() {
            var dropdown = document.getElementById('<%= MAXMARKSZOO.ClientID %>');
var maxmark = parseInt(dropdown.options[dropdown.selectedIndex].text, 10); // Get text, not value

                    var obtmarkInput = document.getElementById('<%= OBTMARKSZOO.ClientID %>');
                    var obtmark = parseInt(obtmarkInput.value, 10);

                    if (!isNaN(maxmark) && !isNaN(obtmark) && obtmark > maxmark) { // Change to ">"
                        obtmarkInput.value = ""; // Clear input field
                    }
        }

        function checkmarksBiology() {
            var dropdown = document.getElementById('<%= MAXMARKSBIO.ClientID %>');
var maxmark = parseInt(dropdown.options[dropdown.selectedIndex].text, 10); // Get text, not value

                    var obtmarkInput = document.getElementById('<%= OBTMARKSBIO.ClientID %>');
                    var obtmark = parseInt(obtmarkInput.value, 10);

                    if (!isNaN(maxmark) && !isNaN(obtmark) && obtmark > maxmark) { // Change to ">"
                        obtmarkInput.value = ""; // Clear input field
                    }
        }

        function checkmarksMathsOthers() {
            var dropdown = document.getElementById('<%= MAXMARKSMATOTH.ClientID %>');
var maxmark = parseInt(dropdown.options[dropdown.selectedIndex].text, 10); // Get text, not value

                    var obtmarkInput = document.getElementById('<%= OBTMARKSMATOTH.ClientID %>');
                    var obtmark = parseInt(obtmarkInput.value, 10);

                    if (!isNaN(maxmark) && !isNaN(obtmark) && obtmark > maxmark) { // Change to ">"
                        obtmarkInput.value = ""; // Clear input field
                    }
                }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div style="box-shadow: 0px 0px 50px grey; padding-top: 1px; padding-bottom: 1px;" class="mt-2 ms-3 mb-2 me-3">

<div class="border border-info ms-2 mt-1 me-2" style="border-radius: 5px;">

    <div class="ps-3 pt-1 pb-1 " style="background-color: #dcebfb; box-sizing: border-box; border-radius: 5px;">
        <h5 style="color: #172e81">ACADEMIC AND  SCHOOLING</h5>
    </div>


    <div class="container-fluid">

        <div class="row">

            <div class="col-6">
                <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">PASSED ALL THE SUBJECTS OF HSC EXAM IN NO. OF ATTEMPTS</h6>
            </div>

            <div class="col-6 mt-3">

                <asp:DropDownList ID="ddlNumberOfAttempts" runat="server" Style="width: 20%; height: 30px" CssClass="custom-textbox" required="required">
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="More than 5">More than 5</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>


        <div class="row">

            <div class="col-6">
                <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">DID YOU STUDIED 6<sup>th</sup> TO 12<sup>th</sup> STANDARD IN TAMILNADU GOVERNMENT SCHOOL</h6>
            </div>

            <div class="col-6 mt-3">

                <asp:RadioButtonList ID="govtschooloptions" runat="server" RepeatDirection="Horizontal" EnableViewState="true"
                    AutoPostBack="false" >
                    <asp:ListItem Text="Yes" Value="Yes" style="padding-left: 10px;"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No" Selected="True" style="padding-left: 10px;"></asp:ListItem>
                </asp:RadioButtonList>

            </div>
        </div>


        <div class="row">

    <div class="col-6">
        <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">DID YOU STUDIED 6<sup>th</sup> TO 12<sup>th</sup> STANDARD IN TAMILNADU UNDER RTE </h6>
    </div>

    <div class="col-6 mt-3">

        <asp:RadioButtonList ID="rteoptions" runat="server" RepeatDirection="Horizontal" EnableViewState="true"
            AutoPostBack="false" >
            <asp:ListItem Text="Yes" Value="Yes" style="padding-left: 10px;"></asp:ListItem>
            <asp:ListItem Text="No" Value="No" Selected="True" style="padding-left: 10px;"></asp:ListItem>
        </asp:RadioButtonList>

    </div>
</div>


    </div>
           <div class="d-flex justify-content-center align-content-center">

                <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3"><b>MARKS OBTAINED IN HSC (ACADEMIC/ EQUIVALENT) EXAMINATION</b></h6>


           </div>


        <div>

            <table class="table table-bordered">
                <thead class="table-secondary fw-bold ">
                    <tr class="text-center align-middle ">

                        <td></td>
                        <td>SUBJECTS</td>
                        <td>REGISTER NUMBER</td>
                        <td>MONTH OF PASSED</td>
                        <td>YEAR OF PASSED</td>
                        <td>MAX.MARKS</td>
                        <td>OBT.MARKS</td>

                    </tr>
                </thead>

                <tbody style="border-top: 3px solid grey">

                    <tr>
                        <td></td>
                        <td>
                            <h6 style="color: #172e81;" ><b id="PHYSICSSUBJECT" runat="server">PHYSICS</b></h6>
                        </td>
                        <td>
                            <input id="RNPHY" runat="server" style="width: 70%;" class="custom-textbox" required="required"/>
                            &nbsp;<i class="fa fa-copy" onclick="registernumbercopy();" style="cursor:pointer;"></i></td>
                        <td>

                            <asp:DropDownList ID="MOPPHY" runat="server" Style="width: 70%; height: 30px" class="custom-textbox" required="required">
                                <asp:ListItem Value="" Disabled="True" Selected="True">Select</asp:ListItem>
                              
                            </asp:DropDownList>
                            &nbsp;<i class="fa fa-copy" onclick="monthofpassedcopy();" style="cursor:pointer;"></i>

                        </td>
                        <td>
                            <input id="YOPPHY" runat="server" style="width: 70%;"  class="custom-textbox" required="required"/>
                            &nbsp;<i class="fa fa-copy" onclick="yearofpassedcopy();" style="cursor:pointer;"></i></td>
                        <td>
                            <asp:DropDownList ID="MAXMARKSPHY" runat="server" Style="width: 80%; height: 30px" class="custom-textbox" required="required">
                                <asp:ListItem Value="" Disabled="True" Selected="True">Select </asp:ListItem>
                               
                            </asp:DropDownList>

                        </td>
                        <td>
                            <input id="OBTMARKSPHY" runat="server" style="width: 50%;" class="custom-textbox" required="required"  onchange="checkmarksPhysics()"/>
                        </td>
                    </tr>

                    <tr>
                        <td></td>
                        <td>
                            <h6 style="color: #172e81;"><b id="CHEMISTRYSUBJECT" runat="server">CHEMISTRY</b></h6>
                        </td>
                        <td>
                            <input id="RNCHE" runat="server" style="width: 70%;"  class="custom-textbox" required="required"/>
                        </td>
                        <td>

                            <asp:DropDownList ID="MOPCHE" runat="server" Style="width: 70%; height: 30px" class="custom-textbox" required="required">
                                <asp:ListItem Value="" Disabled="True" Selected="True">Select</asp:ListItem>
                               
                            </asp:DropDownList>


                        </td>
                        <td>
                            <input id="YOPCHE" runat="server" style="width: 70%;" class="custom-textbox" required="required" />
                        </td>
                        <td>
                            <asp:DropDownList ID="MAXMARKSCHE" runat="server" Style="width: 80%; height: 30px" class="custom-textbox" required="required">
                                <asp:ListItem Value="" Disabled="True" Selected="True">Select </asp:ListItem>
                              
                            </asp:DropDownList>

                        </td>
                        <td>
                            <input id="OBTMARKSCHE" runat="server" style="width: 50%;" class="custom-textbox" required="required" onchange="checkmarksChemistry()" />
                        </td>
                    </tr>
                            <!-- BOTANY ZOOLOGY -->

                    <tr>
                        <td rowspan="2" style="padding-top:30px;">  <asp:CheckBox ID="checkbox1" runat="server" Checked="true" onclick="toggleCheckbox(this);boxchecking();" /></td>
                        <td>
                            <h6 style="color: #172e81;"><b id="BOTANYSUBJECT" runat="server">BOTANY</b></h6>
                        </td>
                        <td>
                            <input id="RNBOT" runat="server" style="width: 70%;" disabled="disabled" class="custom-textbox" required="required" />
                        </td>
                        <td>

                            <asp:DropDownList ID="MOPBOT" runat="server" Style="width: 70%; height: 30px"  disabled="disabled" class="custom-textbox" required="required">
                                <asp:ListItem Value="" Disabled="True" Selected="True">Select</asp:ListItem>
                               
                            </asp:DropDownList>


                        </td>
                        <td>
                            <input id="YOPBOT" runat="server" style="width: 70%;"  disabled="disabled" class="custom-textbox" required="required" />
                        </td>
                        <td>
                            <asp:DropDownList ID="MAXMARKSBOT" runat="server" Style="width: 80%; height: 30px"  disabled="disabled" class="custom-textbox" required="required">
                                <asp:ListItem Value="" Disabled="True" Selected="True">Select </asp:ListItem>
                              
                            </asp:DropDownList>

                        </td>
                        <td>
                            <input id="OBTMARKSBOT" runat="server" style="width: 50%;"  disabled="disabled"   class="custom-textbox" required="required" onchange="checkmarksBotany()"/>
                        </td>
                    </tr>

                    <tr>
                        
                        <td>
                            <h6 style="color: #172e81;"><b id="ZOOLOGYSUBJECT" runat="server">ZOOLOGY</b></h6>
                        </td>
                        <td>
                            <input id="RNZOO" runat="server" style="width: 70%;"   disabled="disabled" class="custom-textbox" required="required"/>
                        </td>
                        <td>

                            <asp:DropDownList ID="MOPZOO" runat="server" Style="width: 70%; height: 30px"  disabled="disabled" class="custom-textbox" required="required">
                                <asp:ListItem Value="" Disabled="True" Selected="True">Select</asp:ListItem>
                               
                            </asp:DropDownList>


                        </td>
                        <td>
                            <input id="YOPZOO" runat="server" style="width: 70%;"  disabled="disabled"  class="custom-textbox" required="required"/>
                        </td>
                        <td>
                            <asp:DropDownList ID="MAXMARKSZOO" runat="server" Style="width: 80%; height: 30px"  disabled="disabled" class="custom-textbox" required="required">
                                <asp:ListItem Value="" Disabled="True" Selected="True">Select </asp:ListItem>
                               
                            </asp:DropDownList>

                        </td>
                        <td>
                            <input id="OBTMARKSZOO" runat="server" style="width: 50%;"   disabled="disabled"   class="custom-textbox" required="required" onchange="checkmarksZoology()"/>
                        </td>
                    </tr>

                    <!--............ section 2 .............-->

                         <tr>
         <td rowspan="2" style="padding-top:30px;"> <asp:CheckBox ID="checkbox2" runat="server" onclick="toggleCheckbox(this);boxchecking();" /> </td>
         <td>
             <h6 style="color: #172e81;"><b id="BIOLOGYSUBJECT" runat="server">BIOLOGY / BIO-TECHNOLOGY</b></h6>
         </td>
         <td>
             <input id="RNBIO" runat="server" style="width: 70%;"  disabled="disabled" class="custom-textbox" required="required" />
         </td>
         <td>

             <asp:DropDownList ID="MOPBIO" runat="server" Style="width: 70%; height: 30px"  disabled="disabled" class="custom-textbox" required="required">
                 <asp:ListItem Value="" Disabled="True" Selected="True">Select</asp:ListItem>
                
             </asp:DropDownList>


         </td>
         <td>
             <input id="YOPBIO" runat="server" style="width: 70%;"  disabled="disabled" class="custom-textbox" required="required" />
         </td>
         <td>
             <asp:DropDownList ID="MAXMARKSBIO" runat="server" Style="width: 80%; height: 30px"  disabled="disabled " class="custom-textbox" required="required">
                 <asp:ListItem Value="" Disabled="True" Selected="True">Select </asp:ListItem>
                 
             </asp:DropDownList>

         </td>
         <td>
             <input id="OBTMARKSBIO" runat="server" style="width: 50%;"  disabled="disabled"   class="custom-textbox" required="required" onchange="checkmarksBiology()"/>
         </td>
     </tr>

     <tr>
         
         <td>
             <asp:DropDownList ID="MATHSOTHERSSUBJECT" runat="server" >
                 <asp:ListItem Value="MATHEMATICS">MATHEMATICS</asp:ListItem>
                 <asp:ListItem Value="OTHERS">OTHERS</asp:ListItem>
             </asp:DropDownList>
         </td>
         <td>
             <input id="RNMATOTH" runat="server" style="width: 70%;"   disabled="disabled" class="custom-textbox" required="required"/>
         </td>
         <td>

             <asp:DropDownList ID="MOPMATOTH" runat="server" Style="width: 70%; height: 30px"  disabled="disabled" class="custom-textbox"  required="required">
                 <asp:ListItem Value="" Disabled="True" Selected="True">Select</asp:ListItem>
                
             </asp:DropDownList>


         </td>
         <td>
             <input id="YOPMATOTH" runat="server" style="width: 70%;"   disabled="disabled" class="custom-textbox" required="required"/>
         </td>
         <td>
             <asp:DropDownList ID="MAXMARKSMATOTH" runat="server" Style="width: 80%; height: 30px"  disabled="disabled" class="custom-textbox" required="required">
                 <asp:ListItem Value="" Disabled="True" Selected="True">Select </asp:ListItem>
                
             </asp:DropDownList>

         </td>
         <td>
             <input id="OBTMARKSMATOTH" runat="server" style="width: 50%;"   disabled="disabled" class="custom-textbox" required="required" onchange="checkmarksMathsOthers()"/>
         </td>
     </tr>



                </tbody>

            </table>







        </div>

        
          <div class="border border-secondary mt-2 mb-2" style="border-bottom:none;">

          </div>

        
           <div class="container-fluid">

               <div class="row">

                   
                   <div class="col-5">

                        <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">MEDIUM OF INSTRUCTION </h6>

                   </div>

                   <div class="col-7 mt-2">
                       <asp:DropDownList ID="ddlMediumOfInstruction" runat="server" Style="width: 50%;height:25px" class="custom-textbox mb-2" required="required">
                           <asp:ListItem Value="" Disabled="True" Selected="True">-- Select --</asp:ListItem>
                           
                       </asp:DropDownList>

                   </div>

               </div>


               <div class="row">


                   <div class="col-5 ">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">CIVIC SCHOOL</h6>

                   </div>

                   <div class="col-7 mt-2">
                       <asp:DropDownList ID="ddlCivicSchool" runat="server" Style="width: 50%; height: 25px;" CssClass="custom-textbox" required="required">
                           <asp:ListItem Value="" Disabled="True" Selected="True">-- Select --</asp:ListItem>
                          
                       </asp:DropDownList>


                   </div>

               </div>



               <div class="row">


                   <div class="col-5 ">

                       <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">CIVIC NATIVE</h6>

                   </div>

                   <div class="col-7 mt-2">
                       <asp:DropDownList ID="ddlCivicNative" runat="server" Style="width: 50%; height: 25px;" CssClass="custom-textbox" required="required">
                           <asp:ListItem Value="" Disabled="True" Selected="True">-- Select --</asp:ListItem>
                          
                       </asp:DropDownList>


                   </div>

               </div>




           </div>


            <div>
        <table class="table table-bordered mt-2">
            <thead class="table-secondary fw-bold">
                <tr class="text-center align-middle">
                    <td>CLASS</td>
                    <td>YEAR OF PASSING</td>
                    <td>NAME OF THE SCHOOL</td>
                    <td>STATE</td>
                    <td>DISTRICT</td>
                </tr>
            </thead>
            <tbody style="border-top: 3px solid grey">

                <tr>
                    <td>
                        <h6 style="color: #172e81;"><b>VI</b></h6>
                    </td>
                    <td>
                        <input id="YOP6" runat="server" style="width: 40%;"  class="custom-textbox" required="required" />
                        &nbsp; <i class="fa fa-angle-down" style="cursor:pointer;" onclick="schoolyopcopy();"></i></td>
                    <td>
                        <input id="NOTS6" runat="server" style="width: 270px" class="custom-textbox" required="required"/>
                        &nbsp;<i class="fa fa-copy" style="cursor:pointer;" onclick="schoolnamecopy();"></i></td>
                    <td>
                        <asp:DropDownList ID="STATE6" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="updateDistrictDropdown6(this.value);" >
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>

                        </asp:DropDownList>
                        &nbsp;<i class="fa fa-copy" style="cursor:pointer;" onclick="schoolstatecopy();"></i>


                    </td>
                    <td>
                        <asp:DropDownList ID="DISTRICT6" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="storeDistrict6Value(this)">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select </asp:ListItem>

                        </asp:DropDownList>
                        &nbsp;<i class="fa fa-copy" style="cursor:pointer;" onclick="schooldistrictcopy();"></i>

                        <asp:HiddenField ID="HiddenDistrict6" runat="server" />

                    </td>
                </tr>

                <tr>
                    <td>
                        <h6 style="color: #172e81;"><b>VII</b></h6>
                    </td>
                    <td>
                        <input id="YOP7" runat="server" style="width: 40%;"  class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <input id="NOTS7" runat="server" style="width: 270px" class="custom-textbox" required="required" />
                    </td>
                    <td>
                        <asp:DropDownList ID="STATE7" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="updateDistrictDropdown7(this.value);">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>

                        </asp:DropDownList>


                    </td>
                    <td>
                        <asp:DropDownList ID="DISTRICT7" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="storeDistrict7Value(this)">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select </asp:ListItem>

                        </asp:DropDownList>

                         <asp:HiddenField ID="HiddenDistrict7" runat="server" />


                    </td>
                </tr>

                <tr>
                    <td>
                        <h6 style="color: #172e81;"><b>VIII</b></h6>
                    </td>
                    <td>
                        <input id="YOP8" runat="server" style="width: 40%;" class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <input id="NOTS8" runat="server" style="width: 270px" class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="STATE8" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="updateDistrictDropdown8(this.value);">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>

                        </asp:DropDownList>


                    </td>
                    <td>
                        <asp:DropDownList ID="DISTRICT8" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="storeDistrict8Value(this)">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select </asp:ListItem>

                        </asp:DropDownList>

                         <asp:HiddenField ID="HiddenDistrict8" runat="server" />


                    </td>
                </tr>

                <tr>
                    <td>
                        <h6 style="color: #172e81;"><b>IX</b></h6>
                    </td>
                    <td>
                        <input id="YOP9" runat="server" style="width: 40%;" class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <input id="NOTS9" runat="server" style="width: 270px" class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="STATE9" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="updateDistrictDropdown9(this.value);">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>

                        </asp:DropDownList>


                    </td>
                    <td>
                        <asp:DropDownList ID="DISTRICT9" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="storeDistrict9Value(this)">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select </asp:ListItem>

                        </asp:DropDownList>

                         <asp:HiddenField ID="HiddenDistrict9" runat="server" />


                    </td>
                </tr>

                <tr>
                    <td>
                        <h6 style="color: #172e81;"><b>X</b></h6>
                    </td>
                    <td>
                        <input id="YOP10" runat="server" style="width: 40%;" class="custom-textbox" required="required" />
                    </td>
                    <td>
                        <input id="NOTS10" runat="server" style="width: 270px" class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="STATE10" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="updateDistrictDropdown10(this.value);">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>

                        </asp:DropDownList>


                    </td>
                    <td>
                        <asp:DropDownList ID="DISTRICT10" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="storeDistrict10Value(this)">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select </asp:ListItem>

                        </asp:DropDownList>

                         <asp:HiddenField ID="HiddenDistrict10" runat="server" />


                    </td>
                </tr>

                <tr>
                    <td>
                        <h6 style="color: #172e81;"><b>XI</b></h6>
                    </td>
                    <td>
                        <input id="YOP11" runat="server" style="width: 40%;"  class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <input id="NOTS11" runat="server" style="width: 270px"  class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="STATE11" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="updateDistrictDropdown11(this.value);">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>

                        </asp:DropDownList>


                    </td>
                    <td>
                        <asp:DropDownList ID="DISTRICT11" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="storeDistrict11Value(this)">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select </asp:ListItem>

                        </asp:DropDownList>

                         <asp:HiddenField ID="HiddenDistrict11" runat="server" />


                    </td>
                </tr>

                <tr>
                    <td>
                        <h6 style="color: #172e81;"><b>XII</b></h6>
                    </td>
                    <td>
                        <input id="YOP12" runat="server" style="width: 40%;" class="custom-textbox" required="required" />
                    </td>
                    <td>
                        <input id="NOTS12" runat="server" style="width: 270px" class="custom-textbox" required="required"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="STATE12" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="updateDistrictDropdown12(this.value);">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>

                        </asp:DropDownList>


                    </td>
                    <td>
                        <asp:DropDownList ID="DISTRICT12" runat="server" Style="width: 100px;" class="custom-textbox" required="required" onchange="storeDistrict12Value(this)">
                            <asp:ListItem Value="" Disabled="True" Selected="True">-- Select </asp:ListItem>

                        </asp:DropDownList>

                         <asp:HiddenField ID="HiddenDistrict12" runat="server" />


                    </td>
                </tr>



            </tbody>
        </table>
    </div>

            
            
           <div class="border border-indo mt-2 mb-2" style="border-bottom: none;">
           </div>

            
                
    <div class="container-fluid">

        <div class="row ">

            <div class="col-5">

                <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">NUMBER OF NEET ATTEMPT</h6>

            </div>

            <div class="col-7 mt-2">

                <asp:DropDownList ID="NEETATTEMPT" runat="server" Style="width: 40%; height: 30px" CssClass="custom-textbox" required="required">
                    <asp:ListItem Value="1st Attempt" Selected="True">1st Attempt</asp:ListItem>
                    <asp:ListItem Value="2nd Attempt">2nd Attempt</asp:ListItem>
                    <asp:ListItem Value="3rd Attempt">3rd Attempt</asp:ListItem>
                    <asp:ListItem Value="4th Attempt">4th Attempt</asp:ListItem>
                    <asp:ListItem Value="5th Attempt">5th Attempt</asp:ListItem>
                    <asp:ListItem Value="More than 5 Attempts">More than 5 Attempts</asp:ListItem>
                </asp:DropDownList>

            </div>

        </div>



        <div class="row">

            <div class="col-5">

                <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">DID YOU WENT TO NEET COACHING</h6>

            </div>

            <div class="col-7 mt-2">



                <asp:RadioButtonList ID="NeetCoachingOptions" runat="server" RepeatDirection="Horizontal" CssClass="custom-textbox" required="required" AutoPostBack="false"  onchange="toggleneetcoach();">
                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No" Selected="True" style="padding-left: 10px;"></asp:ListItem>
                </asp:RadioButtonList>

               
            </div>

            <div  id="neetcoachyes" runat="server" style="padding-left:200px;padding-right:200px;display:none;" class="mt-3 mb-3">

                <div class="border border-info">
                    <div class="row">

                        <div class="col-6" style="padding-left:30px">

                             <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">Mention the State</h6>

                            <asp:DropDownList ID="STATEneet" runat="server" Style="width: 70%;" class="custom-textbox mb-4" >
                                <asp:ListItem Value="" Disabled="True" Selected="True">-- Select  </asp:ListItem>

                            </asp:DropDownList>

                        </div>

                        <div class="col-6">
                             <h6 style="color: #172e81; margin-bottom: 4px;" class="pt-3">	Addresss of NEET Coaching</h6>

                            <asp:TextBox ID="neetaddress" runat="server" class="custom-textbox mb-4" ></asp:TextBox>


                        </div>

                    </div>

                </div>

            </div>

        </div>



    </div>



    <div class=" d-flex justify-content-center align-items-center mb-3 mt-2" style="background-color: #dcebfb; box-sizing: border-box;">

        <asp:Button ID="btnSaveContinue" runat="server" class="btn btn-primary mt-1 mb-1"  Text="Save & Continue " OnClick="btnSaveContinue_Click"></asp:Button>

    </div>



    </div>
</div>
  

</asp:Content>
