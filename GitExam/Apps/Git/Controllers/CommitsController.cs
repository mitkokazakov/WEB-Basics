using Git.Data;
using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(ICommitsService commitsService, IRepositoryService repositoryService)
        {
            this.commitsService = commitsService;
            this.repositoryService = repositoryService;
        }
        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Create(string id)
        {
            SingleRepoViewModel repository = this.repositoryService.GetRepoById(id);

            return this.View(repository);
        }

        [HttpPost]
        public HttpResponse Create()
        {
            return this.Redirect("/Commits/All");
        }
    }
}
