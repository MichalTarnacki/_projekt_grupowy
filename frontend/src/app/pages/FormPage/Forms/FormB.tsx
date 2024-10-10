import FormTemplate from '../Wrappers/FormTemplate';
import React from 'react';
import { CruiseInfoSection } from './FormBSections/CruiseInfoSection';
import { CruiseManagersSection } from './FormBSections/CruiseManagersSection';
import { PermissionsSection } from './FormA/FormASections/PermissionsSection';
import { ResearchAreaSection } from './FormA/FormASections/ResearchAreaSection';
import { CruiseUsageSection } from './FormBSections/CruiseUsageSection';
import { SpubTasksSection } from './FormA/FormASections/SpubTasksSection';
import { GoalSection } from './FormBSections/GoalSection';
import { TasksSection } from './FormA/FormASections/TasksSection';
import { ContractSection } from './FormA/FormASections/ContractSection';
import { ResearchTeamsSection } from './FormBSections/ResearchTeamsSection';
import { CruiseDetailsSection } from './FormBSections/CruiseDetailsSection';
import { PublicationsSection } from './FormA/FormASections/PublicationsSection';
import { CruisePlanSection } from './FormBSections/CruisePlanSection';
import { EquipementSection } from './FormBSections/EquipmentSection';
import { TechnicalElementsSection } from './FormBSections/TechnicalElementsSection';
import { CruiseApplicationContext } from '@contexts/CruiseApplicationContext';

import { extendedUseLocation } from '@hooks/extendedUseLocation';
import cruiseApplicationFromLocation from '@hooks/cruiseApplicationFromLocation';

const FormBSections = () => [
    CruiseInfoSection(),
    CruiseManagersSection(),
    CruiseUsageSection(),
    PermissionsSection(),
    ResearchAreaSection(),
    GoalSection(),
    TasksSection(),
    ContractSection(),
    ResearchTeamsSection(),
    PublicationsSection(),
    SpubTasksSection(),
    CruiseDetailsSection(),
    CruisePlanSection(),
    EquipementSection(),
    TechnicalElementsSection(),
];

function FormB() {
    const sections = FormBSections();
    const cruiseApplication = cruiseApplicationFromLocation();
    return (
        <CruiseApplicationContext.Provider value={cruiseApplication}>
            <FormTemplate sections={sections} type="B" />
        </CruiseApplicationContext.Provider>
    );
}


export default FormB;