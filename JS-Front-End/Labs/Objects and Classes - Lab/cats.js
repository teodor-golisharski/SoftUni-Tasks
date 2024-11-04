function meow(arr){
    class Cat{
        constructor(name ,age){
            this.name = name;
            this.age = age;
        }
    
        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }
    

    for (const iterator of arr) {
        const[name,age] = iterator.split(' ');
        let cat = new Cat(name, age);
        cat.meow();
    }
}