function printCharacters(x, y) {
    if (x > y) {
        let temp = x;
        x = y;
        y = temp;
    }

    let start = x.charCodeAt();
    let end = y.charCodeAt();
    let array = [];

    for (let index = start + 1; index < end; index++) {
        array.push(String.fromCharCode(index));
    }

    console.log(array.join(' '));
}
printCharacters('a', 'r');
