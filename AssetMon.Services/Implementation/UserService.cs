using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using AutoMapper;

namespace AssetMon.Services.Implementation
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task DeleteUserProfileAsync(string userId, bool trackChanges)
        {
            var userProfile = await CheckIfExistsAndGetUserProfile(userId, trackChanges);

            await _repository.User.DeleteUserProfileAsync(userProfile);
            await _repository.SaveAsync();
        }

        public async Task<ResultDTO<UserProfileDTO>> GetUserProfileByIdAsync(string userId, bool trackChanges)
        {
            var userProfile = await CheckIfExistsAndGetUserProfile(userId, trackChanges);

            var mappedEntity = _mapper.Map<UserProfileDTO>(userProfile);
            return new ResultDTO<UserProfileDTO> { Data = mappedEntity, Success = true };
        }

        public async Task<(ResultDTO<IEnumerable<UserProfileDTO>> users, MetaData metaData)> GetUserProfilesAsync(UserParameters userParameters, bool trackChanges)
        {
            if (!userParameters.ValidDateRange) throw new MaxDateRangeBadRequestException();

            var usersWithMetaData = await _repository.User.GetUserProfilesAsync(userParameters, trackChanges);

            var mappedEntity = _mapper.Map<List<UserProfileDTO>>(usersWithMetaData);

            return (users: new ResultDTO<IEnumerable<UserProfileDTO>> { Success = true, Data = mappedEntity }, metaData: usersWithMetaData.MetaData);
        }

        public async Task UpdateUserProfileAsync(string userId, UserProfileToUpdateDTO userProfileToUpdateDTO, bool trackChanges)
        {
            var userProfile = await CheckIfExistsAndGetUserProfile(userId, trackChanges);

            _mapper.Map(userProfileToUpdateDTO, userProfile);
            await _repository.SaveAsync();
        }

        private async Task<UserProfile> CheckIfExistsAndGetUserProfile(string userId, bool trackChanges)
        {
            var userProfile = await _repository.User.GetUserProfileByIdAsync(userId, trackChanges);

            if (userProfile == null)
            {
                throw new UserProfileNotFoundException(userId);
            }

            return userProfile;
        }
    }
}
