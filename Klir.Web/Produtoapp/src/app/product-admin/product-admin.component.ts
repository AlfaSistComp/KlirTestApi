import { Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../model/ProductViewModel';
import { ErroViewModel } from '../model/ErroViewModel';
import { ProductService } from './product-service.service'
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-product-admin',
  templateUrl: './product-admin.component.html',
  styleUrls: ['./product-admin.component.css']
})
export class ProductAdminComponent implements OnInit {
  public products: ProductViewModel[];
  constructor(private servico: ProductService) {
    this.products = [];
    this.products.push({id: 1, name: 'Ale', price: 10})
  }

  ngOnInit(): void {
    this.LoadProducts();
  }
  LoadProducts() {
    console.log("Alessandro");
    this.servico.getList()
      .subscribe({
        next: (products: ProductViewModel[]) => { this.products = products },
        error: (e: ErroViewModel) => console.log(e)
    });
  }
}
