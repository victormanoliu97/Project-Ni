import {GenericResponse} from '../genericResponse';

export class AuthResponse extends GenericResponse {
    userId: number;
    authKey: string;
}
