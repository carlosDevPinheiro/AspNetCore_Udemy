using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class MeuMiddleWare
    {
        // proximo middle os middle sempre devem delegar ao proximo se não houver um proximo então vem a respota para cliente
         private RequestDelegate _next;        

        public MeuMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        // metodo de invocação do proximo middle
        public async Task InvokeAsync(HttpContext context)
        {
                // Request inicio da resposta
                var start = DateTime.Now;

                await _next(context);

                // Response quando termina essa resposta 
                var finish = DateTime.Now;

                // itersceptando a resposta e add o texto do tempo que durou a requisição
                await context.Response.WriteAsync($"O Tempo foi de {finish.Millisecond}");
        }
    }
}