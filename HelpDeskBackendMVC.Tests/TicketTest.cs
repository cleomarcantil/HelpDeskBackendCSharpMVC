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

	[Fact]
	public void AdicionarNotaInterna()
	{
		var ticket = new Ticket(1, "Mensagem origem", TicketStatus.EmAberto);
		int usuarioMensagemId = 2;
		string conteudoNota = "Nota interna";

		ticket.AdicionarNotaInterna(usuarioMensagemId, conteudoNota);

		Assert.Equal(ticket.NotasInternas.Last().UsuarioId, usuarioMensagemId);
		Assert.Equal(ticket.NotasInternas.Last().Conteudo, conteudoNota);
	}

	// TODO: AdicionarAnexo

	[Fact]
	public void Encaminhar()
	{
		var ticket = new Ticket(1, "Mensagem origem", TicketStatus.EmAberto);
		int AtendenteDestinoId = 5;
		string notaEncaminhamento = "Nota encaminhamento";

		ticket.Encaminhar(AtendenteDestinoId, notaEncaminhamento);

		Assert.Equal(ticket.NotasInternas.Last().UsuarioId, AtendenteDestinoId);
		Assert.Equal(ticket.NotasInternas.Last().Conteudo, notaEncaminhamento);
		Assert.Equal(ticket.AtendenteId, AtendenteDestinoId);
		Assert.Equal(TicketStatus.Encaminhado, ticket.Status);
	}

	// TODO: FinalizarAtendimento
	// TODO: Consultar

}