USE [master]
GO
/****** Object:  Database [WHM]    Script Date: 19.02.2021 13:45:34 ******/
CREATE DATABASE [WHM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WHM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WHM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WHM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WHM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WHM] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WHM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WHM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WHM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WHM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WHM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WHM] SET ARITHABORT OFF 
GO
ALTER DATABASE [WHM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WHM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WHM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WHM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WHM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WHM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WHM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WHM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WHM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WHM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WHM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WHM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WHM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WHM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WHM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WHM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WHM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WHM] SET RECOVERY FULL 
GO
ALTER DATABASE [WHM] SET  MULTI_USER 
GO
ALTER DATABASE [WHM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WHM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WHM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WHM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WHM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WHM] SET QUERY_STORE = OFF
GO
USE [WHM]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [WHM]
GO
/****** Object:  User [WHM\WHM_DB_Lager]    Script Date: 19.02.2021 13:45:34 ******/
CREATE USER [WHM\WHM_DB_Lager] FOR LOGIN [WHM\WHM_DB_Lager]
GO
/****** Object:  User [WHM\WHM_DB_Einkauf]    Script Date: 19.02.2021 13:45:34 ******/
CREATE USER [WHM\WHM_DB_Einkauf] FOR LOGIN [WHM\WHM_DB_Einkauf]
GO
/****** Object:  User [WHM\WHM_DB_Admin]    Script Date: 19.02.2021 13:45:34 ******/
CREATE USER [WHM\WHM_DB_Admin] FOR LOGIN [WHM\WHM_DB_Admin]
GO
/****** Object:  User [WHM\WHM_Admin]    Script Date: 19.02.2021 13:45:34 ******/
CREATE USER [WHM\WHM_Admin] FOR LOGIN [WHM\WHM_Admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [WHM\DBAdmin]    Script Date: 19.02.2021 13:45:34 ******/
CREATE USER [WHM\DBAdmin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [WHM\WHM_DB_Lager]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [WHM\WHM_DB_Lager]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [WHM\WHM_DB_Lager]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [WHM\WHM_DB_Lager]
GO
ALTER ROLE [db_datareader] ADD MEMBER [WHM\WHM_DB_Lager]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [WHM\WHM_DB_Lager]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [WHM\WHM_DB_Lager]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [WHM\WHM_DB_Lager]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [WHM\WHM_DB_Einkauf]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [WHM\WHM_DB_Einkauf]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [WHM\WHM_DB_Einkauf]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [WHM\WHM_DB_Einkauf]
GO
ALTER ROLE [db_datareader] ADD MEMBER [WHM\WHM_DB_Einkauf]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [WHM\WHM_DB_Einkauf]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [WHM\WHM_DB_Einkauf]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [WHM\WHM_DB_Einkauf]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [WHM\WHM_DB_Admin]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [WHM\WHM_DB_Admin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [WHM\WHM_DB_Admin]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [WHM\WHM_DB_Admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [WHM\WHM_DB_Admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [WHM\WHM_DB_Admin]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [WHM\WHM_DB_Admin]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [WHM\WHM_DB_Admin]
GO
ALTER ROLE [db_owner] ADD MEMBER [WHM\WHM_Admin]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [WHM\WHM_Admin]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [WHM\WHM_Admin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [WHM\WHM_Admin]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [WHM\WHM_Admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [WHM\WHM_Admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [WHM\WHM_Admin]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [WHM\WHM_Admin]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [WHM\WHM_Admin]
GO
/****** Object:  UserDefinedFunction [dbo].[f_check_ausbuchen]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[f_check_ausbuchen](@LagerplatzNr int)
Returns BIT AS 
BEGIN 
	if(Select Top 1 (l.WarenausgangDatum) from Lagerprozess l where l.LagerplatzNr = @LagerplatzNr order by l.WareneingangDatum desc) is not NULL 
		return 1;
	return 0;
END; 
GO
/****** Object:  UserDefinedFunction [dbo].[f_check_slot]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[f_check_slot](@lagerplatz int)
Returns BIT AS 
BEGIN 
	if 
	(Select TOp 1 (l.WarenausgangDatum)
	from Lagerprozess l 
	where @lagerplatz = l.LagerplatzNr 
	and l.WarenausgangDatum < getdate()
	order by l.WareneingangDatum desc) is not null
	or 
	(Select Top 1(l2.LagerprozessNr) from Lagerprozess l2 join Lagerplatz l3 on l3.LagerplatzNr = l2.LagerplatzNr where l2.LagerplatzNr = @lagerplatz) is NULL 
		return 1;
	return 0;
END; 
GO
/****** Object:  UserDefinedFunction [dbo].[f_check_slot_size]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[f_check_slot_size](@lagerplatz int)
Returns BIT AS 
BEGIN 
	if 
	(Select TOp 1 (l.WarenausgangDatum)
	from Lagerprozess l 
	where @lagerplatz +1 = l.LagerplatzNr 
	and l.WarenausgangDatum < getdate()
	order by l.WareneingangDatum desc) is not null
	or 
	(Select Top 1(l2.LagerprozessNr) from Lagerprozess l2 join Lagerplatz l3 on l3.LagerplatzNr = l2.LagerplatzNr where l2.LagerplatzNr = @lagerplatz +1) is NULL 
		return 1;
	return 0;
END; 
GO
/****** Object:  UserDefinedFunction [dbo].[f_einbuchen]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   function [dbo].[f_einbuchen](@i_waren_id int)
returns @rtn_table TABLE 
(
	beschreibung nvarchar(50),
	speicherbedarf int,
	preis float
)
Begin
	
	insert into @rtn_table
		select w.WareName, w.Warengröße, w.Preis from Ware w
		where w.WareID = @i_waren_id;
	return
END
GO
/****** Object:  UserDefinedFunction [dbo].[f_get_auslastung]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Function [dbo].[f_get_auslastung]( @ts_startdate datetime,  @ts_enddate datetime,  @i_regal int)
Returns int as
BEGIN 
	
	return(Select Count(l.LagerplatzNr) from Lagerplatz l
		join Lagerprozess l2 on l2.LagerplatzNr = l.LagerplatzNr
		where l2.WareneingangDatum > @ts_startdate
		and l2.WarenausgangDatum < @ts_enddate
		and l.Regal = @i_regal)
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[f_get_menge_ware]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Function [dbo].[f_get_menge_ware](@ts_startdate datetime,  @ts_enddate datetime)
RETURNS  @rtnTable TABLE 
(
	Menge int,
	Ware nvarchar(50)
)
Begin
		insert into @rtnTable 
			Select Count(l.WareID), w.WareName from Lagerprozess l 
			join Ware w on w.WareID = l.WareID 
			where l.WareneingangDatum > @ts_startdate
			and l.WarenausgangDatum < @ts_enddate
			and l.uebergroeße = 0
			group by w.WareName;
		
		insert into @rtnTable 
			Select Count(l.WareID) / 2, w.WareName from Lagerprozess l 
			join Ware w on w.WareID = l.WareID 
			where l.WareneingangDatum > @ts_startdate
			and l.WarenausgangDatum < @ts_enddate
			and l.uebergroeße = 1
			group by w.WareName;
			
	return 
END
GO
/****** Object:  UserDefinedFunction [dbo].[WareID]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[WareID] (@WareName nvarchar(50))
RETURNS int as
Begin
	return (select WareID
		from dbo.Ware
		where WareName = @WareName)
END
GO
/****** Object:  Table [dbo].[Lagerplatz]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lagerplatz](
	[LagerplatzNr] [int] NOT NULL,
	[Regal] [int] NOT NULL,
	[Etage] [int] NOT NULL,
 CONSTRAINT [PK_Lagerplatz] PRIMARY KEY CLUSTERED 
(
	[LagerplatzNr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lagerprozess]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lagerprozess](
	[LagerplatzNr] [int] NOT NULL,
	[WareID] [int] NOT NULL,
	[WareneingangDatum] [datetime] NOT NULL,
	[WarenausgangDatum] [datetime] NULL,
	[LagerprozessNr] [int] IDENTITY(1,1) NOT NULL,
	[uebergroeße] [bit] NULL,
 CONSTRAINT [pk_LagerprozessNr] PRIMARY KEY CLUSTERED 
(
	[LagerprozessNr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ware]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ware](
	[WareName] [nvarchar](50) NULL,
	[Preis] [float] NULL,
	[Warengröße] [int] NULL,
	[WareID] [int] IDENTITY(0,1) NOT NULL,
 CONSTRAINT [PK_Ware] PRIMARY KEY CLUSTERED 
(
	[WareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Lagerprozess] ADD  DEFAULT ((0)) FOR [uebergroeße]
GO
ALTER TABLE [dbo].[Lagerprozess]  WITH CHECK ADD  CONSTRAINT [FK_Lagerprozess_Lagerplatz] FOREIGN KEY([LagerplatzNr])
REFERENCES [dbo].[Lagerplatz] ([LagerplatzNr])
GO
ALTER TABLE [dbo].[Lagerprozess] CHECK CONSTRAINT [FK_Lagerprozess_Lagerplatz]
GO
ALTER TABLE [dbo].[Lagerprozess]  WITH CHECK ADD  CONSTRAINT [FK_Lagerprozess_Ware] FOREIGN KEY([WareID])
REFERENCES [dbo].[Ware] ([WareID])
GO
ALTER TABLE [dbo].[Lagerprozess] CHECK CONSTRAINT [FK_Lagerprozess_Ware]
GO
/****** Object:  StoredProcedure [dbo].[Ausbuchen]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ausbuchen] @LagerplatzNr int, @WareID int, @i_ueb int
AS
	Update Lagerprozess set Warenausgangdatum = GETDATE()
	where LagerprozessNr = (Select LagerprozessNr from Lagerprozess where LagerplatzNr = @LagerplatzNr and WareID = @WareID and Warenausgangdatum is NULL)
	
	if(@i_ueb = 1)
			Update Lagerprozess set Warenausgangdatum = GETDATE()
			where LagerprozessNr = (Select LagerprozessNr from Lagerprozess where LagerplatzNr = @LagerplatzNr +1 and WareID = @WareID and Warenausgangdatum is NULL)
GO
/****** Object:  StoredProcedure [dbo].[NeuerArtikel]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NeuerArtikel] @Warename nvarchar(50), @Preis varchar(50), @Warengröße int
AS
INSERT INTO Ware(Warename, Preis, Warengröße)
	VALUES (@Warename, convert(float,@Preis), @Warengröße)
GO
/****** Object:  StoredProcedure [dbo].[p_insert_lagerprozess]    Script Date: 19.02.2021 13:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[p_insert_lagerprozess] @i_waren_id int, @i_lagerplatz_id int, @i_ueb bit
AS
	insert into Lagerprozess (LagerplatzNr, WareID, WareneingangDatum, uebergroeße)
	Values (@i_lagerplatz_id, @i_waren_id, GETDATE(), @i_ueb);

	if(@i_ueb = 1)
			insert into Lagerprozess (LagerplatzNr, WareID, WareneingangDatum, uebergroeße)
			Values (@i_lagerplatz_id + 1, @i_waren_id, GETDATE(), 0);
GO
USE [master]
GO
ALTER DATABASE [WHM] SET  READ_WRITE 
GO
