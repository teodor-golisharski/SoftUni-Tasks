function solve() {
  let text = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;

  let result = [];
  for (let word of text.split(' ')) {
    word = String(word).toLowerCase();
    word = word.split('');
    let firstLetter = word.shift();
    firstLetter = String(firstLetter).toUpperCase();
    word.unshift(firstLetter);
    result.push(word.join(''));
  }

  let finalResult = result.join('');

  if(namingConvention == 'Camel Case'){
    finalResult = finalResult.split('');
    let firstLetter = finalResult.shift();
    firstLetter = String(firstLetter).toLowerCase();
    finalResult.unshift(firstLetter);
    finalResult = finalResult.join('');
  }
  else if(namingConvention == 'Pascal Case'){
    
  }else{
    finalResult = 'Error!';
  }

  document.getElementById('result').textContent = finalResult;

}