import {KeyContext} from "../../Wrappers/FieldTableWrapper";
import {FIntField, FTextField} from "../CellFormFields";
import React from "react";

export const InstitutionField = () =>
    (
        <KeyContext.Provider value={"institution"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Instytucja
                </label>
                <FTextField/>
            </div>
        </KeyContext.Provider>
    )

export const NoOfPersonsField = () =>
    (
        <KeyContext.Provider value={"noOfPersons"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Liczba osób
                </label>
                <FIntField/>
            </div>
        </KeyContext.Provider>
    )