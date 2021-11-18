import { number, string } from "yup/lib/locale";

export interface Dictionary<T> {
    [Key: string]: T;
}

export enum GlobalKeys {
    LoggedUserKey = 'loggedUserKey',
    EncryptKey = "encryptKey",
}
export enum Locale {
    English = 'English',
    VietNam = 'Việt Nam'
}
export enum ResultCode {
    Invalid = -2,
    Unknown = -1,
    UnAuthorized = 0,
    Success = 1,
    Error = 2,
    RegisterExistEmail = 3,
    RegisterExistUserName = 4,
    NotExistUser = 5,
    NotExistEmail = 51,
}
export interface AppSetting {
    BaseUrl: string;
    GoogleClientId: string;
}

export type ApiResponse<T> = {
    resultCode: ResultCode,
    messages: any,
    resource: T,
};

export type ApiRequest<T> = {
    metaData?: MetaData,
    payload: T
};

export type Paging = {
    index: number;
    size: number;
}

export type MetaData = {
    paging: Paging,
    sortBy: string[],
    orderBy: string[],
}











