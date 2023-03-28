CREATE PROCEDURE spUpdateDataOfDataBase
(
@EmployeeName VARCHAR(50),
@Department VARCHAR(50)
)
AS BEGIN
UPDATE employee_payrollServiceDB SET Department = @Department  WHERE EmployeeName = @EmployeeName
END