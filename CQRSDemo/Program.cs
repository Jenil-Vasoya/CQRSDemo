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
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<CIPlatformContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("DbContext")));
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IRequestHandler<GetAllUserQuery, List<User>>, GetAllUserHandler>();
builder.Services.AddTransient<IRequestHandler<AddUserDataCommand, UserAdd>, AddUserDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditUserDataCommand, UserAdd>, EditUserDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetUserDataQuery, User>, GetUserDataHandler>();
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
builder.Services.AddTransient<IRequestHandler<DeleteStoryDataCommand, bool>, DeleteStoryDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllSkillQuery, List<Skill>>, GetAllSkillHandler>();
builder.Services.AddTransient<IRequestHandler<AddSkillDataCommand, Skill>, AddSkillDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditSkillDataCommand, Skill>, EditSkillDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetSkillDataQuery, Skill>, GetSkillDataHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteSkillDataCommand, bool>, DeleteSkillDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllThemeQuery, List<MissionTheme>>, GetAllThemeHandler>();
builder.Services.AddTransient<IRequestHandler<AddThemeDataCommand, MissionTheme>, AddThemeDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditThemeDataCommand, MissionTheme>, EditThemeDataHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteThemeDataCommand, bool>, DeleteThemeDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetThemeDataQuery, MissionTheme>, GetThemeDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllCMSQuery, List<Cmspage>>, GetAllCMSHandler>();
builder.Services.AddTransient<IRequestHandler<AddCMSDataCommand, Cmspage>, AddCMSDataHandler>();
builder.Services.AddTransient<IRequestHandler<EditCMSDataCommand, Cmspage>, EditCMSDataHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteCMSDataCommand, bool>, DeleteCMSDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetCMSDataQuery, Cmspage>, GetCMSDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetMissionDataQuery, Mission>, GetMissionDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllMissionQuery, List<Mission>>, GetAllMissionHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteMissionDataCommand, bool>, DeleteMissionDataHandler>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IBannerRepository,BannerRepository>();
builder.Services.AddScoped<IApplicationRepository,ApplicationRepository>();
builder.Services.AddScoped<IStoryRepository,StoryRepository>();
builder.Services.AddScoped<ISkillRepository,SkillRepository>();
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();
builder.Services.AddScoped<ICMSRepository,CMSRepository>();
builder.Services.AddScoped<IMissionRepository,MissionRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
