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
import {ElementsColumn} from "./TechnicalElementsTableFields";
import {fileExists} from "../ContractsTable/ContractsTable";
import {FieldProps} from "../FormRadio";
import {SpubTask} from "../SpubTasksTable";
import {Crew} from "../CrewTable/CrewTable";
import {InstitutionField} from "../CrewTable/CrewTableFields";



export type TechnicalElements = {
    bowStarboard: boolean,
    aftStarboard: boolean,
    aftPortSide: boolean,
    mainCrane: boolean,
    bomSTBS: boolean,
    bomPS: boolean,
    cableRope35kN: boolean,
    cableRope5kN: boolean,
    mainGantry: boolean,
    STBSAuxiliaryGate: boolean,
    STBSTrawlElevator: boolean,
    PSTrawlElevator: boolean,
    workboat: boolean,
    observatory: boolean

}

const technicalElementsDefault = {
    bowStarboard: false,
    aftStarboard: false,
    aftPortSide: false,
    mainCrane: false,
    bomSTBS: false,
    bomPS: false,
    cableRope35kN: false,
    cableRope5kN: false,
    mainGantry: false,
    STBSAuxiliaryGate: false,
    STBSTrawlElevator: false,
    PSTrawlElevator: false,
    workboat: false,
    observatory: false
}

type TechnicalElementsProps = FieldProps


const technicalElementsTableContent = () => {
    const formContext = useContext(FormContext)

    return[
        () => (<OrdinalNumber label={"Elementy techniczne"}/>),
        ElementsColumn,
        RemoveRowButton,
    ]
}

export const FieldContextWrapper = (Render:React.JSXElementConstructor<any>) => ({field}:FieldValues)=>  (
    <FieldContext.Provider value={field}>
        <Render/>
    </FieldContext.Provider>
)

function TechnicalElementsTable(props: TechnicalElementsProps) {


    const formContext = useContext(FormContext)



    const mdColWidths = [5, 90, 5]
    const mdColTitles = ["Lp.", "Elementy techniczne", ""]
    const colTitle = ""
    const bottomMenu =
        <BottomMenuWithAddButton newOption={technicalElementsDefault as SingleValue<any> }/>
    const emptyText = "Nie dodano żadnych elementów"
    const {Render} = FieldTableWrapper(colTitle, mdColWidths, mdColTitles, technicalElementsTableContent,
        bottomMenu, emptyText, formContext!.getValues(props.fieldName))


    const fieldProps = {
        ...props,
        defaultValue: [],
        rules: {
            required: false,
            validate: {
                notEmptyArray: notEmptyArray<Crew>,
                fileExists:fileExists,
            }
        },
        render: FieldContextWrapper(Render)
    }

    return (
        <FieldWrapper {...fieldProps}/>
    )
}


export default TechnicalElementsTable
