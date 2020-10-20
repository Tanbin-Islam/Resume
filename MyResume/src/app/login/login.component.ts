import { Component, OnInit } from '@angular/core';

import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators,
} from "@angular/forms";
import { Router } from "@angular/router";

import {LoginService} from "./login.service"

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(
    private _fb: FormBuilder,
    private auth: LoginService,
    private route: Router
  ) {}
  emailPattern = "^[a-z0-9_]+@[a-z]+\\.[a-z]{2,3}$";

  ngOnInit(): void {
  }

    /**
   * Login Form
   * Reactive Form
   */
  loginForm = this._fb.group({
    email: new FormControl("", [
      Validators.required,
    ]),
    password: new FormControl("", [Validators.required]),
  });

    /**
   * Get the instance of input field
   */
  get email() {
    return this.loginForm.get("email");
  }
  get password() {
    return this.loginForm.get("password");
  }

  /**
   * On form Submission
   */
  onSubmit() {

    var body = {
      UserName: this.loginForm.get("email").value,
      Password: this.loginForm.get("password").value
    };

    this.auth.login(body).subscribe((res) => {
      console.log(res)
      // if(res){
      //   this.auth.setLoggedIn(true);
      //   this.route.navigateByUrl("/");
      // }else{
      //   this.auth.setLoggedIn(false);
      //   alert("Invalid Credentials Provided");
      // }
    });
  }
}
