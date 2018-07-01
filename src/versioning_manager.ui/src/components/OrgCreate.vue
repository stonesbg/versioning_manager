<template>
<v-dialog v-model="dialog" persistent max-width="500px">
      <v-btn slot="activator" color="primary" dark>Create Organization</v-btn>
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
              v-model="name"
              label="Name"
            ></v-text-field>
          </v-flex>
        </v-layout>  
        <v-layout row>
          <v-flex xs4>
          </v-flex>
          <v-flex xs8>
            <h1>{{enteredText}}</h1>
          </v-flex>
        </v-layout>
      </v-container>
      <small>*indicates required field</small>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn color="blue darken-1" flat @click.native="closeButton">Close</v-btn>
      <v-btn color="blue darken-1" flat @click.native="addButton">Save</v-btn>
    </v-card-actions>
  </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Component, Prop, Watch, Vue } from 'vue-property-decorator';

@Component
export default class OrgCreate extends Vue {
  @Prop() private dialog: boolean = false;
  private name: string = '';
  private outputText: string = '';

  public addButton() {
    alert('Simulated create of the Org: ' + this.name);
    this.dialog = false;
  }

  public closeButton() {
    alert('Simulated close create org.');
    this.dialog = false;
  }

  public greeting() {
    let result = '';
    if (this.name !== '') {
      result = 'New organization ' + this.name + ' will be created.'; // + this.$store.organization;
    }

    return result;
  }

  get enteredText(): string {
    return this.greeting();
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
</style>
