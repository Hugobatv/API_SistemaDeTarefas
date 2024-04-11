using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repository;
using SistemaDeTarefas.Repository.Interfaces;
using System.Diagnostics.CodeAnalysis;


    
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEntityFrameworkSqlServer()
           .AddDbContext<TaskSystemDBContext>(
                opitions => opitions.UseSqlServer(builder.Configuration.GetConnectionString("TaskSystemDBContext"))
            ) ;
        builder.Services.AddScoped<IRepositoryTasks, RepositoryUser>();
        builder.Services.AddScoped<IRepositoryTask, RepositoryTask>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    




