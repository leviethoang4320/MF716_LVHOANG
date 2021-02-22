import Vue from 'vue'
import VueRouter from 'vue-router'

import Store from '../views/dictionary/chain_stores/Store.vue'


Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Store',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: Store
  },
  
  {
    path: '/dictionary/store',
    name: 'Store',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: Store
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
