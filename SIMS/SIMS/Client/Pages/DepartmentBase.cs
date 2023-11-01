using Microsoft.AspNetCore.Components;
using SIMS.Client.Services;
using SIMS.Client.Services.Contracts;
using SIMS.Shared;

namespace SIMS.Client.Pages
{
    public class DepartmentBase:ComponentBase
    {
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public IEnumerable<Department>? Departments { get; set; }
        public Department TDept { get; set; }=new Department();

        public Department? Dept { get; set; }
        public bool IsDepart { get; set; }

        [Parameter]
        public int Id {  get; set; }


        protected override async Task OnInitializedAsync() => Departments = await DepartmentService.GetDepartments();
        public async Task SubmitForm() => await DepartmentService.Create_Department(TDept);
        public async Task EditForm()
        {
            
            await DepartmentService.EditDept(Dept);
        }
        public async Task GetData(Department hero)
        {
            IsDepart = true;
            Dept=hero;
        }
    }
}
