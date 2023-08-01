// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addD() {
    x = document.getElementById('AddDates')
    z = document.createElement('h6')
    const inn = document.getElementById('checkin').value;
    const outt = document.getElementById('checkout').value;
    z.innerHTML = "Check in " + inn + " Check out: " + outt;
    z.setAttribute("display", "flex");
    z.style.color = "black";
    x.appendChild(z);

    var svg = document.createElementNS("http://www.w3.org/2000/svg", "svg");

    svg.setAttribute("width", "35px");
    svg.setAttribute("height", "35px");
    svg.setAttribute("viewBox", "0 0 50 50");
    svg.setAttribute("fill", "#000000");

    var g1 = document.createElementNS("http://www.w3.org/2000/svg", "g");
    g1.setAttribute("id", "SVGRepo_bgCarrier");
    g1.setAttribute("stroke-width", "0");

    var g2 = document.createElementNS("http://www.w3.org/2000/svg", "g");
    g2.setAttribute("id", "SVGRepo_tracerCarrier");
    g2.setAttribute("stroke-linecap", "round");
    g2.setAttribute("stroke-linejoin", "round");

    var g3 = document.createElementNS("http://www.w3.org/2000/svg", "g");
    g3.setAttribute("id", "SVGRepo_iconCarrier");

    var title = document.createElementNS("http://www.w3.org/2000/svg", "title");
    title.textContent = "minus-round";

    var path = document.createElementNS("http://www.w3.org/2000/svg", "path");
    path.setAttribute("d", "M0 16q0 3.264 1.28 6.208t3.392 5.12 5.12 3.424 6.208 1.248 6.208-1.248 5.12-3.424 3.392-5.12 1.28-6.208-1.28-6.208-3.392-5.12-5.088-3.392-6.24-1.28q-3.264 0-6.208 1.28t-5.12 3.392-3.392 5.12-1.28 6.208zM4 16q0-3.264 1.6-6.016t4.384-4.352 6.016-1.632 6.016 1.632 4.384 4.352 1.6 6.016-1.6 6.048-4.384 4.352-6.016 1.6-6.016-1.6-4.384-4.352-1.6-6.048zM8 16q0 0.832 0.576 1.44t1.44 0.576h12q0.8 0 1.408-0.576t0.576-1.44-0.576-1.408-1.408-0.576h-12q-0.832 0-1.44 0.576t-0.576 1.408z");


    svg.addEventListener("click", function (event) {
        // Get the parent element of the clicked element
        
        var parentElement = event.target.parentNode;
        if (parentElement.id == "SVGRepo_iconCarrier") {

            parentElement = parentElement.parentNode.parentNode.parentNode.parentNode;
            parentElement.remove();
        }
        else {
         
            parentElement.remove();

        }

    });

    g3.appendChild(title);
    g3.appendChild(path);
    g2.appendChild(g3);
    g1.appendChild(g2);
    svg.appendChild(g1);

    svg.style.marginTop = "8px";
    svg.style.marginLeft = "15px";
    svg.style.cursor = "pointer";
    svg.style.verticalAlign = "middle"; //new CSS line to vertically center the SVG

    z.appendChild(svg);
}


//-----JS for Price Range slider-----

function initMap() {

    // Create a new map object
    var map = L.map('map').setView([27.18, 31.18], 13);

    // Add a tile layer to the map
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors',
        maxZoom: 18
    }).addTo(map);

    // Create a new marker object
    var marker = L.marker([27.18, 31.18], {
        draggable: true // Allow the user to drag the marker
    }).addTo(map);

    // Add an event listener to the marker to update its position when it's dragged
    marker.on('dragend', function (event) {
        var latlng = event.target.getLatLng();
        console.log('Marker position: ' + latlng.lat + ', ' + latlng.lng);

        // Send a reverse geocoding request to the OpenStreetMap Nominatim API
        var url = 'https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=' + latlng.lat + '&lon=' + latlng.lng;
        fetch(url)
            .then(response => response.json())
            .then(data => {
                console.log('Address: ' + data.display_name);
                var address = 'Address: ' + data.display_name;
                var ad = document.getElementById("address");
                ad.value = address;
            })
            .catch(error => console.error(error));
    });
}

initMap();

$('.alert').alert('close');


$('.alert').alert('close');

function successAdd() {
    alert("Room was added successfully\nPress Ok to continue");
}  
function Del() {

    var modal = document.getElementById('id01');
    window.onclick = function (event) {
        window.location.href = '/Home/Delete';
        modal.style.display = "none";
    }
}

function Update() {

    var modal = document.getElementById('id02');
    window.onclick = function (event) {
        window.location.href = '/Customer/EditCustomer';
        modal.style.display = "none";
    }
}

function Logout() {

    var modal = document.getElementById('id03');
    console.log("zzzzzz");
    window.onclick = function (event) {
        window.location.href = '/Owner/LogOut';
        modal.style.display = "none";
    }
}

function Logoout() {

    var modal = document.getElementById('id04');
    console.log("zzzzzz");
    window.onclick = function (event) {
        window.location.href = '/Home/LogOut';
        modal.style.display = "none";
    }
}