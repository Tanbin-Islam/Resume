import { Component, OnInit } from '@angular/core';
import { LoginService } from "../login/login.service";
import { Router } from "@angular/router";


@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  constructor(private auth: LoginService, protected router: Router) {}


  ngOnInit(): void {
    this.router.navigate(["/login"]);
    // this.auth.setLoggedIn(false);
    localStorage.removeItem("loggedIn");
  }

}
