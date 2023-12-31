USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCategory]    Script Date: 28-11-2023 5.36.35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- Update Category
CREATE PROCEDURE [dbo].[sp_UpdateCategory]
    @CategoryId INT,
    @Name VARCHAR(100),
    @DisplayOrder INT

AS
BEGIN
DECLARE @RowCount INT =0
 BEGIN TRY 
  SET @RowCount = (SELECT COUNT(1) FROM dbo.Category WITH (NOLOCK) WHERE ID= @CategoryId)
  IF(@RowCount>0)
   BEGIN
    BEGIN TRAN
    UPDATE dbo.Category
    SET 
	    Name = @Name,
        DisplayOrder = @DisplayOrder,
		CreatedDateTime = GETDATE()
    WHERE ID = @CategoryId;
	COMMIT TRAN
    END
END TRY
BEGIN CATCH
 ROLLBACK TRAN
END CATCH
END
