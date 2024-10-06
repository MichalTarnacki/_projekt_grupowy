import {SectionWrapper} from "../../../FormPage/Wrappers/FormASections";
import React from "react";
import {useLocation} from "react-router-dom";
import CruiseBasicInfo from "../../../CruiseFormPage/CruiseFormSections/CruiseBasicInfo";
import {
    CruiseApplicationCruiseManagerName,
    CruiseApplicationDeputyManagerName
} from "../../../CruiseApplicationDetailsPage/CruiseApplicationInfo";
import {extendedUseLocation} from "../../FormPage";


export const BasicInfo = () => {
    const location = extendedUseLocation()
    return(
        <CruiseBasicInfo cruise={location?.state.cruise} />
    )
}


export const CruiseManagersSection = () => SectionWrapper(
    {
        shortTitle: "Kierownik",
        longTitle: "Kierownik zgłaszanego rejsu",
        children:
            <>
                <CruiseApplicationCruiseManagerName/>
                <CruiseApplicationDeputyManagerName/>
            </>
    }
)
