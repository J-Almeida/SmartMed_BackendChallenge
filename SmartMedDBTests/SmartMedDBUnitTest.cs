using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartMedDBTests
{
    public class SmartMedDBUnitTest
    {
        private const string ApiBaseUrl = "https://localhost:5001/api";

        [Fact]
        public async Task GetMedications()
        {
            var apiClient = new HttpClient();
            var apiResponse = await apiClient.GetAsync($"{ApiBaseUrl}/medications");

            Assert.True(apiResponse.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TryNegativeQuantity()
        {
            var apiClient = new HttpClient();
            var invalidMedication = "{\"Name\": \"Test 3\",\"Quantity\": -12345}";
            var postContent = new StringContent(invalidMedication, Encoding.Unicode, "application/json");
            var apiResponse = await apiClient.PostAsync($"{ApiBaseUrl}/medications", postContent);

            Assert.True(apiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest);

            var responseString = apiResponse.Content.ReadAsStringAsync().Result;

            Assert.Contains("The field Quantity must be between 1 and ∞.", responseString);
        }

    }

}

