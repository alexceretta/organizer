import { Component, OnInit } from "@angular/core";
import { ToDo } from "../../models/todo";
import { ToDoService } from "../services/todo.service";

@Component({
  selector: "app-todos",
  templateUrl: "./todos.component.html",
  styleUrls: ["./todos.component.css"]
})
export class TodosComponent implements OnInit {
  toDos: ToDo[];
  constructor(private toDoService: ToDoService) {}

  ngOnInit() {
    this.getData();
  }

  getData(): void {
    this.toDoService.getToDos().subscribe(
      toDos =>
        (this.toDos = toDos.sort((a, b) => {
          console.log(a.completed);
          console.log(b.completed);
          return a.completed === b.completed ? 0 : a.completed ? 1 : -1;
        }))
    );
  }

  refreshList() {
    this.getData();
  }
}
