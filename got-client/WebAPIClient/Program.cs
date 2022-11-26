// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using System.Text.Json;
using System.Collections.Specialized;
using System.Net;

using System.Text; 
using System.IO;


namespace got_client
{
    //Clase Program
    class Program 
    {

        HttpClient client = new HttpClient();



        //Funcion Main
        static void Main(string[] args)
        {

            Program program = new Program();
            //await program.PostTodoItems();

            program.Comandos();

            //Solo se comenta para una prueba
            //await program.GetTodoItems();
            //await program.gotHelp();
        }

        //Got init
        //>got-init
        //Console.log("Repositorio iniciado")



        //Metodo Get
        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync(
                "http://localhost:8000/pokemons");

            List<Todo>? todo = JsonSerializer.Deserialize<List<Todo>>(response);


            if (todo == null)
            {
                Console.WriteLine("Existe un atributo nulo");
            }
            else
            {
                foreach (var item in todo)
                {

                Console.WriteLine($"id: {item.id}");
                Console.WriteLine($"name: {item?.name}");
                Console.WriteLine($"type: {item?.type}");
                Console.WriteLine($"gen: {item?.gen}");
                Console.WriteLine($" ");
            }
            }  
        }

        private void gotHelp()
        {
            Console.WriteLine("Comando: got init <name>");
            Console.WriteLine("Descripcion: Instancia un nuevo repositorio con el nombre indicado por <name>.");
            Console.WriteLine(" ");

            Console.WriteLine("Comando: got help");
            Console.WriteLine("Descripcion: Información de lo que hace cada comando en Got.");
            Console.WriteLine(" ");

            Console.WriteLine("Comando: got add [-A] [name]");
            Console.WriteLine("Descripcion: Permite agregar todos los archivos que no estén registrados o que");
            Console.WriteLine("tengan nuevos cambios al repositorio,puede indicar cada archivo por agregar,");
            Console.WriteLine("o puede usar el flag -A para agregar todos los archivos relevantes.");
            Console.WriteLine(" ");

            Console.WriteLine("Comando: got commit <mensaje>");
            Console.WriteLine("Descripcion: Envía los archivos agregados y pendientes de commit al server.");
            Console.WriteLine("Se debe especificar un mensaje a la hora de hacer el commit.");
            Console.WriteLine(" ");

            Console.WriteLine("Comando: got status <file>");
            Console.WriteLine("Descripcion: Muestra cuales archivos han sido cambiados, agregados o eliminados de acuerdo al commit anterior.");
            Console.WriteLine("Si el usuario especifica <file>, muestra el historial de cambios, recuperando el historial de cambios desde el server");
            Console.WriteLine(" ");

            Console.WriteLine("Comando: got rollback <file> <commit>");
            Console.WriteLine("Descripcion: Permite regresar un archivo en el tiempo a un commit específico.");
            Console.WriteLine("Para esto, se comunica al server y recupera el archivo hasta dicha versión.");
            Console.WriteLine(" ");

            Console.WriteLine("Comando: got reset <file>");
            Console.WriteLine("Descripcion: Deshace cambios locales para un archivo y lo regresa al último commit.");
            Console.WriteLine(" ");

            Console.WriteLine("Comando: got sync <file>");
            Console.WriteLine("Recupera los cambios para un archivo en el server y lo sincroniza con el archivo en el cliente.");
            Console.WriteLine("Si hay cambios locales, debe permitirle de alguna forma, que el usuario haga merge de los cambios interactivamente");
            Console.WriteLine(" ");

        }


        //Comandos para el manejo de Got
        private void Comandos()
        {
            string? comando;
            
            Console.WriteLine("Escriba el comando got");
            comando = Console.ReadLine();

            //Estructura para el reconocimiento de comandos y su ejecucion 
            switch (comando)
            {
                case "got init":
                    Console.WriteLine("El comando digitado es para la funcion: "+ comando);
                    //En la funcion se debe agregar otro input para el nombre del repositorio
                    break;

                case "got help":
                    gotHelp();
                    break;

                case "got add":
                    Console.WriteLine("El comando digitado es para la funcion: "+ comando);
                    //En la funcion se debe agregar un espacio para el [-A][name]
                    break;

                case "got commit":
                    Console.WriteLine("El comando digitado es para la funcion: "+ comando);
                    //En la funcion se agrega otro input para el mensaje del commit
                    break;

                case "got status":
                    Console.WriteLine("El comando digitado es para la funcion: "+ comando);
                    //Se agrega otro espacio para especificar el file
                    break;

                case "got rollback":
                    Console.WriteLine("El comando digitado es para la funcion: "+ comando);
                    //Se debe agregar un nuevo espacio para el file y el commit
                    break;

                case "got reset":
                    Console.WriteLine("El comando digitado es para la funcion: "+ comando);
                    //Se debe agregar un espacio para el file
                    break;

                case "got sync":
                    Console.WriteLine("El comando digitado es para la funcion: "+ comando);
                    //Se debe agregar un espacio para el file
                    break;
            }
        }

        

        /*private async Task PostTodoItems()
            {
                
                /*var values = new Dictionary<string, string>
                {
                    { "name", "John Doe" },
                    { "occupation", "gardener" }
                };

                var data = new FormUrlEncodedContent(values);

                var url = "http://localhost:8000/pokemons";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);*/

                /*string url = "http://localhost:8000/pokemons";
                var request = (HttpWebRequest)WebRequest.Create(url);

                var 
                    postData = "&id=" + Uri.EscapeDataString("id");
                    postData += "name=" + Uri.EscapeDataString("name");
                    postData = "type=" + Uri.EscapeDataString("type");
                    postData += "&gen=" + Uri.EscapeDataString("gen");
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();*/


                /*var wb = new WebClient();
                var data = new NameValueCollection();
                string url = "http://localhost:8000/pokemons";
                data["username"] = "myUser";
                data["password"] = "myPassword";

                var response = wb.UploadValues(url, "POST", data);
              }*/

    }    

    class Todo
    {
        public int id { get; set; }
        public string? name {get ; set; }

        public string? type { get; set; }

        public int gen { get; set; }

    }   

}
