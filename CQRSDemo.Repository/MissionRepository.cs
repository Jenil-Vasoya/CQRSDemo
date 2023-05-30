using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository
{
    public class MissionRepository : IMissionRepository
    {

        private readonly CIPlatformContext _CIPlatformContext;

        public MissionRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<Mission>> GetAllMission()
        {
            return await _CIPlatformContext.Missions.ToListAsync();
        }

        public async Task<Mission> GetMissionData(long MissionId)
        {
            return await _CIPlatformContext.Missions.FirstAsync(m => m.MissionId == MissionId);
             
        }

        public async Task<bool> DeleteMissionData(long MissionId)
        {
            var mission = _CIPlatformContext.Missions.Where(u => u.MissionId == MissionId).FirstOrDefault();
            if (mission != null)
            {
                mission.DeletedAt = DateTime.Now;
                 _CIPlatformContext.Missions.Update(mission);
                await _CIPlatformContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<MissionAddModel> AddMissionData(MissionAddModel model)
        {
            if (model.MissionId == 0 || model.MissionId == null)
            {

                Mission mission = new Mission();
                {
                    mission.CityId = model.CityId;
                    mission.CountryId = model.CountryId;
                    mission.MissionThemeId = model.MissionThemeId;
                    mission.Title = model.Title;
                    mission.Status = model.Status;
                    mission.Deadline = model.Deadline;
                    mission.Description = model.Description;
                    mission.StartDate = model.StartDate;
                    mission.EndDate = model.EndDate;
                    mission.MissionType = model.MissionType;
                    mission.OrganizationName = model.OrganizationName;
                    mission.OrganizationDetail = model.OrganizationDetail;
                    mission.ShortDescription = model.ShortDescription;
                    mission.TotalSeats = model.TotalSeats;
                    mission.Availibility = model.Availibility;

                    _CIPlatformContext.Missions.Add(mission);
                   await _CIPlatformContext.SaveChangesAsync();
                }

                Notification notification = new Notification();
                {
                    notification.Text = "New Mission : " + mission.Title;
                    notification.Status = "Unseen";
                    _CIPlatformContext.Notifications.Add(notification);
                    await _CIPlatformContext.SaveChangesAsync();
                }
                if (model.MissionSkill != null)
                {
                    foreach (var skillId in model.MissionSkill)
                    {
                        MissionSkill skill = new MissionSkill();
                        {
                            skill.SkillId = skillId;
                            skill.MissionId = mission.MissionId;

                            _CIPlatformContext.MissionSkills.Add(skill);
                            await _CIPlatformContext.SaveChangesAsync();
                        }
                    }
                }

                if (model.GoalText != null && model.GoalValue != 0)
                {
                    GoalMission goalMission = new GoalMission();
                    goalMission.MissionId = mission.MissionId;
                    goalMission.GoalObjectiveText = model.GoalText;
                    goalMission.GoalValue = model.GoalValue;

                    _CIPlatformContext.GoalMissions.Add(goalMission);
                    await _CIPlatformContext.SaveChangesAsync();
                }

                if (model.MissionImages.Count != 0)
                {
                    List<MissionMedium> missionMedia = _CIPlatformContext.MissionMedia.Where(a => a.MissionId == mission.MissionId).ToList();
                    foreach (var missionMediaItem in missionMedia)
                    {
                        _CIPlatformContext.MissionMedia.Remove(missionMediaItem);
                        await _CIPlatformContext.SaveChangesAsync();
                    }




                    var filePath = new List<string>();
                    foreach (var i in model.MissionImages)
                    {
                        MissionMedium missionMedium = new MissionMedium();
                        missionMedium.MissionId = mission.MissionId;
                        missionMedium.MediaName = i.FileName;
                        missionMedium.MediaType = "png";
                        missionMedium.MediaPath = "Images/" + i.FileName;
                        _CIPlatformContext.MissionMedia.Add(missionMedium);
                        await _CIPlatformContext.SaveChangesAsync();
                        if (i.Length > 0)
                        {
                            //string path = Server.MapPath("~/wwwroot/Assets/Story");
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", i.FileName);
                            filePath.Add(path);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                i.CopyTo(stream);
                            }
                        }

                    }

                    if (model.Documents != null)
                    {
                        var docPath = new List<string>();
                        foreach (var i in model.Documents)
                        {
                            MissionDocument missionDocument = new MissionDocument();
                            missionDocument.MissionId = mission.MissionId;
                            missionDocument.DocumentName = i.FileName;
                            missionDocument.DocumentType = "pdf";
                            missionDocument.DocumentPath = "Documents/" + i.FileName;
                            _CIPlatformContext.MissionDocuments.Add(missionDocument);
                            await _CIPlatformContext.SaveChangesAsync();
                            if (i.Length > 0)
                            {
                                //string path = Server.MapPath("~/wwwroot/Assets/Story");
                                var path = Path.Combine(Directory.GetCurrentDirectory(), "Documents", i.FileName);
                                docPath.Add(path);
                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    i.CopyTo(stream);
                                }
                            }

                        }
                    }

                }
                if (model.VideoUrl != null)
                {

                    MissionMedium medium = new MissionMedium();
                    medium.MissionId = mission.MissionId;
                    medium.MediaName = model.VideoUrl;
                    medium.MediaType = "mp4";
                    medium.MediaPath = model.VideoUrl;
                    _CIPlatformContext.MissionMedia.Add(medium);
                    await _CIPlatformContext.SaveChangesAsync();
                }

                return model;
            }
            else
            {
                var mission = _CIPlatformContext.Missions.Find(model.MissionId);
                var goalMission = _CIPlatformContext.GoalMissions.Where(g => g.MissionId == model.MissionId).FirstOrDefault();
                if (mission != null)
                {

                    mission.Title = model.Title;
                    mission.Description = model.Description;
                    mission.Status = model.Status;
                    mission.CityId = model.CityId;
                    mission.CountryId = model.CountryId;
                    mission.EndDate = model.EndDate;
                    mission.Deadline = model.Deadline;
                    mission.StartDate = model.StartDate;
                    mission.MissionType = model.MissionType;
                    mission.MissionThemeId = model.MissionThemeId;
                    mission.OrganizationName = model.OrganizationName;
                    mission.OrganizationDetail = model.OrganizationDetail;
                    mission.ShortDescription = model.ShortDescription;
                    mission.TotalSeats = model.TotalSeats;
                    mission.UpdatedAt = DateTime.Now;

                    _CIPlatformContext.Missions.Update(mission);
                    await _CIPlatformContext.SaveChangesAsync();


                    if (model.MissionType == "Goal")
                    {
                        if (goalMission != null)
                        {

                            goalMission.MissionId = mission.MissionId;
                            goalMission.GoalObjectiveText = model.GoalText;
                            goalMission.GoalValue = model.GoalValue;

                            _CIPlatformContext.GoalMissions.Update(goalMission);
                            _CIPlatformContext.SaveChanges();
                        }
                        else
                        {
                            GoalMission goalMission1 = new GoalMission();
                            goalMission1.MissionId = mission.MissionId;
                            goalMission1.GoalObjectiveText = model.GoalText;
                            goalMission1.GoalValue = model.GoalValue;

                            _CIPlatformContext.GoalMissions.Add(goalMission1);
                            await _CIPlatformContext.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        if (goalMission != null)
                        {
                            _CIPlatformContext.GoalMissions.Remove(goalMission);
                            await _CIPlatformContext.SaveChangesAsync();
                        }
                    }
                    

                    if (model.MissionSkill?.Count != 0)
                    {

                        List<MissionSkill> missionSkills = _CIPlatformContext.MissionSkills.Where(a => a.MissionId == mission.MissionId).ToList();
                        foreach (var missionSkillItem in missionSkills)
                        {
                            _CIPlatformContext.MissionSkills.Remove(missionSkillItem);
                            await _CIPlatformContext.SaveChangesAsync();
                        }


                        foreach (var skillId in model.MissionSkill)
                        {
                            MissionSkill skill = new MissionSkill();
                            {
                                skill.SkillId = skillId;
                                skill.MissionId = mission.MissionId;

                                _CIPlatformContext.MissionSkills.Add(skill);
                                await _CIPlatformContext.SaveChangesAsync();
                            }
                        }
                    }

                    if (model.MissionImages != null)
                    {
                        List<MissionMedium> missionMedia = _CIPlatformContext.MissionMedia.Where(a => a.MissionId == mission.MissionId && a.MediaType == "png").ToList();
                        foreach (var missionMediaItem in missionMedia)
                        {
                            _CIPlatformContext.MissionMedia.Remove(missionMediaItem);
                            await _CIPlatformContext.SaveChangesAsync();
                        }




                        var filePath = new List<string>();
                        foreach (var i in model.MissionImages)
                        {
                            MissionMedium missionMedium = new MissionMedium();
                            missionMedium.MissionId = mission.MissionId;
                            missionMedium.MediaName = i.FileName;
                            missionMedium.MediaType = "png";
                            missionMedium.MediaPath = "~/Assets/StoryImages/" + i.FileName;
                            _CIPlatformContext.MissionMedia.Add(missionMedium);
                            await _CIPlatformContext.SaveChangesAsync();
                            if (i.Length > 0)
                            {
                                //string path = Server.MapPath("~/wwwroot/Assets/Story");
                                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", i.FileName);
                                filePath.Add(path);
                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    i.CopyTo(stream);
                                }
                            }

                        }

                    }
                    if (model.Documents != null)
                    {
                        List<MissionDocument> missionDocuments = _CIPlatformContext.MissionDocuments.Where(a => a.MissionId == mission.MissionId).ToList();
                        foreach (var document in missionDocuments)
                        {
                            _CIPlatformContext.MissionDocuments.Remove(document);
                            await _CIPlatformContext.SaveChangesAsync();
                        }


                        var docPath = new List<string>();
                        foreach (var i in model.Documents)
                        {
                            MissionDocument missionDocument = new MissionDocument();
                            missionDocument.MissionId = mission.MissionId;
                            missionDocument.DocumentName = i.FileName;
                            missionDocument.DocumentType = "pdf";
                            missionDocument.DocumentPath = "~/Assets/Document/" + i.FileName;
                            _CIPlatformContext.MissionDocuments.Add(missionDocument);
                            await _CIPlatformContext.SaveChangesAsync();
                            if (i.Length > 0)
                            {
                                //string path = Server.MapPath("~/wwwroot/Assets/Story");
                                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Document", i.FileName);
                                docPath.Add(path);
                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    i.CopyTo(stream);
                                }
                            }

                        }
                    }
                    if (model.VideoUrl != null)
                    {
                        List<MissionMedium> missionMedia = _CIPlatformContext.MissionMedia.Where(a => a.MissionId == mission.MissionId && a.MediaType == "mp4").ToList();
                        foreach (var missionMediaItem in missionMedia)
                        {
                            _CIPlatformContext.MissionMedia.Remove(missionMediaItem);
                            await _CIPlatformContext.SaveChangesAsync();
                        }

                        MissionMedium medium = new MissionMedium();
                        medium.MissionId = mission.MissionId;
                        medium.MediaName = model.VideoUrl;
                        medium.MediaType = "mp4";
                        medium.MediaPath = model.VideoUrl;
                        _CIPlatformContext.MissionMedia.Add(medium);
                        await _CIPlatformContext.SaveChangesAsync();
                    }

                    return model;
                }
                else
                {
                    return model;
                }
            }
        }

        public async Task<List<Mission>?> SearchMission(string? search, int page, int pageSize)
        {
            List<Mission> missions = await _CIPlatformContext.Missions.ToListAsync();
            int count = 0;
            if (search != null)
            {
                missions = missions.Where(b => b.Title.Contains(search)).ToList();
                count++;
            }
            if (page != 0 && pageSize != 0)
            {
                missions = missions.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                count++;
            }
            if (count > 0)
            {
                return missions;
            }
            return null;
        }
    }
}
