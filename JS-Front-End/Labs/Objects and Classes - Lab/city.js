function city(object){
    Object.keys(object).forEach(element => {
        console.log(`${element} -> ${object[element]}`);
    });
}

function city2(obj){
    for (const entry of Object.entries(obj)) {
        const[key,value] = entry;
        console.log(`${key} -> ${value}`);
    }
}

city({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
}
);