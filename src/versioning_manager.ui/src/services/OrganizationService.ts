import { AxiosResponse } from 'axios';
import { Organization } from '../models/Organization';
import Api from '../services/Api';

export default {
    // TODO: Add the return to Organization
    async getOrganization(id: number) {
        const response: AxiosResponse<Organization> = await Api().get<Organization>('/organization/' + id);
        return response.data;
    },
    async getOrgnizations() {
      const response: AxiosResponse<Organization[]> = await Api().get('/organization');
      return response.data;
    },
};
