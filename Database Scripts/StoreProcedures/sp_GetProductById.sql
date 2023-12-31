USE [ProductCategoryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductById]    Script Date: 28-11-2023 5.36.34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Get Category by ID
CREATE PROCEDURE [dbo].[sp_GetProductById]
    @ProductId INT
AS
BEGIN
    SELECT p.ID , p.Title ,p.Description,p.Price, c.ID as categoryId,c.Name
    FROM dbo.Products p 
	INNER JOIN dbo.Category c on p.Category = c.ID
    WHERE p.ID = @ProductId;
END
