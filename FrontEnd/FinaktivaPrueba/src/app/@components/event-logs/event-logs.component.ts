import { Component } from '@angular/core';
import { EventLogsService } from '../services/event-logs.service';
import { EventLogsModel } from '../models/event-logs.model';
import { TypeEventLogsService } from '../services/type-event-logs.service';
import { TypeEventLogsModel } from '../models/type-event-logs.model';
import { Message } from 'primeng/api';
import { SignalRService } from '../services/signalr-service';

@Component({
  selector: 'app-event-logs',
  templateUrl: './event-logs.component.html',
  styleUrl: './event-logs.component.css'
})
export class EventLogsComponent {
public eventLogs : EventLogsModel[]=[];
public typeEventLogs : TypeEventLogsModel[]=[];
messages: Message[]=[];

  constructor(
    private eventLogsService: EventLogsService,
    private typeEventLogsService: TypeEventLogsService,
    private signalRService: SignalRService
  ) {}
  
  ngOnInit(): void {  
    this.GetAll();
    this.GetAllTypeEventLogs();
    this.signalRService.emitterNotify.subscribe((message) => {
      this.GetAll();
    });
  }

  GetAll(): void{
    this.eventLogsService.Get().subscribe(
      (response) => {
        this.eventLogs = response;
        this.eventLogs.forEach(element => {
          element.type = element?.typeEventLogs?.type;
        });
      },
      (error) => {
        this.messages = [
          { severity: 'error', summary: error.statusText }
        ];
        
      }
    );
  }

  GetAllTypeEventLogs(): void{
    this.typeEventLogsService.Get().subscribe(
      (response) => {
        this.typeEventLogs = response;
      }
    );
  }
}
