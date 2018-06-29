import { Version } from '@/models/Version';

export class Product {
  public Name: string;
  public CurrentVersion: Version;

  constructor(name: string) {
    this.Name = name;
    this.CurrentVersion = new Version(1, 0, 0, 0);
  }
}
