const dbcategoria =require('./dbcategoria');

//Requerido en todos 
var express = require('express');
var bodyParser = require('body-parser');
var cors = require('cors');
const { request, response } = require('express');

var app = express();
var router = express.Router();


//Para cuando se envia un POST
app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());
app.use(cors());
app.use('/api',router);//Ruta principal

//Ruta para todas las categorias
router.route('/categoria').get((request, response)=>{
    dbcategoria.getCategoria().then(result=>{
        response.json(result[0]);
    })
})

//Ruta para una categoria por id
router.route('/categoria/:id').get((request, response)=>{
    dbcategoria.getCategoria_x_id(request.params.id).then(result=>{
        response.json(result[0]);
    })
})

var port = process.env.PORT || 8090;
app.listen(port);
console.log("Categoria API Iniciado en el puerto : "+ port); //Mensaje de inicio de servicio




/*const SVNRepoDB = require('./db/SVNRepoDB');
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

/*app.get('/repo', (request, response)=>{
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
});*/