function trackWords(arr){

    let sentence = arr.shift();
    let obj = {};

    for (const iterator of sentence.split(' ')) {
        obj[iterator] = 0;
        
        for (const element of arr) {
            if(element === iterator){
                obj[iterator] ++;
            }
        }
    }

    let tempArray = Object.entries(obj);
    tempArray.sort((a,b) => {
        if(a[1] < b[1]){
            return 1;
        }
        else if(a[1]>b[1])
        {
            return -1;
        }
        return 0;
    });

    for (const[key,value] of tempArray) {
        console.log(`${key} - ${value}`);
    }
}

trackWords([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
    );