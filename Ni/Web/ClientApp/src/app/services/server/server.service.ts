import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServerService {

  mainServerUrl = 'https://http://project-ni.azurewebsites.net/api';
  
  constructor() { }
}
