

namespace LegacyApp.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
        {
            var userService = new UserService();
            var result = userService.AddUser(
                null,
                "Kowalski",
                "kowalski@kowal.com",
                DateTime.Parse("2000-01-01"),
                1
            );
            Assert.False(result);
        }

        [Fact]
        public void AddUser_ReturnsFalseWhenEmailIsInvalid()
        {
            var userService = new UserService();
            var result = userService.AddUser(
                "Jan",
                "Kowalski",
                "invalidemail", 
                DateTime.Parse("2000-01-01"),
                1
            );
            Assert.False(result);
        }

        [Fact]
        public void AddUser_ReturnsFalseWhenUnderAge()
        {
            var userService = new UserService();
            var result = userService.AddUser(
                "Jan",
                "Kowalski",
                "kowalski@kowal.com",
                DateTime.Today.AddYears(-20), 
                1
            );
            Assert.False(result);
        }

        [Fact]
        public void AddUser_ReturnsTrueForVeryImportantClient()
        {
            var userService = new UserService();
            var result = userService.AddUser(
                "Jan",
                "Malewski",
                "malewski@gmail.pl",
                DateTime.Parse("1982-03-21"),
                2 
            );
            Assert.True(result);
        }

        [Fact]
        public void AddUser_ReturnsTrueForImportantClientWithSufficientCreditLimit()
        {
            var userService = new UserService();
            var result = userService.AddUser(
                "Jan",
                "Smith",
                "smith@gmail.pl",
                DateTime.Parse("1982-03-21"),
                3 
            );
            Assert.True(result);
        }

        [Fact]
        public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
        {
            var userService = new UserService();
            Action action = () => userService.AddUser(
                "Jan",
                "Kowalski",
                "kowalski@kowal.com",
                DateTime.Parse("2000-01-01"),
                100 
            );
            Assert.Throws<ArgumentException>(action);
        }
    }
}
