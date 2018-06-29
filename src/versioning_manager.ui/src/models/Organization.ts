import { Product } from './Product';

export interface IOrganization {
  Id: number;
  Name: string;
  Products: Product[];
}

export class Organization implements IOrganization {
  public Id: number;
  public Name: string;
  public Products: Product[];

  constructor(id: number, name: string, products: Product[]) {
    this.Id = id;
    this.Name = name;
    this.Products = products;
  }
}
