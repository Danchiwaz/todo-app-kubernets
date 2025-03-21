import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {TodoComponent} from "./components/todo/todo.component";
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TodoComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'frontend';
}
