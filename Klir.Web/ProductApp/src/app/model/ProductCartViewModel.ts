export class ProductCartViewModel {
  id: number =0;
  name: string = "";
  quantity: number = 0;
  quantitypromotion: number = 0;
  price: number = 0;
  discount: number = 0;
  total: number = (this.quantity * this.price) - this.discount;
  idpromotion: number = 0;
  promotion: string="";
}
