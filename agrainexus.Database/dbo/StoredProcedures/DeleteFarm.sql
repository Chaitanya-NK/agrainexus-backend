﻿CREATE PROCEDURE DeleteFarm
(
	@Id INT
)
AS
BEGIN
	DELETE FROM Farms
	WHERE Id = @Id
END
GO