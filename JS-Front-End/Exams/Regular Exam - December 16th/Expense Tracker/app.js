window.addEventListener("load", solve);

function solve(){
    const previewListElement = document.getElementById('preview-list');
    const expenseElement = document.getElementById('expense');
    const amountElement = document.getElementById('amount');
    const dateElement = document.getElementById('date');
    const buttonElement = document.getElementById('add-btn');
    const expenseListElement = document.getElementById('expenses-list');
    const deleteButtonElement = document.getElementsByClassName('btn delete')[0];

    buttonElement.addEventListener('click', (e) => {
        e.preventDefault();

        if(!expenseElement.value || !amountElement.value || !dateElement.value){
            return;
        } 

        const liElement = document.createElement('li');
        liElement.className = 'expense-item';

        const articleElement = document.createElement('article');
        
        const articleExpense = document.createElement('p');
        articleExpense.textContent = `Type: ${expenseElement.value}`;
        
        const articleAmount = document.createElement('p');
        articleAmount.textContent = `Amount: ${amountElement.value}$`;
        
        const articleDate = document.createElement('p');
        articleDate.textContent = `Date: ${dateElement.value}`;
        

        // Buttons:
        const divElement = document.createElement('div');
        divElement.className = 'buttons';
        
        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('btn');
        editButtonElement.classList.add('edit');
        editButtonElement.textContent = 'edit';

        const okButtonElement = document.createElement('button');
        okButtonElement.classList.add('btn');
        okButtonElement.classList.add('ok');
        okButtonElement.textContent = 'ok';

        divElement.appendChild(editButtonElement);
        divElement.appendChild(okButtonElement);
        
        articleElement.appendChild(articleExpense);
        articleElement.appendChild(articleAmount);
        articleElement.appendChild(articleDate);

        liElement.appendChild(articleElement);
        liElement.appendChild(divElement);

        previewListElement.appendChild(liElement);
        
        clearForm();

        buttonElement.setAttribute('disabled', true);

        editButtonElement.addEventListener('click', (e) => {
            const paragraphElements = previewListElement.querySelectorAll('article p');

            const[expensePElement, amountPElement, datePElement] = Array.from(paragraphElements);

            expenseElement.value = expensePElement.textContent.split(': ')[1];
            amountElement.value = amountPElement.textContent.split(': ')[1].substring(0, amountPElement.textContent.split(': ')[1].length-1);
            dateElement.value = datePElement.textContent.split(': ')[1];

            previewListElement.innerHTML = '';

            buttonElement.removeAttribute('disabled');
        })

        okButtonElement.addEventListener('click', (e) => {
            divElement.remove();
            

            expenseListElement.appendChild(liElement);

            previewListElement.innerHTML = '';

            buttonElement.removeAttribute('disabled');
        })

        deleteButtonElement.addEventListener('click', (e) => {
            location.reload();
        })
    })

    function clearForm(){
        expenseElement.value = '';
        amountElement.value = '';
        dateElement.value = '';
    }

}
