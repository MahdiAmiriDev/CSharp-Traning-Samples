using Newtonsoft.Json;
using Quartz;
using QuartzSample.Sesrvices;

namespace QuartzSample.Jobs
{
    public class PostTofFileJob : IJob
    {
        private readonly PostService postService;

        public PostTofFileJob(PostService postService)
        {
            this.postService = postService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var posts = await postService.GetAll();
            System.IO.File.WriteAllText($"E:\\NikAmooz Samples\\TempQ\\{DateTime.Now.Ticks}.json",
                JsonConvert.SerializeObject(posts));
        }
    }
}
