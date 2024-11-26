import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketComponent } from './components/ticket/ticket.component';
import { TicketDetailComponent } from './components/ticket-detail/ticket-detail.component';

const routes: Routes = [
  { path: '', component: TicketComponent },
  { path: 'ticket/:id', component: TicketDetailComponent }, // Rota para detalhes do ticket
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
