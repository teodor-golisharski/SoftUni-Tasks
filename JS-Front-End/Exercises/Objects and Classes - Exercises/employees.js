function assignNumber(arr){
    let obj = {};
    for (const iterator of arr) {
        let length = iterator.length;
        obj[iterator] = length;
    }
    for (const[key,value] of Object.entries(obj)) {
        console.log(`Name: ${key} -- Personal Number: ${value}`);
    }
}

assignNumber([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );