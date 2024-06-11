SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_emprestimo_seleciona]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_emprestimo_seleciona]
GO

CREATE PROCEDURE pr_emprestimo_seleciona(@usuario int)
WITH ENCRYPTION AS
BEGIN
	SET NOCOUNT ON


	select  sum(vlrEmprestimo) as vlrEmprestimo, 
			sum(vlrJuros)	   as vlrJuros
			from emprestimos


	SET NOCOUNT OFF
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF
GO
