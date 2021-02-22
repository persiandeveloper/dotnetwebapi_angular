import { Component, OnInit } from '@angular/core';
import HttpService from '../api-srevice';
import { Enrollment, Student, Subject } from '../models/teacher-model';

@Component({
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrls: ['./grade.component.css']
})
export class GradeComponent implements OnInit {

  grades : Enrollment[];
  students: Student[];
  subjects: Subject[];

  selectecSubject: number;
  selectecStudent: number;

  selectedScore : number;

  constructor(private service: HttpService) { }

  ngOnInit(): void {
    this.refresh();
    this.getStudents();
    this.getSubjects();
  }

  delete(item: Enrollment){
    this.service.deleteEnrollment(item.id).subscribe(r=> this.refresh());
  }

  refresh(){
    this.service.getAllEnrollments().subscribe(r => {
     
      this.grades = r;
    });
  }

  saveNew(){
    if(this.selectecStudent && this.selectecSubject){
      this.service.saveNewEnrollment(this.selectecStudent, this.selectecSubject).subscribe(r => {
     
        this.refresh();
  
      });
    }
  }

  addScore(item : Enrollment){
    item.score = this.selectedScore;
    this.service.updateScore(item).subscribe(r => {
     
      this.refresh();

    });
  }

  getStudents(){
    this.service.getAllStudents().subscribe(r => {
     
      this.students = r;
    });
  }

  getSubjects(){
    this.service.getAllSubjects().subscribe(r => {
     
      this.subjects = r;
    });
  }


}
