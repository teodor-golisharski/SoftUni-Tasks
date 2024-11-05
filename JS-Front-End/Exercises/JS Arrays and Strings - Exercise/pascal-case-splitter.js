function solve(text){
    let regExp = new RegExp('[A-Z][a-z]*', 'g');
    let output = text.match(regExp);
    console.log(output.join(', '))
}

solve('HoldTheDoor');
