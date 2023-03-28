CREATE PROCEDURE spAddingNewDataToDB
(
    @EmployeeName VARCHAR (50),
    @PhoneNumber  VARCHAR (50),
    @Address   VARCHAR (50),
    @Department   VARCHAR (50),
    @Gender    CHAR (1),
    @BasicPay     FLOAT (53),
    @Deduction    FLOAT (53),
    @TaxablePay   FLOAT (53),
    @Tax         FLOAT (53),
    @NetPay       FLOAT (53),
    @StartDate    VARCHAR(20),
    @City         VARCHAR (30),
    @Country VARCHAR (30)
)

AS BEGIN
INSERT INTO employee_payrollServiceDB (EmployeeName, PhoneNumber, Address, Department, Gender, BasicPay, Deduction, TaxablePay, Tax, NetPay, StartDate, City, Country )
VALUES(@EmployeeName, @PhoneNumber, @Address, @Department, @Gender, @BasicPay, @Deduction, @TaxablePay, @Tax, @NetPay, @StartDate, @City, @Country)
END