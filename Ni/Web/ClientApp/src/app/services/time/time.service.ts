import { Injectable } from '@angular/core';
import {ServerService} from '../server/server.service';
import {HttpClient} from '@angular/common/http';
import {TimeRequest} from '../../models/time/time-request';
import {TimeResponse} from '../../models/time/time-response';

@Injectable({
  providedIn: 'root'
})
export class TimeService {

  private timeUrl = 'https://timefunctionniproject.azurewebsites.net/api/Function1';

  constructor(public serverService: ServerService, public http: HttpClient) {
    this.serverService = serverService;
    this.http = http;
  }

  async getTime() {
    const request = new TimeRequest();

    const currentDate = new Date();
    const dateStr = currentDate.getFullYear() + '-' + (currentDate.getMonth() + 1) + '-' +
      currentDate.getDate() + ' ' + currentDate.getHours() + ':' +
      currentDate.getMinutes() + ':' + currentDate.getSeconds() + '.' +
      currentDate.getMilliseconds();

    console.log(dateStr);

    request.Date = dateStr;
    request.TimeZone = '-10';

    return this.http.get(this.timeUrl, {
      responseType: 'text',
      params: request as any,
      headers: this.serverService.requestHeaders
    }).toPromise();
  }
}
