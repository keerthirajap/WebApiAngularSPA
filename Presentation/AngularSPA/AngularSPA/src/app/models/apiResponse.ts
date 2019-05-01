export class ListResponse<T> {
    Message: string;
    DidError: boolean;
    DidValidationError: boolean;
    ErrorMessage: string;
    RequestId: string;
    Model: T;
}

export class SingleResponse<T> {
    Message: string;
    DidError: boolean;
    DidValidationError: boolean;
    ErrorMessage: string;
    RequestId: string;
    Model: T;
}

export class Response {
    Message: string;
    DidError: boolean;
    DidValidationError: boolean;
    ErrorMessage: string;
}
