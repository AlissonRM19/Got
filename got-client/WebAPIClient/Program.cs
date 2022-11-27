
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace got_client
{
    //Clase Program
    class Program 
    {
        //private static readonly HttpClient client = new HttpClient();
        HttpClient client = new HttpClient();

        //Funcion Main
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Comandos();


        }

        //Metodo Get
        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync("http://localhost:8000/repo");

            List<Todo>? todo = JsonSerializer.Deserialize<List<Todo>>(response);

            if (todo == null)
            {
                Console.WriteLine("Existe un atributo nulo");
            }
            else
            {
                foreach (var item in todo)
                {

                //Console.WriteLine($"id: {item.id}");
                Console.WriteLine($"files: {item?.files}");
                Console.WriteLine($" ");
                }
            }  
        }

        private void gotinit()
        {   string? reponame;
            Console.WriteLine("Escriba el nombre del repositorio...");
            reponame = Console.ReadLine();

            //crear el repositorio

            Console.WriteLine("Se inicio el repositorio "+ reponame);
        }

        private  void parastatus(){

           Program program = new Program();
           program.GetTodoItems();
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

        private void gotadd()
        {
            string? filename;
            Console.WriteLine("Escriba el nombre del archivo a agregar...");
            filename = Console.ReadLine();

            if (filename=="-A"){
                //agregar los archivos al repositorio
                Console.WriteLine("Se agregaron todos los archivos al repositorio.(Estan pendientes de commit)");
            }
            else{
                //agregar el archivo al repositorio
                Console.WriteLine(filename+" Se agrego al repositorio.");
            } 
        }

        private void gotcommit()
        {   string? message;
            Console.WriteLine("Escriba la descripcion del commit...");
            message = Console.ReadLine();

            //Realizar el commit
            Console.WriteLine("Se realizo el commit "+message);
        }

        private void gotstatus()
        {
            string? filename;
            Console.WriteLine("Escriba el nombre del archivo...");
            filename = Console.ReadLine();

            if (filename == "-s")
            { 
               parastatus();
            }
            else
            {
                //Dar status del archivo
                Console.WriteLine("Status del archivo " + filename);
            }
        }

        private void gotrollback()
        {   string? filename;
            Console.WriteLine("Escriba el nombre del archivo...");
            filename = Console.ReadLine();

            string? commit;
            Console.WriteLine("Escriba la descripcion del commit...");
            commit = Console.ReadLine();

            //Realizar el rollback
            Console.WriteLine("Se regreso "+filename+" a la version del commit "+commit);
        }

        private void gotreset()
        {   string? filename;
            Console.WriteLine("Escriba el nombre del archivo...");
            filename = Console.ReadLine();

            //Realizar el rollback al commit anterior
            Console.WriteLine("Se regreso "+filename+" a la version anterior.");
        }

        private void gotsync()
        {   string? filename;
            Console.WriteLine("Escriba el nombre del archivo...");
            filename = Console.ReadLine();

            //Sincronizar el archivo
            Console.WriteLine("Se sincronizo "+filename);
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
                    gotinit();
                    break;

                case "got help":
                    gotHelp();
                    break;

                case "got add":
                    gotadd();
                    break;

                case "got commit":
                    gotcommit();
                    break;

                case "got status":
                    gotstatus();
                    break;

                case "got rollback":
                    gotrollback();
                    break;

                case "got reset":
                    gotreset();
                    break;

                case "got sync":
                    gotsync();
                    break;
            }
        }

        
        /*private async Task PostTodoItems()
            {
                /*
                //var values = new Dictionary<string, string>
                var values=
                {
                    {3,"Repo3",{"file5","file6"},"commit 3",3}
                };

                var data = new FormUrlEncodedContent(values);

                var url = "http://localhost:8000/repo";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                string url = "http://localhost:8000/repo";
                var request = (HttpWebRequest)WebRequest.Create(url);

                var 
                    postData = "&id=" + Uri.EscapeDataString("id");
                    postData += "name=" + Uri.EscapeDataString("name");
                    postData += "files=" +Uri.EscapeDataString("files");
                    postData += "lastcommit=" +Uri.EscapeDataString("lastcommit");
                    postData += "&Numcommit=" +Uri.EscapeDataString("Numcommit");
            
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();


                var wb = new WebClient();
                var data = new NameValueCollection();
                string url = "http://localhost:8000/repo";
                data["username"] = "myUser";
                data["password"] = "myPassword";

                var response = wb.UploadValues(url, "POST", data);
                */

                
                  //var values = new Dictionary<string, string>
                    
                    //List<String> files = new {"file5","file6"};
                  
                   /* var values = {"3","Repo3","file1","commit 3","3"};

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync("http://localhost:8000/repo", content);

                    var responseString = await response.Content.ReadAsStringAsync();
                }*/

    }    

    class Todo
    {
        public int id { get; set; }
        public string? name {get ; set; }
        //public List<string> files { get; set; }
        public string? files {get ; set; }
        public string? lastcommit {get; set;}
        public int Numcommit { get; set; }

    }
    //respuesta = new Todo(id=3, );
}
