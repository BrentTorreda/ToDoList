import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ConfigService {
  private http = inject(HttpClient);
  private configData: any;

  async loadConfig() {
    try {
      // We use a relative path. The dev server maps /assets/ to src/assets/
      this.configData = await lastValueFrom(
        this.http.get('/assets/config.json')
      );
    } catch (err) {
      console.error('Could not load config', err);
      // Fallback so the app doesn't crash if the file is missing
      this.configData = { apiUrl: 'http://localhost:5000/api' };
    }
  }

  get apiUrl() {
    return this.configData?.apiUrl;
  }
}