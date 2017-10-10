/*
EntryMeibo の配置スクリプト

このコードはツールによって生成されました。
このファイルへの変更は、正しくない動作の原因になる可能性があると共に、
コードが再生成された場合に失われます。
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "EntryMeibo"
:setvar DefaultFilePrefix "EntryMeibo"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
SQLCMD モードを検出して、SQLCMD モードがサポートされていない場合にスクリプトの実行を無効にします。
SQLCMD モードを有効化した後でスクリプトを再度有効にするには、次を実行します:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'このスクリプトを正常に実行するには SQLCMD モードを有効にする必要があります。';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
/*
テーブル [dbo].[tEntryMeibo] の列 eTimeStamp の型は現在  ROWVERSION NULL ですが、 DATE NULL に変更されます。暗黙的または明示的な変換はありません。
*/
GO
PRINT N'テーブル [dbo].[tEntryMeibo] の再構築を開始しています...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tEntryMeibo] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [eNameSei]         NVARCHAR (20)  NOT NULL,
    [eNameNamae]       NVARCHAR (20)  NOT NULL,
    [eNameSeiKana]     NVARCHAR (20)  NOT NULL,
    [eNameNamaeKana]   NVARCHAR (20)  NOT NULL,
    [eNenrei]          NVARCHAR (20)  NULL,
    [eJitakuRosen]     NVARCHAR (50)  NULL,
    [eJitakuMoyorieki] NVARCHAR (50)  NULL,
    [eJitakuToEki]     NVARCHAR (20)  NULL,
    [eShigotoKibou]    NVARCHAR (800) NULL,
    [eEmail]           VARCHAR (50)   NOT NULL,
    [ePhone]           NVARCHAR (50)  NULL,
    [eMendan1Date]     DATE           NULL,
    [eMendan1Ampm]     CHAR (4)       NULL,
    [eMendan2Date]     DATE           NULL,
    [eMendan2Ampm]     CHAR (4)       NULL,
    [eMendan3Date]     DATE           NULL,
    [eMendan3Ampm]     CHAR (4)       NULL,
    [eQuestion]        NVARCHAR (800) NULL,
    [eTimeStamp]       DATE           NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_tEntryMeibo1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tEntryMeibo])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tEntryMeibo] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tEntryMeibo] ([Id], [eNameSei], [eNameNamae], [eNameSeiKana], [eNameNamaeKana], [eNenrei], [eJitakuRosen], [eJitakuMoyorieki], [eJitakuToEki], [eShigotoKibou], [eEmail], [ePhone], [eMendan1Date], [eMendan1Ampm], [eMendan2Date], [eMendan2Ampm], [eMendan3Date], [eMendan3Ampm], [eQuestion], [eTimeStamp])
        SELECT   [Id],
                 [eNameSei],
                 [eNameNamae],
                 [eNameSeiKana],
                 [eNameNamaeKana],
                 [eNenrei],
                 [eJitakuRosen],
                 [eJitakuMoyorieki],
                 [eJitakuToEki],
                 [eShigotoKibou],
                 [eEmail],
                 [ePhone],
                 [eMendan1Date],
                 [eMendan1Ampm],
                 [eMendan2Date],
                 [eMendan2Ampm],
                 [eMendan3Date],
                 [eMendan3Ampm],
                 [eQuestion],
                 [eTimeStamp]
        FROM     [dbo].[tEntryMeibo]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tEntryMeibo] OFF;
    END

DROP TABLE [dbo].[tEntryMeibo];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tEntryMeibo]', N'tEntryMeibo';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_tEntryMeibo1]', N'PK_tEntryMeibo', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'データベースの更新のトランザクション部分が成功しました。'
COMMIT TRANSACTION
END
ELSE PRINT N'データベースの更新のトランザクション部分が失敗しました。'
GO
DROP TABLE #tmpErrors
GO
PRINT N'更新が完了しました。';


GO
