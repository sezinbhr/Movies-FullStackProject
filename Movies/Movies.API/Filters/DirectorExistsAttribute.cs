using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Movies.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Filters
{
    public class DirectorExistsAttribute : TypeFilterAttribute
    {
        public DirectorExistsAttribute() : base(typeof(DirectorExistingFilter))
        {

        }

        private class DirectorExistingFilter : IAsyncActionFilter
        {
            private IDirectorService directorService;
            public DirectorExistingFilter(IDirectorService directorService)
            {
                this.directorService = directorService;
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {

                if (!context.ActionArguments.ContainsKey("id"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if (!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var genre = directorService.GetDirectorsById(id);
                if (genre == null)
                {
                    context.Result = new NotFoundObjectResult(new { Message = $"{id}. directorId  not founnd" });
                }

                await next();
            }
        }
    }
}
