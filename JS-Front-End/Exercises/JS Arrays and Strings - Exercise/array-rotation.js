function solve(array, rotations) {
    for (let index = 0; index < rotations; index++) {
        const firstEl = array.shift();
        array.push(firstEl);
    }
    let output = '';
    array.forEach(element => {
        output = output.concat(element, ' ');
    });
    console.log(output);
}

solve([51, 47, 32, 61, 21], 2);