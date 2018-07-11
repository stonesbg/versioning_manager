<template>
  <div>
    <h2>Current Version:</h2><span>{{ currentVersionString() }}</span>
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
  </div>
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
import { VersionRecord } from '@/models/VersionRecord';

@Component
export default class VersionHistoryTable extends Vue {
  @Prop()
  public productId!: number;

  private versionTable: VersionRecord[] = [];
  
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
      .then((data) => {
        console.log(data);
        this.versionTable = data
        })
      .catch((error) => console.log(error));
  }

  public currentVersionString(): string {
    if(this.versionTable.length > 0)
      return this.formatVersion(this.versionTable[0].Version);
    else
      return '';
  }

  public sortedVersion(): VersionRecord[] {
    this.versionTable = this.versionTable.sort((left: VersionRecord, right: VersionRecord): number => {
      if (left.Id < right.Id) return 1;
      if (left.Id > right.Id) return -1;
      return 0;
    });

    return this.versionTable;
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

