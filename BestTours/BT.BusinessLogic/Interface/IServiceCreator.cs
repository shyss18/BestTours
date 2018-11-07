namespace BT.BusinessLogic.Interface
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
