// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//submit form confirmation
function submitFormWithConfirmation() {
    if (confirm('Are you sure you want to submit?')) {
        document.getElementById('ClaimsForm').submit();
    }
}
//clear form fields
function confirmClearForm() {
    if (confirm("Are you sure you want to clear the form? This action cannot be undone.")) {
        document.getElementById("ClaimsForm").reset();
    }
}

//edit claim
function confirmEditForm(url) {
    if (confirm("Are you sure you want to edit this claim?")) {
        window.location.href = url;
    }
}//reason for denying to verify claim
function showDenialReason(button) {
    var formId = 'denialForm-' + button.value;
    document.getElementById(formId).style.display = 'block';
}

function showDenialMessage() {
    return confirm('Are you sure you want to deny this claim?');
}


//verify claim(PC)
function showVerifiedMessage() {
    return confirm('Are you sure you want to verify this claim!');
}

//final status update by academic manager
function confirmFinalize() {
    return confirm('Are you sure you want to finalize this claim?');
}

/*user confirmation
update so that if insertion to db is sucessful show this message
else show unsuccessful
*/



//edit personal details

// login
