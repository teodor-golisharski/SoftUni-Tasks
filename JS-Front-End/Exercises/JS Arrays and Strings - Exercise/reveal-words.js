function solve(arr, text){

    arr = arr.split(', ');
    arr.forEach(element => {
       let length = element.length;
       let mask = '*'.repeat(length);
       if(text.includes(mask)){
        text = text.replace(mask, element);
       } 
    });
    console.log(text);
}

solve('great, learning',
'softuni is ***** place for ******** new programming languages'
);