/*
* The custom AccountDetails.js file is used to hold all the javascript functions for the AccountDetails view.
* Author - Viraj S Sankholkar
* Date - 02/12/2018
*/
var homeWindowLink = 'Index';
var AddNewAccountLink = 'AddNewAccountDetails';
var UpdateAccountAliasLink = 'UpdateAccountAliasName';
var RequestAccountChangeLink = 'RequestAccountChangeStatus';

function validateAddNewAccountForm() {

    var accountNameId = '#accountName';
    var accountEffectiveDateId = '#accountEffectiveDate';
    var errAccountNameId = '#errAccountName';
    var errEffectiveDateId = '#errEffectiveDate';

    var validForm = true;

    if ($(accountNameId).val() == '' || $(accountNameId).val() == null) {
        validForm = false;
        $(errAccountNameId).text('Account alias name field is required.');
    }
    else {
        $(errAccountNameId).text('');
    }

    if ($(accountEffectiveDateId).val() == '' || $(accountEffectiveDateId).val() == null) {
        validForm = false;
        $(errEffectiveDateId).text('Effective Date field is required.');
    }
    else {
        $(errEffectiveDateId).text('');
    }

    return validForm;
}

function validateChangeRequestForm(ID) {
    var validForm = true;

    var accountDescriptionId = '#accountDescription' + ID;
    var accountEffectiveDateId = '#accountEffectiveDate' + ID;
    var errAccountDescriptionId = '#errAccountDescription' + ID;
    var errEffectiveDateId = '#errEffectiveDate' + ID;

    if ($(accountDescriptionId).val() == '' || $(accountDescriptionId).val() == null) {
        validForm = false;
        $(errAccountDescriptionId).text('Description/Comments field is required.');
    }
    else {
        $(errAccountDescriptionId).text('');
    }

    if ($(accountEffectiveDateId).val() == '' || $(accountEffectiveDateId).val() == null) {
        validForm = false;
        $(errEffectiveDateId).text('Effective Date field is required.');
    }
    else {
        $(errEffectiveDateId).text('');
    }

    return validForm;
}


function validateUpdateAccountAliasForm(ID) {
    var validForm = true;
    var newAccountAliasNameId = '#newAccountAliasName' + ID;
    var errnewAccountNameId = '#errnewAccountName' + ID;

    if ($(newAccountAliasNameId).val() == '' || $(newAccountAliasNameId).val() == null) {
        validForm = false;
        $(errnewAccountNameId).text('Account alias name field is required.');
    }
    else {
        $(errnewAccountNameId).text('');
    }  

    return validForm;
}

//Javascript method to add new account to the Database
//Parameters passed - accountName
//Parameters passed - accountTypeName
//Parameters passed - accountDescription
//Parameters passed - accountEffectiveDate
function AddNewAccount()
    {
        var accountNameVal = $("#accountName").val();
        var accountTypeNameVal = $("#accountTypeName").val();
        var accountDescriptionVal = $("#accountDescription").val();
        var accountEffectiveDateVal = $("#accountEffectiveDate").val();

        var sdata = "{ 'AccountName':'" + accountNameVal + "', 'AccountType':" + accountTypeNameVal + ", 'Description':'" + accountDescriptionVal + "', 'EffectiveDate':'" + accountEffectiveDateVal + "' }";
        //alert(sdata);

        $.ajax({
            type: 'POST',
            url: AddNewAccountLink,
            data: "myParams=" + JSON.stringify(sdata), 
            contentType: "application/x-www-form-urlencoded; charset=utf-8;",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });

        function successFunc(data, status) {
            if (data.Success) {

                $("#accountName").val('');
                $("#accountTypeName").val('10');
                $("#accountDescription").val('');
                $("#accountEffectiveDate").val('');

                $("#request_new_account").modal('hide');
                $("#getCode").removeClass('text-danger').addClass('modal-body');
                $("#getCode").html("New account requested!");
                $("#getCodeModal").modal('show');
            }
            else 
            {
                $("#request_new_account").modal('hide');
                $("#getCode").removeClass('modal-body').addClass('text-danger');
                $("#getCode").html("Error requesting add account. "+ data.ErrorMessage);
                $("#getCodeModal").modal('show');
            }
        }

        function errorFunc() {
            $("#request_new_account").modal('hide');            
            $("#getCode").removeClass('modal-body').addClass('text-danger');
            $("#getCode").html("Error occurred!");
            $("#getCodeModal").modal('show');
        }
    };


