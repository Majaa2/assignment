import { Category } from "./category.model";
import { OrderDetails } from "./order-details.model";
import { Supplier } from "./supplier.model";

export class Product {
  ProductId!: number;
  ProductName!: string;
  SupplierId!: number;
  CategoryId!: number;
  QuantityPerUnit!: string;
  UnitPrice!: number;
  UnitsInStock!: number;
  UnitsOnOrder!: number;
  ReorderLevel!: number;
  Discontinued!: boolean;
  Category!: Category;
  Supplier!: Supplier;
  OrderDetails!: Array<OrderDetails>;
}
