using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<AllCommitsViewModel> GetAllCommitsByUserId(string userId)
        {
            var commits = this.db.Commits
                .Where(c => c.CreatorId == userId)
                .Select(c => new AllCommitsViewModel() { 
                        Id = c.Id,
                        RepositoryName = c.Repository.Name,
                        CreatedOn = c.CreatedOn.ToString(),
                        Description = c.Description
                })
                .ToList();

            return commits;
        }

        public void DeleteCommit(string commitId)
        {
            Commit commit = this.db.Commits.FirstOrDefault(c => c.Id == commitId);

            commit.CreatorId = null;
            commit.RepositoryId = null;

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }
    }
}
