<template>
  <div class="home">
    <v-container>
      <v-layout>
        <v-flex xs2>
            <v-card flat tile>
                <v-card-title>
                  {{ getOrganization().Name }}
                </v-card-title>
                <v-card-text>
                  [Placeholder] for details about the Organization created [Placeholder]
                </v-card-text>
              </v-card>
          </v-flex>
        <v-flex>
          <v-container>
            <v-layout>
              <v-flex d-flex xs10 sm6 md4 v-for="product in getOrganization().Products" :key="product.Name">
                <v-layout row wrap>
                  <v-flex d-flex>
                    <v-card flat tile class="product-card">
                      <v-card-title>
                        {{ product.Name }}
                      </v-card-title>
                      <v-card-text>
                        <span>{{ formatVersion(product.CurrentVersion) }}</span>
                      </v-card-text>
                    </v-card>
                  </v-flex>
                </v-layout>
              </v-flex>
              <v-flex d-flex xs12 sm6 md4></v-flex>
            </v-layout>
          </v-container>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Organization } from "../models/Organization";
import { Version } from "../models/Version";
import { Product } from "../models/Product";
import OrganizationService from "../services/OrganizationService";

@Component
export default class OrgOverview extends Vue {
  private org: Organization = {
    Id: -1,
    Name: "[Organization]"
  };

  public loadOrg(id: number) {
    OrganizationService.getOrganization(id)
      .then(data => (this.org = data))
      .catch(error => console.log(error));
  }

  public mounted() {
    const orgId: number = Number(this.$route.params.id);
    this.loadOrg(orgId);
  }

  private formatVersion(version: Version) {
    return (
      version.Major +
      "." +
      version.Minor +
      "." +
      version.Build +
      "." +
      version.Revision
    );
  }
}
</script>

<style lang="scss">
.product-card {
  border: 1px #e1e4e8 solid !important;
  margin: 0.2em;
}
</style>

