using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace hosting
{
    public  class Startup
    {

        // Configuração Pai
        private IConfigurationRoot _configuration;

        // construtor
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)

                // quero que leia esse arquivo de conigurações substitui o web.config para web e app.conig para descktop
                .AddJsonFile("appsettings.json");

                builder.AddEnvironmentVariables();

                _configuration = builder.Build();
        }

        // metodo de configurações dos middles(features do AspNetCore)
        public void Configure(IApplicationBuilder app) {

            // se eu quero que ele seja executado primeiro devo colocar ele acima de todos automaticamente vai enviar a esposta final da requisição
            app.UseMiddleware<MeuMiddleWare>();

            /*
               para mostrar a imagem no navegador  precisamos habilitar o middle de arauivos estaticos
               precisamos de um pacote Microsoft.AspNetCore.StaticFiles */
               app.UseStaticFiles();
           
           // lendo o arquivo de configuração, pegando o valor da chave
            var nomeAplicacao = _configuration.GetValue<string>("ApplicationName");
            app.Run(meuContext => meuContext.Response.WriteAsync($"Ola Mundo 2 | {nomeAplicacao}"));
        }
    }
}