function colorize() {
    let elements = document.getElementsByTagName('tr');
    let count = 1;
    for (const iterator of elements) {
        if (count % 2 == 0) {
            iterator.style.backgroundColor = 'teal';
        }
        count++;
    }
}