USE [supershop]
GO
/****** Object:  Table [dbo].[T_Item]    Script Date: 5/9/2018 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Item](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[ReorderLevel] [int] NOT NULL,
 CONSTRAINT [PK_T_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_Item] ON 

INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (1, 3, 101, N'Primo F2', 10)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (2, 3, 101, N'Primo F3', 10)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (3, 2, 101, N'J2', 10)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (4, 5, 100, N'Football', 15)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (6, 3, 101, N'GH', 15)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (7, 2, 103, N'Note', 22)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (8, 2, 101, N'J1', 5)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (9, 1, 105, N'i3', 20)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (10, 1, 105, N'i5', 22)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (11, 1, 105, N'i7', 15)
INSERT [dbo].[T_Item] ([ID], [CompanyID], [CategoryID], [ItemName], [ReorderLevel]) VALUES (12, 4, 102, N'Laptop', 30)
SET IDENTITY_INSERT [dbo].[T_Item] OFF
ALTER TABLE [dbo].[T_Item]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[T_Category] ([catID])
GO
ALTER TABLE [dbo].[T_Item]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_Company] ([ComID])
GO
