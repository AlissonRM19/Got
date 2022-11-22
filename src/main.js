const pokemonsDB = require('./db/pokemonsDB');
const helpDB = require('./db/helpDB');
const express= require('express');
const { createNewPokemon} = require('./services/PokemonService');

const port = 8000;
const app = express();
const app2 = express();
app.use(express.json());
app2.use(express.json());

//Comando para help
app2.get('/pokemons', (request, response)=>{
    response.send(helpDB);
});

app.get('/pokemons', (request, response)=>{
    //console.log(response.send('Hola mundo'));
    response.send(pokemonsDB);

});

app.post('/pokemons', (request, response)=>{
    try {
        createNewPokemon(request.body);
        response.status(200).send(pokemonsDB);

    } catch(error){
        response.status(400).send(error.message);
    }
});


app.listen(port,()=>{
    console.log('Server ready on port ${port}');
});
