import { Component, OnInit } from '@angular/core';
import {ResumeService} from "./resume.service";

@Component({
  selector: 'app-resume',
  templateUrl: './resume.component.html',
  styleUrls: ['./resume.component.css']
})
export class ResumeComponent implements OnInit {

  resumeData;
  Careers;
  Educations;
  Parsonal;
  Referees;
  Trainings;

  constructor(private _resume: ResumeService) { }

  ngOnInit(): void {
    this._resume.getData().subscribe(res => {
      this.resumeData = res

      console.log(res)

      res.map(data => {
        this.Careers = data.Career
        this.Educations = data.Educations
        this.Parsonal = data.Personal
        this.Referees = data.Referee
        this.Trainings = data.Trainings
      })
    })
  }

}
