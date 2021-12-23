import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ProductViewModel } from '../model/ProductViewModel';
import { ProductCartViewModel } from '../model/ProductCartViewModel';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  getList(): Observable<ProductViewModel[]> {
    return this.http.get<ProductViewModel[]>(environment.baseURL + "/Product");
  }

  calculateTotal(products: ProductCartViewModel[]): Observable<ProductCartViewModel[]> {
    return this.http.post<ProductCartViewModel[]>(environment.baseURL + "/Checkout", products);
  }
}
