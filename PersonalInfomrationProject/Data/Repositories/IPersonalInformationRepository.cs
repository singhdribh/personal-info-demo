using PersonalInfomrationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalInfomrationProject.Data.Repositories
{
    public interface IPersonalInformationRepository
    {
        Task DeleteAsync(string id);
        Task<List<PersonalInformationModel>> GetAllAsync();
        Task SaveInfo(PersonalInformationModel request);
    }
}