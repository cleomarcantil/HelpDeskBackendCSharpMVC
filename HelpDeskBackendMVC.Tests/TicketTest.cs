using HelpDeskBackendMVC.Data.Entities;
using System.Linq;
using Xunit;

namespace HelpDeskBackendMVC.Tests;

public class TicketTest
{
	[Fact]
	public void Criar()
	{
		const string MENSAGEM_CHAMADO = "Chamado teste";
		var autorDoChamado = Usuario.Create("Usuário teste");
		var departamentoDoChamado = Departamento.Create("Departamento teste");

		var ticket = Ticket.Create(autorDoChamado, departamentoDoChamado, MENSAGEM_CHAMADO);

		Assert.NotNull(ticket);
		Assert.Equal(autorDoChamado, ticket.Autor);
		Assert.Equal(departamentoDoChamado, ticket.Departamento);
		Assert.Equal(MENSAGEM_CHAMADO, ticket.Mensagens.Last().Conteudo);
		Assert.Equal(TicketStatus.EmAberto, ticket.Status);
	}

	[Fact]
	public void IniciarAtendimento()
	{
		var autorDoChamado = Usuario.Create("Usuário teste");
		var departamentoDoChamado = Departamento.Create("Departamento teste");
		var ticket = new Ticket(autorDoChamado, departamentoDoChamado, "...", TicketStatus.EmAberto);
		var atendenteDoChamado = Usuario.Create("Atendente teste");

		ticket.IniciarAtendimento(atendenteDoChamado);

		Assert.Equal(atendenteDoChamado, ticket.Atendente);
		Assert.Equal(TicketStatus.EmAtendimento, ticket.Status);
	}

	[Fact]
	public void AdicionarMensagem()
	{
		var autorDoChamado = Usuario.Create("Usuário teste");
		var departamentoDoChamado = Departamento.Create("Departamento teste");
		var ticket = new Ticket(autorDoChamado, departamentoDoChamado, "Mensagem origem", TicketStatus.EmAberto);
		var usuarioMensagem = Usuario.Create("Usuário teste mensagem");
		string conteudoMensagem = "Resposta";

		ticket.AdicionarMensagem(usuarioMensagem, conteudoMensagem);

		Assert.Equal(usuarioMensagem, ticket.Mensagens.Last().Autor);
		Assert.Equal(conteudoMensagem, ticket.Mensagens.Last().Conteudo);
	}

	[Fact]
	public void AdicionarNotaInterna()
	{
		var autorDoChamado = Usuario.Create("Usuário teste");
		var departamentoDoChamado = Departamento.Create("Departamento teste");
		var ticket = new Ticket(autorDoChamado, departamentoDoChamado, "Mensagem origem", TicketStatus.EmAberto);
		var usuarioNota = Usuario.Create("Usuário teste nota");
		string conteudoNota = "Nota interna";

		ticket.AdicionarNotaInterna(usuarioNota, conteudoNota);

		Assert.Equal(usuarioNota, ticket.NotasInternas.Last().Autor);
		Assert.Equal(conteudoNota, ticket.NotasInternas.Last().Conteudo);
	}

	// TODO: AdicionarAnexo

	[Fact]
	public void Encaminhar()
	{
		var autorDoChamado = Usuario.Create("Usuário teste");
		var departamentoDoChamado = Departamento.Create("Departamento teste");
		var ticket = new Ticket(autorDoChamado, departamentoDoChamado, "Mensagem origem", TicketStatus.EmAberto);
		var atendenteDestino = Usuario.Create("Atendente destino");
		string notaEncaminhamento = "Nota encaminhamento";

		ticket.Encaminhar(atendenteDestino, notaEncaminhamento);

		Assert.Equal(atendenteDestino, ticket.NotasInternas.Last().Autor);
		Assert.Equal(notaEncaminhamento, ticket.NotasInternas.Last().Conteudo);
		Assert.Equal(atendenteDestino, ticket.Atendente);
		Assert.Equal(TicketStatus.Encaminhado, ticket.Status);
	}

	[Fact]
	public void FinalizarAtendimento()
	{
		var autorDoChamado = Usuario.Create("Usuário teste");
		var departamentoDoChamado = Departamento.Create("Departamento teste");
		var ticket = new Ticket(autorDoChamado, departamentoDoChamado, "Mensagem origem", TicketStatus.EmAberto);
		var atendenteFinalizacao = Usuario.Create("Atendente finalização"); ;
		string notaFinalizacao = "Nota finalização";

		ticket.Finalizar(atendenteFinalizacao, notaFinalizacao);

		Assert.Equal(atendenteFinalizacao, ticket.NotasInternas.Last().Autor);
		Assert.Equal(notaFinalizacao, ticket.NotasInternas.Last().Conteudo);
		Assert.Null(ticket.Atendente);
		Assert.Equal(TicketStatus.Finalizado, ticket.Status);
	}



	// TODO: Consultar

}