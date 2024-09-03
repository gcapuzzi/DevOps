import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './layout/header/header.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  baseUrl = 'http://localhost:20120/api/';
  private http = inject(HttpClient);
  title = 'Skinet';
  products: any[] = [];

  ngOnInit(): void {
    this.http.get<any>(this.baseUrl + 'product').subscribe({
      //next: (response) => (this.products = response.data),
      next: (data) => console.log(data),
      error: (error) => console.log(error),
      complete: () => console.log('complete'),
    });
  }
}
