using Backend.DTO;

namespace Backend.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDTO>> Get();
    }
}
