import { TOKEN } from "../constants";
import store from "../store";
import routes from "./router";
import { ROUTER } from "../constants";
import { getToken } from "@/utils/storage";

routes.beforeEach((to, from, next) => {
  if (to.meta.middleware === "guest") {
    document.title = to.meta.title;
    if (store.state.auth.authenticated) {
      console.log('guest đã đăng nhập');
      next('/employee');
    }
    next(); // Continue navigation if not authenticated
  } else {
    if(to.meta.middleware === "auth"){
      document.title = to.meta.title;
      if (store.state.auth.authenticated) {
        // console.log('đã đăng nhập');
        if (to.meta.middleware === "guest") {
          next();
        }else{
          next();
        }
      } else {
        console.log('chưa đăng nhập');
        next('/login');
      }
    }else{
      console.log('không thuộc gì cả');
      next('/employee');
    }
  }
});

  // document.title = to.meta.title;
  // const token = localStorage.getItem(TOKEN.ACCESS_TOKEN);
  // // console.log('tokenqqqq',token);
  // // console.log('middleware',to.meta.middleware);
  // if (to.meta.middleware == "guest") {
  //   if (store.state.auth.authenticated) {
  //     if (token) {
  //       console.log('đã đăng nhập');
  //       next({ name: ROUTER.MstOverview.name});
  //     }
  //   }
  //   next();
  // } else {
  //   if (store.state.auth.authenticated) {
  //     next();
  //   } else {
  //     console.log('Lỗi đăng nhập');
  //     from.name === ROUTER.ComLogin.name ? next() : next({ name: ROUTER.ComLogin.name });
  //   }
  // }



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
