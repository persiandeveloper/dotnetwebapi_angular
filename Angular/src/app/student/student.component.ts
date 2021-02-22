import { Component, OnInit } from '@angular/core';
import HttpService from '../api-srevice';
import { Student } from '../models/teacher-model';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  students : Student[];

  student: Student = {name  : "", id : null};

  updateMode: boolean = false;

  constructor(private service: HttpService) { }

  ngOnInit(): void {
   this.refresh();
  }

  saveNew() {
    this.service.saveStudent(this.student).subscribe(r => {
      this.student =  {name  : "", id : null};
      this.updateMode = false;
      this.refresh();
    })
  }

  enableUpdate(item: Student) {
    this.student = item;
    this.updateMode= true;
  }

  delete(item: Student){
    this.service.deleteStudent(item.id).subscribe(r=> this.refresh());
  }


  refresh(){
    this.service.getAllStudents().subscribe(r => {
     
      this.students = r;
    });
  }

}
