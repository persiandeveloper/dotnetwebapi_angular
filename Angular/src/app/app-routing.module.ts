import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { CourseComponent } from './course/course.component';
import { GradeComponent } from './grade/grade.component';
import { HomeComponent } from './home/home.component';
import { StudentComponent } from './student/student.component';
import { SubjectComponent } from './subject/subject.component';
import { TeacherComponent } from './teacher/teacher.component';

const routes: Routes = [ { path: '', component: HomeComponent, pathMatch: 'full' },
{ path: 'Teacher', component: TeacherComponent },
{ path: 'Student', component: StudentComponent },
{ path: 'Courses', component: CourseComponent },
{ path: 'Subjects', component: SubjectComponent },
{ path: 'Grades', component: GradeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
