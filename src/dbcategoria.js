 var config = require('./dbconfig'); //Instanciamos el archivo dbconfig
 const sql =require('mssql'); //Se nesesita paquete mssql


 //Funcion Async : Asyncrona esta devuelve un objeto
 async function getCategoria(){
    try{
        let pool = await sql.connect(config);
        let categorias = await pool.request().query("SELECT * FROM TM_CATEGORIA" );
        return categorias.recordsets;
    }catch(error){
        console.log(error);
    }

 }

 async function getCategoria_x_id(cat_id){
    try{
        let pool = await sql.connect(config);
        let categorias = await pool.request()
            .input('input_parameter', sql.Int, cat_id)
            .query("SELECT * FROM TM_CATEGORIA where CAT_ID = @input_parameter");
        return categorias.recordsets;
    }catch(error){
        console.log(error);
    }
 }
//en progreso
 async function getCategoria_x_id(cat_id){
    try{
        let pool = await sql.connect(config);
        let categorias = await pool.request()
            .input('input_parameter', sql.Int, cat_id)
            .query("SELECT * FROM TM_CATEGORIA where CAT_ID = @input_parameter");
        return categorias.recordsets;
    }catch(error){
        console.log(error);
    }
 }




 module.exports = {
    getCategoria : getCategoria,
    getCategoria_x_id : getCategoria_x_id
 }