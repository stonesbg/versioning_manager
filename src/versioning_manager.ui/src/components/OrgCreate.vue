<template>
<v-dialog v-model="dialog" persistent max-width="500px">
      <v-btn slot="activator" outline fab small primary darken-1 >
        <v-icon dark>add</v-icon>
      </v-btn>
  <v-card>
    <v-card-title>
      <span class="headline">Organization</span>
    </v-card-title>
    <v-card-text>
      <v-container grid-list-md>
        <v-layout wrap>
          <v-flex xs8>
            <v-text-field
              id="org_name"
              name="name"
              v-model="org.Name"
              label="Name"
            ></v-text-field>
          </v-flex>
          <v-flex xs8>
            <v-text-field
              id="org_description"
              name="description"
              v-model="org.Description"
              label="Description"
            ></v-text-field>
          </v-flex>
        </v-layout>  
      </v-container>
      <small>*indicates required field</small>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn flat secondary darken-1 @click.native="closeButton">Close</v-btn>
      <v-btn flat primary darken-1 @click.native="addButton">Save</v-btn>
    </v-card-actions>
  </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Component, Prop, Watch, Vue } from "vue-property-decorator";
import OrganizationService from "@/services/OrganizationService";
import { Organization } from "@/models/Organization";

@Component
export default class OrgCreate extends Vue {
  @Prop() private dialog: boolean = false;
  private org: Organization = new Organization(-1, "", "");
  private outputText: string = "";

  public addButton() {
    OrganizationService.create(this.org);
    this.$store.commit("addOrg", this.org);
    this.dialog = false;
  }

  public closeButton() {
    this.dialog = false;
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
</style>
