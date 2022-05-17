CREATE DATABASE [provacandidato]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'provacandidato', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\provacandidato.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'provacandidato_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\provacandidato_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [provacandidato] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [provacandidato] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [provacandidato] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [provacandidato] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [provacandidato] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [provacandidato] SET ARITHABORT OFF 
GO
ALTER DATABASE [provacandidato] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [provacandidato] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [provacandidato] SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF)
GO
ALTER DATABASE [provacandidato] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [provacandidato] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [provacandidato] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [provacandidato] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [provacandidato] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [provacandidato] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [provacandidato] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [provacandidato] SET  DISABLE_BROKER 
GO
ALTER DATABASE [provacandidato] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [provacandidato] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [provacandidato] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [provacandidato] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [provacandidato] SET  READ_WRITE 
GO
ALTER DATABASE [provacandidato] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [provacandidato] SET  MULTI_USER 
GO
ALTER DATABASE [provacandidato] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [provacandidato] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [provacandidato] SET DELAYED_DURABILITY = DISABLED 
GO
USE [provacandidato]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = On;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = Primary;
GO
USE [provacandidato]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [provacandidato] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO