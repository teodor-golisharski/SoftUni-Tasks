function solve(n, array) {
    let temp = array.slice(0, n);
    temp = temp.reverse();
    let output = "";
    temp.forEach(element => {
        output+=element+" "
    });
    console.log(output);
}

solve(3, [1, 2, 3, 4, 5, 6]);