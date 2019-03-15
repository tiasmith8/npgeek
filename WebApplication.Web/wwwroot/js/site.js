// Looks at localStorage to determine if user prefers Celsius over the default Fahrenheit.
// Sets the tempConvert checkbox appropriately and makes a call to convert to Celsius if necessary.
function checkCelsius() {
    if (localStorage.getItem("toCelsius") == "true") {
        // Set checkbox to checked
        document.getElementById("tempConvert").checked = true;
        // And convert to Celsius
        setTemp();
    }
    // Otherwise keep default values (unchecked, Fahrenheit)
}

// Overwrites localStorage based on current tempConvert checkbox state.
// Converts temperature between Celsius and Fahrenheit and adds appropriate degree symbol to each forecast
function setTemp() {
    // Get the checkBox
    var checkBox = document.getElementById("tempConvert");

    // If user would like to convert to Celcius (checked)
    if (checkBox.checked) {
        localStorage.setItem("toCelsius", "true");

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
        localStorage.setItem("toCelsius", "false");

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

// When the user scrolls the page, execute myFunction 
window.onscroll = function () {
    myFunction();
};

// Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
function myFunction() {
    // Get the header
    var header = document.getElementById("nav-links");

    // Get the offset position of the navbar
    var sticky = header.offsetTop;
    if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
    } else {
        header.classList.remove("sticky");
    }
}