import { AxiosResponse } from 'axios';
import { Organization } from '@/models/Organization';
import Api from '@/services/Api';

type Org = {
  id: number,
  name: string,
}

export default {
  async getOrganization(id: number) {
    const response: AxiosResponse<Organization> = await Api().get<Organization>('/organization/' + id);
    return response.data;
  },
  async getOrgnizations() {
    const response = await Api().get('/organization') as AxiosResponse<Org[]>;
    const orglist = response.data.map((item) => {
      return new Organization(item.id, item.name);
    });

    console.log(orglist);

    return orglist as Organization[];
  },
};
