<template>
  <div class="home">
    <h1>Organizatons</h1>
    <v-layout row wrap>
      <v-flex xs10 offset-xs1>
        <OrgCreate />
      </v-flex>
      <v-flex xs8 offset-xs2>
        <v-card v-for="org in orgList" :key="org.Name">
          <v-container fluid grid-list-lg>
            <v-layout row wrap>
              <v-flex xs12>
                <v-card color="blue-grey darken-2" class="white--text">
                  <v-card-title primary-title>
                    <div class="headline">{{org.Name}}</div>
                  </v-card-title>
                  <v-card-text>
                    <div>PLACEHOLDER FOR DESCRIPTION</div>
                  </v-card-text>
                  <v-card-actions>
                    <v-btn flat dark :to="{path: '/organization/' + org.Id}" class="org-link">View</v-btn>
                  </v-card-actions>
                </v-card>
              </v-flex>
            </v-layout>
          </v-container>
        </v-card>
      </v-flex>
    </v-layout>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import OrgCreate from '../components/OrgCreate.vue';
import { Organization } from '../models/Organization';
import { Version } from '../models/Version';
import { Product } from '../models/Product';
import OrganizationService from '../services/OrganizationService';

@Component({
  components: {
    OrgCreate,
}})
export default class Home extends Vue {
  public orgList: Organization[] = [];

  public loadOrgs() {
    OrganizationService.getOrgnizations()
    .then((data) => {
      console.log(data);
      this.orgList = data;
    })
    .catch((error) => console.log(error));
  }

  public mounted() {
    this.loadOrgs();
  }

}
</script>

<style lang="scss" scoped>
.headline
{
  font-size: 24px !important;
  font-weight: 400;
  line-height: 32px !important;
  letter-spacing: normal !important;
}

</style>

