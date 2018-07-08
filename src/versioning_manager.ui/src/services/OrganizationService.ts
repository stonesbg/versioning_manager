import { Organization } from '@/models/Organization';
import Api from '@/services/Api';
import { AxiosResponse } from 'axios';

interface OrgResponse {
  id: number;
  name: string;
  description: string;
}

export default {
  async create(org: Organization): Promise<Organization> {
    const postBody = {
      Name: org.Name,
      Description: org.Description,
    };

    const response = await Api().post('/organization', postBody) as AxiosResponse<OrgResponse>;
    const organization = new Organization(response.data.id, response.data.name, response.data.description);

    return organization;
  },
  async getById(id: number): Promise<Organization> {
    const response = await Api().get('/organization/' + id) as AxiosResponse<OrgResponse>;
    const organization = new Organization(response.data.id, response.data.name, response.data.description);

    return organization;
  },
  async getAll(): Promise<Organization[]> {
    const response = await Api().get('/organization') as AxiosResponse<OrgResponse[]>;
    const orglist = response.data.map((item) => {
      return new Organization(item.id, item.name, item.description);
    });

    return orglist;
  },
};
