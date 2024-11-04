function solve(input){
    let even = 0, odd = 0;
    input.forEach(element => {
        if(element % 2 === 0){
            even+=element;
        }
        else{
            odd+=element;
        }
    });
    console.log(even-odd);
}

solve([1,2,3,4,5,6]);