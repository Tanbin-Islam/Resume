import { Injectable } from '@angular/core';
import { HttpClient  } from "@angular/common/http";
import {Register} from "./register"
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  serverUrl = "http://localhost:51273/api/";

  constructor(private _http: HttpClient) {

   }

  register(data): Observable<Register>{
    return this._http.post<Register>(this.serverUrl + "ApplicationUser/Register", data);
  }
}
