function deleteByEmail() {
    let input = document.getElementsByName('email')[0].value;
    let result = document.getElementById('result');

    // let trs = document.getElementsByTagName('td');

    // for (const element of trs) {
    //     if(input == element.textContent){
    //         let parent = element.parentNode;
    //         parent.parentNode.removeChild(parent);
    //         result.textContent = 'Deleted.';
    //         return;
    //     }
    //     else{
    //         result.textContent = 'Not found.';
    //     }
    // }

    let trs = document.getElementsByTagName('tr');

    for (const iterator of trs) {
        if (input === iterator.children[1].textContent) {
            iterator.parentNode.removeChild(iterator);
            result.textContent = 'Deleted.';
            return;
        }
        else{
            result.textContent = 'Not found.';
        }
    }
}