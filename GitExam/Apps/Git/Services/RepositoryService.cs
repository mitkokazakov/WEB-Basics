using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext db;

        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateRepo(CreateRepoInputModel model, string userId)
        {
            bool isPublic = model.RepositoryType == "Public" ? true : false;

            User user = this.db.Users.FirstOrDefault(u => u.Id == userId);

            Repository repository = new Repository()
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = isPublic,
                Owner = user
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }
    }
}
