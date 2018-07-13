<template>
  <v-navigation-drawer
      v-model="drawer"
      fixed
      app
    >
      <v-list dense>
          <v-list-tile :to="'/'" active-class="blue-grey--text">
            <v-list-tile-action>
              <v-icon>home</v-icon>
            </v-list-tile-action>
            <v-list-tile-content>
              <v-list-tile-title>Home</v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
          <v-list-tile :to="'/about'" active-class="blue-grey--text">
            <v-list-tile-action>
              <v-icon>contact_mail</v-icon>
            </v-list-tile-action>
            <v-list-tile-content>
              <v-list-tile-title>About</v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
      </v-list>
    </v-navigation-drawer>
</template>

<script lang="ts">
import { Component, Prop, Watch, Vue } from "vue-property-decorator";

@Component
export default class Sidebar extends Vue {
  @Prop() private drawer: boolean = false;
}
</script>