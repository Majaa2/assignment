import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Supplier } from '../_models/supplier.model';
import { SupplierService } from '../_services/supplier.service';
import { DetailsDialogComponent } from './details-dialog/details-dialog.component';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.scss'],
})
export class SuppliersComponent implements OnInit {
  displayedColumns: string[] = ['name', 'address', 'city', 'phone', 'actions'];
  dataSource: MatTableDataSource<Supplier>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private ss: SupplierService, public dialog: MatDialog) {
    this.ss.refresh();
    this.ss.supplierSub.subscribe(data => {
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

    this.ss.getById(id).subscribe(res => {
      dialogRef = this.dialog.open(DetailsDialogComponent, {
        width: '750px',
        data: {supplier: res.Result as Supplier}
      });
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
      });
    })


  }

}
