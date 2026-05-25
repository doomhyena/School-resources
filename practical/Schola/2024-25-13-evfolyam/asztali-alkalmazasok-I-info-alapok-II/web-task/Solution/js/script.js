window.onload = function() {
    loadSchedule();
    setInterval(updateCurrentClass, 60000);
};

function loadSchedule() {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", "load_schedule.php", true);
    xhr.onload = function() {
        if (xhr.status === 200) {
            const data = JSON.parse(xhr.responseText);
            displaySchedule(data);
        }
    };
    xhr.send();
}

function displaySchedule(schedule) {
    const tbody = document.getElementById("orarend-body");
    tbody.innerHTML = '';

    schedule.forEach(item => {
        const row = document.createElement("tr");

        const dayCell = document.createElement("td");
        dayCell.textContent = item.day;
        row.appendChild(dayCell);

        const startCell = document.createElement("td");
        startCell.textContent = item.start;
        row.appendChild(startCell);

        const typeCell = document.createElement("td");
        typeCell.textContent = item.type || 'Nincs óra';
        row.appendChild(typeCell);

        const teacherCell = document.createElement("td");
        teacherCell.textContent = item.teacher || '-';
        row.appendChild(teacherCell);

        const roomCell = document.createElement("td");
        roomCell.textContent = item.room || '-';
        row.appendChild(roomCell);

        tbody.appendChild(row);
    });
}

function updateCurrentClass() {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", "current_class.php", true);
    xhr.onload = function() {
        if (xhr.status === 200) {
            const data = JSON.parse(xhr.responseText);
            const dynamicMessage = document.getElementById("dynamic-message");
            
            if (data.currentClass) {
                dynamicMessage.textContent = `Jelenleg ${data.currentClass.name} óra van, tanár: ${data.currentClass.teacher}, terem: ${data.currentClass.room}.`;
            } else {
                dynamicMessage.textContent = "Jelenleg szünet van.";
            }
        }
    };
    xhr.send();
}
