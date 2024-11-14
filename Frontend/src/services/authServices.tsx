import axios from "axios";
import { handleError } from "../helpers/errorHandler";
import { UserProfileToken } from "../models/user";

const api = "https://localhost:7275/api/";

export const loginApi = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/login", {
            username: username,
            password: password
        });

        return data;
    }
    catch (error) {
        handleError(error);
    }
};

export const registerApi = async (email: string, username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/register", {
            email: email,
            username: username,
            password: password
        });

        return data;
    }
    catch (error) {
        handleError(error);
    }
};