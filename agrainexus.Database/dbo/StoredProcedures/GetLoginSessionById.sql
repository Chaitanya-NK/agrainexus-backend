CREATE PROCEDURE GetLoginSessionById
    @Id INT
AS
BEGIN
    SELECT * FROM LoginSessions WHERE Id = @Id
END