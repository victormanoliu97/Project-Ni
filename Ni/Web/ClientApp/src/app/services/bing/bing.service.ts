import { Injectable } from '@angular/core';
import {BingSerachRequest} from '../../models/genericResponse';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BingService {
  private bingUrl = 'https://api.cognitive.microsoft.com/bing/v7.0/search'
  constructor(public http: HttpClient) {
    this.http = http;
  }

  bingSearch(query: string) {
    const request = new BingSerachRequest();

    const requestHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Ocp-Apim-Subscription-Key': 'aba6a2700f7d4cd69b7f2d9edce47219'
    });
    request.q = query;
    return this.http.get(this.bingUrl, {
      params: request as any,
      headers: requestHeaders
    }).toPromise();
  }
}
