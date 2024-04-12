namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string?> UserNameAsync(string email); 
        

        
    }
}
