import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PostDTO} from '../../models/posts/postDTO';
import {CommentService} from '../../services/comment/comment.service';
import {CommentDTO} from '../../models/comments/commentDTO';
import {BingService} from '../../services/bing/bing.service';
import {ModalDismissReasons, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {GenericResponse} from '../../models/genericResponse';
import {AppStateService} from '../../services/app-state/app-state.service';
import {AiTextService} from '../../services/ai-text/ai-text.service';
import {TimeService} from '../../services/time/time.service';

@Component({
    selector: 'app-post',
    templateUrl: './post.component.html',
    styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

    @Input() post: PostDTO;
    @Input() big = false;
    // tslint:disable-next-line:no-output-on-prefix
    @Output() onSelect = new EventEmitter<PostDTO>();
    commentsExtended = false;
    comments: CommentDTO[];
    closeResult: string;
    addCommentRequestResponse: GenericResponse;
    postContentText: string;
    language: string;

    constructor(public commentService: CommentService,
                public bingService: BingService,
                public aiTextService: AiTextService,
                public timeService: TimeService,
                private modalService: NgbModal,
                public appStateService: AppStateService) {
        this.commentService = commentService;
        this.bingService = bingService;
        this.aiTextService = aiTextService;
        this.appStateService = appStateService;
        this.timeService = timeService;
    }

    async ngOnInit() {
        await this.getTextLanguage();
        if (this.big) {
            this.loadComments();
        }
    }

    async loadComments() {
        const commentsResponse = await this.commentService.getCommentsByPost(this.post.post.id);
        // for (const entry of commentsResponse.comments) {
          // entry.comment.date = await this.timeService.getTime();
        // }
        this.comments = commentsResponse.comments;
    }

    async onExtendClick() {
        this.onSelect.emit(this.post);
        // this.commentsExtended = !this.commentsExtended;
        // if (this.commentsExtended) {
        //     this.loadComments();
        // }
    }

    async clickOnTag(tag: string) {
        const response = await this.bingService.bingSearch(tag);
        window.open(response['webPages']['value'][0]['url']);
    }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
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

  async addPostComment() {
      const response = await this.commentService.addCommentToPost(
        this.appStateService.auth.userId,
        this.appStateService.auth.authKey,
        this.post.post.id, this.postContentText);
      console.log(
          this.appStateService.auth.userId,
          this.appStateService.auth.authKey);
      console.log(response);
  }

  async getTextLanguage() {
        const response = await this.aiTextService.textSearch(this.post.post.text);
        console.log(response);
        this.language = response['documents'][0]['detectedLanguages'][0]['name'];
  }

}
