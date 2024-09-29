import React, {useContext, useState} from "react";
import {FormContext} from "../Pages/FormPage/Wrappers/FormTemplate";
import Api from "./Api";
import {useLocation, useNavigate} from "react-router-dom";
import {Path} from "./Path";
import BusyEvent from "../CommonComponents/BusyEvent";
import {extendedUseLocation} from "../Pages/FormPage/FormPage";
export const SaveButton = () => {
    const formContext = useContext(FormContext)
    const locationState = extendedUseLocation()?.state
    const navigate = useNavigate()
    const handleAddCruise = () => Api
        .post(
            `/api/Cruises`,
            formContext!.getValues()
        )
        .then(_ =>
            navigate(Path.Cruises)
        )

    const handleEditCruise = () => {
        if(locationState.cruise)
            Api.patch(
                `/api/Cruises/${locationState.cruise!.id}`,
                formContext!.getValues())
                .then(_ =>
                    navigate(Path.Cruises)
                )
    }

    return(
        <div onClick={ locationState?.cruise ? formContext!.handleSubmit(handleEditCruise):
            formContext!.handleSubmit(handleAddCruise)} className="form-page-option-button w-100"> Zapisz rejs </div>
    )
}
export const ClearFormButton = () => {


    const formContext = useContext(FormContext)
    const locationState = extendedUseLocation()?.state

    const resetEditCruiseForm = () => formContext!.reset()

    return(
        <div onClick={ resetEditCruiseForm } className="form-page-option-button w-100"> {locationState?.cruise ? "Cofnij zmiany" : "Wyczyść formularz"} </div>
    )
}


export const BottomOptionBar = () => (
    <div className="form-page-option-bar">
        <ClearFormButton/>
        <SaveButton/>
    </div>
)