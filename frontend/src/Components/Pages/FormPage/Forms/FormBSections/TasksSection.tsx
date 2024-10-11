import {SectionWrapper} from "../../Wrappers/FormASections";
import React from "react";


export const researchTasksSectionFieldNames = {
    researchTasks:"researchTasks",
}

export const TasksSection = () => SectionWrapper(
    {
        shortTitle: "Zadania",
        longTitle: "Zadania do zrealizowania w trakcie rejsu",
        sectionFieldNames:researchTasksSectionFieldNames,
        children:  <></>
    }
)