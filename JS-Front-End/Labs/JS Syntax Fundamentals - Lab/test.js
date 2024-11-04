function solve1(num) {
    console.log(num * 2);
}

function solve2(name, age, grade) {
    console.log(`Name: ${name}, Age: ${age}, Grade: ${grade.toFixed(2)}`);
}

function solve3(grade) {
    if (grade >= 5.5) {
        console.log(`Excellent`);
    } else {
        console.log(`Not excellent`);
    }
}

function solve4(key) {
    let month;
    switch (key) {
        case 1:
            month = "January";
            break;
        case 2:
            month = "February";
            break;

        case 3:
            month = "March";
            break;
        case 4:
            month = "April";
            break;
        case 5:
            month = "May";
            break;
        case 6:
            month = "June";
            break;
        case 7:
            month = "July";
            break;
        case 8:
            month = "August";
            break;
        case 9:
            month = "September";
            break;
        case 10:
            month = "October";
            break;
        case 11:
            month = "November";
            break;
        case 12:
            month = "December";
            break;
        default:
            month = "Error!"
            break;
    }
    console.log(month);
}

function solve5(num1, num2, operator) {
    let result = 0;

    switch (operator) {
        case "+": result = num1 + num2; break;
        case "-": result = num1 - num2; break;
        case "*": result = num1 * num2; break;
        case "/": result = num1 / num2; break;
        case "%": result = num1 % num2; break;
        case "**": result = num1 ** num2; break;
    }

    console.log(result);
}

function solve6(num1, num2, num3) {
    let result;

    if (num1 > num2 && num1 > num3) result = num1;
    else if (num2 > num1 && num2 > num3) result = num2;
    else result = num3;

    console.log(`The largest number is ${result}.`);
}

function solve7(day, age) {
    let result = 0;
    switch (day) {
        case "Weekday":
            if (age >= 0 && age <= 18) {
                result = 12;
            }
            else if (age > 18 && age <= 64) {
                result = 18;
            }
            else if (age > 64 && age<= 122) {
                result = 12;
            }
            else {
                result = "Error!";
            }
            break;

        case "Weekend":
            if (age >= 0 && age <= 18) {
                result = 15;
            }
            else if (age > 18 && age <= 64) {
                result = 20;
            }
            else if (age > 64 && age<= 122) {
                result = 15;
            }
            else {
                result = "Error!";
            }
            break;

        case "Holiday":
            if (age >= 0 && age <= 18) {
                result = 5;
            }
            else if (age > 18 && age <= 64) {
                result = 12;
            }
            else if (age > 64 && age<= 122) {
                result = 10;
            }
            else {
                result = "Error!";
            }
            break;

    }
    if (result != "Error!") {
        console.log(`${result}$`)
    }
    else console.log(`${result}`);

}

function solve8(num) {
    let type = typeof num;
    let result;

    if(typeof num == 'number' )
    {
        result = Math.PI*Math.pow(num, 2);
        result = result.toFixed(2);
    }else{
        result = `We can not calculate the circle area, because we receive a ${type}.`
    }
    console.log(result);
}

function solve9(){
    for (let i = 1; i <= 5; i++) {
        console.log(i);
    }
}

function solve10(m ,n){
    for(let i = m; i>= n; i--){
        console.log(i);
    }
}

solve10(6, 2);