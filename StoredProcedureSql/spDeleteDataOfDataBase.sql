CREATE PROCEDURE spDeleteDataOfDataBase
(
@EmployeeName VARCHAR(50)
)
AS BEGIN
DELETE FROM employee_payrollServiceDB WHERE EmployeeName = @EmployeeName
END