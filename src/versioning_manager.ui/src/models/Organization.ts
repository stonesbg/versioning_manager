import { IOrganization } from '@/contracts/IOrganization';

export class Organization implements IOrganization {
  public Id: number;
  public Name: string;
  public Description: string;

  constructor(id: number, name: string, description: string) {
    this.Id = id;
    this.Name = name;
    this.Description = description;
  }
}
