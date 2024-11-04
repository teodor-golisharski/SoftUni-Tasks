const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const loadButton = document.getElementById('load-meals');
const mealList = document.getElementById('list');

const formElement = document.getElementById('form');

const foodInput = document.getElementById('food');
const timeInput = document.getElementById('time');
const caloriesInput = document.getElementById('calories');
const formAddButton = document.getElementById('add-meal');
const formEditButton = document.getElementById('edit-meal');
const formdivElement = document.getElementById('form-buttons');

function loadVocations(){
    fetch(baseUrl)
        .then(res => res.json())
        .then(result => {
            renderMeals(Object.values(result));
        });
    
}

loadButton.addEventListener('click', loadVocations);
    

formAddButton.addEventListener('click', (e) => {
    e.preventDefault();

    const newMeal = {
        food: foodInput.value,
        time: timeInput.value,
        calories: caloriesInput.value
    };

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newMeal)
    })
    .then(loadVocations)
    .then(clearForm);

    
})

formEditButton.addEventListener('click', (e) => {
    e.preventDefault();

    const mealId = formElement.dataset.meal;

    const mealData = {
        _id: formElement.dataset.meal,
        food: foodInput.value,
        time: timeInput.value,
        calories: caloriesInput.value
    }

    fetch(`${baseUrl}/${mealId}`, {
        method: 'PUT',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(mealData)
    })
    .then(loadVocations)
    .then(() =>{
        formAddButton.removeAttribute('disabled');
        formEditButton.setAttribute('disabled', 'disabled');
        delete formElement.dataset.meal;
    })
})

function clearForm(){
    foodInput.value = '';
    timeInput.value = '';
    calories.value = '';
}

function renderMeals(meals){
    mealList.innerHTML = '';

    meals
    .map(meal = renderMeal)
    .forEach(mealElement => mealList.appendChild(mealElement));
}

function renderMeal(meal){
    const container = document.createElement('div');
    container.className = 'meal';

    const h2Element = document.createElement('h2');
    h2Element.textContent = meal.food;
    const h3TimeElement = document.createElement('h3');
    h3TimeElement.textContent = meal.time;
    const h3CalElement = document.createElement('h3');
    h3CalElement.textContent = meal.calories;

    const innerDiv = document.createElement('div');
    innerDiv.id = 'meal-buttons';
    const changeButton = document.createElement('button');
    changeButton.className = 'change-meal';
    changeButton.textContent = 'Change';
    changeButton.addEventListener('click', () => {
        
        foodInput.value = meal.food;
        timeInput.value = meal.time;
        caloriesInput.value = meal.calories;

        container.remove();

        formEditButton.removeAttribute('disabled');
        formAddButton.setAttribute('disabled', 'disabled');

        formElement.dataset.meal = meal._id;
    })



    const deleteButton = document.createElement('button');
    deleteButton.className = 'delete-meal';
    deleteButton.textContent = 'Delete';

    deleteButton.addEventListener('click', () => {
        fetch(`${baseUrl}/${meal._id}`,{
            method: 'DELETE'
        })
        .then(loadVocations);
    })
    
    innerDiv.appendChild(changeButton);
    innerDiv.appendChild(deleteButton);

    container.appendChild(h2Element);
    container.appendChild(h3TimeElement);
    container.appendChild(h3CalElement);
    container.appendChild(innerDiv);
    
    return container;
}