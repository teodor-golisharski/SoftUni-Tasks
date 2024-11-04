function extractText() {
    let listItems = document.getElementsByTagName('li');
    let textArea = document.getElementById('result');
    for (const iterator of listItems) {
        textArea.textContent+=iterator.textContent+'\n';
    }
}