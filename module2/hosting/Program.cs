using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    class Program
    {
        // com uso da classe de inicialização startup pois nao devemos criar um hostig com classe de inicialização         
        static void Main(string[] args)
        {
            // criando um hosting quem vai pegar as requisições Vamos usar o kestrel
            var carlosHost = new WebHostBuilder()
               .UseKestrel()
               // avisando qual classe que inicializa a aplicação
               .UseStartup<Startup>()

               // avisando que pode ter  arquivos na raiz que vou utilzar (appsettings.json)
               .UseContentRoot(Directory.GetCurrentDirectory())
               .Build();

            // rodando a aplicação
            carlosHost.Run();
        }


        // static void Main(string[] args)
        // {
        //     // criando um hosting quem vai pegar as requisições Vamos usar o kestrel
        //      var carlosHost = new WebHostBuilder()
        //         .UseKestrel()
        //         .Configure( app => {
        //             // toda requisição vai aparecer essa menssagem
        //             app.Run( contextoDaAplicacao => contextoDaAplicacao.Response.WriteAsync("Ola Mundo") );
        //         })
        //         .Build();

        //         // rodando a aplicação
        //         carlosHost.Run();
        // }

    }
}


/*
    pacotes intalados: 
        dotnet add package Microsoft.AspNetCore
        dotnet add package Microsoft.AspNetCore.hosting   

        Pdde-se add macote global com todos 
        Microsoft.AspNetCore.All
 */
