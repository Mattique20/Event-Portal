using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using Project.Database_Handler;

namespace SE
{
    public partial class CustomerSupport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public class ChatGPT : System.Web.Services.WebService
    {
        [WebMethod]
        public async Task<string> Chat(string message)
        {
            try
            {
                // Call the ChatGPT API to get the response
                var response = await GetChatGPTResponse(message);
                return response;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        private async Task<string> GetChatGPTResponse(string userInput)
        {
            // Replace 'YOUR_CHATGPT_API_KEY' with your actual ChatGPT API key
            string apiKey = "YOUR_CHATGPT_API_KEY";
            string endpoint = "https://api.openai.com/v1/chat/completions";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { prompt = userInput }), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                    return data.choices[0].text;
                }
                else
                {
                    throw new Exception("Failed to get response from ChatGPT API");
                }
            }
        }
    }
}
