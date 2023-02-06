USE [InvoiceDb]
GO
/****** Object:  Table [dbo].[ArchievedInvoice]    Script Date: 1/23/2023 5:02:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchievedInvoice](
	[InvoiceDate] [date] NOT NULL,
	[InvoiceNo] [int] NOT NULL,
	[CustomerCode] [nvarchar](15) NOT NULL,
	[Amount] [decimal](7, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 1/23/2023 5:02:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerCode] [nvarchar](15) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_CustomerDb] PRIMARY KEY CLUSTERED 
(
	[CustomerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 1/23/2023 5:02:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceDate] [date] NOT NULL,
	[InvoiceNo] [int] IDENTITY(10000,1) NOT NULL,
	[CustomerCode] [nvarchar](15) NOT NULL,
	[Amount] [decimal](7, 2) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2022-03-15' AS Date), 10003, N'PS104', CAST(10000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2022-05-12' AS Date), 10002, N'SP101', CAST(14000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2022-04-20' AS Date), 10008, N'VP205', CAST(17000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-17' AS Date), 10009, N'PS104', CAST(18000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-18' AS Date), 10010, N'SM559', CAST(13000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2022-04-20' AS Date), 10007, N'RM204', CAST(14000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-17' AS Date), 10008, N'SP101', CAST(14000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-14' AS Date), 10001, N'PS104', CAST(12000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2022-01-23' AS Date), 10000, N'SP101', CAST(15000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-18' AS Date), 10013, N'VP205', CAST(14000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[ArchievedInvoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-18' AS Date), 10016, N'SP101', CAST(12000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[Customer] ([CustomerCode], [FirstName], [LastName]) VALUES (N'AS163', N'Axar', N'shah')
GO
INSERT [dbo].[Customer] ([CustomerCode], [FirstName], [LastName]) VALUES (N'PS104', N'Pavan', N'Shinde')
GO
INSERT [dbo].[Customer] ([CustomerCode], [FirstName], [LastName]) VALUES (N'RM204', N'Hemant', N'Mane')
GO
INSERT [dbo].[Customer] ([CustomerCode], [FirstName], [LastName]) VALUES (N'RM847', N'Roshan', N'Mohite')
GO
INSERT [dbo].[Customer] ([CustomerCode], [FirstName], [LastName]) VALUES (N'SM559', N'sameer', N'mohite')
GO
INSERT [dbo].[Customer] ([CustomerCode], [FirstName], [LastName]) VALUES (N'SP101', N'Sachin', N'Patil')
GO
INSERT [dbo].[Customer] ([CustomerCode], [FirstName], [LastName]) VALUES (N'VP205', N'Vinayak', N'Patil')
GO
INSERT [dbo].[Customer] ([CustomerCode], [FirstName], [LastName]) VALUES (N'VS345', N'vaibhav', N'sawant')
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 
GO
INSERT [dbo].[Invoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-18' AS Date), 10014, N'SM559', CAST(3000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[Invoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-23' AS Date), 10019, N'RM847', CAST(12456.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[Invoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-18' AS Date), 10012, N'SP101', CAST(15000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[Invoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-23' AS Date), 10018, N'SP101', CAST(12000.00 AS Decimal(7, 2)))
GO
INSERT [dbo].[Invoice] ([InvoiceDate], [InvoiceNo], [CustomerCode], [Amount]) VALUES (CAST(N'2023-01-18' AS Date), 10017, N'RM204', CAST(12300.00 AS Decimal(7, 2)))
GO
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
ALTER TABLE [dbo].[ArchievedInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ArchievedInvoice_Customer] FOREIGN KEY([CustomerCode])
REFERENCES [dbo].[Customer] ([CustomerCode])
GO
ALTER TABLE [dbo].[ArchievedInvoice] CHECK CONSTRAINT [FK_ArchievedInvoice_Customer]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([CustomerCode])
REFERENCES [dbo].[Customer] ([CustomerCode])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer]
GO
ALTER TABLE [dbo].[ArchievedInvoice]  WITH CHECK ADD  CONSTRAINT [CK_ArchievedInvoice] CHECK  (([Amount]>=(1) AND [Amount]<=(20000)))
GO
ALTER TABLE [dbo].[ArchievedInvoice] CHECK CONSTRAINT [CK_ArchievedInvoice]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [CK_Invoice] CHECK  (([Amount]>=(1) AND [Amount]<=(20000)))
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [CK_Invoice]
GO
/****** Object:  StoredProcedure [dbo].[spAddCustomer]    Script Date: 1/23/2023 5:02:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[spAddCustomer]
@customerCode nvarchar(15),
@firstName nvarchar(25),
@lastName nvarchar(25),
@IsSuccessful bit out
as
BEGIN
	BEGIN TRY 
		INSERT INTO Customer VALUES (@customerCode,@firstName,@lastName);
		SET @IsSuccessful = 1;
	END TRY 
	BEGIN CATCH 
		SET @IsSuccessful = 0;
	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[spAddInvoice]    Script Date: 1/23/2023 5:02:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[spAddInvoice]
@invoiceDate date,
@customerCode nvarchar(15),
@amount decimal(7,2),
@IsSuccessful bit out
as
BEGIN
	BEGIN TRY 
		INSERT INTO Invoice VALUES (@invoiceDate, @customerCode, @amount);
		SET @IsSuccessful = 1;
	END TRY 
	BEGIN CATCH 
		SET @IsSuccessful = 0;
	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[spConfirmPayment]    Script Date: 1/23/2023 5:02:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spConfirmPayment]
@invoiceNo int,
@customerCode nvarchar(15),
@isSuccessful bit out
as
BEGIN

	IF EXISTS(SELECT * FROM Invoice WHERE InvoiceNo = @invoiceNo and CustomerCode = @customerCode) 
	BEGIN 
		BEGIN TRANSACTION 

		BEGIN TRY 

			INSERT INTO ArchievedInvoice 
			SELECT * 
			FROM Invoice 
			WHERE InvoiceNo = @invoiceNo and customerCode = @customerCode;
	
			DELETE FROM Invoice	
			WHERE InvoiceNo = @invoiceNo and customerCode = @customerCode;

			COMMIT TRANSACTION
			SET @isSuccessful = 1

		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH

	END
	ELSE
		BEGIN
			SET @isSuccessful = 0
		END
	
END
GO
/****** Object:  StoredProcedure [dbo].[spSearchText]    Script Date: 1/23/2023 5:02:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spSearchText]
@searchText nvarchar(15)
as
BEGIN
		if(@searchText = 'paid')
		begin
			select i.InvoiceDate as 'Invoice Date' , i.InvoiceNo as 'Number' , i.CustomerCode as 'Customer Code' ,
			CONCAT(c.FirstName ,' ', c.LastName) as 'FullName' , i.Amount , 'paid' as status 
			from ArchievedInvoice as i
			inner join customer as c
			on i.customerCode = c.customerCode
			order by i.InvoiceDate desc
		
		end
		else if(@searchText = 'unpaid')
		begin
			select i.InvoiceDate as 'Invoice Date' , i.InvoiceNo as 'Number' , i.CustomerCode as 'Customer Code' ,
			CONCAT(c.FirstName ,' ', c.LastName) as 'FullName' , i.Amount , 'unpaid' as status 
			from Invoice as i
			inner join customer as c
			on i.customerCode = c.customerCode
			order by i.InvoiceDate desc
		end
		else
		begin
			if exists(select * from customer where CustomerCode like @searchText+'%' )
				BEGIN
					select i.InvoiceDate as 'Invoice Date' , i.InvoiceNo as 'Number' , i.CustomerCode as 'Customer Code' ,
					CONCAT(c.FirstName ,' ', c.LastName) as 'FullName' , i.Amount , 'unpaid' as status
					from Invoice as i
					inner join customer as c
					on i.customerCode = c.customerCode
					where i.customerCode like @searchText+'%'
					Union
					select a.InvoiceDate as 'Invoice Date' , a.InvoiceNo as 'Number' , a.CustomerCode as 'Customer Code' ,
					CONCAT(u.FirstName ,' ', u.LastName) as 'FullName' , a.Amount , 'paid' as status
					from ArchievedInvoice as a
					inner join customer as u
					on a.customerCode = u.customerCode
					where a.customerCode like @searchText+'%'
					order by status desc,[Invoice Date]desc
				END
			else
				BEGIN
					print 'No invoices found with search text as : ' + @searchText;
				END
		end
END
GO







SELECT * FROM CUSTOMER;


