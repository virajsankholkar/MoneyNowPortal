/*
* The custom MakePayment.js file is used to hold all the javascript functions for the MakePayment view.
* Author - Viraj S Sankholkar
* Date - 02/20/2018
*/
//Test comment
//Javascript method toggle radio button when User enters into "Other Amount" textbox.
//Parameters passed - N/A
function onEnter() {
    var radiobtn = document.getElementById("max");
    radiobtn.checked = true;
}

$('input[id=min]').change(function () {    
    $('#otherAmount').val('');
});