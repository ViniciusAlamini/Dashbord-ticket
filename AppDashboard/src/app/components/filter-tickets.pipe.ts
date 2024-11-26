import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filterTickets'
  })
  export class FilterTicketsPipe implements PipeTransform {
    transform(
      tickets: any[], 
      statusFilter?: string, 
      prioridadeFilter?: string,
      clienteFilter?: string,
      moduloFilter?: string
    ): any[] {
      if (!tickets) return [];
  
      return tickets.filter(ticket => {
        const matchStatus = !statusFilter || ticket.status === statusFilter;
        const matchPrioridade = !prioridadeFilter || ticket.prioridade === prioridadeFilter;
        const matchCliente = !clienteFilter || ticket.cliente.nome.toLowerCase().includes(clienteFilter.toLowerCase());
        const matchModulo = !moduloFilter || ticket.modulo.nome.toLowerCase().includes(moduloFilter.toLowerCase());
        
        return matchStatus && matchPrioridade && matchCliente && matchModulo;
      });
    }
  }