using HelpDeskBackendMVC.Data.Entities;
using Xunit;

namespace HelpDeskBackendMVC.Tests;

public class UsuarioTest
{
	[Fact]
	public void Criar()
	{
		const string USUARIO_NOME = "Fulano de Tal";

		var usuario = Usuario.Create(USUARIO_NOME);

		Assert.NotNull(usuario);
		Assert.Equal(USUARIO_NOME, usuario.Nome);
	}


}
