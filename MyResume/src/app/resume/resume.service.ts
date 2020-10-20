import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ResumeService {

  constructor(private _http: HttpClient) { }

  getData(){
    return this._http.get<any>("http://localhost:51273/api/candidates");
  }
}
