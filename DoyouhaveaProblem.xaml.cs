using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autocare_WPF.data_access;
using Newtonsoft.Json;

namespace Autocare_WPF
{
    
    public partial class DoyouhaveaProblem : Window
    {
        private string currentUsername = string.Empty;
        private static readonly string apiKey = "your_api_key"; // cheie1
        public DoyouhaveaProblem(string username)
        {
            InitializeComponent();
            currentUsername = DataAccess.Instance.CurrentUsername;
            myheader.Username = currentUsername;
        }
        private async void AskAI_Click(object sender, RoutedEventArgs e) 
        {
            string userMessage = UserInput.Text;
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                MessageBox.Show("Please enter a question.");
                return;
            }

            AIResponse.Text = "Thinking..."; 
            string aiResponse = await GetAIResponse(userMessage);
            AIResponse.Text = aiResponse;
        }
        private async Task<string> GetAIResponse(string prompt)
        {
            int retryCount = 0;
            int maxRetries = 3;

            while (retryCount < maxRetries)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                        var requestBody = new
                        {
                            model = "gpt-4o",
                            messages = new[]
                            {
                        new { role = "system", content = "You are an assistant helping with car issues." },
                        new { role = "user", content = prompt }
                    }
                        };

                        string jsonRequest = JsonConvert.SerializeObject(requestBody);
                        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            dynamic responseObject = JsonConvert.DeserializeObject(jsonResponse);
                            return responseObject.choices[0].message.content.ToString();
                        }
                        else if ((int)response.StatusCode == 429) // Too Many Requests
                        {
                            retryCount++;
                            await Task.Delay(2000 * retryCount); // Exponential backoff
                        }
                        else
                        {
                            string errorMessage = await response.Content.ReadAsStringAsync();
                            return $"Error: {response.StatusCode} - {errorMessage}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }

            return "Error: Exceeded maximum retries. Please try again later.";
        }

    }
}
