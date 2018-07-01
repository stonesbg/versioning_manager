import { Version } from '@/models/Version';

export class Product {
  public Id: number;
  public Name: string;
  public CurrentVersion: Version;

  constructor(id: number, name: string) {
    this.Id = id;
    this.Name = name;
    this.CurrentVersion = new Version(1, 0, 0, 0);
  }
}
