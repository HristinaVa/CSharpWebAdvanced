using AutoMapper;

namespace KindergartenService.Services.Mapping
{

    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}

