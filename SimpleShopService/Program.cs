namespace SimpleShopService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var services = builder.Services;

        services.AddControllers();
        services.AddApiVersioning();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.Scan(scan => scan
            .FromApplicationDependencies(a => a.FullName!.StartsWith("SimpleShopService"))
            .AddClasses(false)
            .AsMatchingInterface()
            .WithSingletonLifetime());

        services.AddSwaggerGen(setup => setup.DescribeAllParametersInCamelCase());

        builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler();
            app.UseHsts();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
