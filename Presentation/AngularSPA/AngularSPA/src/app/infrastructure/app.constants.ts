import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })

export class Configuration {
    public server = 'https://localhost:44333/';
    public apiUrl = 'api/';
    public serverWithApiUrl = this.server + this.apiUrl;
    public apiVersion = '?api-version=1.0';
    public userManagementApiPath = 'UserManagement/';
}
