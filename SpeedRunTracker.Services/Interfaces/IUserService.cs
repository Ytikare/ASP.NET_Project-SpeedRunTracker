namespace SpeedRunTracker.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CheckIfUsernameExits(string username);

        public Task<bool> CheckIfEmailExits(string email);
    }
}
