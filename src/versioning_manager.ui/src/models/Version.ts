export class Version {
  public Major: number;
  public Minor: number;
  public Build: number;
  public Revision: number;

  constructor(major: number, minor: number, build: number, revision: number) {
    this.Major = major;
    this.Minor = minor;
    this.Build = build;
    this.Revision = revision;
  }
}
