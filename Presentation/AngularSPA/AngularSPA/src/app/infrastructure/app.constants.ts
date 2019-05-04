import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })

export class Configuration {
    public server = 'https://localhost:44388/';
    public apiUrl = 'api/';
    public apiVersion = 'v1.0/';
    public serverApiVersionUrl = this.server + this.apiUrl + this.apiVersion;
    public userManagementApiPath = 'UserManagement/';
}
