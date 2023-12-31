USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateProduct]    Script Date: 28-11-2023 5.36.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- Update Category
CREATE PROCEDURE [dbo].[sp_UpdateProduct]
    @ProductId INT,
    @Title VARCHAR(100),
	@Description VARCHAR(MAX),
    @Price FLOAT,
    @Category INT
AS
BEGIN
DECLARE @RowCount INT =0
 BEGIN TRY 
  SET @RowCount = (SELECT COUNT(1) FROM dbo.Products WITH (NOLOCK) WHERE ID= @ProductId)
  IF(@RowCount>0)
   BEGIN
    BEGIN TRAN
    UPDATE dbo.Products
    SET 
    Title= @Title,
	Description= @Description,
    Price=@Price,
    Category= @Category
    WHERE ID = @ProductId;
	COMMIT TRAN
    END
END TRY
BEGIN CATCH
 ROLLBACK TRAN
END CATCH
END
