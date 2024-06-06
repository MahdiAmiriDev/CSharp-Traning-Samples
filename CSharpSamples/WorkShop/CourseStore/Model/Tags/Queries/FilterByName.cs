using CourseStore.Model.FrameWork;
using CourseStore.Model.Tags.Dto;
using MediatR;

namespace CourseStore.Model.Tags.Queries
{
    public class FilterByName:IRequest<ApplicationServiceResponse<List<TagQr>>>
    {
        public string? TagNane { get; set; }
    }
}
