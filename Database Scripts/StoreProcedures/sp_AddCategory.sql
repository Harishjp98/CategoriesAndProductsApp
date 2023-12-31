USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddCategory]    Script Date: 28-11-2023 5.36.25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddCategory]
    @Name VARCHAR(100),
    @DisplayOrder INT
	
AS
BEGIN

BEGIN TRY
BEGIN TRAN

    INSERT INTO dbo.Category (Name, DisplayOrder, CreatedDateTime)
    VALUES (
	@Name, 
	@DisplayOrder,
	GETDATE());
	COMMIT TRAN
	END TRY
BEGIN CATCH
 ROLLBACK TRAN
END CATCH
END
