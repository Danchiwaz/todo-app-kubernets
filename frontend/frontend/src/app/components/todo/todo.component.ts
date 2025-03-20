import {Component, OnInit} from '@angular/core';
import {Todo} from "../../Models/todo.models";
import {TodoService} from "../../Services/todo.service";
import {FormsModule} from "@angular/forms";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf
  ],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.scss'
})
export class TodoComponent implements OnInit{
  todos: Todo[] = [];
  newTodo: string = ''

  constructor(private todoService: TodoService) {
  }

ngOnInit() {
this.loadTodos();
}
loadTodos(): void {
    this.todoService.getTodos().subscribe((data) => {
      this.todos = data;
    })
}
addTodo(){
    if(!this.newTodo.trim()) return;
    const todo: Todo = {title: this.newTodo, isCompleted: false}
  this.todoService.addTodo(todo).subscribe(() => {
    this.newTodo = '';
    this.loadTodos();
  })
}

  toggleComplete(todo: Todo) {
    todo.isCompleted = !todo.isCompleted;
    this.todoService.updateToDo(todo).subscribe(() => this.loadTodos())
}
deleteTodo(id: number) {
    this.todoService.deleteToDo(id).subscribe(() => this.loadTodos());
}
}
