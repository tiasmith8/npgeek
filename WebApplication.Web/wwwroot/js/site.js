// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkCelsius() {
    var allCookies = document.cookie;
    var cookiearray = allCookies.split(';');
    var toCelsius;

    for (var i = 0; i < cookiearray.length; i++) {
        name = cookiearray[i].split('=')[0];
        value = cookiearray[i].split('=')[1];
        if (name == "toCelsius") {
            toCelsius = value;
        }
    }

    if (toCelsius == "true") {
        document.getElementById("tempConvert").checked = true;
        setTemp();
    } else {
        document.getElementById("tempConvert").checked = false;
    }
}

function setTemp() {
    var checkBox = document.getElementById("tempConvert");
    var i;
    if (checkBox.checked) {
        document.cookie = "toCelsius=true; path=/";

        for (i = 0; i < 5; i++) {
            var text = document.getElementById("high-temp-day-" + i);
            text.innerHTML = Math.round((text.innerHTML - 32) * 5 / 9);

            var text = document.getElementById("low-temp-day-" + i);
            text.innerHTML = Math.round((text.innerHTML - 32) * 5 / 9);

            document.getElementById("degree-type-high-day-" + i).innerHTML = " &#8451";
            document.getElementById("degree-type-low-day-" + i).innerHTML = " &#8451";
        }
    } else {
        document.cookie = "toCelsius=false; path=/";

        for (i = 0; i < 5; i++) {
            var text = document.getElementById("high-temp-day-" + i);
            text.innerHTML = Math.round((text.innerHTML * 9 / 5 + 32));

            var text = document.getElementById("low-temp-day-" + i);
            text.innerHTML = Math.round((text.innerHTML * 9 / 5 + 32));

            document.getElementById("degree-type-high-day-" + i).innerHTML = " &#8457";
            document.getElementById("degree-type-low-day-" + i).innerHTML = " &#8457";
        }
    }
}