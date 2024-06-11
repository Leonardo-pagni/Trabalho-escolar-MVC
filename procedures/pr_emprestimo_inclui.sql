SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_emprestimo_inclui]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_emprestimo_inclui]
GO

CREATE PROCEDURE pr_emprestimo_inclui(@xml_dados_cliente ntext, @cd_usuario_logado int)
WITH ENCRYPTION AS
BEGIN
	SET NOCOUNT ON

	DECLARE	@idocXML	int
	DECLARE	@err		int

	-- Declaração das variáveis
	DECLARE @Email NVARCHAR(200),
			@Senha NVARCHAR(20),
			@CPF NVARCHAR(20)

	-- Preenche objeto DOM a partir do xml enviado
	EXEC  @err = sp_xml_preparedocument @idocXML OUTPUT, @xml_dados_cliente
	SELECT @err = @@error + COALESCE(@err, 4711)

	IF @err <> 0
	BEGIN
		RAISERROR('Falha carregando XML para inclusão do cliente', 16, 1)
		RETURN
	END
	
	INSERT INTO emprestimos (vlrEmprestimo, vlrJuros)
	SELECT 
		vlremprestimo,
		vlrJuros
	FROM
		OPENXML(@idocXML, '/xml/dadosemprestimo/emprestimo') 
	WITH (
		vlremprestimo		  decimal(10,4),
		vlrJuros			  decimal(10,4)
		)

		

 	-- Liberar o objeto DOM
	EXEC sp_xml_removedocument @idocXML

	SET NOCOUNT OFF
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF
GO
