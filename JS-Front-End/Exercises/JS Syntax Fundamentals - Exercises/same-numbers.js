function numbers(num) {
    let sum = 0;
    let checker = num % 10;
    let flag = true;
    while (num > 0) {

        if (checker != num % 10) {
            flag = false;
        }

        sum += num % 10;
        num -= num % 10;
        num /= 10;
    }

    console.log(flag);
    console.log(sum);
}

numbers(222222);