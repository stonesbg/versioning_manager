<template>
  <div class="home">
    <v-layout>
      <v-flex>
        <v-layout row wrap>
          <ul>
            <li v-for="org in orgList" :key="org.Name">
              <router-link :to="{path: '/organization/' + org.Id}" class="org-link">{{ org.Name }}</router-link>
            </li>
          </ul>
        </v-layout>
        <OrgCreate />
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
import OrganizationService from '../services/OrganizationService'

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
    .catch(error => console.log(error));
  }

  public mounted() {
    this.loadOrgs();
  }
  
}
</script>
