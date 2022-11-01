USE [master]
GO
/****** Object:  Database [QuanLySinhVien]    Script Date: 10/18/2021 12:16:56 PM ******/
CREATE DATABASE [QuanLySinhVien]
GO
USE [QuanLySinhVien]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 10/18/2021 12:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[FacultyID] [int] NOT NULL,
	[FacultyName] [nvarchar](50) NOT NULL,
	[TotalProfessor] [int] NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[FacultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10/18/2021 12:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[AverageScore] [float] NOT NULL,
	[FacultyID] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Faculty] ([FacultyID], [FacultyName], [TotalProfessor]) VALUES (1, N'Công nghệ thông tin', 10)
GO
INSERT [dbo].[Faculty] ([FacultyID], [FacultyName], [TotalProfessor]) VALUES (2, N'Ngôn ngữ anh', 5)
GO
INSERT [dbo].[Faculty] ([FacultyID], [FacultyName], [TotalProfessor]) VALUES (3, N'Quản trị kinh doanh', 5)
GO
INSERT [dbo].[Faculty] ([FacultyID], [FacultyName], [TotalProfessor]) VALUES (4, N'Ngôn  ngữ hàn', 5)
GO
INSERT [dbo].[Student] ([StudentID], [FullName], [AverageScore], [FacultyID]) VALUES (N'1611789456', N'Hồ A Thanh', 8.5, 3)
GO
INSERT [dbo].[Student] ([StudentID], [FullName], [AverageScore], [FacultyID]) VALUES (N'1711067777', N'Hồ A Tín', 8.5, 3)
GO
INSERT [dbo].[Student] ([StudentID], [FullName], [AverageScore], [FacultyID]) VALUES (N'1911068888', N'Trương Tài', 5, 3)
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Faculty] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculty] ([FacultyID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Faculty]
GO
USE [master]
GO
ALTER DATABASE [QuanLySinhVien] SET  READ_WRITE 
GO
