import { Version } from '@/models/Version';
import { VersionRecord } from '@/models/VersionRecord';
import Api from '@/services/Api';
import { AxiosResponse } from 'axios';

interface VersionReponse {
  major: number;
  minor: number;
  build: number;
  revision: number;
}

interface VersionRecordReponse {
  id: number;
  name: string;
  version: VersionReponse;
  created_date: Date;
}

export default {
  async getByProductId(productId: number) {
    const response = await Api().get('/version?product_id=' + productId) as AxiosResponse<VersionRecordReponse[]>;
    const versionList = response.data.map((item) => {
      return new VersionRecord(item.id,
        new Version(item.version.major, item.version.minor, item.version.build, item.version.revision),
        item.created_date);
    });

    return versionList as VersionRecord[];
  },
  // async getById(id: number) {
  //   const response = await Api().get('/product/' + id) as AxiosResponse<VersionReponse>;
  //   const organization = new Version(response.data.id, response.data.name);

  //   return organization as Version;
  // },
  async getAll() {
    const versionTable: VersionRecord[] = [
      {Id: 1, Version: new Version(1, 0, 0, 0), CreatedDate: new Date('1968-11-16T00:00:00')},
      {Id: 2, Version: new Version(1, 0, 2, 2), CreatedDate: new Date('1999-11-16T00:00:00')},
      {Id: 3, Version: new Version(1, 0, 4, 4), CreatedDate: new Date('2018-07-01T12:30:20')},
      {Id: 4, Version: new Version(1, 1, 0, 0), CreatedDate: new Date('2018-07-01T16:20:10')},
    ];

    // const response = await Api().get('/product') as AxiosResponse<VersionReponse[]>;
    // const orglist = response.data.map((item) => {
    //   return new Version(item.id, item.name);
    // });

    // return orglist as Version[];
    return versionTable;
  },
};
