function sumEvenOdd(num) {
    let even = 0;
    let odd = 0;

    let numberAsString = num.toString();

    for (let index = 0; index < numberAsString.length; index++) {
        
        let currentDigit = Number(numberAsString[index]);

        if(currentDigit % 2 == 0){
            even += currentDigit;
        }
        else{
            odd += currentDigit;
        }
        
    }

    console.log(`Odd sum = ${odd}, Even sum = ${even}`);
}

