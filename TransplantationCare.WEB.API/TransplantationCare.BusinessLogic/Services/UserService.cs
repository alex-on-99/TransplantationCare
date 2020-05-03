using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();
            var userModels = new List<UserModel>();

            foreach(var item in users)
            {
                userModels.Add(new UserModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    SecondName = item.SecondName,
                    DateOfBirth = item.DateOfBirth,
                    Login = item.Login,
                    Mail = item.Mail,
                    Pasport = item.Pasport,
                    PhoneNumber = item.PhoneNumber,
                    CompanyId = item.CompanyId,
                    RoleId = item.RoleId
                });
            }

            return userModels;
        }

        public async Task<UserModel> GetUser(int id)
        {
            var user = await userRepository.GetWithIncludesByIdAsync(id);
            var reviewModels = new List<ReviewCreationModel>();

            foreach(var item in user.Reviews)
            {
                var reviewer = await userRepository.GetByIdAsync(item.ReviewerId);
                reviewModels.Add(new ReviewCreationModel
                {
                    DateTimeReview = item.DateTimeReview,
                    Message = item.Message,
                    ReviewerLogin = reviewer.Login,
                    UserId = item.UserId
                });
            }

            var userModel = new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                SecondName = user.SecondName,
                DateOfBirth = user.DateOfBirth,
                Login = user.Login,
                Mail = user.Mail,
                Pasport = user.Pasport,
                PhoneNumber = user.PhoneNumber,
                CompanyId = user.CompanyId,
                RoleId = user.RoleId,
                ReviewModels = reviewModels
            };

            return userModel;
        }

        public async Task<UserModel> GetUserByLogin(string login)
        {
            var user = await userRepository.GetWithIncludesByLoginAsync(login);
            var reviewModels = new List<ReviewCreationModel>();

            foreach (var item in user.Reviews)
            {
                var reviewer = await userRepository.GetByIdAsync(item.ReviewerId);
                reviewModels.Add(new ReviewCreationModel
                {
                    DateTimeReview = item.DateTimeReview,
                    Message = item.Message,
                    ReviewerLogin = reviewer.Login,
                    UserId = item.UserId
                });
            }

            var userModel = new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                SecondName = user.SecondName,
                DateOfBirth = user.DateOfBirth,
                Login = user.Login,
                Mail = user.Mail,
                Pasport = user.Pasport,
                PhoneNumber = user.PhoneNumber,
                CompanyId = user.CompanyId,
                RoleId = user.RoleId,
                ReviewModels = reviewModels
            };

            return userModel;
        }
    }
}
