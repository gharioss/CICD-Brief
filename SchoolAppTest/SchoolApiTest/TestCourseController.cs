using SchoolApiTest.Models;
using SchoolApiTest.Services;
using System.Net;

namespace SchoolApiTest
{
    public class TestCourseController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsCountOfCourses()
        {
            // Arrange
            string url = "https://localhost:7243/api/Course";
            TestCourseService sut = new();

            // Act
            List<Course> result = await sut.GetAllCourseAsync(url);

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Theory]
        [InlineData("PhP")]
        [InlineData("HTML")]
        [InlineData("CSS")]
        [InlineData("C++")]
        [InlineData("C")]
        [InlineData("NodeJS")]
        public async Task Post_InvalidObjectPassed_Returns201Created(string course)
        {
            // Arrange
            string url = "https://localhost:7243/api/Course";
            TestCourseService sut = new();

            // Act
            HttpStatusCode result = await sut.PostCourseAsync(url, course);

            // Assert
            Assert.Equal("Created", result.ToString());
        }

        [Fact]
        public async Task Post_ReturnsIDK()
        {
            
        }
    }
}