using SciQuery.Service.DTOs.User;
using SciQuery.Service.Pagination.PaginatedList;

namespace SciQuery.Service.Interfaces;
public interface IUserService
{
    Task<PaginatedList<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(UserForCreateDto userCreateDto);
    Task UpdateAsync(int id, UserForUpdatesDto userUpdateDto);
    Task<bool> DeleteAsync(int id);
}
