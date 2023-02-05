using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRateLimiter(conf => {
  conf.AddSlidingWindowLimiter("global", options =>
  {
    options.PermitLimit = 100;
    options.SegmentsPerWindow = 3;
    options.Window = TimeSpan.FromSeconds(30);
    options.QueueLimit = 10;
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
  });

  conf.AddFixedWindowLimiter("2par2", options =>
  {
    options.Window = TimeSpan.FromSeconds(5);
    options.PermitLimit = 2;
    options.QueueLimit = 0;
    options.AutoReplenishment = true;
  });
});
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}")
   .RequireRateLimiting("2par2");

app.UseRateLimiter();

app.Run();
