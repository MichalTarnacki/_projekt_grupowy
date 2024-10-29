import React, {createContext, useContext, useEffect, useState} from "react";

import {FieldTableWrapper} from "../FormPage/Wrappers/FieldTableWrapper";

import {OrdinalNumber} from "../FormPage/Inputs/TableParts";
import {CellContext} from "@contexts/CellContext";
import ReadOnlyTextInput from "../../../ToBeMoved/CommonComponents/ReadOnlyTextInput";
import Api from "@api/Api";
import Page from "../../../ToBeMoved/Pages/Page";
import PageTitle from "../../../components/Page/PageTitle";
import {PublicationData} from "PublicationData";

export const PublicationsContext = createContext<null | PublicationData[]>(null)
export const SetPublicationListContext = createContext<React.Dispatch<React.SetStateAction<PublicationData[]>> | null>(null)


export const PublicationsTools = () => {
    const cellContext = useContext(CellContext);
    const publicationsContext = useContext(PublicationsContext);

    const setPublicationContext = useContext(SetPublicationListContext);
    const publication: PublicationData = publicationsContext![cellContext?.rowIndex!]
    //TODO zmienić logike by dało się usunąć publikacje
    const removePublication = (key: PublicationData) => {
        // @ts-ignore
        let newPulicationList = [...publicationsContext!];
        newPulicationList = newPulicationList.filter(publication => publication != key);
        setPublicationContext!(newPulicationList)
    }
    return {publication, removePublication}
}

const TableReadOnlyField = (props: { fieldLabel: string, fieldKey: keyof PublicationData }) => {
    const {publication} = PublicationsTools()
    return (
        <div className={"task-field-input col-md-6"}>
            <label>
                {props.fieldLabel}
            </label>
            <ReadOnlyTextInput value={publication![props.fieldKey] as string}/>
        </div>
    )
}
export const Informations = () => (
    <div className={"w-100 d-flex flex-row flex-wrap"}>
        <TableReadOnlyField fieldLabel={"DOI:"} fieldKey={"doi"}/>
        <TableReadOnlyField fieldLabel={"Autorzy:"} fieldKey={"authors"}/>
        <TableReadOnlyField fieldLabel={"Tytuł:"} fieldKey={"title"}/>
        <TableReadOnlyField fieldLabel={"Czasopismo:"} fieldKey={"magazine"}/>
    </div>
)
export const Year = () => (
    <div className={"d-flex justify-content-center align-items-center"}>
        <TableReadOnlyField fieldLabel={"Rok wydania:"} fieldKey={"year"}/>
    </div>)
export const MinisterialPoints = () => (
    <div className={"d-flex justify-content-center align-items-center"}>
        <TableReadOnlyField fieldLabel={"Punkty ministerialne:"} fieldKey={"ministerialPoints"}/>
    </div>
)
export const Actions = () => {
    const {publication, removePublication} = PublicationsTools()
    console.log(publication);

    return (
        <div className="btn-group-vertical">
            <div className={"user-action-link"}
                 onClick={() => deletePublication(publication).then(() => removePublication(publication))}>
                Usuń publikację
            </div>
        </div>
    )
}

const managePublicationsPageTableContent = () => [
    () => (<OrdinalNumber label={"Publikacja"}/>),
    Informations,
    Year,
    MinisterialPoints,
    Actions,
];

const deletePublication = (publication: PublicationData) => Api.delete('/api/CruiseApplications/' + publication.id +'/Publications/');
const getPublications = () => Api.get('/api/CruiseApplications/Publications').then(response => {
    return response.data
});

// TODO Zamienić plik csv na liste obiektów i przesłać do backendu

function MyPublicationsPage() {
    const [publicationList, setPublicationList] = useState<PublicationData[]>([])
    const fetchData = async () => {
        let list: PublicationData[] = [];
        return getPublications().then(response => {
            response.forEach((element: { publication: PublicationData; }) => {
                list.push(element.publication)
            });
            setPublicationList(list);
        });
    };
    useEffect(() => {
        (fetchData)()
    }, []);

    const mdColWidths = [5, 55, 15, 15, 10]
    const mdColTitles = ["Lp.", "Informacje", "Rok publikacji", "Punkty ministerialne", "Akcje"]
    const colTitle = "Publikacje"

    const emptyText = "Nie dodano żadnej publikacji"
    const {Render} = FieldTableWrapper(colTitle, mdColWidths, mdColTitles, managePublicationsPageTableContent, null, emptyText, publicationList)

    return (
        <Page className={"bg-white d-flex flex-column m-3"}>
            <PageTitle title={"Moje publikacje"}/>
            <SetPublicationListContext.Provider value={setPublicationList}>
                <PublicationsContext.Provider value={publicationList}>
                    <div className="form-page-content d-flex flex-column align-items-center w-100">
                        <Render className={"overflow-y-scroll w-100"}/>
                    </div>
                </PublicationsContext.Provider>
            </SetPublicationListContext.Provider>

        </Page>
    )
}

export default MyPublicationsPage;