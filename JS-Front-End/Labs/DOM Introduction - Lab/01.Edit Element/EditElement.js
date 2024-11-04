function editElement(ref, match, replacement) {
    const content = ref.textContent;
    const editedText = content.replace(new RegExp(match, 'g'),
    replacement);

    ref.textContent = editedText;
}