CREATE PROCEDURE spGetSelectedDataFromDataBase
(
@EmployeeName VARCHAR(50)
)
AS BEGIN
SELECT * FROM employee_payrollServiceDB WHERE EmployeeName = @EmployeeName
END