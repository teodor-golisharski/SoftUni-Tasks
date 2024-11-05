function loadingBar(num) {
    let dots = 10 - (num / 10);
    let line = num.toString().concat(`% [${'%'.repeat(num/10)}${'.'.repeat(dots)}]`);
    if(dots == 0){
        console.log('100% Complete!');
        console.log(line);
    }
    else{
        console.log(line);
        console.log('Still loading...');
    }
}

loadingBar(50);