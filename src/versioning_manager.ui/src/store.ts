import Vue from 'vue';
import Vuex from 'vuex';
import { Organization } from '@/models/Organization';
import OrganizationService from '@/services/OrganizationService';
import { stat } from 'fs';

Vue.use(Vuex);

export interface State {
  loading: boolean;
  orgs: Organization[];
}

export default new Vuex.Store({
  state: {
    loading: true,
    orgs: [],
  },
  mutations: {
    setOrgList(state: State, orgList: Organization[]) {
      state.orgs = orgList;
    },
    addOrg(state: State, org: Organization) {
      state.orgs.push(org);
    }
  },
  actions: {
    loadOrgList({ commit }) {
      OrganizationService.getAll()
        .then((data) => {
          commit('setOrgList', data);
        })
        .catch((error) => console.log(error));
    },
  },
  getters: {
    getOrgList(state: State): Organization[] {
      return state.orgs;
    }
  },
});
