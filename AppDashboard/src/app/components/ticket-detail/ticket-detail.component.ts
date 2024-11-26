import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TicketService } from '../../services/ticket.service';
import { Ticket } from '../../models/ticket.models';

@Component({
  selector: 'app-ticket-detail',
  templateUrl: './ticket-detail.component.html',
  styleUrls: ['./ticket-detail.component.css']
})
export class TicketDetailComponent implements OnInit {
  ticket: Ticket | null = null;
  isEditing: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private ticketService: TicketService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const ticketId = Number(this.route.snapshot.paramMap.get('id'));
    if (ticketId) {
      this.ticketService.BuscarPorId(ticketId).subscribe(ticket => {
        this.ticket = ticket;
      });
    }
  }

  finalizarTicket(): void {
    if (this.ticket) {
      this.ticket.status = 'Finalizado'; // Exemplo de mudança de status
      this.ticket.dataEncerramento = new Date(); // Atualiza a data de encerramento
      this.ticketService.Atualizar(this.ticket.ticketId!, this.ticket).subscribe(() => {
        alert('Ticket finalizado com sucesso!');
        this.router.navigate(['/']); // Volta para a tela principal
      });
    }
  }

  salvarAlteracoes(): void {
    if (this.ticket) {
      this.ticketService.Atualizar(this.ticket.ticketId!, this.ticket).subscribe(() => {
        alert('Alterações salvas com sucesso!');
        this.isEditing = false;
      });
    }
  }
}
