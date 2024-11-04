function extract(content) {
    let exp = /\([a-zA-Z\s]+\)/g;
    let element = document.getElementById(content);
    let arr = element.textContent.match(exp);

    let result = [];
    for (const iterator of arr) {
        let word = iterator.substring(1, iterator.length-1);
        result.push(word);
    }

    return result.join('; ');
}