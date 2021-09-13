using HelpDeskBackendMVC.Data.Entities;
using Xunit;

namespace HelpDeskBackendMVC.Tests;

public class TicketTest
{
	[Fact]
	public void Criar()
	{
		const int USUARIO_CHAMADO = 1;
		const string MENSAGEM_CHAMADO = "Chamado teste";

		var ticket = Ticket.Create(USUARIO_CHAMADO, MENSAGEM_CHAMADO);

		Assert.NotNull(ticket);
		Assert.Equal(USUARIO_CHAMADO, ticket.UsuarioId);
		Assert.Equal(MENSAGEM_CHAMADO, ticket.Mensagens.Last().Conteudo);
		Assert.Equal(TicketStatus.EmAberto, ticket.Status);
	}

	[Fact]
	public void IniciarAtendimento()
	{
		var atendenteId = 9;
		var ticket = new Ticket(1, "...", TicketStatus.EmAberto);

		ticket.IniciarAtendimento(atendenteId);

		Assert.NotNull(ticket.AtendenteId);
		Assert.Equal(atendenteId, ticket.AtendenteId);
		Assert.Equal(TicketStatus.EmAtendimento, ticket.Status);
	}

	[Fact]
	public void AdicionarMensagem()
	{
		var ticket = new Ticket(1, "Mensagem origem", TicketStatus.EmAberto);
		int usuarioMensagemId = 2;
		string conteudoMensagem = "Resposta";

		ticket.AdicionarMensagem(usuarioMensagemId, conteudoMensagem);

		Assert.Equal(ticket.Mensagens.Last().UsuarioId, usuarioMensagemId);
		Assert.Equal(ticket.Mensagens.Last().Conteudo, conteudoMensagem);
	}

	// TODO: AdicionarNotaInterna
	// TODO: AdicionarAnexo
	// TODO: Encaminhar
	// TODO: FinalizarAtendimento
	// TODO: Consultar

}