function printSum(a, b) {
    let sum = 0;
    let result = ``;
    for (let index = a; index <= b; index++) {
        sum += index;
        result += `${index} `;
    }
    console.log(result);
    console.log(`Sum: ${sum}`);
}

printSum(5, 10);