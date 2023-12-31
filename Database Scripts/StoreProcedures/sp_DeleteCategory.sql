USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCategory]    Script Date: 28-11-2023 5.36.27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete Category
CREATE PROCEDURE [dbo].[sp_DeleteCategory]
    @CategoryId INT
AS
BEGIN
DECLARE @RowCount INT =0
 BEGIN TRY 
  SET @RowCount = (SELECT COUNT(1) FROM dbo.Category WITH (NOLOCK) WHERE ID= @CategoryId)
  IF(@RowCount>0)
   BEGIN
    BEGIN TRAN
        DELETE FROM dbo.Category
    WHERE ID = @CategoryId;
	COMMIT TRAN
    END
END TRY
BEGIN CATCH
 ROLLBACK TRAN
END CATCH
END
