/*
* The custom CardDetails.js file is used to hold all the javascript functions for the CardDetails view.
* Author - Viraj S Sankholkar
* Date - 02/15/2018
*/

//Javascript method toggle between Lock and Unlock card
//Parameters passed - ID
function LockedClicked(ID) {    
    var buttonId = '#lockCard' + ID;
    
    if ($(buttonId).hasClass("btn locked btn-even")) {

        $(buttonId).removeClass("btn locked btn-even").addClass("btn btn-primary btn-custom btn-even");
        $(buttonId).html("<i class='fas fa-lock'></i>&nbsp;Lock Card")

    }
    else {
        $(buttonId).removeClass("btn btn-primary btn-custom btn-even").addClass("btn locked btn-even");
        $(buttonId).html("<i class='fas fa-lock'></i>&nbsp;Unlock Card")
    } 
};

//Javascript method toggle between Freeze and UnFreeze card
//Parameters passed - ID
function FreezeClicked(ID) {
    var buttonId = '#freezeCard' + ID;

    if ($(buttonId).hasClass("btn frozen btn-even")) {
        $(buttonId).removeClass("btn frozen btn-even").addClass("btn btn-primary btn-custom btn-even");
        $(buttonId).html("<i class='far fa-stop-circle'></i>&nbsp;Freeze Card")
    }
    else {
        $(buttonId).removeClass("btn btn-primary btn-custom btn-even").addClass("btn frozen btn-even");
        $(buttonId).html("<i class='far fa-stop-circle'></i>&nbsp;Unfreeze Card")
    }
};

//Javascript method toggle between Restrict and UnRestrict card
//Parameters passed - ID
function RestrictClicked(ID) {
    
    var buttonId = '#restrictCard' + ID;

    if ($(buttonId).hasClass("btn restricted btn-even")) {
        $(buttonId).removeClass("btn restricted btn-even").addClass("btn btn-primary btn-custom btn-even");
        $(buttonId).html("<i class='fas fa-exclamation-triangle'></i>&nbsp;Restrict Card")
    }
    else {
        $(buttonId).removeClass("btn btn-primary btn-custom btn-even").addClass("btn restricted btn-even");
        $(buttonId).html("<i class='fas fa-exclamation-triangle'></i>&nbsp;Unrestrict Card")
    }
};