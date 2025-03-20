import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Todo} from "../Models/todo.models";

@Injectable({
  providedIn: 'root'
})
export class TodoService{
  private apiUrl = 'http://localhost:5178/api/todos';
  constructor(private http: HttpClient) {
  }

  getTodos():Observable<Todo[]> {
    return this.http.get<Todo[]>(this.apiUrl)
  }

  addTodo(todo:Todo):Observable<Todo> {
    return this.http.post<Todo>(this.apiUrl, todo)
  }
  updateToDo(todo:Todo):Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${todo.id}`, todo)
  }

  deleteToDo(id: number):Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }
}
