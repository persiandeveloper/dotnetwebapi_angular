import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Enrollment, Teacher,Course, Subject, Student } from './models/teacher-model';
import { environment } from 'src/environments/environment';

@Injectable()
export default class HttpService {

  public API = environment.api;
  public Teacher_API = `${this.API}/Teacher/`;
  public Student_API = `${this.API}/Student/`;
  public Courses_API = `${this.API}/Course/`;
  public Subjects_API = `${this.API}/Subject/`;
  public Enrollment_API = `${this.API}/Enrollment/`;


  constructor(private http: HttpClient) {}

  getAllTeachers(): Observable<Array<Teacher>> {
    return this.http.get<Array<Teacher>>(this.Teacher_API);
  }

  saveTeacher(t: Teacher ){
    if(t.id){
      return this.http.put(this.Teacher_API, t);
    }
    return this.http.post(this.Teacher_API, t);
  }

  saveCourse(t: Course ){
    if(t.id){
      return this.http.put(this.Courses_API, t);
    }
    return this.http.post(this.Courses_API, t);
  }

  saveStudent(t: Student){
    if(t.id){
      return this.http.put(this.Student_API, t);
    }
    return this.http.post(this.Student_API, t);
  }

  saveNewSubject(selectecCourse: number, selectecTeacher: number) : Observable<any> {
    return this.http.post(this.Subjects_API, {CourseId: selectecCourse, TechaerId:selectecTeacher });
  }

  saveNewEnrollment(student: number, subject: number) : Observable<any>{
    return this.http.post(this.Enrollment_API, {StudentId: student, SubjectId: subject });

  }

  updateScore(item : Enrollment){
    return this.http.put(this.Enrollment_API, item);

  }

  getAllStudents(): Observable<Array<Student>> {
    return this.http.get<Array<Student>>(this.Student_API);
  }

  getAllCourses(): Observable<Array<Course>> {
    return this.http.get<Array<Course>>(this.Courses_API);
  }

  
  getAllSubjects(): Observable<Array<Subject>> {
    return this.http.get<Array<Subject>>(this.Subjects_API);
  }

  getAllEnrollments(): Observable<Array<Enrollment>> {
    return this.http.get<Array<Enrollment>>(this.Enrollment_API);
  }

  deleteCourse(id: number): Observable<any> {
    return this.http.delete(`${this.Courses_API}${id}`);
  }

  deleteStudent(id: number): Observable<any> {
    return this.http.delete(`${this.Student_API}${id}`);

  }

  deleteTeacher(id: number): Observable<any> {
    return this.http.delete(`${this.Teacher_API}${id}`);
  }

  deleteSubject(id: number): Observable<any> {
    return this.http.delete(`${this.Subjects_API}${id}`);
  }

  deleteEnrollment(id: number): Observable<any> {
    return this.http.delete(`${this.Enrollment_API}${id}`);
  }

}