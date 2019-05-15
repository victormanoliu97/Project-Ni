import {AddCommentRequest} from './addCommentRequest';

export class AddSubCommentRequest extends AddCommentRequest {
    parentCommentId: number;
}
