using Saxmay.Entities;
using Saxmay.Entities.Dtos;

namespace Saxmay.Business.Interfaces
{
    public interface IActivityBusiness
    {
        Task<Activity> GetById(int id);
        Task<List<ActivityDto>> GetAll();
        Task<Activity> Created(ActivityDto activity);
        Task<Activity> Updated(ActivityDto activity);
        Task<bool> Delete(int id);
    }
}
