import React, {createContext, useContext, useEffect, useState} from "react";
import {CruiseEffectData} from "../../CommonComponents/DataTypes";
import {CellContext, FieldTableWrapper} from "../FormPage/Wrappers/FieldTableWrapper";
import ReadOnlyTextInput from "../../CommonComponents/ReadOnlyTextInput";
import {OrdinalNumber} from "../FormPage/Inputs/TableParts";
import Api from "../../Tools/Api";
import Page from "../Page";
import PageTitle from "../CommonComponents/PageTitle";

export const CruiseEffectsContext = createContext<null | CruiseEffectData[]>(null)
export const SetCruiseEffectListContext = createContext<React.Dispatch<React.SetStateAction<CruiseEffectData[]>> | null>(null)

export const CruiseEffectsTools = () => {
    const cellContext = useContext(CellContext);
    const cruiseEffectsContext = useContext(CruiseEffectsContext);

    const setCruiseEffectListContext = useContext(SetCruiseEffectListContext);
    const cruiseEffect: CruiseEffectData = cruiseEffectsContext![cellContext?.rowIndex!]
    //TODO zmienić logike by dało się usunąć efekty
    const updateCruiseEffect = (fieldKey: keyof CruiseEffectData, value: CruiseEffectData) => {
        cruiseEffect[fieldKey] = value
        const newCruiseEffectList = [...cruiseEffectsContext!]
        const publicationIndex = newCruiseEffectList.findIndex(_cruiseEffect => _cruiseEffect.id == cruiseEffect.id)
        newCruiseEffectList[publicationIndex] = cruiseEffect
        setCruiseEffectListContext!(newCruiseEffectList)
    }
    return {cruiseEffect, updateCruiseEffect}
}

type NestedKeyOf<ObjectType extends object> = {
    [Key in keyof ObjectType & (string | number)]: ObjectType[Key] extends object
        ? `${Key}` | `${Key}.${NestedKeyOf<ObjectType[Key]>}`
        : `${Key}`;
}[keyof ObjectType & (string | number)];

const TableReadOnlyField = (props: { fieldLabel: string, fieldKey: NestedKeyOf<CruiseEffectData> }) => {
    const {cruiseEffect} = CruiseEffectsTools()

    const getValue = (key: string, obj: any): any => key.split('.').reduce((o, i) => o?.[i], obj)
    return (
        <div className={"task-field-input col-md-6"}>
            <label>
                {props.fieldLabel}
            </label>
            <ReadOnlyTextInput value={getValue(props.fieldKey, cruiseEffect) as string}/>
        </div>
    )
}

export const Informations = () => (
    <div className={"w-100 d-flex flex-row flex-wrap"}>
        <TableReadOnlyField fieldLabel={"Typ: "} fieldKey={"researchTask.type"}/>
        <TableReadOnlyField fieldLabel={"Autorzy:"} fieldKey={"researchTask.authors"}/>
        <TableReadOnlyField fieldLabel={"Tytuł:"} fieldKey={"researchTask.title"}/>
        <TableReadOnlyField fieldLabel={"Data:"} fieldKey={"id"}/>
    </div>
)

const manageCruiseEffectsPageTableContent = () => [
    () => (<OrdinalNumber label={"Efekt rejsu"}/>),
    Informations,
]

const deleteCruiseEffect = (cruiseEffect: CruiseEffectData) => Api.delete('/CrusiseEffect/' + cruiseEffect.id)
const getCruiseEffect = () => Api.get('/effectsEvaluations').then(response => {
    return response.data
})

function CruiseEffectsPage() {
    const [cruiseEffectList, setCruiseEffectList] = useState<CruiseEffectData[]>([])
    const fetchData = async () => {
        setCruiseEffectList([{
            researchTask: {
                type: "33.3016/j.marenvres.2023.106132",
                authors: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                institution: "string",
                date: "string",
                financingAmount: "string",
                description: "string",
                done: "string",
            },
            points: "0",
            id: "1235"}])

        //return getCruiseEffect().then(response => setCruiseEffectList(response))
        }
    useEffect(() => {
        (fetchData)()
    }, []);

    const mdColWidths = [5, 95]
    const mdColTitles = ["Lp.", "Informacje"]
    const colTitle = "Efekty rejsu"

    const emptyText = "Nie ma żadnego efektu rejsu"
    const {Render} = FieldTableWrapper(colTitle, mdColWidths, mdColTitles, manageCruiseEffectsPageTableContent, null, emptyText, cruiseEffectList)

    return (
        <Page className={"bg-white d-flex flex-column m-3"}>
            <PageTitle title={"Efekty rejsów"}/>
            <SetCruiseEffectListContext.Provider value={setCruiseEffectList}>
                <CruiseEffectsContext.Provider value={cruiseEffectList}>
                    <div className="form-page-content d-flex flex-column align-items-center w-100">
                        <Render className={"overflow-y-scroll w-100"}/>
                    </div>
                </CruiseEffectsContext.Provider>
            </SetCruiseEffectListContext.Provider>

        </Page>
    )
}

export default CruiseEffectsPage;