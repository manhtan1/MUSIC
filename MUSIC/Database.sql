USE [master]
GO
/****** Object:  Database [MUSIC]    Script Date: 11/05/22 4:07:14 PM ******/
CREATE DATABASE [MUSIC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MUSIC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MUSIC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MUSIC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MUSIC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MUSIC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MUSIC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MUSIC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MUSIC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MUSIC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MUSIC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MUSIC] SET ARITHABORT OFF 
GO
ALTER DATABASE [MUSIC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MUSIC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MUSIC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MUSIC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MUSIC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MUSIC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MUSIC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MUSIC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MUSIC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MUSIC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MUSIC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MUSIC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MUSIC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MUSIC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MUSIC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MUSIC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MUSIC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MUSIC] SET RECOVERY FULL 
GO
ALTER DATABASE [MUSIC] SET  MULTI_USER 
GO
ALTER DATABASE [MUSIC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MUSIC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MUSIC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MUSIC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MUSIC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MUSIC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MUSIC', N'ON'
GO
ALTER DATABASE [MUSIC] SET QUERY_STORE = OFF
GO
USE [MUSIC]
GO
/****** Object:  Table [dbo].[ALBUM]    Script Date: 11/05/22 4:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALBUM](
	[idalbum] [int] NOT NULL,
	[tenalbum] [nvarchar](50) NOT NULL,
	[tencasialbum] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_ALBUM] PRIMARY KEY CLUSTERED 
(
	[idalbum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BAIHAT]    Script Date: 11/05/22 4:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAIHAT](
	[idbaihat] [int] NOT NULL,
	[idtheloai] [int] NULL,
	[idalbum] [int] NULL,
	[idplaylist] [int] NULL,
	[tenbaihat] [nvarchar](50) NOT NULL,
	[hinhbaihat] [nvarchar](50) NOT NULL,
	[casi] [nvarchar](50) NOT NULL,
	[linkbaihat] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_BAIHAT] PRIMARY KEY CLUSTERED 
(
	[idbaihat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUDE]    Script Date: 11/05/22 4:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUDE](
	[idchude] [int] NOT NULL,
	[tenchude] [nvarchar](50) NOT NULL,
	[hinhchude] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_CHUDE] PRIMARY KEY CLUSTERED 
(
	[idchude] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PLAYLIST]    Script Date: 11/05/22 4:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLAYLIST](
	[idplaylist] [int] NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[hinhnen] [nvarchar](50) NOT NULL,
	[hinhicon] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_PLAYLIST] PRIMARY KEY CLUSTERED 
(
	[idplaylist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THANHVIEN]    Script Date: 11/05/22 4:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THANHVIEN](
	[HoTen] [nvarchar](50) NULL,
	[TenDN] [varchar](50) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[DienThoai] [varchar](20) NULL,
	[Tuoi] [int] NULL,
	[NgayDangKy] [date] NULL,
	[Email] [varchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[CauHoiBaoMat] [nvarchar](50) NULL,
	[CauTraLoi] [nvarchar](50) NULL,
 CONSTRAINT [PK_THANHVIEN] PRIMARY KEY CLUSTERED 
(
	[TenDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THELOAI]    Script Date: 11/05/22 4:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
	[idtheloai] [int] NOT NULL,
	[idchude] [int] NULL,
	[tentheloai] [nvarchar](50) NOT NULL,
	[hinhtheloai] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_THELOAI] PRIMARY KEY CLUSTERED 
(
	[idtheloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ALBUM] ([idalbum], [tenalbum], [tencasialbum]) VALUES (1, N'Đi để trở về', N'Phan Mạnh Quỳnh')
GO
INSERT [dbo].[ALBUM] ([idalbum], [tenalbum], [tencasialbum]) VALUES (2, N'Đất nước', N'Đen Vâu')
GO
INSERT [dbo].[ALBUM] ([idalbum], [tenalbum], [tencasialbum]) VALUES (3, N'Tình yêu', N'Sơn Tùng')
GO
INSERT [dbo].[ALBUM] ([idalbum], [tenalbum], [tencasialbum]) VALUES (4, N'Rap Việt', N'Binz')
GO
INSERT [dbo].[ALBUM] ([idalbum], [tenalbum], [tencasialbum]) VALUES (5, N'My love', N'Phương Ly')
GO
INSERT [dbo].[ALBUM] ([idalbum], [tenalbum], [tencasialbum]) VALUES (6, N'Lời chưa nói', N'Trịnh Thăng Bình')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (1, 3, 1, 3, N'Đi để trở về', N'/images/nhac/didetrove.jpg', N'Phan Mạnh Quỳnh', N'/music/didetrove.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (2, 2, 5, 4, N'Mặt trời của em', N'/images/nhac/mattroicuaem.jpg', N'Phương Ly', N'/music/mattroicuaem.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (3, 1, 2, 1, N'Mang tiền về cho mẹ', N'/images/nhac/mangtienvechome.jpg', N'ĐEN VÂU', N'/music/mangtienvechome.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (4, 5, 4, 5, N'Big cityboy', N'/images/nhac/bigcityboi.jpg', N'Binz', N'/music/bigcityboi.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (5, 6, 6, 6, N'Người ấy', N'/images/nhac/nguoiay.jpg', N'Trịnh Thăng Bình', N'/music/nguoiay.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (6, 1, 6, 6, N'Vì mẹ con ngoan', N'/images/nhac/vimeconngoan.jpg', N'Trịnh Thăng Bình', N'/music/vimeconngoan.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (7, 5, 4, 5, N'Cơn mưa cuối', N'/images/nhac/conmuacuoi.jpg', N'Binz', N'/music/conmuacuoi.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (8, 2, 1, 3, N'Vợ người ta', N'/images/nhac/vonguoita.jpg', N'Phan Mạnh Quỳnh', N'/music/vonguoita.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (9, 1, 2, 1, N'Đi về nhà', N'/images/nhac/divenha.jpg', N'ĐEN VÂU', N'/music/divenha.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (10, 1, 3, 2, N'Thả giấc mơ', N'/images/nhac/thagiacmo.jpg', N'Sơn Tùng MTP', N'/music/thagiacmo.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (11, 2, 3, 2, N'Có chắc yêu là đây', N'/images/nhac/cochacyeuladay.jpg', N'Sơn Tùng MTP', N'/music/cochacyeuladay.mp3')
GO
INSERT [dbo].[BAIHAT] ([idbaihat], [idtheloai], [idalbum], [idplaylist], [tenbaihat], [hinhbaihat], [casi], [linkbaihat]) VALUES (12, 1, 5, 4, N'Túi ba gang', N'/images/nhac/tuibagang.jpg', N'Phương Ly', N'/music/tuibagang.mp3')
GO
INSERT [dbo].[CHUDE] ([idchude], [tenchude], [hinhchude]) VALUES (1, N'Đất nước', N'/images/chude/chudedatnuoc.png')
GO
INSERT [dbo].[CHUDE] ([idchude], [tenchude], [hinhchude]) VALUES (2, N'Tình yêu', N'/images/chude/chudetinhyeu.png')
GO
INSERT [dbo].[CHUDE] ([idchude], [tenchude], [hinhchude]) VALUES (3, N'Thiếu nhi', N'/images/chude/chudethieunhi.png')
GO
INSERT [dbo].[PLAYLIST] ([idplaylist], [ten], [hinhnen], [hinhicon]) VALUES (1, N'ĐEN VÂU', N'/images/nhacsi/denvau.png', N'/images/nhacsi/denvau.png')
GO
INSERT [dbo].[PLAYLIST] ([idplaylist], [ten], [hinhnen], [hinhicon]) VALUES (2, N'Sơn Tùng MTP', N'/images/nhacsi/septung.png', N'/images/nhacsi/septung.png')
GO
INSERT [dbo].[PLAYLIST] ([idplaylist], [ten], [hinhnen], [hinhicon]) VALUES (3, N'Phan Mạnh Quỳnh', N'/images/nhacsi/phanmanhquynh.png', N'/images/nhacsi/phanmanhquynh.png')
GO
INSERT [dbo].[PLAYLIST] ([idplaylist], [ten], [hinhnen], [hinhicon]) VALUES (4, N'Phương Ly', N'/images/nhacsi/phuongly.png', N'/images/nhacsi/phuongly.png')
GO
INSERT [dbo].[PLAYLIST] ([idplaylist], [ten], [hinhnen], [hinhicon]) VALUES (5, N'BINZ', N'/images/nhacsi/binz.png/images/nhacsi/binz.png', N'/images/nhacsi/binz.png')
GO
INSERT [dbo].[PLAYLIST] ([idplaylist], [ten], [hinhnen], [hinhicon]) VALUES (6, N'Trịnh Thăng Bình', N'/images/nhacsi/thanhbinh.png', N'/images/nhacsi/thanhbinh.png')
GO
INSERT [dbo].[THELOAI] ([idtheloai], [idchude], [tentheloai], [hinhtheloai]) VALUES (1, 1, N'nhacrap', N'/images/theloainhac/rap.png')
GO
INSERT [dbo].[THELOAI] ([idtheloai], [idchude], [tentheloai], [hinhtheloai]) VALUES (2, 2, N'nhactre', N'/images/theloainhac/nhactre.png')
GO
INSERT [dbo].[THELOAI] ([idtheloai], [idchude], [tentheloai], [hinhtheloai]) VALUES (3, 1, N'nhạc trẻ ,V-POP', N'/images/theloainhac/nhactre.png')
GO
INSERT [dbo].[THELOAI] ([idtheloai], [idchude], [tentheloai], [hinhtheloai]) VALUES (4, 3, N'nhạc thiếu nhi', N'/images/theloainhac/nhacthieunhi.png')
GO
INSERT [dbo].[THELOAI] ([idtheloai], [idchude], [tentheloai], [hinhtheloai]) VALUES (5, 2, N'Nhạc Rock', N'/images/theloainhac/nhactre.png')
GO
INSERT [dbo].[THELOAI] ([idtheloai], [idchude], [tentheloai], [hinhtheloai]) VALUES (6, 2, N'Mashup', N'/inages/theloainhac/bolero.png')
GO
ALTER TABLE [dbo].[BAIHAT]  WITH CHECK ADD  CONSTRAINT [fk_album_BAIHAT] FOREIGN KEY([idalbum])
REFERENCES [dbo].[ALBUM] ([idalbum])
GO
ALTER TABLE [dbo].[BAIHAT] CHECK CONSTRAINT [fk_album_BAIHAT]
GO
ALTER TABLE [dbo].[BAIHAT]  WITH CHECK ADD  CONSTRAINT [fk_playlist_BAIHAT] FOREIGN KEY([idplaylist])
REFERENCES [dbo].[PLAYLIST] ([idplaylist])
GO
ALTER TABLE [dbo].[BAIHAT] CHECK CONSTRAINT [fk_playlist_BAIHAT]
GO
ALTER TABLE [dbo].[BAIHAT]  WITH CHECK ADD  CONSTRAINT [fk_theloai_BAIHAT] FOREIGN KEY([idtheloai])
REFERENCES [dbo].[THELOAI] ([idtheloai])
GO
ALTER TABLE [dbo].[BAIHAT] CHECK CONSTRAINT [fk_theloai_BAIHAT]
GO
ALTER TABLE [dbo].[THELOAI]  WITH CHECK ADD  CONSTRAINT [fk_chude_THELOAI] FOREIGN KEY([idchude])
REFERENCES [dbo].[CHUDE] ([idchude])
GO
ALTER TABLE [dbo].[THELOAI] CHECK CONSTRAINT [fk_chude_THELOAI]
GO
USE [master]
GO
ALTER DATABASE [MUSIC] SET  READ_WRITE 
GO
