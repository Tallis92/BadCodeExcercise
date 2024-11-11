using Microsoft.Extensions.DependencyInjection;
using SalesReport;
using SalesReport.Interfaces;
using SalesReport.Models;

var serviceProvider = new ServiceCollection()
    .AddScoped<IProductRepository, ProductRepository>()  
    .AddScoped<ICategoryRepository, CategoryRepository>()  
    .AddScoped<IDatabase, Database>() 
    .AddScoped<FileWriter>()  
    .AddScoped<GenerateReports>()
    .BuildServiceProvider();


var db = serviceProvider.GetRequiredService<IDatabase>();
var fileWriter = serviceProvider.GetRequiredService<FileWriter>();
serviceProvider.GetRequiredService<GenerateReports>().ReportSetup(db, fileWriter);


