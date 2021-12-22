import { Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../model/ProductViewModel';
import { ErroViewModel } from '../model/ErroViewModel';
import { ProductService } from './product.service'
import { error } from '@angular/compiler/src/util';
import { PromotionViewModel } from '../model/PromotionViewModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-admin',
  templateUrl: './product-admin.component.html',
  styleUrls: ['./product-admin.component.css']
})
export class ProductAdminComponent implements OnInit {
  public promotionForm: FormGroup;
  public products: ProductViewModel[];
  public promotions: PromotionViewModel[];
  public productSelected: number;
  constructor(private fb: FormBuilder, private servico: ProductService) {
    this.products = [];
    this.promotions = [];
    this.productSelected = 0;
    this.promotionForm = this.fb.group({
      idpromotion: [0, Validators.required]
    });
  }

  ngOnInit(): void {
    this.LoadProducts();
    this.LoadPromotions();
  }
  LoadPromotions() {
    this.servico.getPromotionList()
      .subscribe({
        next: (promotions: PromotionViewModel[]) => { this.promotions = promotions },
        error: (e: ErroViewModel) => console.log(e)
      });
  }
  LoadProducts() {
    this.servico.getList()
      .subscribe({
        next: (products: ProductViewModel[]) => { this.products = products },
        error: (e: ErroViewModel) => console.log(e)
      });
  }
  HavePromotion(product: ProductViewModel) {
    console.log(product.idpromotion);
    return product.idpromotion > 0;
  }
  ProductClear(product: ProductViewModel) {
    var _prod = product.id;
    this.servico.updatePromotion(_prod, 0).subscribe({
      next: (_return: ErroViewModel) => {
        console.log(_return);
        if (_return.erro) {
          console.log(_return.erro);
        } else {
          this.LoadProducts();
        }
      },
      error: (err: Error) => {
        console.log(err);
      }
    })
  }
  ProductSelected(product: ProductViewModel) {
    return this.productSelected == product.id;
  }
  SelectProduct(product: ProductViewModel) {
    this.productSelected = product.id;
  }
  promotionSubmit(idproduct: number) {
    var _prom = this.promotionForm.value.idpromotion;
    var _prod = idproduct;
    this.servico.updatePromotion(_prod, _prom).subscribe({
      next: (_return: ErroViewModel) => {
        console.log(_return);
        if (_return.erro) {
          console.log(_return.erro);
        } else {
          this.LoadProducts();
        }
      },
      error: (err: Error) => {
        console.log(err);
      }
    })
    this.productSelected = 0;
  }
}
