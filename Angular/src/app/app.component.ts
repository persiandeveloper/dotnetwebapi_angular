import { Component } from '@angular/core';
import HttpService from './api-srevice';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private httpService: HttpService) {}

  title = 'Angular';
}
