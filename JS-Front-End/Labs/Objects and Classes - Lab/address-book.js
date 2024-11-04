function storeData(arr){
    let addressBook = {};
    for (const iterator of arr) {
        [name,address] = iterator.split(':');
        addressBook[name] = address;
    }

    let addressArray = Object.entries(addressBook);
    addressArray.sort();

    for (const[key,value]  of addressArray) {
        console.log(`${key} -> ${value}`);
    }
}

storeData(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']);