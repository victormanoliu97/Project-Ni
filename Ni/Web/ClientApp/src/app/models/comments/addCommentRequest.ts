import {GenericLoggedInRequest} from '../genericLoggedInRequest';

export class AddCommentRequest extends GenericLoggedInRequest {
    postId: number;
    content: string;
}

