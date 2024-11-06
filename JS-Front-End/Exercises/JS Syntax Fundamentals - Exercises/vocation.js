function vocationPrice(n, type, day) {
    let result = 0;

    if (type == "Students") {
        switch (day) {
            case "Friday":
                result = n * 8.45;
                break;

            case "Saturday":
                result = n * 9.80;
                break;

            case "Sunday":
                result = n * 10.46;
                break;

        }

        if (n >= 30) {
            result *= 0.85;
        }
    }
    else if (type == "Business") {
        if (n >= 100) {
            n -= 10;
        }

        switch (day) {
            case "Friday":
                result = n * 10.90;
                break;

            case "Saturday":
                result = n * 15.60;
                break;

            case "Sunday":
                result = n * 16;
                break;

        }

    }
    else if (type == "Regular") {
        switch (day) {
            case "Friday":
                result = n * 15;
                break;

            case "Saturday":
                result = n * 20;
                break;

            case "Sunday":
                result = n * 22.50;
                break;

            default:
                break;
        }

        if (n >= 10 && n <= 20) {
            result *= 0.95;
        }
    }

    console.log(`Total price: ${result.toFixed(2)}`);
}

