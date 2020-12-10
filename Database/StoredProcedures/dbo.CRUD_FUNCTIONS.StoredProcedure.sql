IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CRUD_FUNCTIONS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CRUD_FUNCTIONS]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[CRUD_FUNCTIONS]
	@AccountNumber NVARCHAR(200)
	,@AccountHolder NVARCHAR(200) 
	,@CurrentBalance  NVARCHAR(200)
	,@BankName NVARCHAR(200)
	,@OpeningDate DATETIME 
	,@IsActive NVARCHAR(50) 
	,@Function NVARCHAR(200)
AS
BEGIN

	DECLARE @EXIST NVARCHAR(15) = NULL
IF (@Function = 'INSERT')
BEGIN
	SET  @EXIST = (SELECT AccountNumber FROM Account Where AccountNumber = @AccountNumber)

	IF(@EXIST IS NULL)
	BEGIN
		INSERT INTO Account (AccountNumber,AccountHolder,CurrentBalance,BankName,OpeningDate,IsActive)
		VALUES (@AccountNumber,@AccountHolder,@CurrentBalance,@BankName,@OpeningDate, @IsActive)
	END
	ELSE
	BEGIN	
		SELECT 'ACCT_NO_EXIST'
	END
END
IF (@Function = 'UPDATE')
BEGIN
	UPDATE Account
		SET AccountHolder = @AccountHolder
		,CurrentBalance = @CurrentBalance
		,BankName = @BankName
		,OpeningDate = @OpeningDate
		,IsActive = @IsActive
	WHERE Account.AccountNumber = @AccountNumber
END
IF (@Function = 'DELETE')
BEGIN
	DELETE FROM Account
	WHERE Account.AccountNumber = @AccountNumber
END
IF (@Function = 'SELECT')
BEGIN
	SELECT 
	AccountNumber
	,AccountHolder
	,CAST(CurrentBalance AS NUMERIC(25,2)) AS CurrentBalance
	,BankName
	,CAST (OpeningDate AS DATE) AS OpeningDate
	,IsActive
	FROM Account
END
IF (@Function = 'SELECTBYID')
BEGIN
	SELECT
	AccountNumber
	,AccountHolder
	,CAST(CurrentBalance AS NUMERIC(25,2)) AS CurrentBalance
	,BankName
	,CAST (OpeningDate AS DATE) AS OpeningDate
	,IsActive
	FROM Account
	WHERE AccountNumber = @AccountNumber
END
END
GO