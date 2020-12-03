using Microsoft.EntityFrameworkCore;
using System;
using TulaHealthCodeChallenge.Domain;

namespace TulaHealthCodeChallenge.Data
{
    public class TablesContext : DbContext
    {
        public TablesContext(DbContextOptions<TablesContext> options)
            :base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
