using MFS.Contract;
using MFS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace MFS.xUnitTest.Initialize
{
    public class DatabaseTestBase : IDisposable
    {
        protected readonly MFSContext context;
        protected readonly IUnitOfWork unitOfWork;

        public DatabaseTestBase()
        {
            var options = new DbContextOptionsBuilder<MFSContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            context = new MFSContext(options);
            unitOfWork = new UnitOfWork(context);
            context.Database.EnsureCreated();

            DatabaseInitializer.Initialize(context);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
