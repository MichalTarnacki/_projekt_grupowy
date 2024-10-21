import React, {createContext, useContext, useEffect, useState} from "react";

import {FieldTableWrapper} from "../FormPage/Wrappers/FieldTableWrapper";
import {OrdinalNumber} from "../FormPage/Inputs/TableParts";
import {CellContext} from "@contexts/CellContext";
import ReadOnlyTextInput from "../../../ToBeMoved/CommonComponents/ReadOnlyTextInput";
import Api from "@api/Api";
import Page from "../../../ToBeMoved/Pages/Page";
import PageTitle from "../../../components/Page/PageTitle";
import {CruiseEffectData} from "CruiseEffectData";


export const CruiseEffectsContext = createContext<null | CruiseEffectData[]>(null);
export const SetCruiseEffectListContext = createContext<React.Dispatch<React.SetStateAction<CruiseEffectData[]>> | null>(null);

export const CruiseEffectsTools = () => {
    const cellContext = useContext(CellContext);
    const cruiseEffectsContext = useContext(CruiseEffectsContext);

    const setCruiseEffectListContext = useContext(SetCruiseEffectListContext);
    const cruiseEffect: CruiseEffectData = cruiseEffectsContext![cellContext?.rowIndex!];
    //TODO zmienić logike by dało się usunąć efekty
    const updateCruiseEffect = (fieldKey: keyof CruiseEffectData, value: CruiseEffectData) => {
        // @ts-ignore
        cruiseEffect[fieldKey] = value;
        const newCruiseEffectList = [...cruiseEffectsContext!];
        const publicationIndex = newCruiseEffectList.findIndex(_cruiseEffect => _cruiseEffect.userId === cruiseEffect.userId);
        newCruiseEffectList[publicationIndex] = cruiseEffect;
        setCruiseEffectListContext!(newCruiseEffectList)
    };
    return {cruiseEffect, updateCruiseEffect}
};

type NestedKeyOf<ObjectType extends object> = {
    [Key in keyof ObjectType & (string | number)]: ObjectType[Key] extends object
        ? `${Key}` | `${Key}.${NestedKeyOf<ObjectType[Key]>}`
        : `${Key}`;
}[keyof ObjectType & (string | number)];

const TableReadOnlyField = (props: { fieldLabel: string, fieldKey: NestedKeyOf<CruiseEffectData> }) => {
    const {cruiseEffect} = CruiseEffectsTools();

    const getValue = (key: string, obj: any): any => key.split('.').reduce((o, i) => o?.[i], obj);
    return (
        <div className={"task-field-input col-md-6"}>
            <label>
                {props.fieldLabel}
            </label>
            <ReadOnlyTextInput value={getValue(props.fieldKey, cruiseEffect) as string}/>
        </div>
    )
};

export const Type = () => {
    const {cruiseEffect} = CruiseEffectsTools();
    return (
        <div className={"task-field-input"}>
            <i>{cruiseEffect.effect.type}</i>
        </div>)
};

export const Points = () => {
    const {cruiseEffect} = CruiseEffectsTools();
    return (
        <div className={"task-field-input"}>
            <i>{cruiseEffect.points}</i>
        </div>)
};

export const Publication = () => (
    <div className={"w-100 d-flex flex-row flex-wrap"}>
        <TableReadOnlyField fieldLabel={"Autor:"} fieldKey={"effect.author"}/>
        <TableReadOnlyField fieldLabel={"Tytuł: "} fieldKey={"effect.title"}/>
    </div>
);

export const ScienceProject = () => {
    const {cruiseEffect} = CruiseEffectsTools();

    return (
        <div className={"w-100 d-flex flex-row flex-wrap"}>
            <TableReadOnlyField fieldLabel={"Roboczy tytuł projektu: "} fieldKey={"effect.title"}/>
            <TableReadOnlyField fieldLabel={"Przewidywany termin złożenia:"} fieldKey={"effect.date"}/>
            <div className={"task-field-input col-md-6"}>
                <label>
                    Otrzymano finansowanie:
                </label>
                <ReadOnlyTextInput value={cruiseEffect.effect.financingApproved ? "tak" : "nie"}/>
            </div>
        </div>
    )
};

