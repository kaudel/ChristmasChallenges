function distributeGifts(packOfGifts, reindeers) {
    let result = 0;
    let pofWeight = 0;
    for(let i=0; i<packOfGifts.length; i++)
    {
        pofWeight += packOfGifts[i].length; 
    }
    
    let mwl = 0;
    for(let i=0; i<reindeers.length; i++)
    {  
      mwl += (reindeers[i].length * 2); 
    }
    
    result = Math.floor(mwl / pofWeight) ;

    return result;
}
/**
 * 
 */
let packOfGifts = ["book", "doll", "ball"];
let reindeers = ["dasher", "dancer"];
console.log(distributeGifts(packOfGifts, reindeers));
packOfGifts =['a', 'b', 'c'];
reindeers = ['d', 'e'];
console.log(distributeGifts(packOfGifts, reindeers));
packOfGifts = ['videogames', 'console'];
reindeers = ['midu'];
console.log(distributeGifts(packOfGifts, reindeers));
packOfGifts = ['game', 'videoconsole', 'computer'];
reindeers = ['midudev', 'pheralb', 'codingwithdani', 'carlosble', 'blasco', 'facundocapua', 'madeval', 'memxd'];