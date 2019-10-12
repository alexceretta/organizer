import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { ToDo } from "src/models/todo";
import { ToDoService } from "src/app/services/todo.service";
import { MatCheckboxChange } from "@angular/material/checkbox";

@Component({
  selector: "app-todo-form",
  templateUrl: "./todo-form.component.html",
  styleUrls: ["./todo-form.component.css"]
})
export class TodoFormComponent implements OnInit {
  private previous: ToDo = null;
  isEditing = false;
  isNew = true;
  toDo = new ToDo();

  @Input() currentToDo: ToDo;
  @Output() changeToDoList: EventEmitter<ToDo> = new EventEmitter();

  constructor(private toDoService: ToDoService) {}

  ngOnInit() {
    this.toDo = this.currentToDo || this.toDo;
    this.isNew = this.toDo.id === undefined;
  }

  newToDo() {
    this.toDo = new ToDo();
    this.toggleEdition();
  }

  editToDo() {
    this.previous = { ...this.toDo };
    this.toggleEdition();
  }

  toggleEdition(): void {
    this.isEditing = !this.isEditing;
    if (!this.isEditing && this.previous !== null) {
      this.toDo = { ...this.previous };
      this.previous = null;
    }
  }

  createToDo(): void {
    this.toDoService.createToDo(this.toDo).subscribe(() => {
      this.changeToDoList.emit();
      this.toggleEdition();
    });
  }

  updateToDo(): void {
    this.toDoService.updateToDo(this.toDo).subscribe(() => {
      this.changeToDoList.emit();
      this.toggleEdition();
    });
  }

  deleteToDo(): void {
    this.toDoService.deleteToDo(this.toDo.id).subscribe(() => {
      this.changeToDoList.emit();
    });
  }

  toggleStatus(event: MatCheckboxChange): void {
    this.toDo.completed = event.checked;
    this.toDoService.updateToDo(this.toDo).subscribe(() => {
      console.log("ToDo status changed");
    });
  }
}
