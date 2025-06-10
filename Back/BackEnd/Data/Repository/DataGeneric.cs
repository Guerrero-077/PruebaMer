using Entity.Context;
using Entity.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class DataGeneric<T> : ABaseModelData<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;

        public DataGeneric(ApplicationDbContext context)
        {
            _context = context;
        }


        public override async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .ToListAsync();
        }

        public override async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.is_deleted == false && e.id == id);

        }
        public override async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
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
