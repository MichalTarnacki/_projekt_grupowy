import React, { useContext } from 'react';
import { FormContext } from '@contexts/FormContext';
import EvaluatedUgTeamsTable from '../../../FormPage/Inputs/UgTeamsTable/EvaluatedUgTeamsTable';

export const UgTeamsField = () => {
    const formContext = useContext(FormContext);
    return (
        <EvaluatedUgTeamsTable
            className="two-fields-beside-md"
            fieldLabel="Uczestnictwo osób z jednostek organizacyjnych UG"
            ugTeams={formContext!.initValues?.ugTeams}
        />
    );
};