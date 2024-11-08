import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TypeEventLogsService {
  private httpOptions: any;
  constructor(private http: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };
  }

  public Get(): Observable<any> {
    return this.http.get<any>(
      'https://localhost:7222/api/TypeEventLogs',
      this.httpOptions
    );
  }
}