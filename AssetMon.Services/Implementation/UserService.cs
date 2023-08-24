using AssetMon.Data.Repositories.Interface;
using AssetMon.Models.Exceptions;
using AssetMon.Models;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AutoMapper;
using LoggerService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task UpdateUserProfileAsync(string userId, UserProfileDTO userProfileDTO, bool trackChanges)
        {
            var userProfile = await CheckIfExistsAndGetUserProfile(userId, trackChanges);

            _mapper.Map(userProfileDTO, userProfile);
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
