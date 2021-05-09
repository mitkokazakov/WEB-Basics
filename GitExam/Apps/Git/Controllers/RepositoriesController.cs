using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Create() 
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepoInputModel model)
        {
            string currentUserId = null;

            if (this.IsUserSignedIn())
            {
                 currentUserId = this.GetUserId();
            }

            //TODO: Check the input !!


            this.repositoryService.CreateRepo(model, currentUserId);

            return this.Redirect("/Repositories/All");

        }
    }
}
