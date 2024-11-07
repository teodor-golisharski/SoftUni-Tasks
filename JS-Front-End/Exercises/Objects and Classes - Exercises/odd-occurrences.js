function oddOccurrences(text) {
    text = text.toLowerCase();

    let obj = {};
    for (const iterator of text.split(' ')) {
        if (obj.hasOwnProperty(iterator)) {
            obj[iterator]++;
        }
        else {
            obj[iterator] = 1;
        }
    }

    let outputArray = [];
    for (const [key, value] of Object.entries(obj)) {
        if (value % 2 == 1) {
            outputArray.push(key);
        }
    }

    console.log(outputArray.join(' '));
}