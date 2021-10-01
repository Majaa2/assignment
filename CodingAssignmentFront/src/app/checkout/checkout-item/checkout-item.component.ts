import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { OrderDetails } from 'src/app/_models/order-details.model';
import { Order } from 'src/app/_models/order.model';

@Component({
  selector: 'app-checkout-item',
  templateUrl: './checkout-item.component.html',
  styleUrls: ['./checkout-item.component.scss'],
})
export class CheckoutItemComponent implements OnInit {
  @Input() data!: OrderDetails;
  @Output() removeProduct = new EventEmitter<number>();
  @Output() quantity = new EventEmitter<any>();
  stockInfo: string = '';
  disableInc: boolean = false;
  constructor() {}

  ngOnInit(): void {
    if (this.data.Product.UnitsInStock - 1 == this.data.Quantity) {
      this.stockInfo = 'One item left';
    } else if (this.data.Product.UnitsInStock == this.data.Quantity) {
      this.disableInc = true;
      this.stockInfo = '';
    }
  }
  increase() {
    if (this.data.Product.UnitsInStock - 1 == this.data.Quantity + 1) {
      this.quantity.emit({
        quantity: this.data.Quantity + 1,
        productId: this.data.ProductId,
      });
      this.stockInfo = 'One item left';
    } else if (this.data.Product.UnitsInStock == this.data.Quantity + 1) {
      this.disableInc = true;
      this.quantity.emit({
        quantity: this.data.Quantity + 1,
        productId: this.data.ProductId,
      });
      this.stockInfo = '';
    } else if (this.data.Product.UnitsInStock > this.data.Quantity) {
      this.quantity.emit({
        quantity: this.data.Quantity + 1,
        productId: this.data.ProductId,
      });
      this.stockInfo = '';
    }
  }
  decrease() {
    if (this.data.Quantity == 1) {
      this.remove();
    } else {
      this.quantity.emit({
        quantity: this.data.Quantity - 1,
        productId: this.data.ProductId,
      });
      if (this.data.Quantity - 1 < this.data.Product.UnitsInStock) {
        this.disableInc = false;
        this.stockInfo = '';
      }
      if (this.data.Product.UnitsInStock - 1 == this.data.Quantity - 1) {
        this.stockInfo = 'One item left';
      }
    }
  }
  remove() {
    this.removeProduct.emit(this.data.ProductId);
  }
}
