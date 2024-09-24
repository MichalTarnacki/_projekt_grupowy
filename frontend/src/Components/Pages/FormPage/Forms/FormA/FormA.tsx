import React from "react";
import {CruiseManagerSection} from "./FormASections/CruiseManagerSection";
import {TimeSection} from "./FormASections/TimeSection";
import {PermissionsSection} from "./FormASections/PermissionsSection";
import {ResearchAreaSection} from "./FormASections/ResearchAreaSection";
import {GoalSection} from "./FormASections/GoalSection";
import {TasksSection} from "./FormASections/TasksSection";
import {ContractSection} from "./FormASections/ContractSection";
import {ResearchTeamsSection} from "./FormASections/ResearchTeamsSection";
import {PublicationsSection} from "./FormASections/PublicationsSection";
import {SpubTasksSection} from "./FormASections/SpubTasksSection";
import {SupervisorSection} from "./FormASections/SupervisorSection";
import {formType} from "../../../CommonComponents/FormTitleWithNavigation";
import {FormWrapper} from "../FormsMisc";

const FormASections = () => [
    CruiseManagerSection(),
    TimeSection(),
    PermissionsSection(),
    ResearchAreaSection(),
    GoalSection(),
    TasksSection(),
    ContractSection(),
    ResearchTeamsSection(),
    PublicationsSection(),
    SpubTasksSection(),
    SupervisorSection(),
]

const FormA = () => ( <FormWrapper sections={FormASections} type={formType.A}/> )


export default FormA