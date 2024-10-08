import React, {createContext, Dispatch, useEffect, useState} from "react";
import {Cruise} from "../CruisesPage/CruisesPage";
import {Location, useLocation} from "react-router-dom";
import {CruiseApplication} from "../CruiseApplicationsPage/CruiseApplicationsPage";
import {fetchCruiseApplications} from "../../Tools/Fetchers";
import FormTemplate from "../FormPage/Wrappers/FormTemplate";
import {ApplicationsSection} from "./CruiseFormSections/Sections/AppicationsSection";
import {DateSection} from "./CruiseFormSections/Sections/InfoSection";
import {CruiseManagersSection} from "./CruiseFormSections/Sections/CruiseManagersSection";
import {BottomOptionBar, CruiseLocationData} from "../../Tools/CruiseFormBottomOptionBar";
import {InfoSection} from "./CruiseFormSections/Sections/DateSection";
import {formType} from "../CommonComponents/FormTitleWithNavigation";
import {extendedUseLocation} from "../FormPage/FormPage";
import Api from "../../Tools/Api";
import {ApplicationsContext} from "../CruiseApplicationsPage/CruiseApplicationsList";
import {CruiseStatus} from "./CruiseFormSections/CruiseBasicInfo";


type CruiseManagersTeam = {
    mainCruiseManagerId: string,
    mainDeputyManagerId: string
}

export type EditCruiseFormValues = {
    date: Time,
    managersTeam: CruiseManagersTeam,
    cruiseApplicationsIds: string[]
}

type CruiseFormPageLocationState = {
    cruise?: Cruise
}

export const EMPTY_GUID: string = "00000000-0000-0000-0000-000000000000"


const CruiseFormSections = () => [
    DateSection(),
    InfoSection(),
    CruiseManagersSection(),

    ApplicationsSection(),
]

const EditCruiseFormDefaultValues = (cruise?:Cruise) => {
    if(cruise)
        return{
            startDate: new Date(cruise.startDate).toISOString() ,
            endDate: new Date(cruise.endDate).toISOString() ,
            managersTeam: {
                mainCruiseManagerId: cruise.mainCruiseManagerId,
                mainDeputyManagerId: cruise.mainDeputyManagerId
            },
            cruiseApplicationsIds: cruise.cruiseApplicationsShortInfo.map(app => app.id)
        }
    return{
        startDate: undefined ,
        endDate: undefined ,
        managersTeam: { mainCruiseManagerId:EMPTY_GUID, mainDeputyManagerId: EMPTY_GUID },
        cruiseApplicationsIds: []
    }

}

export const CruiseApplicationsContext =
    createContext<{cruiseApplications: CruiseApplication[],
        setCruiseApplications: React.Dispatch<React.SetStateAction<CruiseApplication[]>>}|null>
    (null)

export default function CruiseFormPage() {

    const cruise = CruiseLocationData()
    const editCruiseFormDefaultValues = EditCruiseFormDefaultValues(cruise)

    const sections = CruiseFormSections()

    const cruiseIsNew = !cruise || cruise?.status == CruiseStatus.New
    console.log(cruiseIsNew)
    const [fetchedCruiseApplications, setFetchedCruiseApplications] = useState([])
    useEffect(() => {
        if(fetchedCruiseApplications.length<=0){
            Api.get(cruiseIsNew ? '/api/CruiseApplications/forCruise': '/api/CruiseApplications').then(response =>
                setFetchedCruiseApplications(response?.data))
        }

    }, []);

    return (
        <CruiseApplicationsContext.Provider value={fetchedCruiseApplications}>
            <FormTemplate sections={sections} type={formType.CruiseDetails} BottomOptionBar={BottomOptionBar}
                          defaultValues={editCruiseFormDefaultValues} />
        </CruiseApplicationsContext.Provider>
    )
}