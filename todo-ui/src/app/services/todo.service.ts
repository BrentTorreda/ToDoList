import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';

export interface Todo { id: number; title: string; isCompleted: boolean; }

@Injectable({ providedIn: 'root' })
export class TodoService {
  private config = inject(ConfigService);
  private http = inject(HttpClient);
  private readonly apiUrl = `${this.config.apiUrl}/todos`;

  todos = signal<Todo[]>([]);

  loadAll() {
    this.http.get<Todo[]>(this.apiUrl).subscribe(data => this.todos.set(data));
  }

  add(title: string) {
    this.http.post<Todo>(this.apiUrl, null, { params: { title } })
      .subscribe(() => this.loadAll());
  }

  remove(id: number) {
    this.http.delete(`${this.apiUrl}/${id}`).subscribe(() => this.loadAll());
  }
}