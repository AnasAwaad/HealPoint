// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var updatedRow;
$(document).ready(function () {
    var message = $('.js-success-message').text();
    if (message != '') {
        showSuccessMessage(message);
	}


	// Handle Global Modal 
	$(document).on('click', '.js-render-modal', function () {
		var btn = $(this);
		var myModal = $('#myModal');
		var title = btn.data('title');
		var url = btn.data('url');

		if (btn.data('update') != undefined) {
			updatedRow = btn.parents('tr');
		}

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

	$(document).on('click', '.js-modal-save', function () {
		$('#ModalForm').submit();
	})
})

function onModalFormSuccess(row) {
	var message;
	if (updatedRow != undefined) {
		// Updates existing row with new HTML, then clears 'updatedRow' reference.
		$(updatedRow).replaceWith(row);
		updatedRow = undefined;

		message = "Category updated successfully";
	} else {
		// Appends new row HTML to the table body.
		$('.js-tbody').append(row);

		message = "Category created successfully";
	}


	$('#myModal').modal('hide');

	showSuccessMessage(message);

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