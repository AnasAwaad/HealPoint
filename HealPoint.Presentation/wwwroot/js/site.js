// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var message = $('.js-success-message').text();
    if (message != '') {
        showSuccessMessage(message);
    }
})

function showSuccessMessage(message){
	Toastify({
		text: message,
		duration: 3000,
		newWindow: true,
		close: true,
		gravity: "top",
		position: "right",
		stopOnFocus: true,
		style: {
			background: "linear-gradient(to right, #00b09b, #96c93d)",
		},
	}).showToast();
}

function showErrorMessage(message) {
	Toastify({
		text: message,
		duration: 3000,
		newWindow: true,
		close: true,
		gravity: "top",
		position: "right",
		stopOnFocus: true,
		style: {
			background: "linear-gradient(to right, #ff5f6d, #ffc371)", // red-orange gradient
			color: "#fff"
		},
		icon: "❌"
	}).showToast();

}