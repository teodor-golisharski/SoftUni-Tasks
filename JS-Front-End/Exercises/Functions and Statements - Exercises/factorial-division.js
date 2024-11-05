function factorialDivision(a, b) {

    function calcFact(num) {
        let result = 1;
        for (let index = 1; index <= num; index++) {
            result *= index;
        }
        return result;
    }

    let factA = calcFact(a);
    let factB = calcFact(b);

    console.log((factA/factB).toFixed(2));
}