SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_usuario_login]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_usuario_login]
GO

CREATE PROCEDURE pr_usuario_login(@email varchar(200),@senha varchar(100), @cd_usuario_logado int)
WITH ENCRYPTION AS
BEGIN
	SET NOCOUNT ON




	IF EXISTS (select 1 from usuario where dsemail = @email and dssenha = @senha)
	BEGIN
		select 1,1
	END
	ELSE IF EXISTS (select 1 from usuario where dsemail = @email and dssenha <> @senha)
	BEGIN
	select 1,0
	END
	ELSE IF EXISTS (select 1 from usuario where dsemail <> @email and dssenha = @senha)
	BEGIN
		select 0,1
	END
	ELSE IF EXISTS (select 1 from usuario where dsemail <> @email and dssenha <> @senha)
	BEGIN
		select 0,1
	END
	
		IF EXISTS (select 1 from usuario where dsemail = @email and dssenha = @senha)
	BEGIN
		insert into historico(email, acao, dataAlteracao)	
		select @email, 'Usuario Logou', GETDATE()
	END


	SET NOCOUNT OFF
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF
GO
