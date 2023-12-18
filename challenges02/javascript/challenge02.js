/*
The year may be a leap year. Make the checks you need for it, if necessary.
Although the holiday is December 31, the extra hours will be done the same year.
Date.getDay() method returns the day of the week of a date. 0 is Sunday, 1 is Monday, etc.
*/
//TODO: Complete!!
function countHours(year, holidays) {
    result = 0;
    // Check for leap year
    const isLeapYear = year % 400 === 0 || (year % 4 === 0 && year % 100 !== 0);
    //const d = new Date("July 21, 1983 01:15:00");
    console.log(`holidays.length:${holidays.length}`);
    for (let i = 0; i < holidays.length; i++) {
        const holiday = holidays[i];
        console.log(`holiday:${holiday}[${holiday.split("/")[0]}${holiday.split("/")[1]}]`);
        const d = new Date(year, holiday.split("/")[0], holiday.split("/")[1], 0, 0, 0, 0);
        let day = d.getDay();
        console.log("DATE:", day);
        if (!(d instanceof Date)) {
            throw new TypeError('Invalid input: date must be a Date object');
        }
        
        //console.log("Number Day", day.getDay());
        if(isLeapYear(year) && holiday.split("/")[0]){

        }
    }
    return result;
}

// Helper functions
function isLeapYear(year) {
    let result = false;
    //three conditions to find out the leap year
    if ((0 == year % 4) && (0 != year % 100) || (0 == year % 400)) {
        console.log(year + ' is a leap year');
        result = true;
    } /*else {
        console.log(year + ' is not a leap year');
    }*/
    return result;
}
function getDayName(date) {
    // Create an array of the names of the days
    var days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    
    // Get the day index from the date object
    var dayIndex = date.getDay();
    
    // Return the corresponding name from the array
    return days[dayIndex];
}
//Test cases
const year = 2022;
let holidays = ['01/06', '04/01', '12/25', '02/29', '02/30', '02/31']; // format MM/DD

// 01/06 is January 6, Thursday. Count.
// 04/01 is April 1, Friday. Count.
// 12/25 is December 25, Sunday. Do not count.

countHours(year, holidays); // 2 days -> 4 extra hours in the year
/*
holidays = ['01/01', '02/09', '12/31'] // format MM/DD
// 01/01 is January 1, Saturday. Do not count.
// 02/09 is February 9, Wednesday. Count.
// 12/31 is December 31, Saturday. Do not count.
countHours(year, holidays) // 2 days -> 2 extra hours in the year
 */