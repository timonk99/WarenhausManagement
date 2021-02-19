USE [WHM]
GO
/****** Object:  User [WHM\DBAdmin]    Script Date: 19.02.2021 13:03:49 ******/
CREATE USER [WHM\DBAdmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [WHM\WHM_Admin]    Script Date: 19.02.2021 13:03:49 ******/
CREATE USER [WHM\WHM_Admin] FOR LOGIN [WHM\WHM_Admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [WHM\WHM_DB_Admin]    Script Date: 19.02.2021 13:03:49 ******/
CREATE USER [WHM\WHM_DB_Admin] FOR LOGIN [WHM\WHM_DB_Admin]
GO
/****** Object:  User [WHM\WHM_DB_Einkauf]    Script Date: 19.02.2021 13:03:49 ******/
CREATE USER [WHM\WHM_DB_Einkauf] FOR LOGIN [WHM\WHM_DB_Einkauf]
GO
/****** Object:  User [WHM\WHM_DB_Lager]    Script Date: 19.02.2021 13:03:49 ******/
CREATE USER [WHM\WHM_DB_Lager] FOR LOGIN [WHM\WHM_DB_Lager]
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
/****** Object:  UserDefinedFunction [dbo].[f_check_ausbuchen]    Script Date: 19.02.2021 13:03:49 ******/
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
/****** Object:  UserDefinedFunction [dbo].[f_check_slot]    Script Date: 19.02.2021 13:03:49 ******/
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
/****** Object:  UserDefinedFunction [dbo].[f_check_slot_size]    Script Date: 19.02.2021 13:03:49 ******/
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
/****** Object:  UserDefinedFunction [dbo].[f_einbuchen]    Script Date: 19.02.2021 13:03:49 ******/
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
/****** Object:  UserDefinedFunction [dbo].[f_get_auslastung]    Script Date: 19.02.2021 13:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   Function [dbo].[f_get_auslastung]( @ts_startdate datetime,  @ts_enddate datetime,  @i_regal int)
Returns int as
BEGIN 
	
	return(Select Count(l.LagerplatzNr) from Lagerplatz l
		join Lagerprozess l2 on l2.LagerplatzNr = l.LagerplatzNr
		where l2.WareneingangDatum < @ts_startdate
		and l2.WarenausgangDatum > @ts_enddate
		and l.Regal = @i_regal)
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[f_get_menge_ware]    Script Date: 19.02.2021 13:03:49 ******/
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
			where l.WareneingangDatum < @ts_startdate
			and l.WarenausgangDatum > @ts_enddate
			and l.uebergroeße = 0
			and l.uebergroeße = null
			group by w.WareName;
		
		insert into @rtnTable 
			Select Count(l.WareID) / 2, w.WareName from Lagerprozess l 
			join Ware w on w.WareID = l.WareID 
			where l.WareneingangDatum < @ts_startdate
			and l.WarenausgangDatum > @ts_enddate
			and l.uebergroeße = 1
			group by w.WareName;
			
	return 
END
GO
/****** Object:  UserDefinedFunction [dbo].[WareID]    Script Date: 19.02.2021 13:03:49 ******/
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
/****** Object:  Table [dbo].[Lagerplatz]    Script Date: 19.02.2021 13:03:49 ******/
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
/****** Object:  Table [dbo].[Lagerprozess]    Script Date: 19.02.2021 13:03:49 ******/
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
/****** Object:  Table [dbo].[Ware]    Script Date: 19.02.2021 13:03:49 ******/
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
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10101, 1, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10102, 1, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10103, 1, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10104, 1, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10105, 1, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10106, 1, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10107, 1, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10108, 1, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10109, 1, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10110, 1, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10201, 2, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10202, 2, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10203, 2, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10204, 2, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10205, 2, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10206, 2, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10207, 2, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10208, 2, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10209, 2, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10210, 2, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10301, 3, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10302, 3, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10303, 3, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10304, 3, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10305, 3, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10306, 3, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10307, 3, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10308, 3, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10309, 3, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10310, 3, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10401, 4, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10402, 4, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10403, 4, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10404, 4, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10405, 4, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10406, 4, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10407, 4, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10408, 4, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10409, 4, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10410, 4, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10501, 5, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10502, 5, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10503, 5, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10504, 5, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10505, 5, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10506, 5, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10507, 5, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10508, 5, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10509, 5, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10510, 5, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10601, 6, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10602, 6, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10603, 6, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10604, 6, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10605, 6, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10606, 6, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10607, 6, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10608, 6, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10609, 6, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10610, 6, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10701, 7, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10702, 7, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10703, 7, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10704, 7, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10705, 7, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10706, 7, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10707, 7, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10708, 7, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10709, 7, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10710, 7, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10801, 8, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10802, 8, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10803, 8, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10804, 8, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10805, 8, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10806, 8, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10807, 8, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10808, 8, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10809, 8, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10810, 8, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10901, 9, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10902, 9, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10903, 9, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10904, 9, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10905, 9, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10906, 9, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10907, 9, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10908, 9, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10909, 9, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (10910, 9, 10)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11001, 10, 1)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11002, 10, 2)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11003, 10, 3)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11004, 10, 4)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11005, 10, 5)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11006, 10, 6)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11007, 10, 7)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11008, 10, 8)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11009, 10, 9)
INSERT [dbo].[Lagerplatz] ([LagerplatzNr], [Regal], [Etage]) VALUES (11010, 10, 10)
GO
SET IDENTITY_INSERT [dbo].[Lagerprozess] ON 

INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10101, 1, CAST(N'2020-11-25T10:00:00.000' AS DateTime), CAST(N'2020-11-25T11:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10101, 1, CAST(N'2020-11-25T12:00:00.000' AS DateTime), CAST(N'2020-11-25T13:00:00.000' AS DateTime), 2, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10109, 2, CAST(N'2020-11-25T12:30:00.000' AS DateTime), CAST(N'2020-11-25T13:00:00.000' AS DateTime), 3, 1)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10102, 1, CAST(N'2020-11-26T10:49:49.520' AS DateTime), NULL, 4, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10102, 1, CAST(N'2020-11-27T12:49:01.617' AS DateTime), NULL, 5, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10404, 1, CAST(N'2020-11-27T12:49:55.140' AS DateTime), NULL, 6, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10801, 31, CAST(N'2020-12-04T11:07:03.920' AS DateTime), NULL, 8, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10101, 1, CAST(N'2021-02-11T10:57:19.560' AS DateTime), NULL, 1007, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10103, 1, CAST(N'2021-02-12T11:55:07.710' AS DateTime), NULL, 1008, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10101, 1, CAST(N'2021-02-16T12:04:19.693' AS DateTime), NULL, 1014, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10101, 1, CAST(N'2021-02-16T12:09:21.897' AS DateTime), NULL, 1016, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10109, 1, CAST(N'2021-02-17T13:52:49.663' AS DateTime), NULL, 1017, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10301, 3, CAST(N'2021-02-17T14:00:52.107' AS DateTime), CAST(N'2021-02-17T14:33:36.263' AS DateTime), 1018, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10301, 3, CAST(N'2021-02-17T14:39:32.760' AS DateTime), CAST(N'2021-02-17T14:43:10.713' AS DateTime), 1019, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10302, 3, CAST(N'2021-02-17T17:15:19.940' AS DateTime), CAST(N'2021-02-17T17:17:42.533' AS DateTime), 1020, 0)
INSERT [dbo].[Lagerprozess] ([LagerplatzNr], [WareID], [WareneingangDatum], [WarenausgangDatum], [LagerprozessNr], [uebergroeße]) VALUES (10305, 1036, CAST(N'2021-02-19T12:30:23.617' AS DateTime), NULL, 1026, 0)
SET IDENTITY_INSERT [dbo].[Lagerprozess] OFF
SET IDENTITY_INSERT [dbo].[Ware] ON 

INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kola Kola', 0.99, 2, 0)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'American Kola', 1.54, 2, 1)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Tofu      ', 2.43, 2, 2)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Ravioli Angelo', 1.24, 1, 3)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Chocolade', 1.51, 1, 4)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Schoggi Schokolade', 1.76, 1, 5)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Teatime Chocolate Biscuits', 2.53, 1, 6)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Scottish Longbreads', 0.99, 2, 7)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Raclette Courdavault', 4.99, 2, 8)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Manjimup Dried Apples', 0.78, 2, 9)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Longlife Tofu', 2.78, 2, 10)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Ipoh Coffee', 1.35, 2, 11)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Nord-Ost Matjeshering', 2.32, 2, 12)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Aniseed Syrup ', 1.78, 1, 13)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Uncle Bob''s Organic Dried Pears ', 2.1, 1, 14)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Northwoods Cranberry Sauce', 1.45, 1, 15)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Chef Anton''s Gumbo Mix ', 2.78, 2, 16)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Chai', 1.48, 1, 17)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'test', 9, 1, 18)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Test', 1, 1, 19)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Test6', 1.25, 1, 20)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'test021', 2.99, 1, 22)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Brot', 1.99, 1, 23)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kiste Wasser', 3.65, 1, 24)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kiste Cola', 4.99, 1, 25)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kiste Fanta', 4.99, 1, 26)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kiste Sprite', 4.99, 1, 27)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kiste Sprite light', 4.99, 1, 28)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kiste Fanta light', 4.99, 1, 29)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kiste Waser mt Kohlensäure', 3.5, 1, 30)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Kiste Wasser Medium', 3.5, 1, 31)
INSERT [dbo].[Ware] ([WareName], [Preis], [Warengröße], [WareID]) VALUES (N'Fonny Chips', 2.99, 1, 1036)
SET IDENTITY_INSERT [dbo].[Ware] OFF
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
/****** Object:  StoredProcedure [dbo].[Ausbuchen]    Script Date: 19.02.2021 13:03:49 ******/
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
/****** Object:  StoredProcedure [dbo].[NeuerArtikel]    Script Date: 19.02.2021 13:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NeuerArtikel] @Warename nvarchar(50), @Preis varchar(50), @Warengröße int
AS
INSERT INTO Ware(Warename, Preis, Warengröße)
	VALUES (@Warename, convert(float,@Preis), @Warengröße)
GO
/****** Object:  StoredProcedure [dbo].[p_insert_lagerprozess]    Script Date: 19.02.2021 13:03:49 ******/
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
