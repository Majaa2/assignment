import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../environments/environment';
import { CAResponse } from '../_models/caresponse.model';
import { Category } from '../_models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  url = `${environment.apiUrl}/category`;
  categorySub = new Subject<Array<Category>>();

  constructor(private http: HttpClient) { }

  refresh() {
    this.http.get<CAResponse>(`${this.url}`)
      .toPromise()
      .then(res => {
        this.categorySub.next(res.Result as Array<Category>)
      });      
  }

  getById(id: number): Observable<CAResponse>{
    return this.http.get<CAResponse>(`${this.url}/${id}`);
  }
  
}
