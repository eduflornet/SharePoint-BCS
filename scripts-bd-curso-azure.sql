/****** Object:  Table [dbo].[Alumno]    Script Date: 5/3/2016 3:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[edad] [int] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Alumno_Curso]    Script Date: 5/3/2016 3:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno_Curso](
	[idAlumno] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
	[nota] [int] NULL,
 CONSTRAINT [PK_Alumno_Curso] PRIMARY KEY CLUSTERED 
(
	[idAlumno] ASC,
	[idCurso] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Curso]    Script Date: 5/3/2016 3:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[inicio] [date] NULL,
	[fin] [date] NULL,
	[duracion] [nchar](10) NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
ALTER TABLE [dbo].[Alumno_Curso]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Curso_Alumno] FOREIGN KEY([idAlumno])
REFERENCES [dbo].[Alumno] ([id])
GO
ALTER TABLE [dbo].[Alumno_Curso] CHECK CONSTRAINT [FK_Alumno_Curso_Alumno]
GO
ALTER TABLE [dbo].[Alumno_Curso]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Curso_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Curso] ([id])
GO
ALTER TABLE [dbo].[Alumno_Curso] CHECK CONSTRAINT [FK_Alumno_Curso_Curso]
GO
