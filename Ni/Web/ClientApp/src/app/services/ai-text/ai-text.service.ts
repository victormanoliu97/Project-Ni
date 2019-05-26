import {Injectable} from '@angular/core';
import {AiTextDoc, AiTextRequest} from '../../models/genericResponse';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class AiTextService {

    accessKey = '751da7dd841a40ea9f41e7b77e462ad5';
    uri = 'https://westeurope.api.cognitive.microsoft.com';
    path = '/text/analytics/v2.1/languages';

    constructor(public http: HttpClient) {
        this.http = http;
    }

    textSearch(query: string) {
        const request = new AiTextRequest();
        const requestHeaders = new HttpHeaders({
            'Content-Type': 'application/json',
            'Ocp-Apim-Subscription-Key': this.accessKey
        });
        request.documents = [];
        request.documents.push(new AiTextDoc());
        request.documents[0].id = '1';
        request.documents[0].text = query;
        return this.http.post(this.uri + this.path, request, {headers: requestHeaders}).toPromise();
    }
}
