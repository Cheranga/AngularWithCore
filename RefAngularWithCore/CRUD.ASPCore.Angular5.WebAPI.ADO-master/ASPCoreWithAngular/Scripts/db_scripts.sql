USE [EmployeeDbDev]
GO
/****** Object:  Table [dbo].[Plate]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Plate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[MinCharacters] [int] NULL,
	[MaxCharacters] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[PlatePattern]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlatePattern](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlateId] [int] NULL,
	[Name] [varchar](20) NOT NULL,
	[Pattern] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[City] [varchar](20) NOT NULL,
	[Department] [varchar](20) NOT NULL,
	[Gender] [varchar](6) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[spAddEmployee]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddEmployee]         
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
GO
/****** Object:  StoredProcedure [dbo].[spAddPlate]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddPlate]         
(        
    @Name VARCHAR(20),         
    @MinCharacters int,        
    @MaxCharacters int        
)        
as         
Begin         
    Insert into Plate (Name,MinCharacters, MaxCharacters)         
	OUTPUT INSERTED.*
    Values (@Name, @MinCharacters, @MaxCharacters)         
End
GO
/****** Object:  StoredProcedure [dbo].[spAddPlatePattern]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddPlatePattern]
(        
	@PlateId int,
    @Name varchar(20),      
	@Pattern varchar(max)	
)        
as         
Begin         
    Insert into PlatePattern (PlateId, Name,Pattern)         
    Values (@PlateId, @Name, @Pattern)         
End
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEmployee]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spDeleteEmployee]       
(        
   @Id int        
)        
as         
begin        
   Delete from tblEmployee where Id=@Id        
End
GO
/****** Object:  StoredProcedure [dbo].[spDeletePlate]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeletePlate]         
(        
    @Id int
)        
as         
Begin         
    delete Plate where Id = @Id
End
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEmployees]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetAllEmployees]      
as      
Begin      
    select *      
    from tblEmployee   
    order by Id      
End
GO
/****** Object:  StoredProcedure [dbo].[spGetPlatePattern]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetPlatePattern]
(        
	@Id int,
    @PlateId int
)        
as         
Begin         
    select top 1 * from PlatePattern where Id=@id and PlateId = @PlateId
End
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEmployee]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spUpdateEmployee]        
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
GO
/****** Object:  StoredProcedure [dbo].[spUpdatePlatePattern]    Script Date: 14/05/2018 5:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdatePlatePattern]
(        
	@Id int,
    @Name varchar(20),      
	@Pattern varchar(max)	
)        
as         
Begin         
    update PlatePattern
    set Name = @Name,
	Pattern=@Pattern
	where Id=@Id
End
GO
