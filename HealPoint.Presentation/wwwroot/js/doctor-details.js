$(document).ready(function () {

    GetAvailableTimesForDay($('.day.active').data('date'));
    $(document).on('click', '.day.active', function () {
        var btn = $(this);
        if (btn.hasClass('disabled') || btn.hasClass('prev') || btn.hasClass('next'))
            return;

        const selectedDate = btn.data('date');
        GetAvailableTimesForDay(selectedDate);
    });

})

function GetAvailableTimesForDay(day) {
    const doctorId = $('#Id').val();

    $.ajax({
        url: '/Doctors/GetDoctorSchedulesForDate',
        type: 'GET',
        data: {
            doctorId: doctorId,
            date: day
        },
        success: function (slots) {
            const container = $('#timeSlots');
            container.empty();

            if (slots.length === 0) {
                container.append('<div class="text-muted fs-3">No available time slots for this day.</div>');
                return;
            }


            slots.forEach(function (slot) {
                const newTime = formatTime(slot);
                container.append(`
                                <button type="button" class="btn btn-outline-primary mb-2 slot-btn" data-slot="${slot}">
                                    ${newTime}
                                </button>
                            `);
            });

        },
        error: function () {
            container.html('<span class="text-danger">Error loading time slots</span>');
        }
    });

}

function formatTime(timeStr) {
    const [hours, minutes] = timeStr.split(':');
    const h = parseInt(hours, 10);
    const ampm = h >= 12 ? 'PM' : 'AM';
    const hour12 = h % 12 || 12; // convert 0 to 12
    return `${hour12}:${minutes} ${ampm}`;
}