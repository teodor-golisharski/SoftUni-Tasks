function movies(arr) {

    let movies = [];

    for (const element of arr) {

        if (element.includes('addMovie')) {

            let movie = element.split('addMovie ')[1];
            
            movies.push({ name: movie });
        }
        else if (element.includes('directedBy')) {

            const [name, director] = element.split(' directedBy ');

            let movieExists = movies.find((el) => el.name === name);

            if (movieExists) {
                movieExists['director'] = director;
            }
        }
        else if (element.includes('onDate')) {
            const [name, date] = element.split(' onDate ');
            let movieExists = movies.find((el) => el.name === name);

            if (movieExists) {
                movieExists['date'] = date;
            }
        }
    }

    movies.forEach((movie) => {
        if (movie.name && movie.date && movie.director) {
            console.log(JSON.stringify(movie));
        }
    })
}

movies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
);