using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;
        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateCommit( string userId, CommitInputViewModel model)
        {
            Commit commit = new Commit()
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                RepositoryId = model.Id,
                CreatorId = userId
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }
    }
}
