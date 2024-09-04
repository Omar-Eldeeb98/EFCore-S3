using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC_Session3.Migrations
{
    /// <inheritdoc />
    public partial class AddView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create View EmployessWorkForDepartments
                                 as
                                    select E.Id as EmpId  , E.Employeename , D.Id as DeptId , D.DepartmentName
                                    from Employees E , Departments D
                                    where E.Dept_Id = D.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop View EmployessWorkForDepartments");
        }
    }
}