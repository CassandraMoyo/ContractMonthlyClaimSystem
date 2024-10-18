// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//submit form confirmation
function submitFormWithConfirmation() {
    const userConfirmed = confirm("Are you sure you want to submit this claim?");
    if (!userConfirmed) {
        event.preventDefault();
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
    
    event.preventDefault();
    const claimId = button.closest("form").querySelector("input[name='id']").value;
    document.getElementById(`denialForm-${claimId}`).style.display = "block";
    return confirm('This claim will reflect as denied,please state the reason!');
}
//verify claim(PC)
function showVerifiedMessage() {
    return confirm('Are you sure you want to verify this claim!');
}

//final status update by academic manager
function confirmFinalize() {
    return confirm('Are you sure you want to finalize this claim?');
}

//pop up messages
