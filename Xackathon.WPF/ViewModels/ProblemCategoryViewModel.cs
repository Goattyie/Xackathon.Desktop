using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using Xackathon.WPF.Models;

namespace Xackathon.WPF.ViewModels
{
    public class ProblemCategoryViewModel : BindableBase
    {
        private HttpClient _httpClient;
        JsonSerializerOptions _options;
        public ProblemCategoryViewModel()
        {
            _httpClient = new();
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            LoadCategories();
        }
        public ObservableCollection<ProblemCategory> Categories { get; set; }
        private void LoadCategories()
        {
            var response = _httpClient.GetAsync("http://localhost:5000/problem-categories").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var result = JsonSerializer.Deserialize<ProblemCategoryGetRequest>(data, _options);
                Categories = new(result.Data);
            }
        }
    }
}
