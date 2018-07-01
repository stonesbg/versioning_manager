import { Organization } from '@/models/Organization';
import Api from '@/services/Api';
import { AxiosResponse } from 'axios';

interface OrgResponse {
  id: number;
  name: string;
}

export default {
  async getById(id: number) {
    const response = await Api().get('/organization/' + id) as AxiosResponse<OrgResponse>;
    const organization = new Organization(response.data.id, response.data.name);

    return organization as Organization;
  },
  async getAll() {
    const response = await Api().get('/organization') as AxiosResponse<OrgResponse[]>;
    const orglist = response.data.map((item) => {
      return new Organization(item.id, item.name);
    });

    return orglist as Organization[];
  },
};
