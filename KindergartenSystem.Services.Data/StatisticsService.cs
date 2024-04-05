using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Statistic;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data
{
    public class StatisticsService : IStatisticsService
    {
        private readonly KindergartenDbContext _dbContext;
        public StatisticsService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;  
        }
        public async Task<StatisticsServiceModel> Statistics()
        {
            var totalAgeGroups = await _dbContext.AgeGroups.CountAsync();
            var totalClassGroups = await _dbContext.ClassGroups.CountAsync();
            var totalChildren = await _dbContext.Children.Where(x => x.IsKindergartener).CountAsync();

            var model = new StatisticsServiceModel
            {
                TotalAgeGroups = totalAgeGroups,
                TotalClassGroups = totalClassGroups,
                TotalChildren = totalChildren
            };
           
            return model;
        }
    }
}
