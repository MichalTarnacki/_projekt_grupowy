import {KeyContext} from "../../Wrappers/FieldTableWrapper";
import {FDateFieldOnlyYear, FIntField, FSelectField, FTextField, FStandardDateField} from "../CellFormFields";
import React from "react";


export const StartDateField = () => {
    return(
        <KeyContext.Provider value={"startDate"}>
            <div className={"task-field-input"}>
                <label>
                    Od
                </label>
                <FStandardDateField/>
            </div>
        </KeyContext.Provider>
    )}

export const EndDateField = () => {
    return(
        <KeyContext.Provider value={"endDate"}>
            <div className={"task-field-input col-md-6"}>
                <label>
                    Do
                </label>
                <FStandardDateField/>
            </div>
        </KeyContext.Provider>
    )}

export const NameField = () => {
    return(
        <KeyContext.Provider value={"name"}>
            <div className={"task-field-input col-md-6"}>
                <label>
                    Nazwa
                </label>
                <FTextField/>
            </div>
        </KeyContext.Provider>
    )}

