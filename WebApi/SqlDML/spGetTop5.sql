USE [EAS]
GO
/****** Object:  StoredProcedure [dbo].[GetProductos]    Script Date: 7/04/2018 2:53:31 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
      
    Alter Procedure [dbo].[GetTopProductos]  
     
    As  
     Begin  
	 SELECT TOP 5  * FROM Productos ORDER BY NEWID()
	End  
