import {SectionWrapper} from "../../Wrappers/FormASections";
import React from "react";
import DetailedPlanInput from "../../Inputs/DetailedPlanInput";
import DetailedPlanTable from "../../Inputs/DetailedPlanTable/DetailedPlanTable";
import {publicationsSectionFieldNames} from "../FormA/FormASections/PublicationsSection";

export const cruisePlanSectionFieldNames = {
    detailedPlan:"DetailedPlan"
}


// TODO: CHANGE

//                     <DetailedPlanInput className={"col-12"} name={"plan"}/>


export const CruisePlanSection = () => SectionWrapper(
    {
        shortTitle: "Plan",
        longTitle: "Szczegółowy plan zadań do realizacji podczas rejsu",
        sectionFieldNames:cruisePlanSectionFieldNames,
        children: <>
            <DetailedPlanTable
                fieldName={cruisePlanSectionFieldNames.detailedPlan}
                className={"single-field"}
                fieldLabel={"Szczegółowy plan"}/>
        </>
    }
)