function checkPart(part) {
    let result = false;
    console.log(part);
    if(part.trim().length > 0){
        let reversedStr = part.split("").reverse().join("");
        result = isPalindrome(reversedStr.trim(), part.trim());
        if(!result){
            console.log(part);
            // Using Loop instead of forEach
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

console.log(checkPart("uwu")); // true
// "uwu" is a palindrome without removing any character

console.log(checkPart("miidim")); // true
// "miidim" can be a palindrome after removing the first "i"

console.log(checkPart("midu")); // false
// "midu" cannot be a palindrome after removing a character
console.log(checkPart("")); // false ?
// "midu" cannot be a palindrome after removing a character
console.log(checkPart("omomo")); // true
// "midu" cannot be a palindrome after removing a character
console.log(checkPart("anitalavalatina")); // true ?
console.log(checkPart("saas"));
