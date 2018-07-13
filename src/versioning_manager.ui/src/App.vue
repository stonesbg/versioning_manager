<template>
  <v-app id="app" dark>
    <Sidebar :drawer='drawer'/>

    <v-toolbar fixed app>
      <v-toolbar-side-icon @click.stop="toggleSidbar"></v-toolbar-side-icon>
      <v-toolbar-title>Build Version Manager</v-toolbar-title>
    </v-toolbar>

    <v-content>
      <v-container fluid>
        <router-view :key="$route.fullPath"/>
      </v-container>
    </v-content>

    <v-footer app>
      <v-layout justify-center row wrap>
        <v-flex py3 text-xs-center white--text xs12>
          <span>Brian Garvey &copy; 2018</span>
        </v-flex>
      </v-layout>
    </v-footer>
  </v-app>
</template>

<style lang="scss">
</style>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import OrgCreate from "./components/OrgCreate.vue";
import Sidebar from "./components/Sidebar.vue";
import { State, Action, Getter } from "vuex-class";

@Component({
  components: {
    OrgCreate,
    Sidebar
  }
})
export default class Home extends Vue {
  @State("drawer") drawer!: boolean;
  @Action("toggleDrawer") toggleDrawer: any;
  toggleSidbar() {
    this.toggleDrawer();
  }
}
</script>
