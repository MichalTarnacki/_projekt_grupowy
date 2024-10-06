import {KeyContext} from "../../Wrappers/FieldTableWrapper";
import {FDateFieldOnlyYear, FIntField, FSelectField, FTextField, FStandardDateField} from "../CellFormFields";
import React from "react";
import {equipmentLeaveActions, equipmentLeaveActionsPL} from "./EquipmentLeaveTable";


export const ActionPicker = () => {
    const equipmentLeaveActionOptions = equipmentLeaveActions.map(
        (action,index)=>({label:equipmentLeaveActionsPL[index], value:action}))

    return(
        <KeyContext.Provider value={"action"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Czynność
                </label>
                <FSelectField options={equipmentLeaveActionOptions}/>
            </div>
        </KeyContext.Provider>
    )}

export const TimeField = () => {
    return(
        <KeyContext.Provider value={"time"}>
            <div className={"task-field-input col-md-6"}>
                <label>
                    Czas
                </label>
                <FTextField/>
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

