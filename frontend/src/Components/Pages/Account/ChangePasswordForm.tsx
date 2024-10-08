import axios from "axios";
import {FieldValues} from "react-hook-form";
import useFormWrapper from "../../CommonComponents/useFormWrapper";
import React, {useState} from "react";
import {ErrorMessageIfPresentNoContext} from "../CommonComponents/ErrorMessageIfPresent";
import userDataManager from "../../CommonComponents/UserDataManager";



export default function ChangePasswordForm() {
    const {ChangePassword} = userDataManager()
    const HandleError = (error:unknown) => {
        if(axios.isAxiosError(error) && error.response?.status == 400)
            setChangePasswordError("Podano błędne hasło")
        else
            setChangePasswordError("Nieznany błąd")
        setChangePasswordSuccess(false)
    }

    const AfterSubmitSuccess = () => {
        setChangePasswordError(null)
        setChangePasswordSuccess(true)
        reset()
    }

    const  onPasswordChangeSubmit = async (data:FieldValues) => {
        setDisabled(true)
        try {
            await ChangePassword(data);
            AfterSubmitSuccess()
        }
        catch (error) { HandleError(error) }
        setDisabled(false)
    }

    const {PasswordTextInput, NewPasswordTextInput, ConfirmNewPasswordTextInput, ConfirmButton,
        setDisabled, handleSubmit, reset} = useFormWrapper()

    const [changePasswordError, setChangePasswordError] =
        useState<null | string>(null)
    const [changePasswordSuccess, setChangePasswordSuccess] =
        useState(false)

    const FormFields = () => (
        <>
            <PasswordTextInput/>
            <NewPasswordTextInput/>
            <ConfirmNewPasswordTextInput/>
            <ConfirmButton/>
        </>
    )

    return(
        <>
            <form className="h6" onSubmit={handleSubmit(onPasswordChangeSubmit)}>
                <FormFields/>
                {changePasswordError && <ErrorMessageIfPresentNoContext message={changePasswordError}/>}
            </form>
            {changePasswordSuccess && <div className="h6 text-center">Pomyślnie zmieniono hasło</div>}
        </>
    )
}