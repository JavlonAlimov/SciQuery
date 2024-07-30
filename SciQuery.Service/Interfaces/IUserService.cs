using SciQuery.Service.DTOs.User;

namespace SciQuery.Service.Interfaces;
public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(UserForCreateDto userCreateDto);
    Task<UserDto> UpdateAsync(int id, UserForUpdatesDto userUpdateDto);
    Task<bool> DeleteAsync(int id);
}
