using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteNavita.Domain;
using TesteNavita.Domain.Identity;

namespace TesteNavita.Repository
{
    public class TesteNaviaRepository : ITesteNaviaRepository
    {
        private readonly TesteNaviaContext _context;

        public TesteNaviaRepository(TesteNaviaContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    
        public async Task<Patrimonio[]> GetPatrimoniosAsync()
        {
            IQueryable<Patrimonio> query = _context.Patrimonios;
                
               
            query = query.AsNoTracking()
                .OrderBy(c => c.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Patrimonio> GetPatrimoniosAsyncById(int PatrimonioId)
        {
            IQueryable<Patrimonio> query = _context.Patrimonios;

            query = query.AsNoTracking()
                .Where(c => c.Id == PatrimonioId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Marca[]> GetMarcasAsync()
        {
            IQueryable<Marca> query = _context.Marcas;


            query = query.AsNoTracking()
                .OrderBy(c => c.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Marca> GetMarcasAsyncById(int MarcaId)
        {
            IQueryable<Marca> query = _context.Marcas;

            query = query.AsNoTracking()
                .Where(c => c.Id == MarcaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Marca[]> GetPatrimoniosAsyncByMarca(int MarcaId)
        {
            IQueryable<Marca> query = _context.Marcas
                .Include(p => p.Patrimonios);
                

            query = query.AsNoTracking().
                Where(c => c.Id == MarcaId)
                .OrderBy(c => c.Nome);

            return await query.ToArrayAsync();
        }

        
    }
}
