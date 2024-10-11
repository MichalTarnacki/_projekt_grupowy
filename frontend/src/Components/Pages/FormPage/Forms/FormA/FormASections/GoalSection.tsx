import React from "react";
import {SectionWrapper} from "../../../Wrappers/FormASections";
import {CruiseGoalDescriptionField, CruiseGoalField} from "./GoalSectionFields";

export const goalSectionFieldNames = {
    cruiseGoal:"cruiseGoal",
    cruiseGoalDescription:"cruiseGoalDescription",
}

export const GoalSection = () => SectionWrapper(
    {
        shortTitle: "Cel",
        longTitle: "Cel rejsu",
        sectionFieldNames: goalSectionFieldNames,
        children:
            <>
                <CruiseGoalField/>
                <CruiseGoalDescriptionField/>
            </>
    }
)