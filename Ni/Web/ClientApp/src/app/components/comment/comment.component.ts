import {Component, Input, OnInit} from '@angular/core';
import {CommentService} from '../../services/comment/comment.service';
import {CommentDTO} from '../../models/comments/commentDTO';
import {DomSanitizer, SafeStyle} from '@angular/platform-browser';

@Component({
    selector: 'app-comment',
    templateUrl: './comment.component.html',
    styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

    @Input() postId: number;
    @Input() comment: CommentDTO;
    @Input() level: number;
    subComments: CommentDTO[];
    cssstyle: string;
    safeStyle: SafeStyle;

    constructor(public commentService: CommentService,
                public domSanitizer: DomSanitizer) {
        this.commentService = commentService;
        this.domSanitizer = domSanitizer;
    }

    async ngOnInit() {
        this.cssstyle = 'color: rgb(' + (this.level + 1) * 100 + ',0,0);';
        this.safeStyle = this.domSanitizer.bypassSecurityTrustStyle(this.cssstyle);
        this.loadComments();
    }

    async loadComments() {
        const commentsResponse = await this.commentService.getCommentsByParentComment(this.postId, this.comment.comment.id);
        this.subComments = commentsResponse.comments;
    }

}
