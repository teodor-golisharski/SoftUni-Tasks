function sum(num) {
    let sum = 0;
    while (num > 0) {
        sum += num % 10;
        num -= num % 10;
        num /= 10;

    }
    console.log(sum);
}

sum(543);