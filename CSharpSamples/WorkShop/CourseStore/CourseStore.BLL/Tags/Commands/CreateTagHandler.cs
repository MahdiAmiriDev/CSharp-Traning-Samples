using CourseStore.BLL.FrameWork;
using CourseStore.DAL;
using CourseStore.Model.FrameWork;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.BLL.Tags.Commands
{
    public class CreateTagHandler : BaseApplicationServiceHandler<CreateTag, Tag>
    {
        public CreateTagHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
        {

        }
        protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
        {
            Tag tag = new Tag()
            {
                TagName = request.TagName,
            };

            await _courseStoreDbContext.Tags.AddAsync(tag);
            await _courseStoreDbContext.SaveChangesAsync();
            AddResult(tag);
        }
    }
}
 