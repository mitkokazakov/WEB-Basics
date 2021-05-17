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
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string userId = this.GetUserId();

            var commits = this.commitsService.GetAllCommitsByUserId(userId);

            return this.View(commits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            SingleRepoViewModel repository = this.repositoryService.GetRepoById(id);

            return this.View(repository);
        }

        [HttpPost]
        public HttpResponse Create(CommitInputViewModel model)
        {
            string userId = this.GetUserId();

            if (String.IsNullOrEmpty(model.Description) || model.Description.Length < 5)
            {
                return this.Error("The Description must be minimum 5 characters");
            }

            this.commitsService.CreateCommit(userId, model);

            return this.Redirect("/Commits/All");
        }

        
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.commitsService.DeleteCommit(id);

            return this.Redirect("/Repositories/All");
        }
    }
}
