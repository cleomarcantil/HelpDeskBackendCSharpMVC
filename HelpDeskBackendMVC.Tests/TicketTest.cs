using HelpDeskBackendMVC.Data.Entities;
using Xunit;

namespace HelpDeskBackendMVC.Tests;

public class TicketTest
{
	[Fact]
	public void Criar()
	{
		const string MENSAGEM_CHAMADO = "Chamado teste";

		var ticket = Ticket.Create(MENSAGEM_CHAMADO);

		Assert.NotNull(ticket);
		Assert.Equal(MENSAGEM_CHAMADO, ticket.Mensagem);
		Assert.Equal(TicketStatus.EmAberto, ticket.Status);
	}

	[Fact]
	public void IniciarAtendimento()
	{
		var atendenteId = 9;
		var ticket = new Ticket("...", TicketStatus.EmAberto);

		ticket.IniciarAtendimento(atendenteId);

		Assert.NotNull(ticket.AtendenteId);
		Assert.Equal(atendenteId, ticket.AtendenteId);
		Assert.Equal(TicketStatus.EmAtendimento, ticket.Status);
	}

	// TODO: AdicionarMensagem
	// TODO: AdicionarNotaInterna
	// TODO: AdicionarAnexo
	// TODO: Encaminhar
	// TODO: FinalizarAtendimento
	// TODO: Consultar

}