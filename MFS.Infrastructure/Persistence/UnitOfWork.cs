using MFS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MFS.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MFSContext _context;

        public UnitOfWork(MFSContext context)
        {
            _context = context;
        }


        public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
