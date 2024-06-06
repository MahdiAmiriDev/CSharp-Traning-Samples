using HostedService.PostSample.Sesrvices;

namespace HostedService.PostSample.Infrastrucrures
{
    public class PostCacheHostedService : BackgroundService
    {
        private readonly PostCache _postCache;
        private readonly IServiceProvider _serviceProvider;

        public PostCacheHostedService(PostCache postCache,IServiceProvider serviceProvider)
        {
            _postCache = postCache;
            _serviceProvider = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using(var scode = _serviceProvider.CreateScope())
                {
                    var postService = scode.ServiceProvider.GetRequiredService<PostService>();
                    var posts = await postService.GetAll();
                    _postCache.Set(posts);
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }               
            }
        }
    }
}
