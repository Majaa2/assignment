import { OrderDetails } from "./order-details.model";

export class Order {
  OrderId!: number;
  CustomerId!: string;
  EmployeeId!: number;
  OrderDate!: Date;
  RequiredDate!: Date;
  ShippedDate!: Date;
  ShipVia!: number;
  Freight!: number;
  ShipName!: string;
  ShipAddress!: string;
  ShipCity!: string;
  ShipRegion!: string;
  ShipPostalCode!: string;
  ShipCountry!: string;
  OrderDetails!: Array<OrderDetails>;
}
