import { IOrganization } from '@/contracts/IOrganization';

export class Organization implements IOrganization {
  public Id: number;
  public Name: string;

  constructor(id: number, name: string) {
    this.Id = id;
    this.Name = name;
  }
}
