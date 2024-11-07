function dictionary(jsonArr) {
    let dict = {};
    for (const iterator of jsonArr) {
        let obj = JSON.parse(iterator);
        dict = Object.assign(dict, obj);
    }

    let sortedKeys = Object.keys(dict);
    sortedKeys.sort((a,b) => {
        return a.localeCompare(b)
    });

    for (const key of sortedKeys) {
        console.log(`Term: ${key} => Definition: ${dict[key]}`)
    }   
}

dictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]
    );