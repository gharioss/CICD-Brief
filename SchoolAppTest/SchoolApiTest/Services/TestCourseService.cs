using Newtonsoft.Json;
using SchoolApiTest.Models;
using System.Net.Http.Json;
using System.Text;

namespace SchoolApiTest.Services
{
    public class TestCourseService
    {
        public async Task<List<Course>> GetAllCourseAsync(string url)
        {
            Uri uri = new(url);

            using (HttpClient httpclient = new HttpClient())
            {
                HttpResponseMessage response = await httpclient.GetAsync(uri);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new List<Course>();

                HttpContent responseContent = response.Content;
                List<Course> allCourses = await responseContent.ReadFromJsonAsync<List<Course>>();

                return allCourses;

            }
        }
        public async Task<System.Net.HttpStatusCode> PostCourseAsync(string url, string course)
        {
            var test = new Course
            {
                Name = course
            };

            var stringTest = JsonConvert.SerializeObject(test);

            StringContent content = new(stringTest, Encoding.UTF8, "application/json");

            Uri uri = new(url);

            using (HttpClient httpclient = new HttpClient())
            {
                var result = await httpclient.PostAsync(uri, content);

                return result.StatusCode;
            }
        }
    }
}
