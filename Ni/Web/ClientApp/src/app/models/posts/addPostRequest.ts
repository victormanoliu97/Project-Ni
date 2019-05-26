import {GenericLoggedInRequest} from '../genericLoggedInRequest';

export class AddPostRequest extends GenericLoggedInRequest {
    title: string;
    content: string;
    tags: string[];
    image: string;
    categoryId: number;
}
