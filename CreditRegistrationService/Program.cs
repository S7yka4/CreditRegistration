
using CreditRegistration.DbCommon;
using CreditRegistrationCommon;
using CreditRegistrationService;
using CreditRegistrationService.Logs;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<ITarrifService, TariffManager>();
        builder.Services.AddTransient<ILoanOrderService, LoanOrderManager>();
        builder.Services.AddTransient<ICreditRatingCalculator, CreditRatingCalculator>();
        builder.Services.AddDbContext<DataContext>(opts => opts.SetDbConnection(builder.Configuration));
        builder.Logging.AddProvider(new FileLoggerProvider(builder.Configuration, builder.Environment.IsDevelopment()));
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
    }
}