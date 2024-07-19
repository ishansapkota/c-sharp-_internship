using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service_Interface
{
    public interface IPostService
    {
        Task<string> AddPostAsync(PostDTO post, int id);
        Task<IEnumerable<PostWithUserDTO>> GetAllPostAsync();
    }
}
