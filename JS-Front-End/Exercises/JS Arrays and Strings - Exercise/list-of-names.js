function solve(array){
    array = array.sort((a,b) => {return a.localeCompare(b)});
    let enumerator = 1;
    array.forEach(element => {
        let output = enumerator + '.'+element;
        console.log(output);
        enumerator++;
    });
}

solve(["John", "Bob", "Christina", "Ema"]);