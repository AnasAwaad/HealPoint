// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var message = $('.js-success-message').text();
    if (message != '') {
        showSuccessMessage(message);
	}


	// Handle Global Modal 
	$('.js-render-modal').on('click', function () {
		var btn = $(this);
		var myModal = $('#myModal');
		var title = btn.data('title');
		var url = btn.data('url');


		myModal.find('.modal-title').text(title);

		// call ajax request to render form inside modal
		$.get({
			url,
			success: function (form) {
				myModal.find('.modal-body').html(form);

				// Re-enable client-side validation for the new form
				$.validator.unobtrusive.parse(myModal);
			},
			error: function (err) {
				showErrorMessage(err);
			}
		})


		myModal.modal('show');
	})

	$('.js-modal-save').on('click', function () {
		$('#ModalForm').submit();
	})
})

function onModalFormSuccess(row) {
	$('.js-tbody').append(row);

	$('#myModal').modal('hide');

	showSuccessMessage("Category created successfully");

	//TODO: Not Workingggggggggggg
	//KTMenu.init();
	//KTMenu.initHandlers();
}

function onModalFormFailure(res) {
	$('#myModal').modal('hide');
	showErrorMessage("An error happen while creating category");
}

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