using CourseStore.BLL.FrameWork;
using CourseStore.DAL;
using CourseStore.DAL.Tags;
using CourseStore.Model.Tags.Dto;
using CourseStore.Model.Tags.Queries;

namespace CourseStore.BLL.Tags.Queries
{
    public class FilterByNameHandler : BaseApplicationServiceHandler<FilterByName,List<TagQr>>
    {
        public FilterByNameHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
        {
        }

        protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
        {
            var tags = await _courseStoreDbContext.Tags.WhereOver(request.TagNane).ToTagQrAsync();

            AddResult(tags);
        }
    }
}
