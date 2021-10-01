import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderDetails } from 'src/app/_models/order-details.model';

@Component({
  selector: 'app-buy-dialog',
  templateUrl: './buy-dialog.component.html',
  styleUrls: ['./buy-dialog.component.scss'],
})
export class BuyDialogComponent implements OnInit {
  quantity: number = 1;
  stockInfo: string = "";
  disableInc: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<BuyDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  increase(){
    if(this.data.product.UnitsInStock - 1 == this.quantity + 1){
      this.quantity++;
      this.stockInfo = "One item left"
    }
    else if(this.data.product.UnitsInStock == this.quantity + 1){
      this.disableInc = true;
      this.quantity++;
      this.stockInfo = "";
    }
    else if(this.data.product.UnitsInStock > this.quantity){
      this.quantity++;
      this.stockInfo = "";
    }
  }
  decrease(){
    if(this.quantity == 1){
      this.onNoClick();
    }
    else{
      this.quantity--;
      if(this.quantity < this.data.product.UnitsInStock){
        this.disableInc = false;
        this.stockInfo = "";
      }
      if(this.data.product.UnitsInStock - 1 == this.quantity){
        this.stockInfo = "One item left";
      }
    }
  }
  createOrderDetail(){
    var od = new OrderDetails();
    od.Discount = 0;
    od.ProductId = this.data.product.ProductId;
    od.Product = this.data.product;
    od.Quantity = this.quantity;
    od.UnitPrice = this.data.product.UnitPrice;

    var orderDetails = [];

    if(localStorage.getItem("orderDetails") != null){
      orderDetails = JSON.parse(localStorage.getItem("orderDetails"));
    }
    if(orderDetails.find(x => x.ProductId == od.ProductId)){
      orderDetails.forEach(o => {
        if(o.ProductId == od.ProductId){
          o.Quantity += od.Quantity
        }
      })
    } else {
      orderDetails.push(od);
    }
    localStorage.setItem("orderDetails", JSON.stringify(orderDetails));

    this.onNoClick();
  }
  ngOnInit(): void {}
}
