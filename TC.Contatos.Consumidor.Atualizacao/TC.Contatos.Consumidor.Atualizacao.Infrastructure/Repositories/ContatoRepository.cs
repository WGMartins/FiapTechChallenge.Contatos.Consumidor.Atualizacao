using Domain.Interfaces;
using Domain.RegionalAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        protected ApplicationDbContext _context;
        protected DbSet<Contato> _dbSet;

        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Contato>();
        }

        public void Alterar(Contato contato)
        {
            contato.AlteradoEm = DateTime.Now;

            _dbSet.Update(contato);
            _context.SaveChanges();
        }

        public Contato ObterPorId(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
    }
}
