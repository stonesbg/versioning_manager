import Vue from 'vue';
import Router from 'vue-router';
import OrgCreate from './components/OrgCreate.vue';
import About from './views/About.vue';
import Home from './views/Home.vue';
import OrgOverview from './views/OrgOverview.vue';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/about',
      name: 'about',
      component: About,
    },
    {
      path: '/organization/create',
      name: 'org_create',
      component: OrgCreate,
    },
    {
      path: '/organization/:id',
      name: 'org_overview',
      component: OrgOverview,
    },
  ],
});
