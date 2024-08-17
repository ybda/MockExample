namespace MockExample.Tests;

public class UserServiceTests
{
    [Fact]
    public void GetUserName_ShouldReturnUserName()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        var user = new User { Id = 1, Name = "John Doe" };
        mockUserRepository.Setup(repo => repo.GetUserById(1)).Returns(user);
        
        var userService = new UserService(mockUserRepository.Object);
        
        // Act
        var result = userService.GetUserName(1);

        // Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void GetUserName_ShouldReturnNullIfUserNotFound()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((User)null);
        
        var userService = new UserService(mockUserRepository.Object);
        
        // Act
        var result = userService.GetUserName(99);

        // Assert
        Assert.Null(result);
    }
}