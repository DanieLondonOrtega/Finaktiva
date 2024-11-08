import { TypeEventLogsModel } from "./type-event-logs.model";

export class EventLogsModel {
    id?: number;
    idType?: number;
    description?: string;
    date?: Date;
    type?: string;
    typeEventLogs?: TypeEventLogsModel;
  }