import {Injectable} from '@angular/core';
import {ServerService} from '../server/server.service';
import {HttpClient} from '@angular/common/http';
import {GenericResponse} from '../../models/genericResponse';
import {AddCommentRequest} from '../../models/comments/addCommentRequest';
import {AddSubCommentRequest} from '../../models/comments/addSubCommentRequest';
import {GetCommentsByPostRequest} from '../../models/comments/getCommentsByPostRequest';
import {GetCommentsResponse} from '../../models/comments/getCommentsResponse';
import {GetCommentsByParentCommentRequest} from '../../models/comments/getCommentsByParentCommentRequest';

@Injectable({
    providedIn: 'root'
})
export class CommentService {

    private postsUrl = 'comment/Post/';
    private subUrl = 'comment/Sub/';

    constructor(public serverService: ServerService,
                public http: HttpClient) {
        this.serverService = serverService;
        this.http = http;
    }

    async addCommentToPost(requesterId: number, authKey: string, postId: number, content: string) {
        const request = new AddCommentRequest();
        request.requesterId = requesterId;
        request.authKey = authKey;
        request.postId = postId;
        request.content = content;
        return this.http.post<GenericResponse>(this.serverService.mainServerUrl + this.postsUrl, request,
            {headers: this.serverService.requestHeaders}).toPromise();
    }

    async addSubcomment(requesterId: number, authKey: string, postId: number, parentCommentId: number, content: string) {
        const request = new AddSubCommentRequest();
        request.requesterId = requesterId;
        request.authKey = authKey;
        request.postId = postId;
        request.parentCommentId = parentCommentId;
        request.content = content;
        return this.http.post<GenericResponse>(this.serverService.mainServerUrl + this.subUrl, request,
            {headers: this.serverService.requestHeaders}).toPromise();
    }

    async getCommentsByPost(postId: number) {
        const request = new GetCommentsByPostRequest();
        request.postId = postId;
        return this.http.get<GetCommentsResponse>(this.serverService.mainServerUrl + this.postsUrl, {
            params: request as any,
            headers: this.serverService.requestHeaders
        }).toPromise();
    }

    async getCommentsByParentComment(postId: number, parentCommentId: number) {
        const request = new GetCommentsByParentCommentRequest();
        request.postId = postId;
        request.parentCommentId = parentCommentId;
        return this.http.get<GetCommentsResponse>(this.serverService.mainServerUrl + this.subUrl, {
            params: request as any,
            headers: this.serverService.requestHeaders
        }).toPromise();
    }
}
