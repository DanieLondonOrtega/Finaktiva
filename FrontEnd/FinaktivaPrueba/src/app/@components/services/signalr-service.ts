import { BuiltinType } from '@angular/compiler';
import { EventEmitter, Injectable } from '@angular/core';
import { HubConnectionBuilder, HubConnection } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  public hubConnection: HubConnection;
  emitterNotify: EventEmitter<boolean> = new EventEmitter();
  constructor() {
    let builder = new HubConnectionBuilder();
    this.hubConnection = builder
      .withUrl('https://localhost:7222/current-time')
      .build();     
      
      this.hubConnection.on("LoadingGetAll",(message)=>{
        this.emitterNotify.emit(message);
      });

      this.hubConnection.start();
  }
}
