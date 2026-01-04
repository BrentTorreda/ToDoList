import { Component, inject, model, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TodoService } from '../../services/todo.service';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.css'
})
export class TodoListComponent implements OnInit {
  protected todoService = inject(TodoService);
  
  // Two-way bound signal for the input field
  newTodoTitle = model('');

  ngOnInit() {
    this.todoService.loadAll();
  }

  handleAdd() {
    const val = this.newTodoTitle().trim();
    if (val) {
      this.todoService.add(val);
      this.newTodoTitle.set('');
    }
  }
}