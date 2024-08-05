using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SentimentalChat.Data
{
    public class DBAccess : DbContext
    {
        public DBAccess()
        {
        }

        public DBAccess(DbContextOptions<DBAccess> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
        
    }
}
