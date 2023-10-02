CREATE PROCEDURE Login
(
	@UserName varchar(100),
	@Password varchar(100)
)
AS
BEGIN
	SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password
END
GO