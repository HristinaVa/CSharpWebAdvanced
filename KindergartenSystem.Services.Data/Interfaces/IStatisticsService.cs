using KindergartenSystem.Services.Data.Models.Statistic;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IStatisticsService
    {
        Task<StatisticsServiceModel> Statistics();
    }
}
