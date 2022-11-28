const SVNRepoDB = require('../db/SVNRepoDB');

/*
    En este arvivo se puede crear nuevos repositorios para la base de datos por medio la funcion createNewRepo.
    Tambien realiza una validacion para comprobar la existencia del nombre para el nuevo repositorio.
    Además realiza un push del contenido de los elementos en la base de datos.
 */
const createNewRepo = (repo) => {
    if (!repo.name){
        throw new Error('name is required');

    }

    let lastId = -1;

    //Check the repo does not exist
    for (let i = 0; i < SVNRepoDB.length; i++){
        if (SVNRepoDB[i].name == repo.name){
            throw new Error('repo already exists');

        }
        lastId = SVNRepoDB[i].id;

    };

    //Push the new repo into the database
    SVNRepoDB.push({
        id: lastId + 1,
        name: repo.name,
        files: repo.files,
        lastcommit: repo.lastcommit,
        Numcommit: repo.Numcommit,
    });

}

module.exports = {
    createNewRepo
}