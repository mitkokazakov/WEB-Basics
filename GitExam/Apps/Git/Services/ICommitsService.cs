using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        void CreateCommit(string userId, CommitInputViewModel model);

        IEnumerable<AllCommitsViewModel> GetAllCommitsByUserId(string userId);

        void DeleteCommit(string commitId);
    }
}
