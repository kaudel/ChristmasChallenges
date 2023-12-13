function wrapping(gifts) {
    let result = [], topWrap = "", bottomWrap = "";
    
    for (let i = 0; i < gifts.length; i++) {
        result[i] = "*";
        topWrap = "";
        bottomWrap = "*\n*";
        gifts[i].split("").forEach(c => {
            topWrap += "*";
            bottomWrap += "*";
            //console.log("char:", c);
        });
        topWrap += "*\n*";
        result[i] = "*" + topWrap + gifts[i] + bottomWrap + "*";
    }
    return result;
}

const gifts = ['cat', 'game', 'socks'];
const wrapped = wrapping(gifts);

console.log(wrapped);