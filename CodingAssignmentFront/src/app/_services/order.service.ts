import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CAResponse } from '../_models/caresponse.model';
import { Order } from '../_models/order.model';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  url = `${environment.apiUrl}/order`;
  orderSub = new Subject<Array<Order>>();

  constructor(private http: HttpClient) {}

  refresh() {
    this.http
      .get<CAResponse>(`${this.url}`)
      .toPromise()
      .then((res) => {
        this.orderSub.next(res.Result as Array<Order>);
      });
  }
  getById(id: number): Observable<CAResponse> {
    return this.http.get<CAResponse>(`${this.url}/${id}`);
  }
  create(order: Order): Observable<CAResponse> {
    return this.http.post<CAResponse>(`${this.url}`, order);
  }
}
