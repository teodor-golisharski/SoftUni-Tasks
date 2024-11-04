function pow(a, b){
    let output = 1;
    for (let index = 0; index < b; index++) {
        output *= a;
    }
    console.log(output);
}

pow(2,8);