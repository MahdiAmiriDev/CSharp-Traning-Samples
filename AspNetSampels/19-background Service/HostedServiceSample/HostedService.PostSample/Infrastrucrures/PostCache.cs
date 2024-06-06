using HostedService.PostSample.Models;

namespace HostedService.PostSample.Infrastrucrures
{
    public class PostCache
    {
        private List<Post> _posts;

        public List<Post> Get() => _posts;

        public void Set(List<Post> posts)
        {
            Interlocked.Exchange(ref _posts, posts);
        }
    }
}
