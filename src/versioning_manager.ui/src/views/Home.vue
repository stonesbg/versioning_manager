<template>
  <div class="home">
    
    <v-layout row wrap>
      <v-flex xs12 mb-4>
        <h1>
          <span>Organizatons</span>
          <OrgCreate />
        </h1>
      </v-flex>
      <v-flex xs10 offset-xs1>
        <v-card v-for="org in orgList" :key="org.Name">
          <v-container grid-list-xl>
            <v-layout>
              <v-flex>
                <v-card color="blue-grey darken-2">
                  <v-card-title primary-title>
                    <h1 class="headline">{{org.Name}}</h1>
                  </v-card-title>
                  <v-card-text>
                    <div>{{ org.Description }}</div>
                  </v-card-text>
                  <v-card-actions>
                    <v-btn flat dark :to="{path: '/organization/' + org.Id}" :org=org class="org-link">View</v-btn>
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
    OrganizationService.getAll()
    .then((data) => {
      console.log(data);
      this.orgList = data;
    })
    .catch((error) => console.log(error));
  }

  public mounted() {
    this.$store.dispatch("loadOrgList");
    this.loadOrgs();
  }

}
</script>

<style lang="scss" scoped>
</style>

