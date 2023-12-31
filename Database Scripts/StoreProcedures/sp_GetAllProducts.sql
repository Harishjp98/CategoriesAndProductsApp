USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProducts]    Script Date: 28-11-2023 5.36.31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllProducts]
AS
BEGIN
    SELECT p.ID , p.Title ,p.Description,p.Price, c.ID as categoryId,c.Name
    FROM dbo.Products p 
	INNER JOIN dbo.Category C ON P.Category = C.Id
	ORDER BY c.DisplayOrder ASC
END
