USE [CPROJECT]
GO
SET IDENTITY_INSERT [dbo].[Organizations] ON 

INSERT [dbo].[Organizations] ([id], [name], [inn], [legal_adress], [physical_adress]) VALUES (1, N'Организация 12345', 123456789012, N'Москва г., Новоуличная ул., 123 д., стр. 228', N'Москва г., Новоуличная ул., 123 д., стр. 228')
INSERT [dbo].[Organizations] ([id], [name], [inn], [legal_adress], [physical_adress]) VALUES (2, N'Афшоры Петровича', 123321222333, N'Москва г., Сертенский бульв., 333 д.', N'Кипр')
INSERT [dbo].[Organizations] ([id], [name], [inn], [legal_adress], [physical_adress]) VALUES (3, N'Шоколадка', 666666666666, N'Москва г., Балаклавский пр-п., 69 д.', N'Москва г., Балаклавский пр-п., 69 д.')
SET IDENTITY_INSERT [dbo].[Organizations] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([id], [surname], [name], [patronymic], [birth_date], [passport_series], [passport_number], [organization_id]) VALUES (1, N'Рагожникова', N'Анна', N'', CAST(N'1990-01-01' AS Date), 1111, 111111, 1)
INSERT [dbo].[Employees] ([id], [surname], [name], [patronymic], [birth_date], [passport_series], [passport_number], [organization_id]) VALUES (2, N'Лучинина', N'Вероника', N'Анатольевна', CAST(N'1995-01-01' AS Date), 1212, 111131, 1)
INSERT [dbo].[Employees] ([id], [surname], [name], [patronymic], [birth_date], [passport_series], [passport_number], [organization_id]) VALUES (3, N'Богуславец', N'Кирилл', N'Петрович', CAST(N'2003-01-01' AS Date), 2222, 411111, 2)
INSERT [dbo].[Employees] ([id], [surname], [name], [patronymic], [birth_date], [passport_series], [passport_number], [organization_id]) VALUES (4, N'Бездельников', N'Петя', N'Агафоньевич', CAST(N'1979-01-01' AS Date), 4321, 115811, 3)
INSERT [dbo].[Employees] ([id], [surname], [name], [patronymic], [birth_date], [passport_series], [passport_number], [organization_id]) VALUES (5, N'Танков', N'Танк', N'Танкович', CAST(N'1988-01-01' AS Date), 4563, 141115, 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
