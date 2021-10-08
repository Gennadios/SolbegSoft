function openForm(formName) {
    document.getElementById(formName).style.display = "block";
}

function closeForm(formName) {
    document.getElementById(formName).style.display = "none";
}

function setMinDateToToday() {
    let today = new Date();
    let dd = today.getDate();
    let mm = today.getMonth() + 1;
    let yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    today = yyyy + '-' + mm + '-' + dd;
    document.getElementById("booking-date").setAttribute("min", today);
}