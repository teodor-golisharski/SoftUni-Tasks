function solve(word, text){
    let lowerWord = word.toLowerCase();
    let lowerText = text.toLowerCase();
    lowerText = lowerText.split(' ');
    
    if(lowerText.includes(lowerWord)){
        console.log(word);
    }
    else{
        console.log(word+' not found!');
    }
}

solve('javascript',
'JavaScript is the best programming language')