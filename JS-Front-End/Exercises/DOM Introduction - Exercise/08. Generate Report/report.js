function generateReport() {

    let personObjects = {};
    let personAllObjects = [];
    let columnSetNumbers = [];

    let columsAll = document.querySelectorAll('thead tr th input');

    for (let index = 0; index < columsAll.length; index++) {
        let checkBoxState = columsAll[index].checked;

        if (checkBoxState) {
            columnSetNumbers.push(index);
        }

    }
    let columnTitles = document.querySelectorAll('thead tr')[0].getElementsByTagName('th');
    let rowsCount = document.querySelectorAll('tbody tr').length;

    for (let row = 0; row < rowsCount; row++) {

        columnSetNumbers.forEach((element) => {
            let key = columnTitles[element].textContent.trim().toLowerCase();
            let value = document.querySelectorAll('tbody tr')[row].getElementsByTagName('td')[element].textContent;
            personObjects[key] = value;

            console.log(value);
        });

        personAllObjects.push(Object.assign(personObjects));
        personObjects = {};
        
    }

    document.getElementById('output').innerHTML = JSON.stringify(personAllObjects);

}