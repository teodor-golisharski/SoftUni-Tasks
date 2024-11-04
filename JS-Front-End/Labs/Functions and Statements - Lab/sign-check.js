function signCheck(a, b, c) {
    const arr = [a, b, c];
    let count = 0;
    arr.forEach(element => {
        if (element < 0) {
            count++;
        }
    });
    if (count % 2 == 0) {
        console.log("Positive");
    }
    else {
        console.log("Negative");
    }
}

signCheck(5, 12, -15);