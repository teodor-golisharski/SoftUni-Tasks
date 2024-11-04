function manageAppointments(arr) {
    function checkSchedule(schedule, day){
        for (const iterator of Object.keys(schedule)) {
            if(iterator == day){
                return false;
            }
        }
        return true;
    }

    let schedule = {};
    for (const iterator of arr) {
        const [day, name] = iterator.split(' ');
        if(checkSchedule(schedule, day)){
            schedule[day] = name;
            console.log(`Scheduled for ${day}`);
        }
        else{
            console.log(`Conflict on ${day}!`);
        }
    }

    for (const[key,value] of Object.entries(schedule)) {
        console.log(`${key} -> ${value}`);
    }
}

manageAppointments(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']);