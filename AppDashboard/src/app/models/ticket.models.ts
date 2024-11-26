import { Cliente } from "./cliente.models";
import { Modulo } from "./modulo.models";

export interface Ticket {
  ticketId: number;
  titulo: string;
  descricao: string;
  prioridade: number;
  status: string;
  dataAbertura: Date;
  dataEncerramento?: Date;
  clienteId: number;
  cliente: Cliente; // Campo opcional, pois pode ser nulo ou ausente
  moduloId: number;
  modulo: Modulo; // Mesmo caso para módulo
}
