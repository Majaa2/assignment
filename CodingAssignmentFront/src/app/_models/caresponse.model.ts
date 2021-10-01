export class CAResponse {
  ResponseCode!: number;
  ResponseMessage!: string;
  ErrorList!: Array<ResponseError>;
  Result!: any;
}

export class ResponseError {
  ValueField!: string;
  ErrorDescription!: string;
}
