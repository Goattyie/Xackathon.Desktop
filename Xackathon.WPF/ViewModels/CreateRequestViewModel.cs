using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xackathon.WPF.Models;

namespace Xackathon.WPF.ViewModels
{
    public class CreateRequestViewModel : BindableBase
    {
        private string _phone;
        private HttpClient _httpClient;
        JsonSerializerOptions _options;
        public CreateRequestViewModel()
        {
            _httpClient = new();
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Phone = "+38071";
            LoadCategories();
        }
        public string Name { get; set; }
        public string Phone { get => _phone; set { if (value.Length >= 6 && value.Length <= 13) _phone = value; } }
        public string Address { get; set; }
        public string Description { get; set; }
        public ProblemCategory SelectedCategory { get; set; }
        public ObservableCollection<ProblemCategory> Categories { get; set; }
        public string Email { get; set; }

        public ICommand SendRequest => new AsyncCommand(async() => 
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/requests");
            request.Content = JsonContent.Create(new { Fio = Name, Phone = Phone, Source="telegram", 
                Content = Array.Empty<string>(), ProblemCategories = new int[] { SelectedCategory?.Id ?? 0 }, 
                Description = Description, Email = Email});

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                ClearData();
            }
            else MessageBox.Show("Не все данные заполнены верно.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        });
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
        private void ClearData()
        {
            Name = string.Empty;
            Address = string.Empty;
            Description = string.Empty;
            Email = string.Empty;
            SelectedCategory = null;
            Phone = "+38071";
        }
    }
}
