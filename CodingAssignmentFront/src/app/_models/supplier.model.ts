import { Product } from './product.model';

export class Supplier {
  SupplierId!: number; 
  CompanyName!: string;
  ContactName!: string;
  ContactTitle!: string;
  Address!: string;
  City!: string;
  Region!: string;
  PostalCode!: string;
  Country!: string;
  Phone!: string;
  Fax!: string;
  HomePage!: string;
  Products!: Array<Product>;
}
