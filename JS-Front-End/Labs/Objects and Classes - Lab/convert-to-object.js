function converter(obj){
    let resultObj = JSON.parse(obj);
    for (const entry of Object.entries(resultObj)) {
        const [key,value] = entry;
        console.log(`${key}: ${value}`)
    }
}