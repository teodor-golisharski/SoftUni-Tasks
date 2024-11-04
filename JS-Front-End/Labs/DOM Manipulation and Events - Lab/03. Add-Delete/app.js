function addItem() {
    const inputElement = document.querySelector('#newItemText').value;
    const ulList = document.querySelector('#items');
    
    if(inputElement.length === 0) return;

    const newListItem = document.createElement('li');

    newListItem.textContent = inputElement; 

    let remove = document.createElement('a');
    let linkText = document.createTextNode('[Delete]');


    remove.appendChild(linkText);
    remove.href = '#';
    remove.addEventListener('click', deleteItem);

    
    inputElement = '';



}