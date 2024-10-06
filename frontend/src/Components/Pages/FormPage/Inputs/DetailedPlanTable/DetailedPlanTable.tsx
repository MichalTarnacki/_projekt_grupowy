import React, {useContext} from "react";
import { FieldValues} from "react-hook-form";
import {SingleValue} from "react-select";
import {
    BottomMenuWithAddButton,
    BottomMenuWithAddButtonAndHistory,
    OrdinalNumber,
    RemoveRowButton
} from "../TableParts";
import {FieldContext, FieldTableWrapper} from "../../Wrappers/FieldTableWrapper";
import {FormField} from "../FormYearSelect";
import {FormContext} from "../../Wrappers/FormTemplate";
import FieldWrapper from "../FieldWrapper";
import {notEmptyArray, Publication} from "../PublicationsTable/PublicationsTable";
import "./DetailedPlanTableFields";
import {fileExists} from "../ContractsTable/ContractsTable";
import {FieldProps} from "../FormRadio";
import {SpubTask} from "../SpubTasksTable";
import {DayField, HoursField, NotesField, PositionField, RegionField, TaskNameField} from "./DetailedPlanTableFields";



export type DetailedPlan = {
    day: string,
    hours: string,
    taskName: string,
    region: string,
    position: string,
    notes: string
}

const detailedPlanDefault = {
    day: "",
    hours: "",
    taskName: "",
    region: "",
    position: "",
    notes: ""
}


type DetailedPlanProps = FieldProps


const detailedPlanTableContent = () => {
    const formContext = useContext(FormContext)

    return[
        () => (<OrdinalNumber label={"Dzień"}/>),
        HoursField,
        TaskNameField,
        RegionField,
        PositionField,
        NotesField,
        RemoveRowButton,
    ]
}

export const FieldContextWrapper = (Render:React.JSXElementConstructor<any>) => ({field}:FieldValues)=>  (
    <FieldContext.Provider value={field}>
        <Render/>
    </FieldContext.Provider>
)

function DetailedPlanTable(props: DetailedPlanProps) {


    const formContext = useContext(FormContext)



    const mdColWidths = [5, 18, 18, 18, 18, 18, 5]
    const mdColTitles = ["Dzień", "Liczba godzin", "Nazwa zadania",  "Rejon zadania", "Pozycja", "Uwagi", ""]
    const colTitle = "Lista uczestników rejsu"
    const bottomMenu =
        <BottomMenuWithAddButton newOption={detailedPlanDefault as SingleValue<any> }/>
    const emptyText = "Nie dodano żadnego dnia"
    const {Render} = FieldTableWrapper(colTitle, mdColWidths, mdColTitles, detailedPlanTableContent,
        bottomMenu, emptyText, formContext!.getValues(props.fieldName))


    const fieldProps = {
        ...props,
        defaultValue: [],
        rules: {
            required: false,
            validate: {
                notEmptyArray: notEmptyArray<DetailedPlan>,
                fileExists:fileExists,
            }
        },
        render: FieldContextWrapper(Render)
    }

    return (
        <FieldWrapper {...fieldProps}/>
    )
}


export default DetailedPlanTable
