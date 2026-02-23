using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Relacionamento Muitos-para-Muitos (Usuários <-> Projetos)
        // Permite que você e sua colega participem dos mesmos projetos
        modelBuilder.Entity<User>()
            .HasMany(u => u.Projects)
            .WithMany(p => p.Users);

        // 2. Relacionamento Um-para-Muitos (Projeto -> Tasks)
        // Cada tarefa pertence a um único projeto
        modelBuilder.Entity<TaskItem>()
            .HasOne<Project>() // Uma TaskItem tem um Projeto
            .WithMany(p => p.Tasks) // Um Projeto tem muitas Tasks
            .HasForeignKey(t => t.ProjectId); // Chave estrangeira em TaskItem

        // 3. Relacionamentos de "Pessoas" na Task (Responsável e Finalizador)
        // Como a tarefa pode ter um usuário ativo e um que a concluiu, 
        // configuramos as chaves estrangeiras manualmente
        
        // Usuário que está fazendo agora (ActiveUser)
        modelBuilder.Entity<TaskItem>()
            .HasOne(t => t.ActiveUser)
            .WithMany() // Não precisamos de uma lista de "TasksAtivas" no User agora
            .HasForeignKey(t => t.ActiveUserId)
            .OnDelete(DeleteBehavior.Restrict); // Não deleta o usuário se a tarefa sumir

        // Usuário que finalizou (ConcluedBy)
        modelBuilder.Entity<TaskItem>()
            .HasOne(t => t.ConcluedBy)
            .WithMany()
            .HasForeignKey(t => t.ConcluedById)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
