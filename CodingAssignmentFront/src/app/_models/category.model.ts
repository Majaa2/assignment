import { Product } from './product.model';

export class Category {
  CategoryId!: number;
  CategoryName!: string;
  Description!: string;
  Picture!: any;
  Products!: Array<Product>;
}
