import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Input() isSmallScreen!: boolean;
  constructor() { }

  ngOnInit(): void {
  }

  get cartItems(){
    var items = []
    if(localStorage.getItem("orderDetails")){
      items = JSON.parse(localStorage.getItem("orderDetails"))
    }

    return items.length
  }
}
