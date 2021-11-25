
import { number } from "yup/lib/locale";
import { AppSetting } from "../types/type";
import { decrypt, encrypt } from "./crypter";
import { Cookies } from 'react-cookie';
import { GlobalKeys } from "./constants";
import { userInfo } from "os";
import { User } from "../services/models/user";

var cookies = new Cookies();
const bgColors = ["primary", "secondary", "success", "danger", "warning", "info", "dark"];
export function GetRandomBgColor() {
    return bgColors[Math.floor(Math.random() * bgColors.length)];;
}

let appSetting: AppSetting = require('../appSetting.json');

export const getLoggedUser = () => {
    try {
        const loggedUser = localStorage.getItem(GlobalKeys.LoggedUserKey);
        //const loggedUser = cookies.get(GlobalKeys.LoggedUserKey); 
        if (loggedUser) {

            return <User>JSON.parse(JSON.stringify(decrypt(loggedUser)));
        }
        else {
            return null;
        }
    }
    catch (e) {
        console.log(e);
        return null;
    }
}

export const setLoggedUser = (user: any) => {

    localStorage.setItem(GlobalKeys.LoggedUserKey, encrypt(user));

    // var expiresDate = new Date();
    // expiresDate.setMinutes(expiresDate.getMinutes() + 30);
    // cookies.set(GlobalKeys.LoggedUserKey, encrypt(user), {
    //     expires: expiresDate,
    //     secure: true,
    //     httpOnly: true,
    //     sameSite: 'none'
    // });
}

export const logout = () => {
    cookies.remove(GlobalKeys.LoggedUserKey);
    localStorage.clear();
}

