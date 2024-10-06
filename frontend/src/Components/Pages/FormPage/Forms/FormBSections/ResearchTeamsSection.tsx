import {SectionWrapper} from "../../Wrappers/FormASections";
import React from "react";
import {CrewField, GuestTeamsField, UgTeamsField} from "./ResearchTeamsSectionFields";

export const researchTeamsSectionFieldNames = {
    ugTeams:"ugTeams",
    guestTeams:"guestTeams",
    crew:"crew"
}

export const ResearchTeamsSection = () => SectionWrapper(
    {
        shortTitle: "Z. badawcze",
        longTitle: "Zespoły badawcze, jakie miałyby uczestniczyć w rejsie",
        sectionFieldNames:researchTeamsSectionFieldNames,
        children:
            <>
                <UgTeamsField/>
                <GuestTeamsField/>
                <CrewField/>
            </>
    }
)