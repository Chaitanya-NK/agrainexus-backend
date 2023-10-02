CREATE PROCEDURE GetUserByEmail
(
	@Email varchar(100)
)
AS
BEGIN
	SELECT * FROM Users WHERE Email = @Email
END
GO