import {Injectable} from '@angular/core';
import {AuthResponse} from '../../models/auth/authResponse';
import {AuthService} from '../auth/auth.service';
import {PostDTO} from '../../models/posts/postDTO';
import {PostService} from '../post/post.service';
import {BingService} from '../bing/bing.service';
import {AiTextService} from '../ai-text/ai-text.service';
import {CookieService} from 'ngx-cookie-service';

@Injectable({
    providedIn: 'root'
})
export class AppStateService {

    auth: AuthResponse;
    posts: PostDTO[] = [];

    constructor(public authService: AuthService,
                public postService: PostService,
                public bingService: BingService,
                public aiTextService: AiTextService,
                public cookieService: CookieService) {
        this.authService = authService;
        this.postService = postService;
        this.postService = postService;
        this.aiTextService = aiTextService;
        this.cookieService = cookieService;
    }

    async loadAppState(category: string = '') {
      let postsResponse = null;
        if (category !== '') {
            postsResponse = await this.postService.getAllPostsByCategory(category);
        } else {
            postsResponse = await this.postService.getAllPosts();
        }
        this.posts = this.posts.concat(postsResponse.posts);
        console.log(this.posts);
        console.log(postsResponse);
        const textResponse = await this.aiTextService.textSearch('Corn');
        console.log(textResponse);
    }

    async setCookie(cookieName: string, cookieValue: string) {
      this.cookieService.set(cookieName, cookieValue);
    }

    async getCookie(cookieName: string) {
      return this.cookieService.get(cookieName);
    }
}
