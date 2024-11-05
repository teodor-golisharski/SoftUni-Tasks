function isPerfect(num) {

    function divisors(num) {
        let sum = 1;
        for (let index = 2; index <= num / 2; index++) {
            if (num % index == 0) {
                sum += index;
            }

        }
        return sum;
    }

    let sum = divisors(num);
    if (sum == num) {
        console.log("We have a perfect number!");
    }
    else{
        console.log("It's not so perfect.")
    }
}

isPerfect(6)