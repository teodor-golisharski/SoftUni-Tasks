function search() {
   let result = document.getElementById('result');
   let towns = document.querySelectorAll('#towns li');
   let input = document.getElementById('searchText');

   console.log(input);
   let count = 0;
   for (let iterator of towns) {
      if(iterator.textContent.includes(input.value)){
         iterator.style.textDecoration = 'underline';
         iterator.style.textDecoration = 'bold';
         count ++;
      }
   }

   result.textContent = `${count} matches found`;
}
