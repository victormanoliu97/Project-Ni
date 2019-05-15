import { Injectable } from '@angular/core';
import {AppStateService} from '../app-state/app-state.service';
import {HttpClient} from '@angular/common/http';
import {ServerService} from '../server/server.service';
import {GetPostsResponse} from '../../models/posts/getPostsResponse';
import {GetLatestPostsRequest} from '../../models/posts/getLatestPostsRequest';
import {GetPostByIdRequest} from '../../models/posts/getPostByIdRequest';
import {GenericResponse} from '../../models/genericResponse';
import {AddPostRequest} from '../../models/posts/addPostRequest';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private postsUrl = 'post/';
  private postIdUrl = 'post/Id/';
  private postLatestUrl = 'post/Latest/';
  private postsAllUrl = 'post/All/';

  constructor(public serverService: ServerService,
              public http: HttpClient) {
    this.serverService = serverService;
    this.http = http;
  }

  async addPost(title: string, content: string, tags: string[]) {
    const request = new AddPostRequest();
    request.title = title;
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
    return this.http.get<GetPostsResponse>(this.serverService.mainServerUrl + this.postIdUrl, {
      params: request as any,
      headers: this.serverService.requestHeaders
    }).toPromise();
  }
}
