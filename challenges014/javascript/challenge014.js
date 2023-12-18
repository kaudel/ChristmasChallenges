// A function that returns the minimum time each reindeer can take to slide down the pyramid using the optimal path
function getOptimalPath(pyramid) {
    // Check if the pyramid is empty
    if (pyramid.length == 0) {
        // Return 0
        return 0;
    }
    console.log(`pyramid original:${pyramid}`);
    // Loop through the pyramid from the second last level to the top
    for (let i = pyramid.length - 2; i >= 0; i--) {
        // Loop through each element in the current level
        for (let j = 0; j < pyramid[i].length; j++) {
            // Get the left and right children of the current element
            let left = pyramid[i + 1][j];
            let right = pyramid[i + 1][j + 1];
            
            // Update the current element to the sum of itself and the minimum of its children
            // Math.min(left, right) can be use, too.
            pyramid[i][j] += left < right ? left : right; 
            console.log(`pyramid updated:${pyramid}`);
        }
    }
    console.log(`pyramid:${pyramid}`);
    // Return the element at the top of the pyramid, which is the optimal path
    return pyramid[0][0];
}
  // Example usage
const pyramid1 = [[0], [7, 4], [2, 4, 6]];
const result1 = getOptimalPath(pyramid1); // 8

const pyramid2 = [[0], [2, 3]];
const result2 = getOptimalPath(pyramid2); // 2

console.log(result1, result2); // 8, 2