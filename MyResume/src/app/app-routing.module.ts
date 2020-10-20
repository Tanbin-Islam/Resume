import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ResumeComponent } from './resume/resume.component';
import {RegistrationComponent} from "./registration/registration.component"
import {LoginComponent} from "./login/login.component";
import { LogoutComponent } from "./logout/logout.component";
import { HomeComponent } from './home/home.component';
import {AuthGuard} from "./login/auth.guard"

const routes: Routes = [
  {path: "", component: ResumeComponent, pathMatch: "full"},
  {path: "home", component: HomeComponent, canActivate: [AuthGuard]},
  {path: "login", component:LoginComponent},
  { path: "logout", component: LogoutComponent },
  {path: "register", component:RegistrationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }

export const routingComponent = [
  ResumeComponent,
  LoginComponent,
  LogoutComponent,
  RegistrationComponent,
  HomeComponent
];