function cooking(num, op1, op2, op3, op4, op5) {
    const op = [op1, op2, op3, op4, op5];
    op.forEach(element => {
        switch (element) {
            case "chop":
                num /= 2;
                break;
            case "dice":
                num = Math.sqrt(num);
                break;
            case "spice":
                num += 1;
                break;
            case "bake":
                num *= 3;
                break;
            case "fillet":
                num *= 0.8;
                break;
            default:
                break;
        }
        console.log(num);
    });
}