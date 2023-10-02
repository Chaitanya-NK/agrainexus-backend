CREATE PROCEDURE UpdateUser
(
	@Id integer,
	@UserName varchar(100),
	@Email varchar(100),
	@Password varchar(100)
)

AS
BEGIN
	UPDATE dbo.Users
	SET
		UserName = @UserName,
		Email = @Email,
		Password = @Password,
	WHERE
		Id = @Id
END
GO