export class UserModel {
    public UserId: number;
    public UserName: string;
    public Token: string;
    public ExpiresOn: Date;
    public LoggedOn: Date;
    public IsUserAuthenticated: boolean;
    public IsUserAccountLocked: boolean;
    public IsUserAccountDisabled: boolean;
    public IsUserAccountFound: boolean;
}
