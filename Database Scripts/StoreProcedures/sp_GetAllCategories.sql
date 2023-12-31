USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCategories]    Script Date: 28-11-2023 5.36.30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Get All Categories
CREATE PROCEDURE [dbo].[sp_GetAllCategories]
AS
BEGIN
    SELECT ID, Name, DisplayOrder,CreatedDateTime
    FROM dbo.Category WITH (NOLOCK)
	Order By DisplayOrder ASC;
END
