function store(arr1, arr2) {
    let obj = {}
    while (arr1.length > 0) {
        let product = arr1.shift();
        let quantity = arr1.shift();

        obj[product] = Number(quantity);
    }
    while (arr2.length > 0) {
        let product = arr2.shift();
        let quantity = arr2.shift();

        if (!obj.hasOwnProperty(`${product}`)) {
            obj[product] = Number(quantity);
        } 
        else {
            obj[product] += Number(quantity);
        }
    }

    for (const [key, value] of Object.entries(obj)) {
        console.log(`${key} -> ${value}`);
    }
}

store([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);