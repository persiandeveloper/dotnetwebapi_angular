import { Component, OnInit } from '@angular/core';
import HttpService from '../api-srevice';
import { Course, Subject, Teacher } from '../models/teacher-model';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit {

  subjects : Subject[];

  courses: Course[];
  teachers: Teacher[];


  selectecCourse : number;

  selectecTeacher : number;


  constructor(private service: HttpService) { }

  ngOnInit(): void {
    this.refresh();
    this.getCourses();
    this.getTeachers();
  }

  getCourses(){
    this.service.getAllCourses().subscribe(r => {
     
      this.courses = r;
    });
  }

  getTeachers(){
    this.service.getAllTeachers().subscribe(r => {
     
      this.teachers = r;
    });
  }

  saveNew(){
    if(this.selectecCourse && this.selectecTeacher){
      this.service.saveNewSubject(this.selectecCourse, this.selectecTeacher).subscribe(r => {
     
        this.refresh();
  
      });
    }
    
  }

  delete(item : Subject){
    this.service.deleteSubject(item.id).subscribe(r=> this.refresh());

  }

  refresh(){
    this.service.getAllSubjects().subscribe(r => {
     
      this.subjects = r;
    });
  }

}
