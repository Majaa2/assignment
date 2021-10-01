import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CAResponse } from '../_models/caresponse.model';
import { Supplier } from '../_models/supplier.model';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  url = `${environment.apiUrl}/supplier`;
  supplierSub = new Subject<Array<Supplier>>();

  constructor(private http: HttpClient) { }

  refresh() {
    this.http.get<CAResponse>(`${this.url}`)
      .toPromise()
      .then(res => {
        this.supplierSub.next(res.Result as Array<Supplier>)
      });      
  }
  getById(id: number): Observable<CAResponse>{
    return this.http.get<CAResponse>(`${this.url}/${id}`);
  }
}
