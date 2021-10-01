import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from '../_models/order.model';
import { OrderService } from '../_services/order.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss'],
})
export class CheckoutComponent implements OnInit {
  error: string = '';
  loading: boolean = false;
  constructor(private os: OrderService, private router: Router) {}

  ngOnInit(): void {}

  get cartItems() {
    var items = [];
    if (localStorage.getItem('orderDetails')) {
      items = JSON.parse(localStorage.getItem('orderDetails'));
    }
    return items;
  }
  get totalValue() {
    var total = 0;
    this.cartItems.forEach((c) => {
      total += c.Quantity * c.UnitPrice;
    });
    return total;
  }
  trackByIndex(index, item) {
    return index;
  }

  remove(productId: number) {
    var filtered = this.cartItems.filter((x) => x.ProductId != productId);
    var filteredString = JSON.stringify(filtered);
    localStorage.setItem('orderDetails', filteredString);
  }

  edit({ quantity, productId }) {
    var changed = JSON.parse(JSON.stringify(this.cartItems));
    changed.forEach((c) => {
      if (c.ProductId == productId) {
        c.Quantity = quantity;
      }
    });
    var filteredString = JSON.stringify(changed);
    localStorage.setItem('orderDetails', filteredString);
  }

  completePurchase() {
    this.loading = true;
    var changed = JSON.parse(JSON.stringify(this.cartItems));
    changed.forEach((c) => {
      c.Product = null;
    });
    var o = new Order();
    o.OrderDetails = changed;
    o.OrderDate = new Date();

    this.os.create(o).subscribe((res) => {
      this.loading = false;
      if (res.ResponseCode == 201) {
        localStorage.removeItem('orderDetails');
        this.router.navigate(['../orders']);
      } else {
        this.error = 'We could not process your order. Please try again!';
      }
    });
  }
}
