using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Movies.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Filters
{
    public class MovieExistsAttribute : TypeFilterAttribute
    {
        public MovieExistsAttribute() : base(typeof(MovieExistingFilter))
        {

        }

        private class MovieExistingFilter : IAsyncActionFilter
        {
            private IMovieService movieService;
            public MovieExistingFilter(IMovieService movieService)
            {
                this.movieService = movieService;
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

                var genre = movieService.GetMoviesById(id);
                if (genre == null)
                {
                    context.Result = new NotFoundObjectResult(new { Message = $"{id}. movieId  not founnd" });
                }

                await next();
            }
        }
    }
}
