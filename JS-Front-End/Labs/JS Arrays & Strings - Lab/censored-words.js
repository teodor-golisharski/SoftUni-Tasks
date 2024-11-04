function solve(input, word){
    while (input.includes(word)) {
        input = input.replace(word, '*'.repeat(word.length)); 
    }
    console.log(input);
}

solve('A small sentence with some words', 'small');