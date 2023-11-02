using Microsoft.AspNetCore.Components;
using SIMS.Client.Services;
using SIMS.Client.Services.Contracts;
using SIMS.Shared;
using Blazorise;

namespace SIMS.Client.Pages
{
    public class DepartmentBase:ComponentBase
    {
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public IEnumerable<Department>? Departments { get; set; }
        public Department Temp_Dept { get; set; }=new Department();


        [Parameter]
        public int? Id {  get; set; }


        protected override async Task OnInitializedAsync() => Departments = await DepartmentService.GetDepartments();
        protected async Task SubmitForm()
        {
            if (Id == 0)
            {
                await DepartmentService.Create_Department(Temp_Dept);
            }
            else
            {
                await DepartmentService.EditDept(Temp_Dept);
            }           
        }
        protected  void GetDept(Department department)
        {
           Temp_Dept = department;
            ShowModal();
        }
        protected async Task DeleteDept(int id) =>await DepartmentService.Delete_Department(id);

        //Functions for Modal Blazorise Start
        protected Modal modalRef;
        protected Task ShowModal()
        {
            return modalRef.Show();
        }

        protected Task HideModal()
        {
            return modalRef.Hide();
        }
        //Functions for Modal Blazorise End
    }
}
