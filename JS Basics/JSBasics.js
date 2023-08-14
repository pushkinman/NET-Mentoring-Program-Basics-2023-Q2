// Define a variable with the given value
var sentence = "I can eat bananas all day";

// Use the slice method to extract the word "bananas"
var word = sentence.slice(10, 17);

// Convert the word to uppercase
var uppercaseWord = word.toUpperCase();

// Display the result using the alert function
alert(uppercaseWord);

// Define an array with the given values
var cars = ["Saab", "Volvo", "BMW"];

// Get the value "BMW"
var bmwValue = cars[2];

// Change the first item of the array
cars[0] = "Toyota";

// Remove the last item in the array
cars.pop();

// Add "Audi" to the array
cars.push("Audi");

// Splice "Volvo" and "BMW"
var splicedCars = cars.splice(1, 2);

console.log("BMW value:", bmwValue);
console.log("Updated array:", cars);
console.log("Spliced cars:", splicedCars);
