function towns(arr) {
    for (const iterator of arr) {

        const [town, latitude, longitude] = iterator.split(' | ');

        let obj = { town: town, latitude: Number(latitude).toFixed(2), longitude: Number(longitude).toFixed(2) };
        console.log(obj);
    }
}

towns(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);