export const ProjectRealization = () => {
    const {cruiseEffect} = CruiseEffectsTools();

    return (
        <div className={"w-100 d-flex flex-row flex-wrap"}>
            <TableReadOnlyField fieldLabel={"Tytuł: "} fieldKey={"effect.title"}/>
            <TableReadOnlyField fieldLabel={"Kwota finansowania:"} fieldKey={"effect.financingAmount"}/>
            <div className={"task-field-input col-md-6"}>
                <label>
                    Ramy czasowe:
                </label>
                <div>
                    <div>
                        <label>
                            {"Od: "}
                        </label>
                        <ReadOnlyTextInput value={cruiseEffect.effect.startDate}/>
                    </div>
                    <div>
                        <label>
                            {"Do: "}
                        </label>
                        <ReadOnlyTextInput value={cruiseEffect.effect.endDate}/>
                    </div>
                </div>

            </div>
            <TableReadOnlyField fieldLabel={"Środki zabezpieczone na realizację rejsu:"}
                                fieldKey={"effect.securedAmount"}/>
        </div>
    )
};

export const Education = () => {
    const {cruiseEffect} = CruiseEffectsTools();
    return(
        <div className={"task-field-input"}>
            <label>
                Opis zajęcia dydaktycznego:
            </label>
            <ReadOnlyTextInput value={cruiseEffect.effect.description}/>
        </div>
    )
};

export const OwnResearchTask = () => (
    <div className={"w-100 d-flex flex-row flex-wrap"}>
        <TableReadOnlyField fieldLabel={"Roboczy tytuł publikacji: "} fieldKey={"effect.title"}/>
        <TableReadOnlyField fieldLabel={"Przewidywany termin składania: "} fieldKey={"effect.date"}/>
        <TableReadOnlyField fieldLabel={"Magazyn: "} fieldKey={"effect.magazine"}/>
        <TableReadOnlyField fieldLabel={"Punkty ministerialne: "} fieldKey={"effect.ministerialPoints"}/>
    </div>
);

export const OtherTask = () => {
    const {cruiseEffect} = CruiseEffectsTools();
    return(
        <div className={"task-field-input"}>
            <label>
                Opis zadania:
            </label>
            <ReadOnlyTextInput value={cruiseEffect.effect.description}/>
        </div>
    )
};

export const Informations = () => {
    const {cruiseEffect} = CruiseEffectsTools();
    switch (cruiseEffect.effect.type) {
        case 'Praca licencjacka':
            return <Publication/>;
        case 'Praca magisterska':
            return <Publication/>;
        case 'Praca doktorska':
            return <Publication/>;
        case 'Przygotowanie projektu naukowego':
            return <ScienceProject/>;
        case 'Realizacja projektu krajowego (NCN, NCBiR, itp.)' :
            return <ProjectRealization/>;
        case 'Realizacja projektu zagranicznego (ERC, Programy ramowe UE, fundusze norweskie, itp)':
            return <ProjectRealization/>;
        case 'Realizacja projektu wewnętrznego UG':
            return <ProjectRealization/>;
        case 'Realizacja innego projektu naukowego':
            return <ProjectRealization/>;
        case 'Realizacja projektu komercyjnego':
            return <ProjectRealization/>;
        case 'Dydaktyka':
            return <Education/>;
        case 'Realizacja własnego zadania badawczego':
            return <OwnResearchTask/>;
        case 'Inne zadanie':
            return <OtherTask/>;
    }
};


const manageCruiseEffectsPageTableContent = () => [
    () => (<OrdinalNumber label={"Efekt rejsu"}/>),
    Type,
    Informations,
    Points,
];

const deleteCruiseEffect = (cruiseEffect: CruiseEffectData) => Api.delete('/CrusiseEffect/' + cruiseEffect.userId);
const getCruiseEffect = () => Api.get('/api/CruiseApplications/effectsEvaluations').then(response => {
    console.log(response);
    return response?.data
});

