USE [proeasy]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacora](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_usuario] [bigint] NULL,
	[criticidad] [varchar](45) NULL,
	[funcionalidad] [varchar](45) NULL,
	[descripcion] [varchar](500) NULL,
	[fecha] [datetime] NULL,
	[dvh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[digito_verificador]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[digito_verificador](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[tabla] [varchar](45) NULL,
	[valor] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familia]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familia](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[eliminado] [tinyint] NULL,
	[dvh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familia_patente]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familia_patente](
	[id_familia] [bigint] NOT NULL,
	[id_patente] [bigint] NOT NULL,
	[dvh] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hora]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hora](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_proyecto] [bigint] NULL,
	[id_tarea] [bigint] NULL,
	[id_usuario] [bigint] NULL,
	[fecha] [datetime] NULL,
	[cantidad] [decimal](10, 0) NULL,
	[eliminado] [tinyint] NULL,
	[dvh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[idioma]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idioma](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[eliminado] [tinyint] NULL,
	[code] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patente]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patente](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proyecto]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proyecto](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[horas_estimadas] [varchar](45) NULL,
	[valor_hora] [varchar](45) NULL,
	[habilitado] [tinyint] NULL,
	[fecha] [datetime] NULL,
	[eliminado] [tinyint] NULL,
	[dvh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proyecto_usuario]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proyecto_usuario](
	[id_proyecto] [bigint] NOT NULL,
	[id_usuario] [bigint] NOT NULL,
	[dvh] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarea]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarea](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_proyecto] [bigint] NULL,
	[titulo] [varchar](45) NULL,
	[descripcion] [varchar](200) NULL,
	[eliminado] [tinyint] NULL,
	[dvh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_idioma] [bigint] NULL,
	[nombre] [varchar](45) NULL,
	[apellido] [varchar](45) NULL,
	[email] [varchar](45) NULL,
	[usuario] [varchar](45) NULL,
	[disponibilidad] [varchar](45) NULL,
	[valor_hora] [varchar](45) NULL,
	[habilitado] [tinyint] NULL,
	[intentos] [int] NULL,
	[eliminado] [tinyint] NULL,
	[contrasenia] [varchar](255) NULL,
	[dvh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_familia]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_familia](
	[id_usuario] [bigint] NOT NULL,
	[id_familia] [bigint] NOT NULL,
	[dvh] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_patente]    Script Date: 25/10/2020 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_patente](
	[id_usuario] [bigint] NOT NULL,
	[id_patente] [bigint] NOT NULL,
	[dvh] [varchar](255) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bitacora] ON 
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (727, 1, N'ALTA', N'LOGIN', N'7+d247OjNaRbyudbI5AbXg==', CAST(N'2020-10-25T15:33:06.283' AS DateTime), N'24d79efa55ee7fd5baac4fd95b6c6812')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (728, 1, N'ALTA', N'LOGIN', N'7+d247OjNaRbyudbI5AbXg==', CAST(N'2020-10-25T15:34:11.417' AS DateTime), N'11a9cdcaa027619826d5a42ade8c91a0')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (729, 1, N'BAJA', N'LISTAR_USUARIO', N'k6VKbRLUiI69aCUypdeojmD5lO2An8dYHHyF5YAatnI=', CAST(N'2020-10-25T15:34:13.603' AS DateTime), N'1173a41681915af97de3603e78f4d00d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (730, 1, N'BAJA', N'LEER_USUARIO', N'2nWo6y/Z0MxsBhqPaUgkcyH8jQoGatdiAl/fPx+4Mt8=', CAST(N'2020-10-25T15:34:15.807' AS DateTime), N'b91ccfe7268a322a030f81aebc473435')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (731, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:17.083' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (732, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:17.090' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (733, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAgE0GYDjVjaAFcz1O5BHew7LFvI9t5DpCBEwr0VfwGqK', CAST(N'2020-10-25T15:34:19.480' AS DateTime), N'c3868f18c1f0acbb4d1fd169f3514bda')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (734, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:19.493' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (735, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:19.497' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (736, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAlj4HNJY5TokFNU6RUWY9vy55NlLLkHRF+bin3DIdswn', CAST(N'2020-10-25T15:34:21.377' AS DateTime), N'9ed2ce2cf4b82c52fa7d74751c994387')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (737, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:21.390' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (738, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:21.393' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (739, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAp7fQaBV5JUhdYbpfNJ65f0euBbS8MR2h/RIESsseHXM', CAST(N'2020-10-25T15:34:23.087' AS DateTime), N'30289b223854e2acaf1d7dee3d4d8721')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (740, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:23.100' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (741, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:23.110' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (742, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAvi947wBy90hwJKA4FNJKz7RVwFSl4yAjLLBkDe1fHpo', CAST(N'2020-10-25T15:34:24.673' AS DateTime), N'89935751267fb1b0986c711fe22bc42a')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (743, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:24.687' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (744, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:24.697' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (745, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAnmSWY4z0lXByQX/8kE3EfxanQIsKus+n+dH5U4infVN', CAST(N'2020-10-25T15:34:26.043' AS DateTime), N'cf0cdf5edaaf3abb5d5a5a0b3e01cd2e')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (746, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:26.057' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (747, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:26.060' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (748, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAm67Zp9VaJw9kS9X5oPJTQEqhPfpETdrhqA6sycHq7T5', CAST(N'2020-10-25T15:34:27.663' AS DateTime), N'a92009d20255d76e7fb31237fa714c27')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (749, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:27.680' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (750, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:27.690' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (751, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAvUnqEJwgSRQHQeUTEzyoIYyj32MOLpSDt5t0nJm2xJE', CAST(N'2020-10-25T15:34:29.407' AS DateTime), N'd6851e59e01d380c5b8a0f78f0620531')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (752, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:29.417' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (753, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:29.423' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (754, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAv1DewAPomtdqAf+srHAUfmMzQNRDFfzSFeK+mJT69+h', CAST(N'2020-10-25T15:34:31.320' AS DateTime), N'5f0282ebdf1b34d860551e37543c68a9')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (755, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:31.330' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (756, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:31.337' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (757, 1, N'ALTA', N'PATENTE', N'XFVLrfDJGI9XDEy1WQgOAlG+tCkp1NXNqUjl001Yb13nyHQN5K8OAEcPJqDVfU1D', CAST(N'2020-10-25T15:34:33.067' AS DateTime), N'55e38b5be31eec64f65c43f64e1d6550')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (758, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMoDv+debDmiUK2PDsJCg4amZL6Qe0ShEJy/VFElJ3Pt+bke1yh7DnIezWTyNPgdtYA==', CAST(N'2020-10-25T15:34:33.080' AS DateTime), N'161576da8de09d2ccec6cd8533420c1d')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (759, 1, N'ALTA', N'PATENTE', N'llfd+MpNKOw+ZFuEGBVXMiKqJzXHKnHWsfBC3fPXeTX0280HTn2NCnzfJD7+vncxqGPOJvuG/zbFeDW8GT4bLQ==', CAST(N'2020-10-25T15:34:33.090' AS DateTime), N'6478ad4de0462e935ef132cf716368da')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (760, 1, N'ALTA', N'FAMILIA', N'llfd+MpNKOw+ZFuEGBVXMqVNEfw3peWpVwWcbuZFp7/x/tl9jHhC2sAWjrWMRHAzEmv1GvTUb5t180UMdrBqZ59J6Ui/Um2QyBk/ialMUX8=', CAST(N'2020-10-25T15:34:36.730' AS DateTime), N'0986d112721faaa37415a67eca0aed88')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (761, 1, N'ALTA', N'FAMILIA', N'llfd+MpNKOw+ZFuEGBVXMvYDxkPikDAjui+HaXuctVVBXRN9/GT1LrzXFwGpeZP2dCyPKZ4lQK1q8KkYLZzOHSs+9kM+qVFZYAb4F48l0Go=', CAST(N'2020-10-25T15:34:36.740' AS DateTime), N'45bac0a8476bc59bb21368d4a3579492')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (762, 1, N'ALTA', N'FAMILIA', N'QuqP89bfiO3S/gX2ps65dSNhyZQWXTaHy00rW/2w0RFPk6ysvU3xOK3w4DmqeW/f4/QjmRV+MR3gFYPvdQmqrw==', CAST(N'2020-10-25T15:34:47.607' AS DateTime), N'54dc43565a8fade3de3eccfee3894c10')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (763, 1, N'ALTA', N'FAMILIA', N'llfd+MpNKOw+ZFuEGBVXMqVNEfw3peWpVwWcbuZFp7/x/tl9jHhC2sAWjrWMRHAzEmv1GvTUb5t180UMdrBqZ59J6Ui/Um2QyBk/ialMUX8=', CAST(N'2020-10-25T15:34:47.617' AS DateTime), N'0986d112721faaa37415a67eca0aed88')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (764, 1, N'ALTA', N'FAMILIA', N'llfd+MpNKOw+ZFuEGBVXMvYDxkPikDAjui+HaXuctVVBXRN9/GT1LrzXFwGpeZP2dCyPKZ4lQK1q8KkYLZzOHSs+9kM+qVFZYAb4F48l0Go=', CAST(N'2020-10-25T15:34:47.620' AS DateTime), N'45bac0a8476bc59bb21368d4a3579492')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (765, 1, N'ALTA', N'FAMILIA', N'QuqP89bfiO3S/gX2ps65db086tkvZigz4i5WjR5bg8gA46nyDwS2YNKqugLLQAsbvW5u3n4P1ArQfZhLxFt9qA==', CAST(N'2020-10-25T15:35:32.920' AS DateTime), N'a02ea6717722e25716220ffcb99d6fdf')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (766, 1, N'ALTA', N'FAMILIA', N'llfd+MpNKOw+ZFuEGBVXMqVNEfw3peWpVwWcbuZFp7/x/tl9jHhC2sAWjrWMRHAzEmv1GvTUb5t180UMdrBqZ59J6Ui/Um2QyBk/ialMUX8=', CAST(N'2020-10-25T15:35:32.930' AS DateTime), N'398756cc0dc8cf48b74b6a3cad4fff39')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (767, 1, N'ALTA', N'FAMILIA', N'llfd+MpNKOw+ZFuEGBVXMvYDxkPikDAjui+HaXuctVVBXRN9/GT1LrzXFwGpeZP2dCyPKZ4lQK1q8KkYLZzOHSs+9kM+qVFZYAb4F48l0Go=', CAST(N'2020-10-25T15:35:32.937' AS DateTime), N'3bdd573dc31d1e9bf5370f1ff83f4a25')
GO
INSERT [dbo].[bitacora] ([id], [id_usuario], [criticidad], [funcionalidad], [descripcion], [fecha], [dvh]) VALUES (768, 1, N'ALTA', N'LOGIN', N'7+d247OjNaRbyudbI5AbXg==', CAST(N'2020-10-25T15:35:41.640' AS DateTime), N'2fada30109629e8aec4d379295fe2061')
GO
SET IDENTITY_INSERT [dbo].[bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[digito_verificador] ON 
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (1, N'BITACORA', N'cde6919d5200ee49e8e159077831829f')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (2, N'USUARIO', N'80d56a0945ff63ea932e3d91167fc986')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (3, N'USUARIO_PATENTE', N'b848fc97e15039659cf48db2ac49de37')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (4, N'PROYECTO', N'9d0254bbc4fe207ff4cbd8c20b90ab9c')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (5, N'PROYECTO_USUARIO', N'ae4fdd92ad8bab915e0118627eb81afd')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (6, N'TAREA', N'8a5f92dbdaa1a177455bfded09b6529c')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (7, N'FAMILIA', N'f7b837db467cdbf130afe2248ac8ed7a')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (8, N'FAMILIA_PATENTE', N'378546465be41ee46dc34044c025d5ca')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (9, N'HORA', N'2f1c373eea8082e8df5869bb05351c1e')
GO
INSERT [dbo].[digito_verificador] ([id], [tabla], [valor]) VALUES (10, N'USUARIO_FAMILIA', N'd4951e6c19caa475143c5ad7c62b849d')
GO
SET IDENTITY_INSERT [dbo].[digito_verificador] OFF
GO
SET IDENTITY_INSERT [dbo].[familia] ON 
GO
INSERT [dbo].[familia] ([id], [nombre], [eliminado], [dvh]) VALUES (1, N'H1DzW0kWZFan1SdgHl560A==', 0, N'84706e26368b00dfba3f50e223544a2f')
GO
INSERT [dbo].[familia] ([id], [nombre], [eliminado], [dvh]) VALUES (3, N'FyNn1d2pWRRUwxuajtUJBA==', 0, N'98d4805a465380022308823943665bc9')
GO
SET IDENTITY_INSERT [dbo].[familia] OFF
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (1, 2, N'c20ad4d76fe97759aa27a0c99bff6710')
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (1, 5, N'9bf31c7ff062936a96d3c8bd1f8f2ff3')
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (1, 7, N'70efdf2ec9b086079795c442636b55fb')
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (1, 8, N'6f4922f45568161a8cdf4ad2299f6d23')
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (1, 9, N'1f0e3dad99908345f7439f8ffabdffc4')
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (1, 10, N'5f93f983524def3dca464469d2cf9f3e')
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (1, 4, N'aab3238922bcc25a6f606eb525ffdc56')
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (3, 1, N'c16a5320fa475530d9583c34fd356ef5')
GO
INSERT [dbo].[familia_patente] ([id_familia], [id_patente], [dvh]) VALUES (3, 3, N'182be0c5cdcd5072bb1864cdee4d3d6e')
GO
SET IDENTITY_INSERT [dbo].[hora] ON 
GO
INSERT [dbo].[hora] ([id], [id_proyecto], [id_tarea], [id_usuario], [fecha], [cantidad], [eliminado], [dvh]) VALUES (1, 1, 1, 2, CAST(N'2020-10-24T20:52:06.697' AS DateTime), CAST(8 AS Decimal(10, 0)), 0, N'f8dd6bc607e6c4693a4eb6236b81285a')
GO
SET IDENTITY_INSERT [dbo].[hora] OFF
GO
SET IDENTITY_INSERT [dbo].[idioma] ON 
GO
INSERT [dbo].[idioma] ([id], [nombre], [eliminado], [code]) VALUES (1, N'Español', 0, N'es')
GO
INSERT [dbo].[idioma] ([id], [nombre], [eliminado], [code]) VALUES (2, N'English', 0, N'en')
GO
SET IDENTITY_INSERT [dbo].[idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[patente] ON 
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (1, N'X8XZecDrMnl7H0ejOWfJjw==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (2, N'bDxAluaZRiQ8ObcChkM0gQ==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (3, N'HsPP0BAA18JWUrzGIV1r+A==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (4, N'a80jLs2lvGMSS1Jeq9olOg==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (5, N'qJktnmov5Sv6bX33VzIQvw==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (6, N'UuHekTMyy46H6mdYPawHeA==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (7, N'vaiq8h/35DqbU2DcUrziow==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (8, N'Tlpgqx6gmjro5TZB1QHFJA==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (9, N'iydH59vewk5RrtLWywxJoA==')
GO
INSERT [dbo].[patente] ([id], [nombre]) VALUES (10, N'oG7mbo+T5nJBH6vzlj3pb1eMGPIFIrUq1IHTDhxB4Kg=')
GO
SET IDENTITY_INSERT [dbo].[patente] OFF
GO
SET IDENTITY_INSERT [dbo].[proyecto] ON 
GO
INSERT [dbo].[proyecto] ([id], [nombre], [horas_estimadas], [valor_hora], [habilitado], [fecha], [eliminado], [dvh]) VALUES (1, N'Pepe', N'daIhzY1oLYfm4H+UXxRHWg==', N't5db5sBXaUnLp1J6youisg==', 1, CAST(N'2020-10-24T20:47:49.927' AS DateTime), 0, N'fc775f17ff04b383ad6c0f7fae727f97')
GO
SET IDENTITY_INSERT [dbo].[proyecto] OFF
GO
INSERT [dbo].[proyecto_usuario] ([id_proyecto], [id_usuario], [dvh]) VALUES (1, 1, N'c197e4b236120e151430bb1ec4a79c7b')
GO
INSERT [dbo].[proyecto_usuario] ([id_proyecto], [id_usuario], [dvh]) VALUES (1, 2, N'e6844641ea13d7cc0ae28b073cf482ec')
GO
SET IDENTITY_INSERT [dbo].[tarea] ON 
GO
INSERT [dbo].[tarea] ([id], [id_proyecto], [titulo], [descripcion], [eliminado], [dvh]) VALUES (1, 1, N'tarea 1', N'dajlsndjkasjda', 0, N'70b943af603571a2a2293ce2fe2db3da')
GO
SET IDENTITY_INSERT [dbo].[tarea] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 
GO
INSERT [dbo].[usuario] ([id], [id_idioma], [nombre], [apellido], [email], [usuario], [disponibilidad], [valor_hora], [habilitado], [intentos], [eliminado], [contrasenia], [dvh]) VALUES (1, 1, N'rolando', N'huber', N'rolandohuber@hotmail.com', N'Ecy+E+O0X9LSJ71OthZ03g==', N'100', N'jvY+fZxY4LEE0hQIOMTPNA==', 1, 0, 0, N'6f777d0ce719a9a6ad1650e3a9929473', N'3a6e95f830b901b38f30cf25249991c6')
GO
INSERT [dbo].[usuario] ([id], [id_idioma], [nombre], [apellido], [email], [usuario], [disponibilidad], [valor_hora], [habilitado], [intentos], [eliminado], [contrasenia], [dvh]) VALUES (2, 1, N'pepe', N'pepe', N'roladnohuber66@gmail.com', N'CDWNxNjeLsAcEMP9ErsVHw==', N'100', N'AZIUp+f3C0G0tGpkDjKL7g==', 1, 0, 0, N'e2d379c422f3da7b57187e06f02e2cdb', N'42aedaae9cfefff37149d5eec3985c44')
GO
INSERT [dbo].[usuario] ([id], [id_idioma], [nombre], [apellido], [email], [usuario], [disponibilidad], [valor_hora], [habilitado], [intentos], [eliminado], [contrasenia], [dvh]) VALUES (3, 1, N'sadasjdnajkdnas', N'kjdnsakjdnajkd', N'rolandohuber@hotmail.com', N'x/7CxYtelszAd/E8/MWoTXrs0db1Sr9XETP+/GI1vrs=', N'2213131', N'hHrOe3eX/x53RuuMfGdd4Q==', 1, 0, 0, N'b635b772957766982963c1d9ec8f75c5', N'd856229a551c2bd3ea17a68e96d37d34')
GO
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
INSERT [dbo].[usuario_familia] ([id_usuario], [id_familia], [dvh]) VALUES (2, 3, N'79d9603b287c404ea99ef7cc0d115421')
GO
INSERT [dbo].[usuario_familia] ([id_usuario], [id_familia], [dvh]) VALUES (3, 3, N'e0dac1595a3769818a6bd9b4bfb2da47')
GO
INSERT [dbo].[usuario_familia] ([id_usuario], [id_familia], [dvh]) VALUES (3, 1, N'b9fef21fb21c4385001ff60576baee5c')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (1, 5, N'9bf31c7ff062936a96d3c8bd1f8f2ff3')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (1, 2, N'c20ad4d76fe97759aa27a0c99bff6710')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 1, N'c16a5320fa475530d9583c34fd356ef5')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 3, N'182be0c5cdcd5072bb1864cdee4d3d6e')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 6, N'19ca14e7ea6328a42e0eb13d585e4c22')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 8, N'a5771bce93e200c36f7cd9dfd0e5deaa')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 9, N'd67d8ab4f4c10bf22aa353e27879133c')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 5, N'1c383cd30b7c298ab50293adfecb7b18')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 4, N'e369853df766fa44e1ed0ff613f563bd')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 7, N'a5bfc9e07964f8dddeb95fc584cd965d')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 10, N'06eb61b839a0cefee4967c67ccb099dc')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (1, 7, N'70efdf2ec9b086079795c442636b55fb')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (1, 9, N'1f0e3dad99908345f7439f8ffabdffc4')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (1, 8, N'6f4922f45568161a8cdf4ad2299f6d23')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (3, 2, N'6364d3f0f495b6ab9dcf8d3b5c6e0b01')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (1, 6, N'c74d97b01eae257e44aa9d5bade97baf')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (1, 10, N'5f93f983524def3dca464469d2cf9f3e')
GO
INSERT [dbo].[usuario_patente] ([id_usuario], [id_patente], [dvh]) VALUES (1, 4, N'aab3238922bcc25a6f606eb525ffdc56')
GO
ALTER TABLE [dbo].[bitacora] ADD  DEFAULT (NULL) FOR [id_usuario]
GO
ALTER TABLE [dbo].[bitacora] ADD  DEFAULT (NULL) FOR [criticidad]
GO
ALTER TABLE [dbo].[bitacora] ADD  DEFAULT (NULL) FOR [funcionalidad]
GO
ALTER TABLE [dbo].[bitacora] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[bitacora] ADD  DEFAULT (NULL) FOR [fecha]
GO
ALTER TABLE [dbo].[bitacora] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[digito_verificador] ADD  DEFAULT (NULL) FOR [tabla]
GO
ALTER TABLE [dbo].[digito_verificador] ADD  DEFAULT (NULL) FOR [valor]
GO
ALTER TABLE [dbo].[familia] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[familia] ADD  DEFAULT (NULL) FOR [eliminado]
GO
ALTER TABLE [dbo].[familia] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[familia_patente] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[hora] ADD  DEFAULT (NULL) FOR [id_proyecto]
GO
ALTER TABLE [dbo].[hora] ADD  DEFAULT (NULL) FOR [id_tarea]
GO
ALTER TABLE [dbo].[hora] ADD  DEFAULT (NULL) FOR [id_usuario]
GO
ALTER TABLE [dbo].[hora] ADD  DEFAULT (NULL) FOR [fecha]
GO
ALTER TABLE [dbo].[hora] ADD  DEFAULT (NULL) FOR [cantidad]
GO
ALTER TABLE [dbo].[hora] ADD  DEFAULT (NULL) FOR [eliminado]
GO
ALTER TABLE [dbo].[hora] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[idioma] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[idioma] ADD  DEFAULT (NULL) FOR [eliminado]
GO
ALTER TABLE [dbo].[patente] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[proyecto] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[proyecto] ADD  DEFAULT (NULL) FOR [horas_estimadas]
GO
ALTER TABLE [dbo].[proyecto] ADD  DEFAULT (NULL) FOR [valor_hora]
GO
ALTER TABLE [dbo].[proyecto] ADD  DEFAULT (NULL) FOR [habilitado]
GO
ALTER TABLE [dbo].[proyecto] ADD  DEFAULT (NULL) FOR [fecha]
GO
ALTER TABLE [dbo].[proyecto] ADD  DEFAULT (NULL) FOR [eliminado]
GO
ALTER TABLE [dbo].[proyecto] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[proyecto_usuario] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[tarea] ADD  DEFAULT (NULL) FOR [id_proyecto]
GO
ALTER TABLE [dbo].[tarea] ADD  DEFAULT (NULL) FOR [titulo]
GO
ALTER TABLE [dbo].[tarea] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[tarea] ADD  DEFAULT (NULL) FOR [eliminado]
GO
ALTER TABLE [dbo].[tarea] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [id_idioma]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [apellido]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [email]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [usuario]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [disponibilidad]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [valor_hora]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [habilitado]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [intentos]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [eliminado]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [contrasenia]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[usuario_familia] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[usuario_patente] ADD  DEFAULT (NULL) FOR [dvh]
GO
ALTER TABLE [dbo].[bitacora]  WITH CHECK ADD  CONSTRAINT [bit_usuario_fk] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[bitacora] CHECK CONSTRAINT [bit_usuario_fk]
GO
ALTER TABLE [dbo].[familia_patente]  WITH CHECK ADD  CONSTRAINT [fp_familia_fk] FOREIGN KEY([id_familia])
REFERENCES [dbo].[familia] ([id])
GO
ALTER TABLE [dbo].[familia_patente] CHECK CONSTRAINT [fp_familia_fk]
GO
ALTER TABLE [dbo].[familia_patente]  WITH CHECK ADD  CONSTRAINT [fp_patente_fk] FOREIGN KEY([id_patente])
REFERENCES [dbo].[patente] ([id])
GO
ALTER TABLE [dbo].[familia_patente] CHECK CONSTRAINT [fp_patente_fk]
GO
ALTER TABLE [dbo].[hora]  WITH CHECK ADD  CONSTRAINT [hora_proyecto] FOREIGN KEY([id_proyecto])
REFERENCES [dbo].[proyecto] ([id])
GO
ALTER TABLE [dbo].[hora] CHECK CONSTRAINT [hora_proyecto]
GO
ALTER TABLE [dbo].[hora]  WITH CHECK ADD  CONSTRAINT [hora_tarea] FOREIGN KEY([id_tarea])
REFERENCES [dbo].[hora] ([id])
GO
ALTER TABLE [dbo].[hora] CHECK CONSTRAINT [hora_tarea]
GO
ALTER TABLE [dbo].[hora]  WITH CHECK ADD  CONSTRAINT [hora_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[hora] CHECK CONSTRAINT [hora_usuario]
GO
ALTER TABLE [dbo].[proyecto_usuario]  WITH CHECK ADD  CONSTRAINT [pu_proyecto_fk] FOREIGN KEY([id_proyecto])
REFERENCES [dbo].[proyecto] ([id])
GO
ALTER TABLE [dbo].[proyecto_usuario] CHECK CONSTRAINT [pu_proyecto_fk]
GO
ALTER TABLE [dbo].[proyecto_usuario]  WITH CHECK ADD  CONSTRAINT [pu_usuario_fk] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[proyecto_usuario] CHECK CONSTRAINT [pu_usuario_fk]
GO
ALTER TABLE [dbo].[tarea]  WITH CHECK ADD  CONSTRAINT [tarea_proyecto] FOREIGN KEY([id_proyecto])
REFERENCES [dbo].[proyecto] ([id])
GO
ALTER TABLE [dbo].[tarea] CHECK CONSTRAINT [tarea_proyecto]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [u_idioma_fk] FOREIGN KEY([id_idioma])
REFERENCES [dbo].[idioma] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [u_idioma_fk]
GO
ALTER TABLE [dbo].[usuario_familia]  WITH CHECK ADD  CONSTRAINT [uf_familia_fk] FOREIGN KEY([id_familia])
REFERENCES [dbo].[familia] ([id])
GO
ALTER TABLE [dbo].[usuario_familia] CHECK CONSTRAINT [uf_familia_fk]
GO
ALTER TABLE [dbo].[usuario_familia]  WITH CHECK ADD  CONSTRAINT [uf_usuario_fk] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[usuario_familia] CHECK CONSTRAINT [uf_usuario_fk]
GO
ALTER TABLE [dbo].[usuario_patente]  WITH CHECK ADD  CONSTRAINT [up_patente_fk] FOREIGN KEY([id_patente])
REFERENCES [dbo].[patente] ([id])
GO
ALTER TABLE [dbo].[usuario_patente] CHECK CONSTRAINT [up_patente_fk]
GO
ALTER TABLE [dbo].[usuario_patente]  WITH CHECK ADD  CONSTRAINT [up_usuario_fk] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[usuario_patente] CHECK CONSTRAINT [up_usuario_fk]
GO
