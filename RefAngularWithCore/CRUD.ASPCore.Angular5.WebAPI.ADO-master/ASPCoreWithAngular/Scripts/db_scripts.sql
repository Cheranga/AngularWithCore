Create table tblEmployee(      
    Id int IDENTITY(1,1) NOT NULL,      
    Name varchar(20) NOT NULL,      
    City varchar(20) NOT NULL,      
    Department varchar(20) NOT NULL,      
    Gender varchar(6) NOT NULL      
)
-----------------------

USE [EmployeeDbDev]
GO
/****** Object:  StoredProcedure [dbo].[spAddEmployee]    Script Date: 12/05/2018 10:19:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spAddEmployee]         
(        
    @Name VARCHAR(20),         
    @City VARCHAR(20),        
    @Department VARCHAR(20),        
    @Gender VARCHAR(6)        
)        
as         
Begin         
    Insert into tblEmployee (Name,City,Department, Gender)         
    Values (@Name,@City,@Department, @Gender)         
END

------------------------

USE [EmployeeDbDev]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEmployee]    Script Date: 12/05/2018 10:19:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spDeleteEmployee]       
(        
   @Id int        
)        
as         
begin        
   Delete from tblEmployee where Id=@Id        
End
----------------------

USE [EmployeeDbDev]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEmployees]    Script Date: 12/05/2018 10:20:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spGetAllEmployees]      
as      
Begin      
    select *      
    from tblEmployee   
    order by Id      
End

------------------

USE [EmployeeDbDev]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEmployee]    Script Date: 12/05/2018 10:20:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spUpdateEmployee]        
(        
   @Id INTEGER ,      
   @Name VARCHAR(20),       
   @City VARCHAR(20),      
   @Department VARCHAR(20),      
   @Gender VARCHAR(6)      
)        
as        
begin        
   Update tblEmployee         
   set Name=@Name,        
   City=@City,        
   Department=@Department,      
   Gender=@Gender        
   where Id=@Id        
End