import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import session from '../helpers/session'
import { roundToNearestMinutes } from 'date-fns'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  linkActiveClass: 'active',
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/product',
      name: 'product',
      component: () => import('../views/ProductView.vue')
    },
    {
      path: '/supplier',
      name: 'supplier',
      component: () => import('../views/SupplierView.vue')
    },
    {
      path: '/employee',
      name: 'employee',
      component: () => import('../views/EmployeeView.vue')
    },
    {
      path: '/customer',
      name: 'customer',
      component: () => import('../views/CustomerView.vue')
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/Login.vue')
    },
  ]
})
router.beforeEach((to, from, next, ) => {
  if (to.name == "login") {
    //TODO: login sayfasına gidememeli!
    // if (session.isAuthenticated()) {
    //   router.back();
    // }
    return next();
  }
  if (!session.isAuthenticated()) {
    session.clear();
    router.push("/login");
  } else {
    return next();
  }

})
export default router
