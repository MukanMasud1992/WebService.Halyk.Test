USE [TEST]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRates]    Script Date: 23.02.2023 23:18:29 ******/

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetRates] 
	-- Add the parameters for the stored procedure here
	@A_DATE date,
	@CODE varchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET ANSI_NULLS ON
	SET NOCOUNT ON;
	IF @CODE IS NULL  
BEGIN  
   SELECT Id,A_DATE, CODE, TITLE, VALUE
	FROM R_CURRENCY 
	WHERE A_DATE = @A_DATE
END  
    -- Insert statements for procedure here
	SELECT Id,A_DATE, CODE, TITLE, VALUE
	FROM R_CURRENCY 
	WHERE A_DATE = @A_DATE AND CODE = @CODE
END

EXEC sp_GetRates @A_DATE = '2019-09-15', @CODE=null