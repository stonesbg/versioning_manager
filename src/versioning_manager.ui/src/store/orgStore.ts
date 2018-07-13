import { Module, ActionTree, MutationTree, GetterTree } from 'vuex';
import { Organization } from '@/models/Organization';
import OrganizationService from '@/services/OrganizationService';
import { RootState, OrgState } from '@/store/types';

export const state: OrgState = {
  orgList: [],
};

export const actions: ActionTree<OrgState, RootState> = {
  loadOrgs({ commit }) {
    OrganizationService.getAll()
      .then((data) => {
        commit('setOrgList', data);
      })
      .catch((error) => console.log(error));
  },
};

export const mutations: MutationTree<OrgState> = {
  setOrgList(orgState, orgList: Organization[]) {
    orgState.orgList = orgList;
  },
  addOrg(orgState, org: Organization) {
    orgState.orgList.push(org);
  }
};

export const getters: GetterTree<OrgState, RootState> = {

};

const namespaced: boolean = true;

export const orgStore: Module<OrgState, RootState> = {
  namespaced,
  state,
  actions,
  mutations,
  getters,
}