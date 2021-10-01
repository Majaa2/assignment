import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';

import { MatBadgeModule } from '@angular/material/badge';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BottomNavigationComponent } from './bottom-navigation/bottom-navigation.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductsComponent } from './products/products.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { HomeComponent } from './home/home.component';
import { MatCardModule } from '@angular/material/card';
import { LoadingComponent } from './loading/loading.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { OverlayModule } from '@angular/cdk/overlay';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { DetailsDialogComponent } from './suppliers/details-dialog/details-dialog.component';
import { OrderDetailsDialogComponent } from './orders/details-dialog/order-details-dialog.component';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { BuyDialogComponent } from './products/buy-dialog/buy-dialog.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CheckoutItemComponent } from './checkout/checkout-item/checkout-item.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BottomNavigationComponent,
    OrdersComponent,
    ProductsComponent,
    SuppliersComponent,
    HomeComponent,
    LoadingComponent,
    DetailsDialogComponent,
    OrderDetailsDialogComponent,
    BuyDialogComponent,
    CheckoutComponent,
    CheckoutItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatTabsModule,
    FlexLayoutModule,
    MatCardModule,
    HttpClientModule,
    OverlayModule,
    NgbModule,
    MatTableModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatListModule,
    MatBadgeModule,
    MatProgressSpinnerModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true,
    },
  ],
  entryComponents: [
    DetailsDialogComponent,
    OrderDetailsDialogComponent,
    BuyDialogComponent,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
