﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoAppNTier.Business.Mappings.AutoMapper;
using ToDoAppNTier.Business.Services;
using ToDoAppNTier.DataAccess.Contexts;
using ToDoAppNTier.DataAccess.UnitofWork;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.Business.DependencyResolvers.Microsoft;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddDbContext<TodoContext>(opt =>
        {
            opt.UseSqlServer("Server=DESKTOP-NP0SP3H\\SQLEXPRESS;Initial Catalog=toDoNTier;Integrated Security=sspi;");
            opt.LogTo(Console.WriteLine, LogLevel.Information);
        });

        var configuration = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new WorkProfile());
        });

        var mapper = configuration.CreateMapper();
        services.AddSingleton(mapper);

        services.AddScoped<IUow, Uow>();
        services.AddScoped<IWorkService, WorkService>();
    }
    
    
}