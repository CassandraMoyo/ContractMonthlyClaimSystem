using ContractMonthlyClaimSystem.Connection;
using Microsoft.EntityFrameworkCore;
//using ContractMonthlyClaimSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//add database
builder.Services.AddDbContext<ClaimToDbContext>(options =>
options.UseInMemoryDatabase("ClaimToDbContext")
);


//add database service = link application serve and Dbcontext =comfigure database
builder.Services.AddDbContext<ClaimToDbContext>(options =>//specified database
{
    //a function that takes the option parameter
    // look into lambda expressions

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//specify connection string 
                                                                                          //varibale to connect to the connection string

    //use connection string
    options.UseSqlServer(connectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
