using Microsoft.EntityFrameworkCore;

namespace Agenda_Telefonica.Models
{
    public class DbContato : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
    }
}
