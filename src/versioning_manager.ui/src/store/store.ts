import Vue from 'vue';
import Vuex, { StoreOptions, ActionTree, MutationTree } from 'vuex';
import { RootState } from '@/store/types';
import { orgStore } from '@/store/orgStore';

Vue.use(Vuex);

export const actions: ActionTree<RootState, RootState> = {
  toggleDrawer({ commit }) {
    commit('toggleDrawer');
  },
};

export const mutations: MutationTree<RootState> = {
  toggleDrawer(state) {
    state.drawer = !state.drawer;
  },
};

const store: StoreOptions<RootState> = {
  state: {
    loading: false,
    drawer: false,
  },
  modules: {
    orgStore,
  },
  actions,
  mutations,
};

export default new Vuex.Store<RootState>(store);
