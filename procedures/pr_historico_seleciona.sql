SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_historico_seleciona]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_historico_seleciona]
GO

CREATE PROCEDURE pr_historico_seleciona(@usuario int)
WITH ENCRYPTION AS
BEGIN
	SET NOCOUNT ON


	select email,acao,dataAlteracao from historico


	SET NOCOUNT OFF
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF
GO
