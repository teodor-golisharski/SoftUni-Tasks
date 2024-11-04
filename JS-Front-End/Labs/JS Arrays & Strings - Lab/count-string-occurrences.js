function solve(text, word) {
    let count = 0;
    text = text.split(' ');
    text.forEach(element => {
        if (element == word) {
            count++;
        }
    });
    console.log(count);
}

solve('This is a word and it also is a sentence',
    'is');