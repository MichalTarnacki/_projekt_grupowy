import React, {useState} from "react";
import {FieldValues } from "react-hook-form";
import ErrorMessageIfPresent, {ErrorMessageIfPresentNoContext} from "../CommonComponents/ErrorMessageIfPresent";
import {Link} from "react-router-dom";
import {Path as Path} from "../../Tools/Path";
import axios from "axios";
import userDataManager from "../../CommonComponents/UserDataManager";
import useFormWrapper from "../../CommonComponents/useFormWrapper";


function LoginForm(){
    const {Login} = userDataManager()
    const [loginError, setLoginError] = useState<null | string>(null)
    const { handleSubmit, ClearField, disabled,
        setDisabled, EmailTextInput, PasswordTextInput, CommonSubmitButton, RegisterLink} = useFormWrapper()

    const BeforeSubmit = () => {
        setDisabled(true);
        setLoginError(null)
    }

    const AfterError = () => {
        ClearField("password")
        setDisabled(false)
    }

    const HandleLoginError = (error: unknown) => {
        if(axios.isAxiosError(error))
            if (error.response && error.response?.status === 401) {
                setLoginError("Podano błędne hasło lub użytkownik nie istnieje")
            }
            else setLoginError("Wystąpił problem z zalogowaniem, spróbuj ponownie później")
        AfterError()
    }
    const onSubmit = async (credentials: FieldValues) => {
        BeforeSubmit()
        try {
            await Login(credentials)
        } catch (error) {
           HandleLoginError(error)
        }
    }
    const ForgetPasswordLink = () => {
        return (
            <Link className="forget-password-link" to={Path.ResetPassword}>Nie pamiętam hasła</Link>
        )
    }

    const LoginButton = () => {
        return (
            <CommonSubmitButton label={"Zaloguj się"}/>
        )
    }



    return (
        <>
            <h1 className={"login-common-header"}>Logowanie</h1>
            <form onSubmit={handleSubmit(onSubmit)}>
                <EmailTextInput/>
                <PasswordTextInput/>
                <ForgetPasswordLink/>
                <LoginButton/>
                {loginError && <ErrorMessageIfPresentNoContext message={loginError} />}
                <RegisterLink/>
            </form>
        </>
    )
}


export default LoginForm