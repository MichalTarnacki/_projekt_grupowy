import React from 'react';
import Page from "../Page";
import { useNavigate} from "react-router-dom";
import useFormWrapper from "../../CommonComponents/useFormWrapper";
import {Path as Path} from "../../Tools/Path";

function LogoutPage(){
    const {ReturnToLoginLink} = useFormWrapper()
    const navigate = useNavigate()

    const LogoutForm = () => {
        return (
            <form onSubmit={() => navigate(Path.Default)}>
                <div className={"text-submit"}>Nastąpiło wylogowanie</div>
                <ReturnToLoginLink/>
            </form>
        )
    }
    return (
            <Page className={"login-common"}>
                <LogoutForm/>
            </Page>
    )
}


export default LogoutPage