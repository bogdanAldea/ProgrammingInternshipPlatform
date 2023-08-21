import { IdToken } from "msal/lib-commonjs/IdToken";

export class ApplicationToken {
    private readonly _accessToken: string;
    private readonly _idToken: IdToken;

    public constructor(accessToken: string, idToken: IdToken) {
        this._accessToken = accessToken;
        this._idToken = idToken;
    }

    public getAccessToken = (): string => {
        return this._accessToken;
    }
    public getIdToken = (): IdToken => {
        return this._idToken;
    }
}