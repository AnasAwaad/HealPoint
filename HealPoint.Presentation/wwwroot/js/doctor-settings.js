
let selectedSymptomIds = [];

$(document).ready(function () {
    // service click
    $('.js-service-card').on('click', function () {
        $('.js-service-card').removeClass('active');
        $(this).addClass('active');

        const id = $(this).data('service-id');
        $('#SelectedServiceId').val(id);

        $('#servicePriceDurationInputs').removeClass('d-none');
    });

    // specialization click
    $('.js-spec-card').on('click', function () {
        $('.js-spec-card').removeClass('active');
        $(this).addClass('active');

        const id = $(this).data('spec-id');
        $('#SelectedSpecializationId').val(id);
        console.log(id)
    });

    // collect all selected symptoms
    $('.js-symptom-card[data-selected="true"]').each(function () {
        const id = $(this).data('symptom-id');
        selectedSymptomIds.push(id);
    });

    // symptom click
    $('.js-symptom-card').on('click', function () {
        const card = $(this)
        const id = card.data('symptom-id');
        if (card.hasClass('active')) {
            card.removeClass('active');
            selectedSymptomIds = selectedSymptomIds.filter(s => s !== id);
        } else {
            card.addClass('active');
            selectedSymptomIds.push(id);
        }
        console.log(selectedSymptomIds);
    })


    $('#btnUpdateService').on('click', function () {
        const serviceId = parseInt($('#SelectedServiceId').val());
        if (!serviceId) return showErrorSwal('Please select a service.');

        $.ajax({
            url: '/Doctor/DoctorSettings/UpdateService',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                DoctorId: parseInt($('#DoctorId').val()),
                ServicePrice: parseInt($('#ServicePrice').val()),
                ServiceDurationInMinutes: parseInt($('#ServiceDurationInMinutes').val()),
                SelectedServiceId: serviceId
            }),
            success: () => showSuccessSwal('Your service is updated successfully.'),
            error: () => showErrorSwal('An error occurred while updating the service.')
        });
    });

    $('#btnUpdateSpecialization').on('click', function () {

        const specId = parseInt($('#SelectedSpecializationId').val());
        if (!specId) return showErrorSwal('Please select a specialization.');


        $.ajax({
            url: '/Doctor/DoctorSettings/UpdateSpecialization',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                DoctorId: parseInt($('#DoctorId').val()),
                SelectedSpecializationId: specId
            }),
            success: () => showSuccessSwal('Your specialization is updated successfully.'),
            error: () => showErrorSwal('An error occurred while updating the specialization.')
        });

    });


    $('#btnUpdateSymptoms').on('click', function () {
        if (selectedSymptomIds.length === 0) return showErrorSwal('Please select at least one symptom.');
        $.ajax({
            url: '/Doctor/DoctorSettings/UpdateSymptoms',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                DoctorId: parseInt($('#DoctorId').val()),
                SelectedSymptoms: selectedSymptomIds
            }),
            success: () => showSuccessSwal('Your symptoms are updated successfully.'),
            error: () => showErrorSwal('An error occurred while updating the symptoms.')
        });
    });


    $(document).on('click', '.js-operation-mode-card', function () {
        $('.js-operation-mode-card').removeClass('active');
        $(this).addClass('active');

        const selectedMode = $(this).data('operation-mode');
        $('#operationModeInput').val(selectedMode);
    });

    $('#btnUpdateOperationMode').on('click', function () {
        const doctorId = $('input[name="DoctorId"]').val();
        const operationMode = $('#operationModeInput').val();

        $.ajax({
            type: "POST",
            url: '/Doctor/DoctorSettings/UpdateOperationMode',
            contentType: 'application/json',
            data: JSON.stringify({
                DoctorId: parseInt(doctorId),
                OperationMode: parseInt(operationMode)
            }),
            success: function () {
                showSuccessSwal("Operation mode updated successfully!");
            },
            error: function () {
                showSuccessSwal("Something went wrong!");
            }
        });
    });
});