using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskBackendMVC.Data.Entities
{
	public class Ticket
	{
		public Ticket(string mensagem, TicketStatus status, int? atendenteId = null)
		{
			Mensagem = mensagem;
			Status = status;
			AtendenteId = atendenteId;
		}

		public string Mensagem { get; private set; }

		public TicketStatus Status { get; private set; }

		public int? AtendenteId { get; private set; }

		public static Ticket Create(string mensagem)
		{
			var ticket = new Ticket(mensagem, TicketStatus.EmAberto);

			return ticket;
		}

		public void IniciarAtendimento(int atendenteId)
		{
			AtendenteId = atendenteId;
			Status = TicketStatus.EmAtendimento;
		}
	}

	public enum TicketStatus
	{
		EmAberto,
		EmAtendimento,
	}

}
