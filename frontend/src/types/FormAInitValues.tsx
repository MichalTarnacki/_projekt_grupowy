import { FormUser } from '@types/FormUser';
import { ResearchArea } from '@app/pages/FormPage/Inputs/ResearchAreaSelect';
import { ResearchTask } from '@app/pages/FormPage/Inputs/TaskTable/TaskTable';
import { Contract } from '@app/pages/FormPage/Inputs/ContractsTable/ContractsTable';
import { UgUnit } from '@app/pages/FormPage/Inputs/UgTeamsTable/UgTeamsTable';
import { SpubTask } from '@types/SpubTask';

export type FormAInitValues = {
    cruiseManagers: FormUser[];
    deputyManagers: FormUser[];
    years: string[];
    shipUsages: string[];
    researchAreas: ResearchArea[];
    cruiseGoals: string[];
    historicalResearchTasks: ResearchTask[];
    historicalContracts: Contract[];
    ugUnits: UgUnit[];
    historicalGuestInstitutions: string[];
    historicalSpubTasks: SpubTask[];
};