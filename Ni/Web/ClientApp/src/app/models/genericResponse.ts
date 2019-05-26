export class GenericResponse {
    statusCode: number;
    errors: string[];
}

export class BingSerachRequest {
    q: string;
}

export class AiTextRequest {
    documents: AiTextDoc[];
}

export class AiTextDoc {
    id: string;
    text: string;
}
