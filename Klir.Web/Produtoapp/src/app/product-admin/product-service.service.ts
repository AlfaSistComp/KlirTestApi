import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ProductViewModel } from '../model/ProductViewModel';
import { PromotionViewModel } from '../model/PromotionViewModel';
import { ErroViewModel } from '../model/ErroViewModel';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  getList(): Observable<ProductViewModel[]> {
    return this.http.get<ProductViewModel[]>(environment.baseURL + "/Product");
  }
  getPromotionList(): Observable<PromotionViewModel[]> {
    return this.http.get<PromotionViewModel[]>(environment.baseURL + "/Promotion");
  }
  updatePromotion(idproduct: number, idpromotion: number): Observable<ErroViewModel> {
    return this.http.put<ErroViewModel>(environment.baseURL + "/Product/" + idproduct + "/" + idpromotion , "");
  }
}
