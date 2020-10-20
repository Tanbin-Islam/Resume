import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {Login} from "./login"
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  serverUrl = "http://localhost:51273/api/";
  constructor(private _http: HttpClient) { }

  login(login): Observable<Login> {
    return this._http.post<Login>(this.serverUrl + "ApplicationUser/Login", login);
  }
  // logout() {
  //   return this._http.get<logout>(this.serverUrl + "/logout");
  // }
}
