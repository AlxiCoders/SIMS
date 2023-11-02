using Microsoft.AspNetCore.Components;
using SIMS.Client.Services.Contracts;
using SIMS.Shared;
using System.Net.Http.Json;

namespace SIMS.Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;
        private readonly NavigationManager navigationManager;

        public DepartmentService(HttpClient httpClient, NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
        }
        public async Task Create_Department(Department dept)
        {
            
                await this.httpClient.PostAsJsonAsync($"api/Department",dept);            
                navigationManager.NavigateTo("/department",true);
        }

        public async Task Delete_Department(int id)
        {
            await this.httpClient.DeleteAsync($"api/department/{id}");
            navigationManager.NavigateTo("/department", true);

        }

        public async Task EditDept(Department department)
        {
            await this.httpClient.PutAsJsonAsync($"api/department",department);
            navigationManager.NavigateTo("/department",true);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Department");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Department>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<Department>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
