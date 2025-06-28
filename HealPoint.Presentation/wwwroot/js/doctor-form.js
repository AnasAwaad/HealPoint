$(document).ready(function () {
    function validateTab(tabId) {
        const inputs = $(tabId).find('input, select, textarea');
        return inputs.length === 0 || inputs.valid();
    }

    function navigateTo(tabId) {
        const tabLink = $(`a[data-bs-toggle="tab"][href="${tabId}"]`);
        tabLink.tab('show');
    }

    $('#btnToProfessionalDetails').click(function () {
        if (validateTab('#add_doctor_PersonalInformation')) {
            navigateTo('#add_doctor_ProfessionalDetails');
        }
    });

    $('#btnToAccountSettings').click(function () {
        if (validateTab('#add_doctor_ProfessionalDetails')) {
            navigateTo('#add_doctor_AccountSettings');
        }
    });

    $('#btnBackToPersonal').click(function () {
        navigateTo('#add_doctor_PersonalInformation');
    });

    $('#btnBackToProfessional').click(function () {
        navigateTo('#add_doctor_ProfessionalDetails');
    });

    // FlatPicker 
    flatpickr("#DateOfBirth", {
        dateFormat: "Y-m-d",
        maxDate: "today",
        altInput: true,
        altFormat: "F j, Y",
    });

    flatpickr("#LicenseExpiryDate", {
        dateFormat: "Y-m-d",
        minDate: "today",
        altInput: true,
        altFormat: "F j, Y",
    });
});