function checkPart(part) {
    let result = false;
    console.log(part);
    if(part.trim().length > 0){
        let reversedStr = part.split("").reverse().join("");
        console.log(`part:${part}. reversedStr:${reversedStr}`);
        result = isPalindrome(reversedStr.trim(), part.trim());
        if(!result){
            console.log(part);
            // Using Loop instead of forEach. As it is required to remove any character until all possible combination have been tested, a loop is required.
            for(let i=0; (i<part.length);i++){
                let newWord = part.substring(0, i) + part.substring(i + 1, part.length); 
                reversedStr = newWord.split("").reverse().join("");
                console.log(reversedStr);
                console.log("newWord: ", newWord);
                result = isPalindrome(reversedStr.trim(), newWord.trim())
                if(result) i = part.length;
                console.log("result: ", result);
            }
            // part.split("").forEach((element, index) => {
                
            // });
        }
    }
    return result;
}
// Helper function
function isPalindrome(word, reversedWord){
    let result = false;
    if(reversedWord.trim() === word.trim()){
        result = true;
    }
    return result;
}

// "uwu" is a palindrome without removing any character
console.log(checkPart("uwu")); // true
// "miidim" can be a palindrome after removing the first "i"
console.log(checkPart("miidim")); // true
// "abca" can be a palindrome after removing the first "i"
console.log(checkPart("abca")); // true
// "midu" cannot be a palindrome after removing a character
console.log(checkPart("midu")); // false
// empty spaces is a palindrome?
console.log(checkPart("")); // false ?
// "omomo" can be a palindrome without removing any character
console.log(checkPart("omomo")); // true
// "anitalavalatina" can be a palindrome without removing any character
//TODO: add space validation to enable statements.
//TODO: convert to lower case.
console.log(checkPart("anitalavalatina")); // true
// "anitalavalatina" can be a palindrome without removing any character
console.log(checkPart("saas"));
