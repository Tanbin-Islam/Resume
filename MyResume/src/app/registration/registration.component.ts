import { Component, OnInit } from '@angular/core';

import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators,
} from "@angular/forms";
import { Router } from "@angular/router";
import {RegisterService} from "./register.service"

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(
    private _fb: FormBuilder,
    private route: Router,
    private register: RegisterService
  ) {}

  emailPattern = "^[a-z0-9_]+@[a-z]+\\.[a-z]{2,3}$";

  ngOnInit(): void {
  }

      /**
   * Login Form
   * Reactive Form
   */
  registerForm = this._fb.group({
    name: new FormControl("", [
      Validators.required,
    ]),
    email: new FormControl("", [
      Validators.required,
      Validators.pattern(this.emailPattern),
    ]),
    password: new FormControl("", [Validators.required]),
    fullname: new FormControl("", [Validators.required])
  });

      /**
   * Get the instance of input field
   */
  get name() {
    return this.registerForm.get("name");
  }
  get email() {
    return this.registerForm.get("email");
  }
  get password() {
    return this.registerForm.get("password");
  }
  get fullname() {
    return this.registerForm.get("fullname");
  }

  onSubmit(){
    var body = {
      UserName: this.registerForm.get("name").value,
      Email: this.registerForm.get("email").value,
      FullName: this.registerForm.get("fullname").value,
      Password: this.registerForm.get("password").value
    };
    
    this.register.register(body).subscribe(res => {
      console.log(res)
    })
  }
}