//Javascript method to add update the Account Alias name
//Parameters passed - AccountID
function UpdateAccountAlias(ID) {

    var modalID = "#card-edit-" + ID;
    var modalID2 = "#accounts-edit-" + ID;

    var accountIDVal = $("#accountID" + ID).val();
    var newAccountAliasNameVal = $("#newAccountAliasName" + ID).val();    

    var sdata = "{'AccountID':" + accountIDVal + ", 'NewAlias':'" + newAccountAliasNameVal + "'}";
    //alert(sdata);

    $.ajax({
        type: 'POST',
        url: UpdateAccountAliasLink,
        data: "myParams=" + JSON.stringify(sdata),
        contentType: "application/x-www-form-urlencoded; charset=utf-8;",
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {                
        if (data.Success) {            
            window.location = homeWindowLink;
        }
        else 
        {
            $(modalID).modal('hide');
            $(modalID2).modal('hide');
            $("#getCode").removeClass('modal-body').addClass('text-danger');
            $("#getCode").html('Error in updating the Account Alias. Please try again later.');
            $("#getCodeModal").modal('show');
        }
    }

    function errorFunc(data, status) {
        $(modalID).modal('hide');
        $(modalID2).modal('hide');
        $("#getCode").removeClass('modal-body').addClass('text-danger');
        $("#getCode").html("Error occurred!");
        $("#getCodeModal").modal('show');
    }
};

//Javascript method to add new account to the Database
//Parameters passed - accountID
//Parameters passed - accountTypeOfChange
//Parameters passed - accountDescription
//Parameters passed - accountEffectiveDate
function RequestAccountChangeStatus(ID) {    

    var modalID = "#accounts-request-change-" + ID;
    var accountIDVal = $("#accountID" + ID).val();
    var accountTypeOfChangeVal = $("#accountTypeOfChange" + ID).val();
    var accountDescriptionVal = $("#accountDescription" + ID).val();
    var accountEffectiveDateVal = $("#accountEffectiveDate" + ID).val();

    var sdata = "{ 'AccountID': " + accountIDVal + ", 'NewStatus': '" + accountTypeOfChangeVal + "', 'Description': '" + accountDescriptionVal + "', 'EffectiveDate': '" + accountEffectiveDateVal + "' }";
    //alert(sdata);

    $.ajax({
        type: 'POST',
        url: RequestAccountChangeLink,
        data: "myParams=" + JSON.stringify(sdata),
        contentType: "application/x-www-form-urlencoded; charset=utf-8;",
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {

        if (data.Success) {
            //alert('Success');
            //window.location = homeWindowLink;       
            $(modalID).modal('hide');
            $("#getCode").html("Request submitted!");
            $("#getCode").removeClass('text-danger').addClass('modal-body');
            $("#getCodeModal").modal('show');
        }
        else {
            $(modalID).modal('hide');
            $(modalID2).modal('hide');
            $("#getCode").removeClass('modal-body').addClass('text-danger');
            $("#getCode").html("Error requesting the account status change. " + data.ErrorMessage);
            $("#getCodeModal").modal('show');
        }
        
    }

    function errorFunc() {
        $(modalID).modal('hide');
        $(modalID2).modal('hide');
        $("#getCode").removeClass('modal-body').addClass('text-danger');
        $("#getCode").html("Error occurred!");
        $("#getCodeModal").modal('show');
    }
};

//Javascript method to add new account to the Database
//Parameters passed - accountID
//Parameters passed - accountTypeOfChange
//Parameters passed - accountDescription
//Parameters passed - accountEffectiveDate
function RequestCardAccountChangeStatus(ID) {

    var modalID = "#card-request-change-" + ID;
    var accountIDVal = $("#accountID"+ ID).val();
    var accountTypeOfChangeVal = $("#accountTypeOfChange" + ID).val();
    var accountDescriptionVal = $("#accountDescription" + ID).val();
    var accountEffectiveDateVal = $("#accountEffectiveDate" + ID).val();

    //var sdata = '{ "accountID": ' + accountIDVal + ', "accountTypeOfChange": ' + accountTypeOfChangeVal + ', "accountDescription": ' + accountDescriptionVal + ', "accountEffectiveDate": ' + accountEffectiveDateVal + ' }';
    var sdata = "{ 'AccountID': " + accountIDVal + ", 'NewStatus': '" + accountTypeOfChangeVal + "', 'Description': '" + accountDescriptionVal + "', 'EffectiveDate': '" + accountEffectiveDateVal + "' }";

    //alert(sdata);

    $.ajax({
        type: 'POST',
        url: RequestAccountChangeLink,
        data: "myParams=" + JSON.stringify(sdata),
        contentType: "application/x-www-form-urlencoded; charset=utf-8;",
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        if (data.Success) {
            //alert('Success');
            //window.location = homeWindowLink;       
            $(modalID).modal('hide');
            $("#getCode").html("Request submitted!");
            $("#getCode").removeClass('text-danger').addClass('modal-body');
            $("#getCodeModal").modal('show');
        }
        else {
            $(modalID).modal('hide');
            $(modalID2).modal('hide');
            $("#getCode").removeClass('modal-body').addClass('text-danger');
            $("#getCode").html("Error requesting the account status change. " + data.ErrorMessage);
            $("#getCodeModal").modal('show');
        }
    }

    function errorFunc() {
        $(modalID).modal('hide');
        $(modalID2).modal('hide');
        $("#getCode").removeClass('modal-body').addClass('text-danger');
        $("#getCode").html("Error occurred!");
        $("#getCodeModal").modal('show');
    }
};