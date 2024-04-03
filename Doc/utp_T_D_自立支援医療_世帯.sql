USE [Usolia障害者福祉システム]
GO

/****** Object:  UserDefinedTableType [dbo].[utp_T_D_自立支援医療_世帯]    Script Date: 2024/04/03 9:31:58 ******/
CREATE TYPE [dbo].[utp_T_D_自立支援医療_世帯] AS TABLE(
	[支給認定基準世帯員_宛名番号] [bigint] NULL,
	[支給認定基準世帯員氏名] [nvarchar](100) NULL,
	[支給認定基準世帯員氏名_氏] [nvarchar](50) NULL,
	[支給認定基準世帯員氏名_名] [nvarchar](50) NULL,
	[支給認定基準世帯員カナ氏名] [nvarchar](100) NULL,
	[支給認定基準世帯員カナ氏名_氏] [nvarchar](50) NULL,
	[支給認定基準世帯員カナ氏名_名] [nvarchar](50) NULL,
	[支給認定基準世帯員続柄コード_1] [varchar](2) NULL,
	[支給認定基準世帯員続柄コード_2] [varchar](2) NULL,
	[支給認定基準世帯員続柄コード_3] [varchar](2) NULL,
	[支給認定基準世帯員続柄コード_4] [varchar](2) NULL,
	[支給認定基準世帯員生年月日] [date] NULL,
	[世帯員住民税均等割額] [money] NULL,
	[世帯員住民税所得割額] [money] NULL,
	[世帯員課税非課税区分コード] [varchar](1) NULL,
	[世帯員合計所得金額] [money] NULL,
	[世帯員障害年金等] [money] NULL,
	[世帯員手当等] [money] NULL,
	[世帯員収入額] [money] NULL,
	[世帯員旧所得割計算前所得割額] [money] NULL,
	[世帯員年少扶養人数] [int] NULL,
	[世帯員特定扶養人数] [int] NULL,
	[世帯員備考] [nvarchar](50) NULL
)
GO


