$(document).ready(function () {


    // Iterate over each day
    const days = [
        { name: 'saturday', dayOfWeek: 0 },
        { name: 'sunday', dayOfWeek: 1 },
        { name: 'monday', dayOfWeek: 2 },
        { name: 'tuesday', dayOfWeek: 3 },
        { name: 'wednesday', dayOfWeek: 4 },
        { name: 'thursday', dayOfWeek: 5 },
        { name: 'friday', dayOfWeek: 6 },
    ]


    days.forEach(function (day) {
        const checkboxId = day.name + 'Checkbox';


        toggleDayInputs(checkboxId);

        $(document).on("change", '#' + checkboxId, function () {
            toggleDayInputs(checkboxId);
        })
    });

    // Handle the visibility of time inputs 
    function toggleDayInputs(checkboxId) {
        const checkbox = $('#' + checkboxId);
        const dayName = checkboxId.replace('Checkbox', '');
        const timeInputs = $('#' + dayName + 'TimeInputs');
        const closedText = $('#' + dayName + 'ClosedText');

        if (checkbox.is(':checked')) {
            timeInputs.removeClass("d-none");
            closedText.addClass("d-none");
        } else {
            closedText.removeClass("d-none");
            timeInputs.addClass("d-none");
        }
    }

    // Handle form submission
    $(document).on('click', '.js-modal-save', function (event) {
        event.preventDefault();

        const clinicSessions = [];
        const clinicId = $('#clinicId').val();

        days.forEach(function (day) {
            const checkbox = $('#' + day.name + 'Checkbox');
            const openTimeInput = $('#' + day.name + 'OpenTime');
            const closeTimeInput = $('#' + day.name + 'CloseTime');

            if (checkbox.is(':checked')) {
                // Get today's date in YYYY-MM-DD
                const date = new Date().toISOString().slice(0, 10);
                // Format: YYYY-MM-DDTHH:mm:ss
                const startTimeString = date + 'T' + openTimeInput.val() + ':00';
                const endTimeString = date + 'T' + closeTimeInput.val() + ':00';

                let session = {
                    Id: 0,
                    StartTime: startTimeString,
                    EndTime: endTimeString,
                    DayOfWeek: day.dayOfWeek,
                    ClinicId: parseInt(clinicId),
                };
                clinicSessions.push(session);
            }
        });

        console.log(clinicSessions);


        $.ajax({
            url: '/Admin/Clinics/SaveClinicSessions',
            data: JSON.stringify(clinicSessions),
            headers: {
                'RequestVerificationToken': $("input[name='__RequestVerificationToken']").val()
            },
            type: 'POST',
            contentType: 'application/json',
            success: function (response) {
                showSuccessMessage('Clinic sessions saved successfully!');
                $('#myModal').modal('hide');
            },
            error: function (xhr, status, error) {
                showErrorMessage('Error saving clinic hours. Please try again.');
                $('#myModal').modal('hide');
            }
        });
    })
});