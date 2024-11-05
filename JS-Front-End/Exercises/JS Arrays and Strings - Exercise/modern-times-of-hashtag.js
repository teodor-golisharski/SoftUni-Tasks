function solve(text){
    let array = text.split(' ');
    let regExp = new RegExp('#[a-zA-Z]+', 'g');
    let output = text.match(regExp);
    
    output.forEach(element => {
        console.log(element.substring(1,element.length));
    });
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');