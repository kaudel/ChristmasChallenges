function checkStepNumbers(systemNames, stepNumbers) {
    // Map (objet) to save the step numbers of each system
    const systemStepsMap = {};
    let result = true;
    
    for (let i = 0; i < systemNames.length; i++) {
        const systemName = systemNames[i];
        const stepNumber = stepNumbers[i];

      // Any map has been processed? Check if the step number is in strictly increasing order.
      // hasOwnProperty helps to validate if a systemName has already been added to the map.
        if (systemStepsMap.hasOwnProperty(systemName)) {
            if (systemStepsMap[systemName] >= stepNumber) {
                result = false;
            }
        }

        // The current step number ([i]) is added to the map, in the corresponding systemName.
        systemStepsMap[systemName] = stepNumber;
    }

    // If all step numbers are in strictly increasing order, return true.
    return result;
}

let systemNames = ["tree_1", "tree_2", "house", "tree_1", "tree_2", "house"];
let stepNumbers = [1, 33, 10, 2, 44, 20];
console.log(checkStepNumbers(systemNames, stepNumbers)); // => true
systemNames = ["tree_1", "tree_1", "house"];
stepNumbers = [2, 1, 10];
console.log(checkStepNumbers(systemNames, stepNumbers));  // => false

systemNames = ["tree_1", "tree_1", "tree_2", "house", "tree_3", "house", "tree_3"];
stepNumbers = [1, 2, 10, 100, 3, 200, 6]; // => true
console.log(checkStepNumbers(systemNames, stepNumbers));  // => true

systemNames = [];
stepNumbers = []; 
console.log(checkStepNumbers(systemNames, stepNumbers));  // => true