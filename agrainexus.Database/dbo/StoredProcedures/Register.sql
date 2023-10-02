CREATE PROCEDURE Register
(
	@UserName varchar(100),
	@Email varchar(100),
	@Password varchar(100)
)
	
AS
BEGIN
	INSERT INTO dbo.Users (UserName, Email, Password)
	VALUES (@UserName, @Email, @Password)
END
GO