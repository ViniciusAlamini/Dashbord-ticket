import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import {TicketService} from '../../services/ticket.service'
import { Ticket } from '../../models/ticket.models';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrl: './ticket.component.css'
})
export class TicketComponent implements OnInit{
  formulario: any;
  tituloFormulario: string | undefined;
  tickets: Ticket[] = [];
  statusFilter: string = ''; // Add this
  prioridadeFilter: string = ''; // Add this
  clienteFilter: string = ''; // Add this
  moduloFilter: string = ''; // Add this

  constructor(private ticketService: TicketService) { }
  ngOnInit(): void {
    this.ticketService.BuscarTodos().subscribe(result => {
      this.tickets = result;
    })
  }
}
