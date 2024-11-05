function solve(array, n){
    let output=[];
    for (let index = 0; index < array.length; index+=n) {
        const element = array[index];
        output.push(element);
    }
    return output;
}

solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
);