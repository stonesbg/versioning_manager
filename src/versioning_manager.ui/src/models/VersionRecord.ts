import { Version } from './Version';

export class VersionRecord {
  public Id: number;
  public Version: Version;
  public CreatedDate: Date;

  constructor(id: number, version: Version, createdDate: Date) {
    this.Id = id;
    this.Version = version;
    this.CreatedDate = createdDate;
  }
}
