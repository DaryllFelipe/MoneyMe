using Microsoft.EntityFrameworkCore;


namespace MoneyMe.CodingChallenge.Repositories;
internal class Context : DbContext
{
    public DbSet<Loan> Loans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("{your connectionstring}Database=MoneyMe;Trusted_Connection=True;");
    }
}
