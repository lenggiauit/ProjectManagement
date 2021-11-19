
import { number } from "yup/lib/locale";
import { AppSetting } from "../types/type";
import { decrypt, encrypt } from "./crypter";
import { Cookies } from 'react-cookie';
import { GlobalKeys } from "./constants";

var cookies = new Cookies();
const bgColors = ["primary", "secondary", "success", "danger", "warning", "info", "dark"];
export function GetRandomBgColor() {
    return bgColors[Math.floor(Math.random() * bgColors.length)];;
}

let appSetting: AppSetting = require('../appSetting.json');

export const getLoggedUser = () => {
    try {
        const loggedUser = cookies.get(GlobalKeys.LoggedUserKey);
        if (loggedUser) {
            return decrypt(loggedUser);
        }
        else {
            return null;
        }
    }
    catch {
        return null;
    }
}

export const setLoggedUser = (user: any) => {
    var expiresDate = new Date();
    expiresDate.setMinutes(expiresDate.getMinutes() + 30);
    cookies.set(GlobalKeys.LoggedUserKey, encrypt(user), { expires: expiresDate });
}

export const logout = () => {
    cookies.remove(GlobalKeys.LoggedUserKey);
    localStorage.clear();
}

