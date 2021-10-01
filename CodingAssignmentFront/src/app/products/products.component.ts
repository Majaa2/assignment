import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../_models/product.model';
import { ProductService } from '../_services/product.service';
import { BuyDialogComponent } from './buy-dialog/buy-dialog.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  displayedColumns: string[] = ['name', 'quantity', 'price', 'unitsInStock', 'actions'];
  dataSource: MatTableDataSource<Product>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private ps: ProductService, private activatedRoute: ActivatedRoute, public dialog: MatDialog) {
    this.activatedRoute.queryParams.subscribe(q => {
      this.ps.refresh(q.Category?q.Category:null, q.Supplier?q.Supplier:null);
    })
    this.ps.productSub.subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    })
  }

  ngOnInit(): void {}

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  openDialog(id: number): void {
    var dialogRef = null;

    this.ps.getById(id).subscribe(res => {
      dialogRef = this.dialog.open(BuyDialogComponent, {
        width: '750px',
        data: {product: res.Result as Product}
      });
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
      });
    })
  }
}
