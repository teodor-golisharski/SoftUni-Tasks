function solve(array) {
    const arrayLength = array.length;

    let sorted = array.sort((a,b)=>a-b);
    let outputArray = [];

    for (let index = 0; index < arrayLength; index++) {
        const element = array[index];
        
        if (index % 2 == 0) {
            outputArray.push(sorted.shift());
        }
        else{
            outputArray.push(sorted.pop());
        }
    }
    return outputArray;
}

console.log(solve([22,9,63,3,2,19,54,11,21,18]));