function isPalindrome(arr) {
    arr.forEach(element => {
        let stringEl = element.toString();
        
        let reversedNum = stringEl.split('').reverse().join('');

        console.log(stringEl === reversedNum);
    });
}

isPalindrome([123,323,421,121])