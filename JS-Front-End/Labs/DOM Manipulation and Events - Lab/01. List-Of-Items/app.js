function addItem() {
    // take the input
    const inputElement = document.querySelector('#newItemText');

    // create element with tag li
    const newListItem = document.createElement('li');
    
    // give the created element text content equal to the value of the input 
    newListItem.textContent = inputElement.value; 

    // take the whole list with items
    const ulList = document.querySelector('#items');
    
    // append the newly created element
    ulList.appendChild(newListItem);

    // reset the input
    inputElement = '';
    console.log("hello world!");
}