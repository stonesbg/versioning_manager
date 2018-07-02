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
                {{ org.Description }}
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
                {{ product.Description }}
                <VersionHistoryTable :productId="product.Id" ></VersionHistoryTable>
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
import VersionHistoryTable from '@/components/VersionHistoryTable.vue'

@Component({
  components: {
    VersionHistoryTable
  }
})
export default class OrgOverview extends Vue {
  private org: Organization = {
    Id: -1,
    Name: '',
    Description: '',
  };
  private productList: Product[] = [];

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

  public mounted() {
    const orgId: number = Number(this.$route.params.id);
    this.loadOrgById(orgId);
    this.loadProducts(orgId);
  }
}
</script>

<style lang="scss">

</style>

