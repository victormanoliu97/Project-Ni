import {Comment} from './comment';

export class CommentDTO {
    username: string;
    comment: Comment;
    subComments: number;
}
