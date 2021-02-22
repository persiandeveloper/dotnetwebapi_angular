import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_BASE_HREF } from '@angular/common';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { TeacherComponent } from './teacher/teacher.component';
import { HttpClientModule } from '@angular/common/http';
import HttpService from './api-srevice';
import { StudentComponent } from './student/student.component';
import { HomeComponent } from './home/home.component';
import { CourseComponent } from './course/course.component';
import { SubjectComponent } from './subject/subject.component';
import { GradeComponent } from './grade/grade.component';

import { FormsModule } from '@angular/forms'; 



@NgModule({
  declarations: [
    AppComponent,
    TeacherComponent,
    StudentComponent,
    HomeComponent,
    CourseComponent,
    SubjectComponent,
    GradeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NoopAnimationsModule
  ],
  providers: [
    HttpService,
    {provide: APP_BASE_HREF, useValue: '/'}
],
  bootstrap: [AppComponent]
})
export class AppModule { }
