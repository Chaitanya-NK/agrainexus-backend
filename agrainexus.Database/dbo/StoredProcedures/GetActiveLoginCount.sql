﻿CREATE PROCEDURE GetActiveLoginCount
AS
BEGIN
    SELECT COUNT(*) FROM LoginSessions WHERE LogoutTime IS NULL
END