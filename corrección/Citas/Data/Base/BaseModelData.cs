
using Entity.Contexts;
using Entity.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Base
{
    public class BaseModelData<T> : BaseModelDataA<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;
        public BaseModelData(ApplicationDbContext context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public override async Task<T> GetAllById(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }
        public override async Task<T> Create(T Entity)
        {
            _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;

        }

        public override async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
