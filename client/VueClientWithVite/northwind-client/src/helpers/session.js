import { parseISO, differenceInMilliseconds } from "date-fns";
export default {
    isAuthenticated: function () {
        let token = window.localStorage.getItem("token");
        let expireAt = window.localStorage.getItem("expireAt");
        let expireDate = parseISO(expireAt);
        debugger;
        //TODO: diff -0 geliyor neden ?
        let diff = differenceInMilliseconds(expireDate, new Date());
        if (!token || diff < 0) {
            return false;
        }
        return true;
    },
    getToken: function () {
        return window.localStorage.getItem("token");
    },
    setToken: function (token, expireAt) {
        window.localStorage.setItem("token", token);
        window.localStorage.setItem("expireAt", expireAt);
    },
    clear() {
        window.localStorage.removeItem("token");
        window.localStorage.removeItem("expireAt");
    }
}