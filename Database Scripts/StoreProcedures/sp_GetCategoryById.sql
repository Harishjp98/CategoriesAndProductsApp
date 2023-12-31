USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategoryById]    Script Date: 28-11-2023 5.36.33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Get Category by ID
CREATE PROCEDURE [dbo].[sp_GetCategoryById]
    @CategoryId INT
AS
BEGIN
    SELECT ID ,Name, DisplayOrder,CreatedDateTime
    FROM dbo.Category WITH (NOLOCK)
    WHERE ID = @CategoryId;
END
