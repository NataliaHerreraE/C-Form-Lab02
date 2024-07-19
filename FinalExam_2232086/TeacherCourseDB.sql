USE [master]
GO
/****** Object:  Database [TeacherCourseDB]    Script Date: 2024-04-26 3:02:08 PM ******/
CREATE DATABASE [TeacherCourseDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TeacherCourseDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019EXPRESS\MSSQL\DATA\TeacherCourseDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TeacherCourseDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019EXPRESS\MSSQL\DATA\TeacherCourseDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TeacherCourseDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TeacherCourseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TeacherCourseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TeacherCourseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TeacherCourseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TeacherCourseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TeacherCourseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TeacherCourseDB] SET  MULTI_USER 
GO
ALTER DATABASE [TeacherCourseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TeacherCourseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TeacherCourseDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TeacherCourseDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TeacherCourseDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TeacherCourseDB] SET QUERY_STORE = OFF
GO
USE [TeacherCourseDB]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2024-04-26 3:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseNumber] [nvarchar](7) NOT NULL,
	[CourseTitle] [nvarchar](50) NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherCourses]    Script Date: 2024-04-26 3:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherCourses](
	[TeacherId] [int] NOT NULL,
	[CourseNumber] [nvarchar](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 2024-04-26 3:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] IDENTITY(11111,11111) NOT NULL,
	[FirstName] [nvarchar](15) NOT NULL,
	[LastName] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2024-04-26 3:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[JobTitle] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration]) VALUES (N'COMP101', N'Structured Programming', 90)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration]) VALUES (N'COMP102', N'Introduction to C#', 75)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration]) VALUES (N'COMP103', N'Advanced Programming in C#', 75)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration]) VALUES (N'COMP104', N'Web Programming I', 90)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [Duration]) VALUES (N'COMP105', N'Web Programming II', 90)
GO
INSERT [dbo].[TeacherCourses] ([TeacherId], [CourseNumber]) VALUES (11111, N'COMP101')
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([TeacherId], [FirstName], [LastName], [Email]) VALUES (11111, N'Mary', N'Brown', N'mary@yahoo.com')
INSERT [dbo].[Teachers] ([TeacherId], [FirstName], [LastName], [Email]) VALUES (22222, N'Wei', N'Huang', N'wei@gmail.com')
INSERT [dbo].[Teachers] ([TeacherId], [FirstName], [LastName], [Email]) VALUES (33333, N'Michael', N'Freitag', N'michael@hotmail.com')
INSERT [dbo].[Teachers] ([TeacherId], [FirstName], [LastName], [Email]) VALUES (55555, N'Daniel', N'Rother', N'daniel@yahoo.com')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
INSERT [dbo].[Users] ([UserID], [Password], [JobTitle]) VALUES (11111, N'Mary_1234', N'Teacher')
INSERT [dbo].[Users] ([UserID], [Password], [JobTitle]) VALUES (22222, N'Wei_1235', N'Teacher')
INSERT [dbo].[Users] ([UserID], [Password], [JobTitle]) VALUES (33333, N'Michael_1236', N'Teacher')
INSERT [dbo].[Users] ([UserID], [Password], [JobTitle]) VALUES (55555, N'Daniel_1237', N'Program Coordinator')
GO
ALTER TABLE [dbo].[TeacherCourses]  WITH CHECK ADD  CONSTRAINT [FK_TeacherCourses_Courses] FOREIGN KEY([CourseNumber])
REFERENCES [dbo].[Courses] ([CourseNumber])
GO
ALTER TABLE [dbo].[TeacherCourses] CHECK CONSTRAINT [FK_TeacherCourses_Courses]
GO
ALTER TABLE [dbo].[TeacherCourses]  WITH CHECK ADD  CONSTRAINT [FK_TeacherCourses_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[TeacherCourses] CHECK CONSTRAINT [FK_TeacherCourses_Teachers]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Teachers] FOREIGN KEY([UserID])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Teachers]
GO
USE [master]
GO
ALTER DATABASE [TeacherCourseDB] SET  READ_WRITE 
GO
