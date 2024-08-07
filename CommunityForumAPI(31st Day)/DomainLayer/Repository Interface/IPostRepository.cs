﻿using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repository_Interface
{
    public interface IPostRepository
    {
        Task<string> Add(PostDTO post,int id);

        Task<IEnumerable<PostWithUserDTO>> GetAll();

        Task<IEnumerable<PostWithUserDTO>> GetAllUnapproved();

        Task Approve(int id);

        Task Delete(int id);

        Task<IEnumerable<PostWithUserDTO>> Retrieve(int id);

        Task<PostWithUserDTO> RetrieveSingle(int id);

        Task DeletePostAsync(int id,int userId);
    }
}
