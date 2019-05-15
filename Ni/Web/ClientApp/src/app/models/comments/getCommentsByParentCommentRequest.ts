import {GetCommentsByPostRequest} from './getCommentsByPostRequest';

export class GetCommentsByParentCommentRequest extends GetCommentsByPostRequest {
    parentCommentId: number;
}