function CruiseEffectsPage() {
    const [cruiseEffectList, setCruiseEffectList] = useState<CruiseEffectData[]>([]);
    const fetchData = async () => {
        setCruiseEffectList([
            {
                effect: {
                    type: "Praca licencjacka",
                    author: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                },
                points: "1",
                userId: "1235"
            },
            {
                effect: {
                    type: "Praca magisterska",
                    author: "Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                },
                points: "5",
                userId: "12345"
            },
            {
                effect: {
                    type: "Praca doktorska",
                    author: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                },
                points: "9",
                userId: "1235"
            },
            {
                effect: {
                    type: "Przygotowanie projektu naukowego",
                    author: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                    date: "21.12.2024",
                    financingApproved: "true",
                },
                points: "12",
                userId: "1235"
            },
            {
                effect: {
                    type: "Realizacja projektu krajowego (NCN, NCBiR, itp.)",
                    author: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                    financingAmount: '21.00',
                    startDate: '20.10.2024',
                    endDate: '25.10.2024',
                    securedAmount: '19.00'
                },
                points: "3",
                userId: "1235"
            },
            {
                effect: {
                    type: "Realizacja projektu zagranicznego (ERC, Programy ramowe UE, fundusze norweskie, itp)",
                    author: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                    financingAmount: '21.00',
                    startDate: '20.10.2024',
                    endDate: '25.10.2024',
                    securedAmount: '19.00'
                },
                points: "5",
                userId: "1235"
            },
            {
                effect: {
                    type: "Realizacja projektu wewnętrznego UG",
                    author: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                    financingAmount: '21.00',
                    startDate: '20.10.2024',
                    endDate: '25.10.2024',
                    securedAmount: '19.00'
                },
                points: "7",
                userId: "1235"
            },
            {
                effect: {
                    type: "Realizacja innego projektu naukowego",
                    author: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                    financingAmount: '21.00',
                    startDate: '20.10.2024',
                    endDate: '25.10.2024',
                    securedAmount: '19.00'
                },
                points: "3",
                userId: "1235"
            },
            {
                effect: {
                    type: "Realizacja projektu komercyjnego",
                    author: "Urszula Kwasigroch, Katarzyna Łukawska-Matuszewska",
                    title: "Drogi lęgowe karasia i jak wpływają na połów rekinów",
                    financingAmount: '21.00',
                    startDate: '20.10.2024',
                    endDate: '25.10.2024',
                    securedAmount: '19.00'
                },
                points: "8",
                userId: "1235"
            },
            {
                effect: {
                    type: "Dydaktyka",
                    description: "Rejs rekreacyjno-dydaktyczny"
                },
                points: "5",
                userId: "1235"
            },
            {
                effect: {
                    type: "Realizacja własnego zadania badawczego",
                    title: 'Molekuły srebra w wodzie morza bałtyckiego',
                    date: '15.10.2024',
                    magazine: 'Chemik powszedni',
                    ministerialPoints: '10'
                },
                points: "9",
                userId: "1235"
            },
            {
                effect: {
                    type: "Inne zadanie",
                    description: "Zadanie do pływania"
                },
                points: "2",
                userId: "1235"
            },
        ]);

        getCruiseEffect().then(response => console.log(response));
        //return getCruiseEffect().then(response => setCruiseEffectList(response))
    };
    useEffect(() => {
        (fetchData)()
    }, []);

    const mdColWidths = [5, 20, 65, 10];
    const mdColTitles = ["Lp.", "Zadanie", "Szczegóły", "Punkty"];
    const colTitle = "Efekty rejsu";

    const emptyText = "Nie ma żadnego efektu rejsu";
    const {Render} = FieldTableWrapper(colTitle, mdColWidths, mdColTitles, manageCruiseEffectsPageTableContent, null, emptyText, cruiseEffectList);

    return (
        <Page className={"bg-white d-flex flex-column m-3 w-75"}>
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