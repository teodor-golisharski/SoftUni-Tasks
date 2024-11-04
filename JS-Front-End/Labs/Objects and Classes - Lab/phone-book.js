function storeData(arr){
    let phonebook = {};
    for (const iterator of arr) {
        [name,phone] = iterator.split(' ');
        phonebook[name] = phone;
    }
    for (const key in phonebook) {
        console.log(`${key} -> ${phonebook[key]}`);
    }
}

storeData(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);