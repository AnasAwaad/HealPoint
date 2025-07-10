const daysContainer = document.querySelector(".days");
const nextBtn = document.querySelector(".next");
const prevBtn = document.querySelector(".prev");
const todayBtn = document.querySelector(".active");
const month = document.querySelector(".month");

const months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
];

const days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

const date = new Date();
let currentMonth = date.getMonth();
let currentYear = date.getFullYear();
const renderCalendar = () => {
    date.setDate(1);
    const firstDay = new Date(currentYear, currentMonth, 1);
    const lastDay = new Date(currentYear, currentMonth + 1, 0);
    const lastDayIndex = lastDay.getDay();
    const lastDayDate = lastDay.getDate();
    const prevLastDay = new Date(currentYear, currentMonth, 0);
    const prevLastDayDate = prevLastDay.getDate();
    const nextDays = 7 - lastDayIndex - 1;

    month.innerHTML = `${months[currentMonth]} ${currentYear}`;

    let daysHTML = "";

    for (let x = firstDay.getDay(); x > 0; x--) {
        daysHTML += `<div class="day prev">${prevLastDayDate - x + 1}</div>`;
    }

    for (let i = 1; i <= lastDayDate; i++) {
        const currentDate = new Date(currentYear, currentMonth, i);
        const today = new Date();
        today.setHours(0, 0, 0, 0); // Remove time portion

        let classNames = "day";

        if (
            i === new Date().getDate() &&
            currentMonth === new Date().getMonth() &&
            currentYear === new Date().getFullYear()
        ) {
            classNames += " active";
        }

        if (currentDate < today) {
            classNames += " disabled";
        }
        const yyyy = currentDate.getFullYear();
        const mm = String(currentDate.getMonth() + 1).padStart(2, '0');
        const dd = String(currentDate.getDate()).padStart(2, '0');
        const dataDate = `${yyyy}-${mm}-${dd}`;

        daysHTML += `<div class="${classNames}" data-date="${dataDate}">${i}</div>`;
    }


    for (let j = 1; j <= nextDays; j++) {
        daysHTML += `<div class="day next">${j}</div>`;
    }

    daysContainer.innerHTML = daysHTML;
    hideTodayBtn();

    // Add click event to each day
    document.querySelectorAll(".day").forEach((dayElem) => {
        dayElem.addEventListener("click", () => {
            // Skip prev and next month days
            if (dayElem.classList.contains("prev") || dayElem.classList.contains("next") || dayElem.classList.contains("disabled")) {
                return;
            }

            const dayText = dayElem.textContent.trim();
            const dayNumber = parseInt(dayText, 10);

            if (isNaN(dayNumber) || dayNumber < 1) return;

            // Remove previous active class
            document.querySelectorAll(".day").forEach((el) => el.classList.remove("active"));

            // Mark selected day as active
            dayElem.classList.add("active");
        });
    });
}


nextBtn.addEventListener("click", () => {
    currentMonth++;
    if (currentMonth > 11) {
        currentMonth = 0;
        currentYear++;
    }
    renderCalendar();
});

prevBtn.addEventListener("click", () => {
    currentMonth--;
    if (currentMonth < 0) {
        currentMonth = 11;
        currentYear--;
    }
    renderCalendar();
});

todayBtn.addEventListener("click", () => {
    currentMonth = date.getMonth();
    currentYear = date.getFullYear();
    renderCalendar();
});

function hideTodayBtn() {
    if (
        currentMonth === new Date().getMonth() &&
        currentYear === new Date().getFullYear()
    ) {
        todayBtn.style.display = "none";
    } else {
        todayBtn.style.display = "flex";
    }
}

renderCalendar();
