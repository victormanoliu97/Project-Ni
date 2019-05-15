import {Component, Input, OnInit} from '@angular/core';
import {PostDTO} from '../../models/posts/postDTO';

@Component({
    selector: 'app-post',
    templateUrl: './post.component.html',
    styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

    @Input() post: PostDTO;

    constructor() {
    }

    ngOnInit() {
    }

}
