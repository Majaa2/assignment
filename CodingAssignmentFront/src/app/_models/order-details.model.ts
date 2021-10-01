import { Order } from './order.model';
import { Product } from './product.model';

export class OrderDetails {
  OrderId!: number;
  ProductId!: number;
  UnitPrice!: number;
  Quantity!: number;
  Discount!: number;
  Order!: Order;
  Product!: Product;
}
