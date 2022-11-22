// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using System.Text.Json;

namespace got_client
{
    //Clase Program
    class Program 
    {
        HttpClient client = new HttpClient();



        //Funcion Main
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetTodoItems();
        }


        //Metodo Get
        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync(
                "http://localhost:8000/pokemons");

            List<Todo> todo = JsonSerializer.Deserialize<List<Todo>>(response);


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
            }

            
            }  
       
       
        }

    }


    class Todo
    {
        public int id { get; set; }
        public string? name {get ; set; }
    }

}