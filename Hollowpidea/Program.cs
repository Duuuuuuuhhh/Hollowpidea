using Hollowpidea.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHollowService, hollowservice>();

var app = builder.Build();
