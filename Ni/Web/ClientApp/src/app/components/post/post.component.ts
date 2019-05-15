import {Component, Input, OnInit} from '@angular/core';
import {PostDTO} from '../../models/posts/postDTO';
import {CommentService} from '../../services/comment/comment.service';
import {CommentDTO} from '../../models/comments/commentDTO';
import {BingService} from '../../services/bing/bing.service';

@Component({
    selector: 'app-post',
    templateUrl: './post.component.html',
    styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

    @Input() post: PostDTO;
    commentsExtended = false;
    comments: CommentDTO[];

    constructor(public commentService: CommentService,
                public bingService: BingService) {
        this.commentService = commentService;
    }

    async ngOnInit() {
    }

    async loadComments() {
        const commentsResponse = await this.commentService.getCommentsByPost(this.post.post.id);
        this.comments = commentsResponse.comments;
    }

    async onExtendClick() {
        this.commentsExtended = !this.commentsExtended;
        if (this.commentsExtended) {
            this.loadComments();
        }
    }

    async clickOnTag(tag: string) {
        const response = await this.bingService.bingSearch(tag);
        window.open(response['webPages']['value'][0]['url']);
    }

}
