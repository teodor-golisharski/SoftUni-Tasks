function smallestNumber(a, b, c) {
    const arr = [a, b, c];
    let minValue = Number.MAX_VALUE;
    arr.forEach(element => {
        if (element < minValue) {
            minValue = element;
        }
    })

    console.log(minValue);
}