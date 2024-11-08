import { Component } from '@angular/core';
import { EventLogsModel } from '../models/event-logs.model';
import { EventLogsService } from '../services/event-logs.service';
import { Message } from 'primeng/api';

@Component({
  selector: 'app-add-event-logs',
  templateUrl: './add-event-logs.component.html',
  styleUrl: './add-event-logs.component.css',
})
export class AddEventLogsComponent {
  public visible: boolean = false;
  public eventLogs: EventLogsModel = new EventLogsModel();
  public desc: string = '';
  messages: Message[]=[];
  constructor(private eventLogsService: EventLogsService) {}
  ngOnInit(): void {}

  Clear() {
    this.eventLogs = new EventLogsModel();
  }

  Save() {
    this.eventLogs.idType = 2;
    this.eventLogs.description = this.eventLogs.description?.trim();
    this.eventLogsService.Post(this.eventLogs).subscribe((response) => {
      if (response) {
        this.Clear();
      }
    },
    (error) => {
      this.messages = [
        { severity: 'error', summary: error.error.title }
      ];
      
    }
    );
  }
}
