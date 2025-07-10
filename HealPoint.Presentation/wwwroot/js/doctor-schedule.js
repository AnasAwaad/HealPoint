$(document).ready(function () {
    $('#submitFormBtn').on('click', function (e) {
        e.preventDefault();

        var $form = $(this).closest('form');

        if (!$form.valid()) {
            return;
        }
        SubmitSchedule($(this).data('url'));
    });
});

function AddItem(btn) {
    const table = btn.closest('table');
    const day = table.dataset.day;

    const newRow = document.createElement('tr');
    newRow.innerHTML = `
				<td><input class="form-control js-start-flat-time" value="09:00" /></td>
				<td><input class="form-control js-end-flat-time" value="09:30" /></td>
				<td>
					<button type="button" class="btn btn-danger" onclick="DeleteItem(this)">Delete</button>
				</td>
				<input type="hidden" class="schedule-time-id" value="0" />
			`;

    table.querySelector('tbody').appendChild(newRow);
    initFlatTimePickers();
    $(btn).parents('.table-responsive').find('.js-alert').hide();
}

function DeleteItem(btn) {
    const table = btn.closest('table');
    btn.closest('tr').remove();
}



function SubmitSchedule(url) {

    var doctorScheduleDetails = []

    $('.schedule-table').each(function () {
        const day = $(this).data('day');
        $(this).find('tbody tr').each(function () {
            const startTime = $(this).find('.js-start-flat-time').eq(0).val();
            const endTime = $(this).find('.js-end-flat-time').eq(0).val();
            const id = $(this).find('.schedule-time-id').val();
            console.log(id)
            console.log(startTime, endTime);
            if (startTime && endTime) {
                console.log(day)
                doctorScheduleDetails.push({
                    "Id": parseInt(id) || 0,
                    "DayOfWeek": day,
                    "StartTime": startTime,
                    "EndTime": endTime
                });
            }
        });

    });

    const model = {
        Id: document.getElementById('scheduleId').value,
        ClinicId: document.getElementById('ClinicId').value,
        StartDate: document.getElementById('StartDate').value,
        EndDate: document.getElementById('EndDate').value,
        Recurrence: parseInt(document.getElementById('Recurrence').value),
        DoctorScheduleDetails: doctorScheduleDetails
    };
    console.log(model)
    $.ajax({
        url: url,
        type: 'POST',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        success: function (response) {
            if (response.success) {
                showSuccessSwal(response.message);
            }
        },
        error: function (request, status, error) {
            const message = request.responseText || "Something went wrong";

            showErrorSwal(message);
        }
    });


}