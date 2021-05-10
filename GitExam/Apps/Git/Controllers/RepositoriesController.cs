using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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

            string[] repoTypes = new string[] { "Public", "Private" };

            //TODO: Check the input !!

            if (model.Name.Length < 3 || model.Name.Length > 10 || String.IsNullOrEmpty(model.Name))
            {
                return this.Error("The Name length field must be between 3 and 10 characters long");
            }

            if (String.IsNullOrEmpty(model.RepositoryType) || !repoTypes.Contains(model.RepositoryType))
            {
                return this.Error("The Repo Type field must be fill correct");
            }

            this.repositoryService.CreateRepo(model, currentUserId);

            return this.Redirect("/Repositories/All");

        }
    }
}
