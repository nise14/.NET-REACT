import axios from "axios";
import { PortfolioGet, PortfolioPost } from "../models/Portfolio";
import { handleError } from "../helpers/errorHandler";

const api ="http://localhost:5139/api/portfolio";

export const portfolioAddAPI= async (symbol:string)=>{
    try
    {
        const data = await axios.post<PortfolioPost>(api+`?symbol=${symbol}`);
        return data;
    }
    catch(error)
    {
        handleError(error);
    }
};

export const portfolioDeleteAPI= async (symbol:string)=>{
    try
    {
        const data = await axios.delete<PortfolioPost>(api+`?symbol=${symbol}`);
        return data;
    }
    catch(error)
    {
        handleError(error);
    }
};

export const portfolioGetAPI= async ()=>{
    try
    {
        const data = await axios.get<PortfolioGet[]>(api);
        return data;
    }
    catch(error)
    {
        handleError(error);
    }
};