$(document).ready(function () {
	$('.table').DataTable();
	$(document).on('change', '#ParentClinicId', function () {

		var selectedText = $(this).find('option:selected').text();

		$('#ParentClinicName').val(selectedText);
	});
})