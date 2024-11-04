function converter(firstName, lastName, color){
    let obj = {};
    obj.name = firstName;
    obj.lastName = lastName;
    obj.hairColor = color;

    let convertedObj = JSON.stringify(obj);
    console.log(convertedObj);
}

converter('George', 'Jones', 'Brown');