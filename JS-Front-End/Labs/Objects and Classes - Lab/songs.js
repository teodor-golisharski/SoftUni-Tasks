function songs(input) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let n = input.shift();
    let type = input.pop();

    for (const iterator of input) {
        const [typeList, name, time] = iterator.split('_');
        let song = new Song(typeList, name, time);

        if (type == "all" || type == typeList) {
            console.log(name);
        }
    }

}

songs([3, 'favourite_DownTown_3:14', 'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01', 'favourite']
);