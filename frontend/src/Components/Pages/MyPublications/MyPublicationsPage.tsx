import Page from "../Page";
import PageTitle from "../CommonComponents/PageTitle";
import React, {createContext, useContext, useEffect, useState} from "react";
import {PublicationData, UserData} from "../../CommonComponents/DataTypes";
import {CellContext, FieldTableWrapper} from "../FormPage/Wrappers/FieldTableWrapper";
import ReadOnlyTextInput from "../../CommonComponents/ReadOnlyTextInput";
import Api from "../../Tools/Api";
import {OrdinalNumber} from "../FormPage/Inputs/TableParts";

export const PublicationsContext = createContext<null | PublicationData[]>(null)
export const SetPublicationListContext = createContext<React.Dispatch<React.SetStateAction<PublicationData[]>> | null>(null)


export const PublicationsTools = () => {
    const cellContext = useContext(CellContext);
    const publicationsContext = useContext(PublicationsContext);

    const setPublicationContext = useContext(SetPublicationListContext);
    const publication: PublicationData = publicationsContext![cellContext?.rowIndex!]
    //TODO zmienić logike by dało się usunąć publikacje
    const updatePublication = (fieldKey: keyof PublicationData, value: PublicationData) => {
        publication[fieldKey] = value
        const newPulicationList = [...publicationsContext!]
        const publicationIndex = newPulicationList.findIndex(_publication => _publication.id == publication.id)
        newPulicationList[publicationIndex] = publication
        setPublicationContext!(newPulicationList)
    }
    return {publication, updatePublication}
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
export const Category = () => (
    <div className={"d-flex justify-content-center align-items-center"}>
        <TableReadOnlyField fieldLabel={"Kategoria"} fieldKey={"category"}/>
    </div>
)
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
    const {publication, updatePublication} = PublicationsTools()

    return (
        <div className="btn-group-vertical">
            <div className={"user-action-link"}
                 onClick={() => deletePublication(publication).then(() => updatePublication("accepted", true))}>
                Usuń publikację
            </div>
        </div>
    )
}

const managePublicationsPageTableContent = () => [
    () => (<OrdinalNumber label={"Publikacja"}/>),
    Category,
    Informations,
    Year,
    MinisterialPoints,
    Actions,
]

const deletePublication = (publication: PublicationData) => Api.delete('/Publications/' + publication.id)
const getPublications = () => Api.get('/Publications').then(response => {
    return response.data
})


function MyPublicationsPage() {
    const [publicationList, setPublicationList] = useState<PublicationData[]>([])
    const fetchData = async () => {
        // TODO tymczasowe dane
        setPublicationList([{
            category: "subject",
            doi: "10.1016/j.marenvres.2023.106132",
            authors: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska, Agnieszka Jędruch, Olga Brocławik, Magdalena Bełdowska",
            title: "Mobility and bioavailability of mercury in sediments of the southern Baltic sea in relation to the chemical fractions of iron: Spatial and temporal patterns",
            magazine: "Marine Environmental Research",
            year: "2023",
            ministerialPoints: "0",
            id: "1234"
        }])
        //return getPublications().then(response => setPublicationList(response))
    }
    useEffect(() => {
        (fetchData)()
    }, []);

    const mdColWidths = [5, 10, 45, 15, 15, 10]
    const mdColTitles = ["Lp.", "Kategoria", "Informacje", "Rok publikacji", "Punkty ministerialne", "Akcje"]
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