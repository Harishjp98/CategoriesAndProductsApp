USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddProduct]    Script Date: 28-11-2023 5.36.26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddProduct]
    
    @Title VARCHAR(100),
	@Description VARCHAR(MAX),
    @Price FLOAT,
    @Category INT
AS
BEGIN

BEGIN TRY
BEGIN TRAN

    INSERT INTO dbo.Products(Title, Description, Price,Category)
    VALUES (
	 @Title,
	@Description,
    @Price,
    @Category);
	COMMIT TRAN
	END TRY
BEGIN CATCH
 ROLLBACK TRAN
END CATCH
END
