import {Component, Input, OnInit} from '@angular/core';
import {CommentService} from '../../services/comment/comment.service';
import {CommentDTO} from '../../models/comments/commentDTO';
import {DomSanitizer, SafeStyle} from '@angular/platform-browser';
import {ModalDismissReasons, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {AppStateService} from '../../services/app-state/app-state.service';

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
    closeResult: string;
    postContentText: string;

    constructor(public commentService: CommentService,
                public appStateService: AppStateService,
                public domSanitizer: DomSanitizer, private modalService: NgbModal) {
        this.commentService = commentService;
        this.appStateService = appStateService;
        this.domSanitizer = domSanitizer;
        this.modalService = modalService;
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

    open(content) {
        this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
            this.closeResult = `Closed with: ${result}`;
        }, (reason) => {
            this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        });
    }

    async addSubComment() {
        const response = await this.commentService.addSubcomment(
            this.appStateService.auth.userId,
            this.appStateService.auth.authKey,
            this.postId, this.comment.comment.id, this.postContentText);
        console.log(
            this.appStateService.auth.userId,
            this.appStateService.auth.authKey);
        console.log(response);
    }

    dateToString(str: string) {
        const date = new Date(str.split('.')[0].replace('T', ' '));
        console.log(date);
        return date.toDateString() + date.toTimeString();
    }

    private getDismissReason(reason: any): string {
        if (reason === ModalDismissReasons.ESC) {
            return 'by pressing ESC';
        } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
            return 'by clicking on a backdrop';
        } else {
            return `with: ${reason}`;
        }
    }

}
