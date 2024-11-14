import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../pages/homepage/HomePage";
import SearchPage from "../pages/searchpage/SearchPage";
import CompanyPage from "../pages/companypage/CompanyPage";
import CompanyProfile from "../components/companyprofile/CompanyProfile";
import IncomeStatement from "../components/incomestatement/IncomeStatement";
import DesignPage from "../pages/designguide/DesignGuide";
import BalanceSheet from "../components/balancesheet/BalanceSheet";
import CashFlowStatement from "../components/cashflowstatement/CashFlowStatement";
import LoginPage from "../pages/loginPage/LoginPage";
import RegisterPage from "../pages/registerPage/registerPage";
import ProtectedRoute from "./ProtectedRoute";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "",
                element: <HomePage />
            },
            {
                path: "login",
                element: <LoginPage />
            },
            {
                path: "register",
                element: <RegisterPage />
            },
            {
                path: "search",
                element: <ProtectedRoute><SearchPage /></ProtectedRoute>
            },
            {
                path: "design-guide",
                element: <DesignPage />
            },
            {
                path: "company/:ticker",
                element: <ProtectedRoute><CompanyPage /></ProtectedRoute>,
                children: [
                    {
                        path: "company-profile",
                        element: <CompanyProfile />
                    },
                    {
                        path: "income-statement",
                        element: <IncomeStatement />
                    },
                    {
                        path: "balance-sheet",
                        element: <BalanceSheet />
                    },
                    {
                        path: "cashflow-statement",
                        element: <CashFlowStatement />
                    }
                ]
            }
        ]
    }
])