export class UserLogin {

    public constructor(init?: Partial<UserLogin>) {
        Object.assign(this, init);
    }
    
    public UserName: string;
    public Password: string;
    public CanRememberMe: boolean;
}
