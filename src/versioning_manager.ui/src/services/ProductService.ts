import { Product } from '@/models/Product';
import Api from '@/services/Api';
import { AxiosResponse } from 'axios';

interface ProductReponse {
  id: number;
  name: string;
}

export default {
  async getByOrgId(orgId: number) {
    const response = await Api().get('/product?org_id=' + orgId) as AxiosResponse<ProductReponse[]>;
    const productList = response.data.map((item) => {
      return new Product(item.id, item.name);
    });

    return productList as Product[];
  },
  async getById(id: number) {
    const response = await Api().get('/product/' + id) as AxiosResponse<ProductReponse>;
    const organization = new Product(response.data.id, response.data.name);

    return organization as Product;
  },
  async getAll() {
    const response = await Api().get('/product') as AxiosResponse<ProductReponse[]>;
    const orglist = response.data.map((item) => {
      return new Product(item.id, item.name);
    });

    return orglist as Product[];
  },
};
