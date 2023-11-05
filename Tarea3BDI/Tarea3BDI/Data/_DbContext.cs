using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tarea3BDI.Models;

namespace Tarea3BDI.Data
{
    public class _DbContext : DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        {
        }

        public DbSet<TipoDocuIdentificacion> TiposDocuIndetificacion { get; set; }

#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        public async Task XMLCatalogo(string xmlContent)
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        {

        }

    }

}
