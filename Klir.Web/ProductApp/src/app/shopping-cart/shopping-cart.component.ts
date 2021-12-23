import { Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../model/ProductViewModel';
import { ErroViewModel } from '../model/ErroViewModel';
import { ProductService } from './product.service'
import { ProductCartViewModel } from '../model/ProductCartViewModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  public products: ProductViewModel[];
  public productsCart: ProductCartViewModel[];
  public shoppingCartForm: FormGroup;
  public totalquantity: number = 0;
  public totalprice: number = 0;

  constructor(private fb: FormBuilder, private servico: ProductService) {
    this.products = [];
    this.productsCart = [];
    this.shoppingCartForm = this.fb.group({
      idpromotion: [0, Validators.required]
    });
  }

  ngOnInit(): void {
    this.LoadProducts();
  }
  LoadProducts() {
    this.servico.getList()
      .subscribe({
        next: (products: ProductViewModel[]) => { this.products = products },
        error: (e: ErroViewModel) => console.log(e)
      });
  }
  InsertProduct(product: ProductViewModel) {
    var idx = this.productsCart.findIndex(i => i.id == product.id);
    if (idx == -1) {
      var _new = new ProductCartViewModel();
      _new.id = product.id;
      _new.name = product.name;
      _new.quantity = 1;
      _new.price = product.price;
      _new.idpromotion = product.idpromotion;
      _new.promotion = product.promotion;
      this.productsCart.push(_new);
    } else {
      this.productsCart[idx].quantity++;
    }
    this.servico.calculateTotal(this.productsCart).subscribe({
      next: (products: ProductCartViewModel[]) => {
        console.log(products);
        this.productsCart = products;
        console.log(this.productsCart);
        this.calculateTotal();
      },
      error: (e: ErroViewModel) => console.log(e)
    })    
  }
  RemoveProduct(product: ProductViewModel) {
    var idx = this.productsCart.findIndex(i => i.id == product.id);
    if (idx > -1) {
      this.productsCart[idx].quantity--;
      if (this.productsCart[idx].quantity == 0) {
        this.productsCart.splice(idx, 1);
      }
    }
    this.servico.calculateTotal(this.productsCart).subscribe({
      next: (products: ProductCartViewModel[]) => {
        this.productsCart = products;
        console.log(products);
        console.log(this.productsCart);
        this.calculateTotal();
      },
      error: (e: ErroViewModel) => console.log(e)
    })
    this.calculateTotal();
  }
  TotalQuantity(id: number) {
    var idx = this.productsCart.findIndex(i => i.id == id);
    if (idx > -1) {
      return false;
    } else {
      return true;
    }
  }
  calculateTotal() {
    this.totalprice = 0;
    this.totalquantity = 0;
    for (var i = 0; i < this.productsCart.length; i++) {
      this.totalquantity += this.productsCart[i].quantity + this.productsCart[i].quantitypromotion;
      this.totalprice += this.productsCart[i].total;
    }
  }
}

