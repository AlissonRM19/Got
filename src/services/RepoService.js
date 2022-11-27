const SVNRepoDB = require('../db/SVNRepoDB');

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