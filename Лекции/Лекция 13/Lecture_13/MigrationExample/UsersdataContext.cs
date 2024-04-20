using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MigrationExample;

public partial class UsersdataContext : DbContext
{
    public UsersdataContext()
    {
    }

    public UsersdataContext(DbContextOptions<UsersdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Антон\\YandexDisk-mileschko.sibsutis\\ВПиЧМВ\\2023\\Лекции\\12\\EntityFrameworkExamples\\CreateDataBaseExample\\bin\\Debug\\net7.0\\userdata.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
