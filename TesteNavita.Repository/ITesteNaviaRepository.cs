using TesteNavita.Domain;
using TesteNavita.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TesteNavita.Repository
{
    public interface ITesteNaviaRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Patrimonio[]> GetPatrimoniosAsync();
        Task<Patrimonio> GetPatrimoniosAsyncById(int PatriminioId);

        Task<Marca[]> GetMarcasAsync();
        Task<Marca> GetMarcasAsyncById(int MarcaId);
        Task<Marca[]> GetPatrimoniosAsyncByMarca(int MarcaId);

    }
}
