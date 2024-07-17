﻿using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service
{
    public class PostService:IPostService
    {
        private readonly IPostRepository iRepo;

        public PostService(IPostRepository _iRepo)
        {
            iRepo = _iRepo;
        }

        public async Task<string> AddPostAsync(PostDTO post, int id)
        {
            return await iRepo.Add(post, id);
        }
    }
}