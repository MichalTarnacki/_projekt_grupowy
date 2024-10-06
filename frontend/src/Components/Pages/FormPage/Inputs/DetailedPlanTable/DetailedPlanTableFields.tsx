import {KeyContext} from "../../Wrappers/FieldTableWrapper";
import {FDateFieldOnlyYear, FIntField, FSelectField, FTextField} from "../CellFormFields";
import React from "react";


export const DayField = () => {
    return(
        <KeyContext.Provider value={"day"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Dzień
                </label>
                <FTextField/>
            </div>
        </KeyContext.Provider>
    )}

export const HoursField = () => {
    return(
        <KeyContext.Provider value={"hours"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Liczba godzin
                </label>
                <FTextField/>
            </div>
        </KeyContext.Provider>
    )}

export const TaskNameField = () => {
    return(
        <KeyContext.Provider value={"taskName"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Nazwa zadania
                </label>
                <FTextField/>
            </div>
        </KeyContext.Provider>
    )}

export const RegionField = () => {
    return(
        <KeyContext.Provider value={"region"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Rejon zadania
                </label>
                <FTextField/>
            </div>
        </KeyContext.Provider>
    )}

export const PositionField = () => {
    return(
        <KeyContext.Provider value={"position"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Pozycja
                </label>
                <FTextField/>
            </div>
        </KeyContext.Provider>
    )}

export const NotesField = () => {
    return(
        <KeyContext.Provider value={"notes"}>
            <div className={"task-field-input"}>
                <label className={"table-field-input-label"}>
                    Uwagi
                </label>
                <FTextField/>
            </div>
        </KeyContext.Provider>
    )}

