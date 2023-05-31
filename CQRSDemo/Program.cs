using CQRSDemo.Commands;
using CQRSDemo.Commands.Application_Commands;
using CQRSDemo.Commands.Banner_Commands;
using CQRSDemo.Commands.CMS_Commands;
using CQRSDemo.Commands.Mission_Commands;
using CQRSDemo.Commands.Skill_Commands;
using CQRSDemo.Commands.Story_Commands;
using CQRSDemo.Commands.Theme_Commands;
using CQRSDemo.Commands.User_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.Application_Queries;
using CQRSDemo.Queries.Banner_Queries;
using CQRSDemo.Queries.CMS_Queries;
using CQRSDemo.Queries.Mission_Queries;
using CQRSDemo.Queries.Skill_Queries;
using CQRSDemo.Queries.Story_Queries;
using CQRSDemo.Queries.Theme_Queries;
using CQRSDemo.Queries.User_Queries;
using CQRSDemo.Repository;
using CQRSDemo.Repository.Interface;
using CQRSDEMO.Handlers;
using CQRSDEMO.Handlers.Application_Handlers;
using CQRSDEMO.Handlers.Banner_Handlers;
using CQRSDEMO.Handlers.CMS_Handlers;
using CQRSDEMO.Handlers.Mission_Handlers;
using CQRSDEMO.Handlers.Skill_Handlers;
using CQRSDEMO.Handlers.Story_Handlers;
using CQRSDEMO.Handlers.Theme_Handlers;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using static CQRSDemo.Commands.User_Commands.AddUserDataCommand;
using static CQRSDemo.Commands.User_Commands.DeleteUserDataCommand;
using static CQRSDemo.Commands.User_Commands.EditUserDataCommand;
using static CQRSDemo.Queries.User_Queries.GetAllUserQuery;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<CIPlatformContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("DbContext")));
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IRequestHandler<GetAllUserQuery, List<User>>, Handler>();
builder.Services.AddTransient<IRequestHandler<AddUserDataCommand, UserAdd>, AddUserDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditUserDataCommand, UserAdd>, EditUserDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetUserDataQuery, User>, GetUserDataHandler>();
builder.Services.AddTransient<IRequestHandler<LogInUserQuery, User>, LogInUserHandler>();
builder.Services.AddTransient<IRequestHandler<SearchUserQuery, List<User>>, SearchUserHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteUserDataCommand, bool>, DeleteUserDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllBannerQuery, List<Banner>>, GetAllBannerHandler>();
builder.Services.AddTransient<IRequestHandler<AddBannerDataCommand, Banner>, AddBannerDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditBannerDataCommand, Banner>, EditBannerDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetBannerDataQuery, Banner>, GetBannerDataHandler>();
builder.Services.AddTransient<IRequestHandler<SearchBannerQuery, List<Banner>>, SearchBannerHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteBannerDataCommand, bool>, DeleteBannerDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllApplicationQuery, List<MissionApplication>>, GetAllApplicationHandler>();
builder.Services.AddTransient<IRequestHandler<EditApplicationDataCommand, MissionApplication>, EditApplicationDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetApplicationDataQuery, MissionApplication>, GetApplicationDataHandler>();
builder.Services.AddTransient<IRequestHandler<SearchApplicationQuery, List<MissionApplication>>, SearchApplicationHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteApplicationDataCommand, bool>, DeleteApplicationDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllStoryQuery, List<Story>>, GetAllStoryHandler>();
builder.Services.AddTransient<IRequestHandler<EditStoryDataCommand, Story>, EditStoryDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetStoryDataQuery, Story>, GetStoryDataHandler>();
builder.Services.AddTransient<IRequestHandler<SearchStoryQuery, List<Story>>, SearchStoryHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteStoryDataCommand, bool>, DeleteStoryDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllSkillQuery, List<Skill>>, GetAllSkillHandler>();
builder.Services.AddTransient<IRequestHandler<AddSkillDataCommand, Skill>, AddSkillDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditSkillDataCommand, Skill>, EditSkillDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetSkillDataQuery, Skill>, GetSkillDataHandler>();
builder.Services.AddTransient<IRequestHandler<SearchSkillQuery, List<Skill>>, SearchSkillHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteSkillDataCommand, bool>, DeleteSkillDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllThemeQuery, List<MissionTheme>>, GetAllThemeHandler>();
builder.Services.AddTransient<IRequestHandler<AddThemeDataCommand, MissionTheme>, AddThemeDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditThemeDataCommand, MissionTheme>, EditThemeDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetThemeDataQuery, MissionTheme>, GetThemeDataHandler>();
builder.Services.AddTransient<IRequestHandler<SearchThemeQuery, List<MissionTheme>>, SearchThemeHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteThemeDataCommand, bool>, DeleteThemeDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllCMSQuery, List<Cmspage>>, GetAllCMSHandler>();
builder.Services.AddTransient<IRequestHandler<AddCMSDataCommand, Cmspage>, AddCMSDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditCMSDataCommand, Cmspage>, EditCMSDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetCMSDataQuery, Cmspage>, GetCMSDataHandler>();
builder.Services.AddTransient<IRequestHandler<SearchCMSQuery, List<Cmspage>>, SearchCMSHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteCMSDataCommand, bool>, DeleteCMSDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetMissionDataQuery, Mission>, GetMissionDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllMissionQuery, List<Mission>>, GetAllMissionHandler>();
builder.Services.AddTransient<IRequestHandler<SearchMissionQuery, List<Mission>>, SearchMissionHandler>();
builder.Services.AddTransient<IRequestHandler<AddMissionDataCommand, MissionAddModel>, AddMissionDataHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteMissionDataCommand, bool>, DeleteMissionDataHandler>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IBannerRepository,BannerRepository>();
builder.Services.AddScoped<IApplicationRepository,ApplicationRepository>();
builder.Services.AddScoped<IStoryRepository,StoryRepository>();
builder.Services.AddScoped<ISkillRepository,SkillRepository>();
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();
builder.Services.AddScoped<ICMSRepository,CMSRepository>();
builder.Services.AddScoped<IMissionRepository,MissionRepository>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();
app.Use(async (context, next) =>
{
    var token = context.Session.GetString("Token");
    if (!string.IsNullOrWhiteSpace(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
