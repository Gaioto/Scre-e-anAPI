using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreamAPI.Models
{
    public class ScreenContext: DbContext
    {
        public ScreenContext(DbContextOptions<ScreenContext> options)
            : base(options)
        {
                
        }

        public virtual DbSet<Imagem> Imagens { get; set; }

    }
}
