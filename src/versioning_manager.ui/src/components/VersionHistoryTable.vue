<template>
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
export default class VersionHistoryTable extends Vue {
  @Prop()
  public productId!: number;

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

  public loadVersions(productId: number){
    VersionService.getByProductId(productId)
      .then((data) => this.versionTable = data)
      .catch((error) => console.log(error));
  }

  public mounted() {
    this.loadVersions(this.productId);
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

