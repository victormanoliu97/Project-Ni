import {Component, Input, OnInit} from '@angular/core';
import {PostDTO} from '../../models/posts/postDTO';
import {AppStateService} from '../../services/app-state/app-state.service';

@Component({
    selector: 'app-post-list',
    templateUrl: './post-list.component.html',
    styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {

    @Input() posts: PostDTO[];

    constructor(public appStateService: AppStateService) {
        this.appStateService = appStateService;
    }

    ngOnInit() {
    }

}
