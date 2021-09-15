using HelpDeskBackendMVC.Data.Entities;
using Xunit;

namespace HelpDeskBackendMVC.Tests;

public class DepartamentoTest
{
	[Fact]
	public void Criar()
	{
		const string DEPARTAMENTO_NOME = "Departamento 01";

		var departamento = Departamento.Create(DEPARTAMENTO_NOME);

		Assert.NotNull(departamento);
		Assert.Equal(DEPARTAMENTO_NOME, departamento.Nome);
	}

}