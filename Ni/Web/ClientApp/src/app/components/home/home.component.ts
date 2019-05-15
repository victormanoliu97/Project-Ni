import {Component} from '@angular/core';
import {AppStateService} from '../../services/app-state/app-state.service';
import {PostService} from '../../services/post/post.service';
import {ModalDismissReasons, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {GenericResponse} from '../../models/genericResponse';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {

  closeResult: string;
  postTitle: string;
  postContent: string;
  postTags: string;
  postTagsList: string[] = [];
  postRequestResponse: GenericResponse;

    constructor(public appStateService: AppStateService, private postService: PostService, private modalService: NgbModal) {
        this.appStateService = appStateService;
        this.postService = postService;
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

  async addPost(postTitle: string, postContent: string, postTags: string) {
      this.postTagsList.push(postTags);
      this.postRequestResponse = await this.postService.addPost(this.appStateService.auth.userId, this.appStateService.auth.authKey,
        postTitle, postContent, this.postTagsList);
  }

}
