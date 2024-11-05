function validate(password) {

    function isValidLength(password) {
        if (password.length < 6 || password.length > 10) {
            return false;
        }
        return true;
    }

    function isAlphaNumeric(password) {
        let regExp = new RegExp('^[a-zA-z0-9]+$', 'g');
        if (!regExp.test(password)) {
            return false;
        }
        return true;
    }

    function checkDigits(password) {
        let counter = 0;
        for (const digit of password) {
            if (!isNaN(digit)) {
                counter++;
            }
        }

        if(counter >= 2){
            return true;
        }
        return false;
    }

    let length = isValidLength(password);
    let alphaNumeric = isAlphaNumeric(password);
    let digits = checkDigits(password);

    if(length && alphaNumeric && digits){
        console.log("Password is valid");
    }
    else{
        if(!length){
            console.log("Password must be between 6 and 10 characters");
        }
        if(!alphaNumeric){
            console.log("Password must consist only of letters and digits");
        }
        if(!digits){
            console.log("Password must have at least 2 digits");
        }
    }
}