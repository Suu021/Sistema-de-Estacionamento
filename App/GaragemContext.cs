using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App;
public class GaragemContext : DbContext
{       
    public DbSet<Veiculo> Veiculos { get; set; } = null!;
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Estacionamento> Estacionamentos { get; set; } = null!;
    public DbSet<HistoricoCaixa> HistoricosCaixa { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("DataSource=C:\\Users\\sk8gi\\OneDrive\\Documentos\\GitHub\\Sistema-de-Estacionamento\\App\\appEstacionamento.db;Cache=Shared");

    //dotnet ef migrations add InitialCreate --context GaragemContext
    //dotnet ef database update --context GaragemContext
}
    