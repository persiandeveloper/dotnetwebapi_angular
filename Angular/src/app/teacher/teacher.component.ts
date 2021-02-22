import { Component, OnInit } from '@angular/core';
import HttpService from '../api-srevice';
import { Teacher } from '../models/teacher-model';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {

  teachers: Teacher[];

  teacher: Teacher = { name: "", id: null, birthDate: "" };

  updateMode: boolean = false;

  constructor(private service: HttpService) { }

  ngOnInit(): void {
    this.refresh();
  }

  saveNew() {
    this.service.saveTeacher(this.teacher).subscribe(r => {
      this.teacher = { name: "", id: null, birthDate: "" };
      this.updateMode = false;
      this.refresh();
    })
  }

  enableUpdate(item: Teacher) {
    this.teacher = item;
    this.updateMode= true;
  }

  delete(item: Teacher){
    this.service.deleteTeacher(item.id).subscribe(r=> this.refresh());
  }

  refresh() {
    this.service.getAllTeachers().subscribe(r => {

      this.teachers = r;
      console.log(this.teachers);
    });
  }

}
