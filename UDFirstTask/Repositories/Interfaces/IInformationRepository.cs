using UDFirstTask.DTOs;

namespace UDFirstTask.Repositories.Interfaces
{
    public interface IInformationRepository
    {
        Task<InformationDetailsDto> GetByIdAsync(int id);
        Task<IEnumerable<InformationDetailsDto>> GetAllAsync();
        Task AddAsync(NewInformationDTO information);
    }

}
