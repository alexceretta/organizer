import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { ToDo } from "src/models/todo";

@Injectable({
  providedIn: "root"
})
export class ToDoService {
  private url = environment.baseUrl + "/todo";
  private httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" })
  };

  constructor(private http: HttpClient) {}

  getToDos(): Observable<ToDo[]> {
    return this.http
      .get<ToDo[]>(this.url)
      .pipe(tap(() => console.log("Got ToDos")));
  }

  getToDo(id: string): Observable<ToDo> {
    return this.http.get<ToDo>(`${this.url}/${id}`);
  }

  createToDo(toDo: ToDo): Observable<ToDo> {
    return this.http
      .post<ToDo>(this.url, toDo, this.httpOptions)
      .pipe(
        tap((newToDo: ToDo) =>
          console.log(`Created new task ${newToDo.description}`)
        )
      );
  }

  updateToDo(toDo: ToDo): Observable<ToDo> {
    return this.http
      .put<ToDo>(`${this.url}/${toDo.id}`, toDo, this.httpOptions)
      .pipe(
        tap((updatedToDo: ToDo) =>
          console.log(`Updated task ${updatedToDo.description}`)
        )
      );
  }

  deleteToDo(id: string): Observable<ToDo> {
    return this.http.delete<ToDo>(`${this.url}/${id}`, this.httpOptions).pipe(
      tap(() => {
        console.log(`Deleted task ${id}`);
      })
    );
  }
}
