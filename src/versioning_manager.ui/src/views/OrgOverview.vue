<template>
  <v-layout>
    <v-flex xs2>
        <v-layout>
          <v-flex xs10 offset-xs1>
          <v-card flat tile>
              <v-card-title>
                <h1>{{ org.Name }}</h1>
              </v-card-title>
              <v-card-text>
                [Placeholder] for details about the Organization created [Placeholder]
              </v-card-text>
            </v-card>
            </v-flex>
          </v-layout>
      </v-flex>
    <v-flex xs10>
      <v-container grid-list-md>
        <v-layout row wrap>
          <v-flex v-for="product in productList" :key="product.Id" xs6>
            <v-card flat tile class="product-card">
              <v-card-title>
                <h1>{{ product.Name }}</h1>
              </v-card-title>
              <v-card-text>
                <h2>Current Version:</h2><span>1.0.0.0</span>
                <v-data-table
                  :headers="versionHeaders"
                  :items="versionTable"
                  hide-actions
                  class="elevation-1"
                >
                  <template slot="items" slot-scope="props">
                    <td>{{ formatVersion(props.item.Version) }}</td>
                    <td>
                      <v-tooltip bottom>
                        <span slot="activator">{{ humanizeDate(props.item.CreatedDate) }}</span>
                        <span>Actual Date: {{ formatDateToString(props.item.CreatedDate) }}</span>
                      </v-tooltip>
                    </td>
                  </template>
                </v-data-table>
              </v-card-text>
            </v-card>
          </v-flex>
        </v-layout>
      </v-container>
    </v-flex>
  </v-layout>
</template>

<script lang="ts">
import { Component, Vue, Prop} from 'vue-property-decorator';
import { Organization } from '@/models/Organization';
import { Version } from '@/models/Version';
import { Product } from '@/models/Product';
import ProductService from '@/services/ProductService';
import OrganizationService from '@/services/OrganizationService';
import VersionService from '@/services/VersionService';
import moment from 'moment'

@Component
export default class OrgOverview extends Vue {
  private org: Organization = {
    Id: -1,
    Name: '[Organization]',
  };
  private productList: Product[] = [];
  //TODO: Specify type
  private versionTable: any = [];
  
  //TODO: Specify type
  private versionHeaders: any = [
          {
            text: 'Build Number',
            align: 'left',
            sortable: false,
            value: 'version'
          },
          {text: 'Created Date', value: 'created_date'}
        ];

  public loadOrgById(orgId: number){
    OrganizationService.getById(orgId)
      .then((data) => (this.org = data))
      .catch((error) => console.log(error));
  }

  public loadProducts(orgId: number) {
    ProductService.getByOrgId(orgId)
      .then((data) => (this.productList = data))
      .catch((error) => console.log(error));
  }

  public loadVersions(productId: number){
    VersionService.getAll()
      .then((data) => this.versionTable = data)
      .catch((error) => console.log(error));
  }

  public mounted() {
    const orgId: number = Number(this.$route.params.id);
    this.loadOrgById(orgId);
    this.loadProducts(orgId);

    // TODO: Move this so that it is associated to the Products
    this.loadVersions(orgId);
  }

  private formatVersion(version: Version) {
    return (
      version.Major +
      '.' +
      version.Minor +
      '.' +
      version.Build +
      '.' +
      version.Revision
    );
  }

  private formatDateToString(date: Date) {
    return moment(date).format('YYYY-MM-DD, hh:mm:ss');
  }

  private humanizeDate(date: Date) {
    return moment(date).fromNow();
  }
}
</script>

<style lang="scss">
// .product-card {
//   border: 1px #e1e4e8 solid !important;
//   margin: 0.2em;
// }
</style>

