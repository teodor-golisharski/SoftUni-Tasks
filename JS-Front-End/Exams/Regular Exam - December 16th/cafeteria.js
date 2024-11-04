function solve(arr){
    let baristas = [];

    let baristasCount = Number(arr.shift());
    for (let index = 0; index < baristasCount; index++) {
        const element = arr[index];
        const[name, shift, drinks] = element.split(' ');
        let obj = {};
        obj.name = name;
        obj.shift = shift;
        obj.drinks = drinks.split(',');
        baristas.push(obj);
    }
    for (const iterator of arr) {
        const[command, ...rest] = iterator.split(' / ');

        if(command == 'Prepare'){
            
            const[name, shift, drink] = rest;
            
            for (const iterator of baristas) {

                if(iterator.name == name){

                    if(iterator.drinks.includes(drink) && iterator.shift == shift){
                        console.log(`${name} has prepared a ${drink} for you!`);
                    }
                    else{
                        console.log(`${name} is not available to prepare a ${drink}.`);
                    }
                }
            }
        }
        else if(command == 'Change Shift'){

            const[name, newShift] = rest;

            for (const iterator of baristas) {
                
                if(iterator.name == name){
                    iterator.shift = newShift;
                    console.log(`${name} has updated his shift to: ${newShift}`);
                }
            }
        }
        else if(command == 'Learn'){

            const[name, drink] = rest;

            for (const iterator of baristas) {
                
                if(iterator.name == name){
                    
                    if(iterator.drinks.includes(drink)){
                        console.log(`${name} knows how to make ${drink}.`);
                    }
                    else{
                        iterator.drinks.push(drink);
                        console.log(`${name} has learned a new coffee type: ${drink}.`);
                    }
                }
            }
        }
        else if(command == 'Closed'){
            
            for (const iterator of baristas) {
                console.log(`Barista: ${iterator.name}, Shift: ${iterator.shift}, Drinks: ${iterator.drinks.join(', ')}`);
            }
        }
    }
}

solve([
    '3',
      'Alice day Espresso,Cappuccino',
      'Bob night Latte,Mocha',
      'Carol day Americano,Mocha',
      'Prepare / Alice / day / Espresso',
      'Change Shift / Bob / night',
      'Learn / Carol / Latte',
      'Learn / Bob / Latte',
      'Prepare / Bob / night / Latte',
      'Closed']
    );