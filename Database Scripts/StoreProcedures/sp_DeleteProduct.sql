USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProduct]    Script Date: 28-11-2023 5.36.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete Category
CREATE PROCEDURE [dbo].[sp_DeleteProduct]
    @ProductId INT
AS
BEGIN
DECLARE @RowCount INT =0
 BEGIN TRY 
  SET @RowCount = (SELECT COUNT(1) FROM dbo.Products WITH (NOLOCK) WHERE ID= @ProductId)
  IF(@RowCount>0)
   BEGIN
    BEGIN TRAN
        DELETE FROM dbo.Products
    WHERE ID = @ProductId;
	COMMIT TRAN
    END
END TRY
BEGIN CATCH
 ROLLBACK TRAN
END CATCH
END
