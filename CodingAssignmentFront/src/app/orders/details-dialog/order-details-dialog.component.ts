import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { OrderDetails } from 'src/app/_models/order-details.model';

@Component({
  selector: 'app-details-dialog',
  templateUrl: './order-details-dialog.component.html',
  styleUrls: ['./order-details-dialog.component.scss']
})
export class OrderDetailsDialogComponent implements OnInit {

  displayedColumns: string[] = ['product', 'unitPrice', 'quantity', 'discount'];
  dataSource: MatTableDataSource<OrderDetails>;

  constructor(
    public dialogRef: MatDialogRef<OrderDetailsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
      this.dataSource = new MatTableDataSource(data.order.OrderDetails);
    }

  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit(): void {
  }
}
