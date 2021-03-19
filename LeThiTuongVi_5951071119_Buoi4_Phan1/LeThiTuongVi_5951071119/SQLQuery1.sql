CREATE PROC Sp_Employee
@Sr_no int, @Emp_name nvarchar(500),
@City nvarchar(500), @STATE nvarchar(500),
@Country nvarchar(500), @Department nvarchar(500),
@flag nvarchar(50)
AS BEGIN
	IF(@flag = 'insert')
	BEGIN
		INSERT INTO tbl_Employee
		(Emp_name, City, STATE, Country, Department)
		VALUES
		(@Emp_name, @City, @STATE, @Country, @Department)
	END

	ELSE IF(@flag = 'UPDATE')
	BEGIN
		UPDATE tbl_Employee SET
		Emp_name = @Emp_name, City = @City, STATE = @STATE,
		Country = @Country, Department = @Department
		WHERE Sr_no = @Sr_no
	END

	ELSE IF(@flag = 'DELETE')
	BEGIN
		DELETE FROM tbl_Employee
		WHERE Sr_no = @Sr_no
	END

	ELSE IF(@flag = 'GETID')
	BEGIN
		SELECT * FROM tbl_Employee
		WHERE Sr_no = @Sr_no
	END

	ELSE IF(@flag = 'GET')
	BEGIN
		SELECT * FROM tbl_Employee
	END
END