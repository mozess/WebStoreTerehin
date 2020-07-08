using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreTerehin.Controllers.Infrastructure.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _Next;
        public TestMiddleware(RequestDelegate Next) { _Next = Next; }

        public async Task Invoke(HttpContext Context)
        {
            //Действия над context до следующего элемента в контейнере
            await _Next(Context); //Вызов следующего промежуточного ПО в контейнере
            //Действия над context после следующего элемента в контейнере
        }
    }
}
