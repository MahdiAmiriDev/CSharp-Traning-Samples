using AutoMapper;
using AutoMapperSample.Models;

namespace AutoMapperSample.AutoMapperProfile
{
    public class CustomProfile:Profile
    {
        public CustomProfile()
        {
            //CreateMap<User, UserViewModel>()
            //    .ForMember(x => x.UserName, b => b.MapFrom(c => c.FirstName + " " + c.LastName))
            //    .ForMember(x => x.Age, b =>
            //    {
            //        b.PreCondition(c => c.Age > 18);
            //        b.MapFrom(c => c.Age);
            //    });


            CreateMap<User, UserViewModel>()
                .ForMember(x => x.UserName, b => b.MapFrom(c => c.FirstName + " " + c.LastName))
                .ForMember(x => x.Age, b => b.MapFrom(c => c.Age > 18 ? c.Age : default(int)));
        }
    }
}
