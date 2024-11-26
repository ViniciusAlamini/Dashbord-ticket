import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from "ngx-bootstrap/modal"

import { TicketService } from './services/ticket.service';
import { TicketComponent } from './components/ticket/ticket.component';
import { TicketDetailComponent } from './components/ticket-detail/ticket-detail.component';
import { FilterTicketsPipe } from './components/filter-tickets.pipe';

@NgModule({
  declarations: [
    AppComponent,
    TicketComponent,
    TicketDetailComponent,
    FilterTicketsPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    FormsModule
  ],
  providers: [HttpClientModule, TicketService],
  bootstrap: [AppComponent]
})
export class AppModule { }
