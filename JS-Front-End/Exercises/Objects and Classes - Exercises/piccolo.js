function manageLot(arr){
    let lotArray = [];

    for (const iterator of arr) {
        const[direction, number] = iterator.split(', ');

        if(direction === 'IN' && !lotArray.includes(number)){
            lotArray.push(number);
        }
        else if(direction === 'OUT' && lotArray.includes(number)){
            let index = lotArray.indexOf(number)
            lotArray.splice(index, 1);
        }
    }

    if(lotArray.length > 0){
        lotArray = lotArray.sort((a,b) => {
            return a.localeCompare(b);
        });

        lotArray.forEach(element => {
            console.log(element);      
        });
    }
    else{
        console.log(`Parking Lot is Empty`);
    }

    

    
}