import {Route, Routes} from "react-router-dom";
import NewFormPage from "./Pages/NewFormPage/NewFormPage";
import ManageUsersPage from "./Pages/ManageUsersPage/ManageUsersPage";
import ShipOwnerPanel from "./Pages/HomePage/ShipOwnerPanel";
import {PathName as Path} from "./Tools/PathName";
import SavedFormPage from "./Pages/SavedFormsPage/SavedFormPage";
import FormPage from "./Pages/FormPage/FormPage";
import AdminPanel from "./Pages/HomePage/AdminPanel";
import MessagesPage from "./Pages/MessagesPage/MessagesPage";
import ApplicationsPage from "./Pages/ApplicationsPage/ApplicationsPage";
import ApplicationDetailsPage from "./Pages/ApplicationDetailsPage/ApplicationDetailsPage";
import CruisesPage from "./Pages/CruisesPage/CruisesPage";
import CruiseFormPage from "./Pages/CruiseFormPage/CruiseFormPage";
import ManagerPanel from "./Pages/HomePage/ManagerPanel";
import LogoutPage from "./Pages/LoginPage/LogoutPage";
import AccountPage from "./Pages/AccountPage/AccountPage";
import EmailConfirmPage from "./Pages/LoginPage/EmailConfirmPage";
import LoginPage from "./Pages/LoginPage/LoginPage";
import React from "react";
import ServerErrorPage from "./Pages/ServerErrorPage";
import UserBasedAccess from "./UserBasedAccess";



const RoleBasedRouting = () => {

    const {UserHasAdminAccess, UserHasShipownerAccess,
        UserHasCruiseManagerAccess, CommonAccess, NotLoggedInAccess
    } = UserBasedAccess()

    const ShipownerRoute = () => {
        return (
            <>
                <Route path="/NewForm" element={<NewFormPage />} />
                <Route path="/ManageUsers" element={<ManageUsersPage />} />
                <Route path="/*" element={<ShipOwnerPanel />} />
            </>
        )
    }

    const AdministratorRoute = () => {
        return (
            <>
                <Route path={Path.SavedForms} element={<SavedFormPage />} />
                <Route path={Path.NewForm} element={<NewFormPage />} />
                <Route path={Path.Form} element={<FormPage />} />
                <Route path={Path.ManageUsers} element={<ManageUsersPage />} />
                <Route path={Path.Default} element={<AdminPanel />} />
                <Route path={Path.Messages} element={<MessagesPage />} />
                <Route path={Path.Applications} element={<ApplicationsPage />} />
                <Route path={Path.ApplicationDetails} element={<ApplicationDetailsPage />} />
                <Route path={Path.Cruises} element={<CruisesPage />} />
                <Route path={Path.CruiseForm} element={<CruiseFormPage />} />
            </>
        )
    }

    const CruiseManagerRoute = () => {
        return (
            <>
                <Route path={Path.NewForm} element={<NewFormPage />} />
                <Route path={Path.Form} element={<FormPage />} />
                <Route path={Path.Default} element={<ManagerPanel />} />
            </>
        )
    }

    const CommonAccessRoute  = () => {
        return (
            <>
                <Route path={Path.ForcedLogout} element={<LogoutPage />} />
                <Route path={Path.AccountSettings} element={<AccountPage />} />

            </>
        )
    }

    const CommonRoute = () => {
        return (
            <>
                <Route path={Path.ServerError} element={<ServerErrorPage/>} />
                <Route path={Path.ConfirmEmail} element={<EmailConfirmPage />} />
            </>
        )
    }
    const NotLoggedRoute = () => {
        return (
            <>
                <Route path={Path.Default} element={<LoginPage />} />
                <Route path={Path.ForcedLogout} element={<LogoutPage />} />
            </>
        )
    }
    return (
        <Routes>
            {UserHasShipownerAccess() &&  <Route> {ShipownerRoute()} </Route>}
            {UserHasAdminAccess() && <Route> {AdministratorRoute()} </Route>}
            {UserHasCruiseManagerAccess() && <Route> {CruiseManagerRoute()}</Route>}
            {CommonAccess() && <Route> {CommonAccessRoute()} </Route>}
            {NotLoggedInAccess() && <Route> {NotLoggedRoute()} </Route>}
            <Route> {CommonRoute()} </Route>
        </Routes>
    )
}
export default RoleBasedRouting