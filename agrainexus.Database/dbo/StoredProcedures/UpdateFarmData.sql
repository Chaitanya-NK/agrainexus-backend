CREATE PROCEDURE UpdateFarmData
(
	@Id INT,
	@NickName VARCHAR(20),
    @Location VARCHAR(100),
    @Crops NVARCHAR(max),
    @Area VARCHAR(100),
	@AreaUnits VARCHAR(25)
)
AS
BEGIN
	UPDATE Farms
	SET 
		NickName = @NickName,
		Location = @Location,
		Crops = @Crops,
		Area = @Area,
		AreaUnits = @AreaUnits
	WHERE
		Id = @Id
END
GO