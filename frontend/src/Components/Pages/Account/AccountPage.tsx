import React from 'react';
import Page from "../Page";
import PageTitle from "../CommonComponents/PageTitle";
import ChangePasswordForm from "./ChangePasswordForm";
import {UserCredentials} from "./UserCredentials";

const ChangePasswordColumn = () => (
    <div className="account-page-change-password-column">
        <ChangePasswordForm/>
    </div>
)

const CredentialsColumn = () => (
    <div className="account-page-credentials-column">
        <UserCredentials/>
    </div>
)

const Content = () => (
    <div className="account-page-data-row mh-100">
        <CredentialsColumn/>
        <ChangePasswordColumn/>
    </div>
)

const AccountPage = () => (
    <Page className={"form-page"}>
        <PageTitle title={"Ustawienia konta"}/>
        <Content/>
    </Page>
    )


export default AccountPage