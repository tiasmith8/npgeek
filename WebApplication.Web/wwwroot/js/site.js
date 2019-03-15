// Looks at cookies to determine if user prefers Celsius over the default Fahrenheit.
// Sets the tempConvert checkbox appropriately and makes a call to convert to Celsius if necessary.
function checkCelsius() {
    // Get all cookies
    var allCookies = document.cookie;
    // Split cookies into array
    var cookiearray = allCookies.split(';');
    var toCelsius;

    // Loop through cookie array
    for (var i = 0; i < cookiearray.length; i++) {
        name = cookiearray[i].split('=')[0];
        value = cookiearray[i].split('=')[1];
        // If we find the conversion cookie
        if (name == "toCelsius") {
            // Save its value to variable
            toCelsius = value;
        }
    }

    // If a cookie is found and user wants to convert to Celsius
    if (toCelsius == "true") {
        // Set checkbox to checked
        document.getElementById("tempConvert").checked = true;
        // And convert to Celsius
        setTemp();
    }
    // Otherwise keep default values (unchecked, Fahrenheit)
}

// Expires previous cookie and creates new cookie based on current tempConvert checkbox state.
// Converts temperature between Celsius and Fahrenheit and adds appropriate degree symbol to each forecast
function setTemp() {
    // Get the checkBox
    var checkBox = document.getElementById("tempConvert");

    // If user would like to convert to Celcius (checked)
    if (checkBox.checked) {
        // Expire previous toCelsius cookie and create new one
        document.cookie = "toCelsius=true; path=/; expires = Thu, 01 Jan 1970 00: 00: 00 GMT";
        document.cookie = "toCelsius=true; path=/";

        // Loop through 5-day forecast
        for (var i = 0; i < 5; i++) {
            // Convert High temp
            var text = document.getElementById("high-temp-day-" + i);
            text.innerHTML = Math.round((text.innerHTML - 32) * 5 / 9);

            // Convert Low temp
            var text = document.getElementById("low-temp-day-" + i);
            text.innerHTML = Math.round((text.innerHTML - 32) * 5 / 9);

            // Convert degree symbol to degree Celsius
            document.getElementById("degree-type-high-day-" + i).innerHTML = " &#8451";
            document.getElementById("degree-type-low-day-" + i).innerHTML = " &#8451";
        }
        // ELSE
    } else {
        // Overwrite cookie
        document.cookie = "toCelsius=false; path=/; expires = Thu, 01 Jan 1970 00: 00: 00 GMT";
        document.cookie = "toCelsius=false; path=/";

        // Convert to Fahrenheit
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