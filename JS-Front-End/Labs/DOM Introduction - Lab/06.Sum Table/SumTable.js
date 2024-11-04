function sumTable() {
    let tdArr = document.querySelectorAll('td:last-child');
    let sum = 0;
    for (const iterator of tdArr) {
        sum += Number(iterator.textContent);
    }
    document.getElementById('sum').textContent = sum.toFixed(2);
}