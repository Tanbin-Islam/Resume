import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PersonalComponent} from "./personal/personal.component"
import {ReferencesComponent} from "./references/references.component"
import {EducationComponent} from "./education/education.component"
import {TrainingsComponent} from "./trainings/trainings.component"
import {CandidatesComponent} from "./candidates/candidates.component"
import {ExperiencesComponent} from "./experiences/experiences.component"

@NgModule({
  declarations: [
    PersonalComponent,
    EducationComponent,
    TrainingsComponent,
    ReferencesComponent,
    ExperiencesComponent,
    CandidatesComponent
  ],
  imports: [
    CommonModule
  ]
})
export class HomeModule { }
