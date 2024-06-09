function filter() {
    var selectedType = document.getElementById("filterSelect").value;
    var rows = document.querySelectorAll(".my-table tbody tr");
    for (var i = 0; i < rows.length; i++) {
        rows[i].style.display = "";
    }

    if (selectedType === "All") {
        for (var i = 0; i < rows.length; i++) {
            rows[i].style.display = "";
        }
    } else {
        for (var i = 0; i < rows.length; i++) {
            var type = rows[i].querySelector("td:nth-child(3)").innerText;
            if (type !== selectedType) {
                rows[i].style.display = "none";
            } else {
                rows[i].style.display = "";
            }
        }
    }
}

window.addEventListener("DOMContentLoaded", function () {
    var selectedType = localStorage.getItem("selectedType");
    if (selectedType) {
        document.getElementById("filterSelect").value = selectedType;
    }
});


document.getElementById("filterSelect").addEventListener("change", function () {
    var selectedType = document.getElementById("filterSelect").value;
    localStorage.setItem("selectedType", selectedType);
});