import axios from "axios"
import session from "./session";
export default {
    install: (app) => {
        const instance = axios.create({
            baseURL: "https://localhost:7000"
        });
        let ajax = {
            get: function (url) {
                return instance.get(url, getHeader());
            },
            post: function (url, data) {
                return instance.post(url, data, getHeader());
            },
            delete: function (url) {
                return instance.delete(url, getHeader());
            },
            put: function (url,data) {
                return instance.pust(url, data, getHeader());
            }
        }
        function getHeader() {
            let config = {
                headers: {
                }
            }
            if (session.isAuthenticated()) {
                config.headers.Authorization = "Bearer " + session.getToken();
            }
            return config;
        }
        app.config.globalProperties.$ajax = ajax;
    }
}