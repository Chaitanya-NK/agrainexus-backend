﻿CREATE PROCEDURE GetUserById
(
	@Id integer
)
AS
BEGIN
	SELECT * FROM Users WHERE Id = @Id
END
GO