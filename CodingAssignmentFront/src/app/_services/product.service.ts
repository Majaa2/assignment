import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CAResponse } from '../_models/caresponse.model';
import { Product } from '../_models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url = `${environment.apiUrl}/product`;
  productSub = new Subject<Array<Product>>();

  constructor(private http: HttpClient) { }

  refresh(categoryId: number, supplierId: number) {
    this.http.post<CAResponse>(`${this.url}`,{CategoryId: categoryId, SupplierId: supplierId})
      .toPromise()
      .then(res => {
        this.productSub.next(res.Result as Array<Product>)
      });      
  }
  getById(id: number): Observable<CAResponse>{
    return this.http.get<CAResponse>(`${this.url}/${id}`);
  }
}
