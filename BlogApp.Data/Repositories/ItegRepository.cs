using BlogApp.Data.Queries;
using BlogApp.Model.DataModel;

namespace BlogApp.Data.Repositories
{
    public interface ItegRepository
    {
        public Task CreateTeg(Teg teg);
        public Task UpdateTeg(Teg teg, UpdateTegQuery query);
        public Task DeleteTeg(Teg teg);
        public Task<Teg> GetTegById(Guid id);
        public Task<Teg[]> GetTegArray();
    }
}
