import {AppStateService} from '../../services/app-state/app-state.service';
import {PostService} from '../../services/post/post.service';
import {ModalDismissReasons, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {GenericResponse} from '../../models/genericResponse';
import {Tag} from './tag';

import {Component} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {Categories} from '../../models/category/categories';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent {

  closeResult: string;
  postTitle: string;
  postContent: string;
  postTagsList: Tag[] = [];
  postRequestResponse: GenericResponse;
  categories: Categories;
  private imageSrc = '';
  category: string;

    constructor(public appStateService: AppStateService, private postService: PostService,
                private modalService: NgbModal, public route: ActivatedRoute, public router: Router) {
        this.appStateService = appStateService;
        this.postService = postService;
        this.categories = new Categories();
      this.route.url.subscribe(params => {
        if (params[1] !== undefined) {
          this.category = params[1].path;
          appStateService.loadAppState(this.category);
          console.log('Router param ' + params[1].path);
        } else {
            appStateService.loadAppState();
        }
      });
    }

    open(content) {
        this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
            this.closeResult = `Closed with: ${result}`;
        }, (reason) => {
            this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        });
    }

    goTo(str: string) {
        window.location.assign(str);
    }

    handleInputChange(e) {
        // tslint:disable-next-line:prefer-const
        const file = e.dataTransfer ? e.dataTransfer.files[0] : e.target.files[0];
        const pattern = /image-*/;
        const reader = new FileReader();
        if (!file.type.match(pattern)) {
            alert('invalid format');
            return;
        }
        reader.onload = this._handleReaderLoaded.bind(this);
        reader.readAsBinaryString(file);
    }

    _handleReaderLoaded(e) {
        const reader = e.target;
        this.imageSrc = reader.result;
        console.log(this.imageSrc);
    }

    async addPost(postTitle: string, postContent: string) {
        const tags = [];
        for (const tag of this.postTagsList) {
            tags.push(tag.tag);
        }
        const categoryId = this.categories.categoriesDictionary[this.category];
        const userId = Number( await this.appStateService.getCookie('userId'));
        const authKey = String( await this.appStateService.getCookie('authKey'));

        this.postRequestResponse = await this.postService.addPost(userId, authKey,
            postTitle, btoa(this.imageSrc), postContent, tags, categoryId);
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
