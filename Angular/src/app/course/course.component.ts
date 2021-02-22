import { Component, OnInit } from '@angular/core';
import HttpService from '../api-srevice';
import { Course } from '../models/teacher-model';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  courses : Course[];

  course : Course = { average: "", name: "" , id : null, students : null, teachers : null};


  updateMode: boolean = false;


  constructor(private service: HttpService) { }

  ngOnInit(): void {
    this.refresh();
  }

  saveNew() {
    this.service.saveCourse(this.course).subscribe(r => {
      this.course = { average: "", name: "" , id : null, students : null, teachers : null};
      this.updateMode = false;
      this.refresh();
    })
  }

  enableUpdate(item: Course) {
    this.course = item;
    this.updateMode= true;
  }

  delete(item: Course){
    this.service.deleteCourse(item.id).subscribe(r=> this.refresh());
  }

  refresh() {
    this.service.getAllCourses().subscribe(r => {
     
      this.courses = r;
    });
  }
}
