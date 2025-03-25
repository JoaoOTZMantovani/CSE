// Plugin 'order-management-clock.js'. - Used to dynamically manage the clock component. 
// You must have two <span> elements with their respective ids: clock and calendar.
// It is automatically started when the plugin is loaded.

function updateClock() {
    let options = {hour: '2-digit', minute: '2-digit'}

    let dateTime = new Date();

    document.getElementById('clock').innerText = dateTime.toLocaleTimeString('pt-BR', options);
}

function updateCalendar() {
    let options = { weekday: 'long', day: '2-digit', month: 'long', year: 'numeric' };

    let formattedDate = new Date().toLocaleDateString('pt-BR', options);
    formattedDate = formattedDate.charAt(0).toUpperCase() + formattedDate.slice(1);

    document.getElementById('calendar').innerText = formattedDate;
}

updateClock();
updateCalendar(); 

setInterval(updateClock, 10000);