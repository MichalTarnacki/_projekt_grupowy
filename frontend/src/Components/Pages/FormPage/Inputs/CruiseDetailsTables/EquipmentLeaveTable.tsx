import React, {useContext} from "react";
import { FieldValues} from "react-hook-form";
import {SingleValue} from "react-select";
import {
    BottomMenuWithAddButton,
    BottomMenuWithAddButtonAndHistory, BottomMenuWithHistory,
    OrdinalNumber,
    RemoveRowButton
} from "../TableParts";
import {FieldContext, FieldTableWrapper} from "../../Wrappers/FieldTableWrapper";
import {FormField} from "../FormYearSelect";
import {FormContext} from "../../Wrappers/FormTemplate";
import FieldWrapper from "../FieldWrapper";
import {
    notEmptyArray,
    Publication,
    publicationCategories,
    publicationCategoriesPL, publicationOptions
} from "../PublicationsTable/PublicationsTable";
import  {ActionPicker, TimeField, NameField} from "./EquipmentLeaveTableFields";
import {fileExists} from "../ContractsTable/ContractsTable";
import {FieldProps} from "../FormRadio";
import {SpubTask} from "../SpubTasksTable";



export type EquipmentLeave = {
    action: string,
    time: string,
    name: string
}

const equipmentLeaveDefault = [{
    action: "leaving",
    time: "",
    name: ""
},
    {
        action: "taking",
        time: "",
        name: ""
    }]

export const equipmentLeaveActions = [
    "leaving",
    "taking"
]

export const equipmentLeaveActionsPL = [
    "Pozostawienie",
    "Zabranie"
]

export const equipmentLeaveOptions = equipmentLeaveActionsPL.map((taskLabel, index) =>
    ({label:taskLabel, value:equipmentLeaveDefault[index]}))

type EquipmentLeaveTableProps = FieldProps &
    {historicalEquipmentLeave?: EquipmentLeave[]}

const EquipmentLeaveRowLabel = (row:EquipmentLeave) =>
    `Czynność: ${row.action}\n
    Czas: ${row.time}\n
    Nazwa sprzętu: ${row.name}\n`


const EquipmentLeaveTableContent = () => {
    const formContext = useContext(FormContext)

    return[
        () => (<OrdinalNumber label={"Sprzęt"}/>),
        ActionPicker,
        TimeField,
        NameField,
        RemoveRowButton,
    ]
}

export const FieldContextWrapper = (Render:React.JSXElementConstructor<any>) => ({field}:FieldValues)=>  (
    <FieldContext.Provider value={field}>
        <Render/>
    </FieldContext.Provider>
)

function EquipmentLeaveTable(props: EquipmentLeaveTableProps) {


    const formContext = useContext(FormContext)

    const FilteredHistoricalEquipmentLeave = (action:string) =>
        props.historicalEquipmentLeave?.filter((row) => row.action == action)
            .map((row: EquipmentLeave) =>
                ({label: EquipmentLeaveRowLabel(row), value: row})) ?? []

    const selectOptions =  equipmentLeaveActions.map((equipmentLeaveCategory, index)=>
        ({label:equipmentLeaveActionsPL[index], options: FilteredHistoricalEquipmentLeave(equipmentLeaveCategory)})) ?? []

    const mdColWidths = [5,30,30, 30, 5]
    const mdColTitles = ["Lp.", "Czynność", "Czas",  "Nazwa sprzętu", ""]
    const colTitle = ""
    const bottomMenu =
        <BottomMenuWithHistory newOptions={equipmentLeaveOptions} historicalOptions={selectOptions}/>
    const emptyText = "Nie dodano żadnego sprzętu"
    const {Render} = FieldTableWrapper(colTitle, mdColWidths, mdColTitles, EquipmentLeaveTableContent,
        bottomMenu, emptyText, formContext!.getValues(props.fieldName))


    const fieldProps = {
        ...props,
        defaultValue: [],
        rules: {
            required: false,
            validate: {
                notEmptyArray: notEmptyArray<EquipmentLeave>,
                fileExists:fileExists,
            }
        },
        render: FieldContextWrapper(Render)
    }

    return (
        <FieldWrapper {...fieldProps}/>
    )
}


export default EquipmentLeaveTable
