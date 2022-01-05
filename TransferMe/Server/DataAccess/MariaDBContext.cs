using Transfer.Me.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Transfer.Me.Shared.DataAccess
{
    public class MariaDBContext : DbContext {
        public MariaDBContext(DbContextOptions<MariaDBContext> options) : base(options) {}

        public DbSet<EncryptedFile> EncryptedFile { get; set; }

    }

}