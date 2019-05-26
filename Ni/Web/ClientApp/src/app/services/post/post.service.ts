import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ServerService} from '../server/server.service';
import {GetPostsResponse} from '../../models/posts/getPostsResponse';
import {GetLatestPostsRequest} from '../../models/posts/getLatestPostsRequest';
import {GetPostByIdRequest} from '../../models/posts/getPostByIdRequest';
import {GenericResponse} from '../../models/genericResponse';
import {AddPostRequest} from '../../models/posts/addPostRequest';
import {GetPostResponse} from '../../models/posts/getPostResponse';
import {GetAllPostsByCategoryRequest} from '../../models/posts/getAllPostsByCategoryRequest';

@Injectable({
    providedIn: 'root'
})
export class PostService {

    private postsUrl = 'Post';
    private postIdUrl = 'post/Id/';
    private postLatestUrl = 'post/Latest/';
    private postsAllUrl = 'post/All/';
    private postsAllCategoryUrl = 'post/Category/';

    constructor(public serverService: ServerService,
                public http: HttpClient) {
        this.serverService = serverService;
        this.http = http;
    }

    async addPost(requesterId: number, authKey: string, title: string, image: string, content: string, tags: string[]) {
        const request = new AddPostRequest();
        request.requesterId = requesterId;
        request.authKey = authKey;
        request.title = title;
        request.image = image;
        request.content = content;
        request.tags = tags;
        return this.http.post<GenericResponse>(this.serverService.mainServerUrl + this.postsUrl, request,
            {headers: this.serverService.requestHeaders}).toPromise();
    }

    async getAllPosts() {
        return this.http.get<GetPostsResponse>(this.serverService.mainServerUrl + this.postsAllUrl, {
            headers: this.serverService.requestHeaders
        }).toPromise();
    }
    async getAllPostsByCategory(category: string) {
        const request = new GetAllPostsByCategoryRequest();
        request.categoryURL = category;
        return this.http.get<GetPostsResponse>(this.serverService.mainServerUrl + this.postsAllCategoryUrl, {
            params: request as any,
            headers: this.serverService.requestHeaders
        }).toPromise();
    }

    async getlatestPosts(start: number, count: number) {
        const request = new GetLatestPostsRequest();
        request.start = start;
        request.count = count;
        return this.http.get<GetPostsResponse>(this.serverService.mainServerUrl + this.postLatestUrl, {
            params: request as any,
            headers: this.serverService.requestHeaders
        }).toPromise();
    }

    async getPostById(id: number) {
        const request = new GetPostByIdRequest();
        request.postId = id;
        return this.http.get<GetPostResponse>(this.serverService.mainServerUrl + this.postIdUrl, {
            params: request as any,
            headers: this.serverService.requestHeaders
        }).toPromise();
    }
}
