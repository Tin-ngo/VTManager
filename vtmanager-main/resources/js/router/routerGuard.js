import { TOKEN } from "../constants";
import store from "../store";
import routes from "./router";
import { ROUTER } from "../constants";
import { getToken } from "@/utils/storage";

routes.beforeEach((to, from, next) => {
  document.title = to.meta.title;
  const token = localStorage.getItem(TOKEN.ACCESS_TOKEN);
  if (to.meta.middleware == "guest") {
    if (store.state.auth.authenticated) {
      if (token) {
        next({ name: ROUTER.ComMain.name});
      }
    }
    next();
  } else {
    if (store.state.auth.authenticated) {
      next();
    } else {
      from.name === ROUTER.ComLogin.name ? next() : next({ name: ROUTER.ComLogin.name });
    }
  }
});



//  const setInterval = async () => {
//   const token = await getToken();
//   if (token) {
//     const decodedToken = JSON.parse(window.atob(token.split('.')[1]));
//     const now = Date.now() / 1000;
//     console.log('decodedToken', decodedToken.exp)
//     console.log('now', now)
//     console.log(decodedToken.exp < now)
//     // if (decodedToken.exp < now) {
//     //   localStorage.removeItem('token');
//     //   app.$router.push('/login');
//     // }
//   }
// }
