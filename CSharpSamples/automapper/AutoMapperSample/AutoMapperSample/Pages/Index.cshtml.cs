using AutoMapper;
using AutoMapperSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMapperSample.Pages
{
    public class IndexModel : PageModel
    {
        public UserViewModel UserViewModel { get; set; }
        public IQueryable<UserViewModel> UsersQuery { get; set; }


        private readonly IMapper _mapper;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IMapper mapper = null)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public void OnGet()
        {
            //User myUser = new()
            //{
            //    Email ="mahdi@gmail.com",
            //    FirstName ="mahdi",
            //    LastName ="amiri",
            //    UserId =1,                
            //};

            //UserViewModel =  _mapper.Map<UserViewModel>(myUser);


            //-----------------------MapCollection-------------

            List<User> users = new()
            {
                new User
                {
                    Email = "mahdi@gmail.com",
                    FirstName = "mahdi",
                    LastName = "amiri",
                    UserId = 1,
                    Age = 12,
                    Gender = Gender.Female
                },
                new User
                {
                    Email = "mahdi@gmail.com",
                    FirstName = "mahdi",
                    LastName = "amiri",
                    UserId = 1,
                    Age=18,
                    Gender = Gender.Female
                },
                new User
                {
                    Email = "mahdi@gmail.com",
                    FirstName = "mahdi",
                    LastName = "amiri",
                    UserId = 1,
                    Age=22,
                    Gender = Gender.Male
                }
            };

            _mapper.Map<List<UserViewModel>>(users);

            //----------------------------------QueryAble

            var userQuery = users.AsQueryable();

            UsersQuery = _mapper.ProjectTo<UserViewModel>(userQuery);

           
        }
    }
}