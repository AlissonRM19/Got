const SVNRepoDB = require('./db/SVNRepoDB');
//const helpDB = require('./db/helpDB');
const express= require('express');
const { createNewRepo} = require('./services/RepoService');

const port = 8000;
const app = express();
//const app2 = express();
app.use(express.json());
//app2.use(express.json());

//Comando para help
/*app2.get('/pokemons', (request, response)=>{
    response.send(helpDB);
});*/

app.get('/repo', (request, response)=>{
    //console.log(response.send('Hola mundo'));
    response.send(SVNRepoDB);

});

app.post('/repo', (request, response)=>{
    try {
        createNewRepo(request.body);
        response.status(200).send(SVNRepoDB);

    } catch(error){
        response.status(400).send(error.message);
    }
});

app.listen(port,()=>{
    console.log('Server ready on port ${port}');
});
