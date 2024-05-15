using Microsoft.EntityFrameworkCore;
using Saxmay.Business.Interfaces;
using Saxmay.Data;
using Saxmay.Entities;
using Saxmay.Entities.Dtos;

namespace Saxmay.Business
{
    public class ActivityBusiness : IActivityBusiness
    {
        private readonly DataContext _dataContext;
        private readonly ApplicationUser _applicationUser;

        public ActivityBusiness(DataContext dataContext, ApplicationUser applicationUser) 
        {
            _dataContext = dataContext;
            _applicationUser = applicationUser;
        }


        public async Task<Activity> Created(ActivityDto activity)
        {
            var newActivity = new Activity()
            {
                Name = activity.Name,
                Description = activity.Description,
                IsActive = activity.IsActive,
                Price = activity.Price,
                CreatedBy = _applicationUser.Name ?? "System"
            };

            _dataContext.Activities.Add(newActivity);

            await _dataContext.SaveChangesAsync();

            return newActivity;
            
        }

        public async Task<bool> Delete(int id)
        {
            var activity = await _dataContext.Activities.FirstOrDefaultAsync(x => x.Id == id);
            if (activity != null)
            {
                _dataContext.Activities.Remove(activity);
                await _dataContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<ActivityDto>> GetAll()
        {
            var activities = await _dataContext.Activities
                                    .ToListAsync();

            return activities.Select(x => new ActivityDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
                Price = x.Price
            })
            .OrderBy(x => x.Name)
            .ToList();
        }

        public async Task<Activity> GetById(int id)
        {
            var activity = await _dataContext.Activities
                        .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (activity != null) return activity;

            return null;
        }

        public async Task<Activity> Updated(ActivityDto item)
        {
            var activity = await _dataContext.Activities.Where(x => x.Id == item.Id).FirstOrDefaultAsync();

            if (activity != null)
            {
                activity.UpdatedDate = DateTime.UtcNow;
                _dataContext.Entry(activity).CurrentValues.SetValues(item);

                await _dataContext.SaveChangesAsync();

                return activity;
            }

            return null;
        }
    }
}
