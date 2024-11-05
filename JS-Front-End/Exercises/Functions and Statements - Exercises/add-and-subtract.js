function solve(a, b, c) {

    let sum = (a, b) => a + b;

    let subtract = (sum, c) => sum - c;

    return subtract(sum(a, b), c);
}