function heroInventory(arr){
    class Hero{
        constructor(name, level, items){
            this.name = name;
            this.level = Number(level);
            this.items = items;
        }
    }

    let heroes = [];
    for (const iterator of arr) {
        const[name, level, items] = iterator.split(' / ');
        
        let hero = new Hero(name, level, items);
        
        heroes.push(hero);
    }
    heroes.sort((a, b) => {
        if(a.level < b.level){
            return -1
        }
        else if(a.level > b.level){
            return 1;
        }
        return 0;
    })

    for (const hero of heroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    }
}

heroInventory([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]
    );