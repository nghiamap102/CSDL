USE [QuanLyBanNuocHoa]
GO
/****** Object:  Table [dbo].[tb_CTHD]    Script Date: 9/21/2021 2:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CTHD](
	[MaHD] [int] NOT NULL,
	[MaHH] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [money] NULL,
 CONSTRAINT [PK_tb_CTHD] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_HangHoa]    Script Date: 9/21/2021 2:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HangHoa](
	[MaHang] [int] IDENTITY(1,1) NOT NULL,
	[TenHang] [nvarchar](30) NULL,
	[SoLuong] [int] NULL,
	[LoaiHangHoa] [int] NULL,
	[DonGia] [money] NULL,
 CONSTRAINT [PK_tb_HangHoa_1] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_HoaDon]    Script Date: 9/21/2021 2:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [date] NULL,
	[KhachHang] [int] NULL,
	[NguoiLap] [int] NULL,
 CONSTRAINT [PK_tb_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_KhachHang]    Script Date: 9/21/2021 2:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](30) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NamSinh] [date] NULL,
	[SDT] [varchar](11) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [varchar](30) NULL,
 CONSTRAINT [PK_tb_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_LoaiHangHoa]    Script Date: 9/21/2021 2:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_LoaiHangHoa](
	[MaLoaiHH] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiHH] [nchar](10) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_LoaiHangHoa] PRIMARY KEY CLUSTERED 
(
	[MaLoaiHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_NhanVien]    Script Date: 9/21/2021 2:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](30) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NamSinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [varchar](11) NULL,
	[MatKhau] [varchar](20) NULL,
 CONSTRAINT [PK_tb_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_CTHD]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHD_tb_HangHoa] FOREIGN KEY([MaHH])
REFERENCES [dbo].[tb_HangHoa] ([MaHang])
GO
ALTER TABLE [dbo].[tb_CTHD] CHECK CONSTRAINT [FK_tb_CTHD_tb_HangHoa]
GO
ALTER TABLE [dbo].[tb_CTHD]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHD_tb_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[tb_HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[tb_CTHD] CHECK CONSTRAINT [FK_tb_CTHD_tb_HoaDon]
GO
ALTER TABLE [dbo].[tb_HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_tb_HangHoa_tb_LoaiHangHoa] FOREIGN KEY([LoaiHangHoa])
REFERENCES [dbo].[tb_LoaiHangHoa] ([MaLoaiHH])
GO
ALTER TABLE [dbo].[tb_HangHoa] CHECK CONSTRAINT [FK_tb_HangHoa_tb_LoaiHangHoa]
GO
ALTER TABLE [dbo].[tb_HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tb_HoaDon_tb_KhachHang] FOREIGN KEY([KhachHang])
REFERENCES [dbo].[tb_KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[tb_HoaDon] CHECK CONSTRAINT [FK_tb_HoaDon_tb_KhachHang]
GO
ALTER TABLE [dbo].[tb_HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tb_HoaDon_tb_NhanVien] FOREIGN KEY([NguoiLap])
REFERENCES [dbo].[tb_NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tb_HoaDon] CHECK CONSTRAINT [FK_tb_HoaDon_tb_NhanVien]
GO
