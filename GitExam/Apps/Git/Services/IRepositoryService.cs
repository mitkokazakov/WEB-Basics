﻿using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoryService
    {
        void CreateRepo(CreateRepoInputModel model, string userId);
    }
}
