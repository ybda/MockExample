namespace MockExample;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string? GetUserName(int userId)
    {
        var user = _userRepository.GetUserById(userId);
        return user?.Name;
    }
}