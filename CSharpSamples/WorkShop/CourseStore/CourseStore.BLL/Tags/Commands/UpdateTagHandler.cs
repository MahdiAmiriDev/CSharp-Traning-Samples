using CourseStore.BLL.FrameWork;
using CourseStore.DAL;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;

namespace CourseStore.BLL.Tags.Commands
{
    public class UpdateTagHandler : BaseApplicationServiceHandler<UpdateTag,Tag>
    {
        public UpdateTagHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
        {
        }

        protected override async Task HandleRequest(UpdateTag request, CancellationToken cancellationToken)
        {

            Tag tag = _courseStoreDbContext.Tags.SingleOrDefault(x => x.Id == request.Id);

            if (tag == null)
            {
                AddError($"تگی با شناسه {request.Id} یافت نشد");
            }
            else
            {
                tag.TagName = request.TagName;
                await _courseStoreDbContext.SaveChangesAsync();
                AddResult(tag);
            }
        }
    }
}
 