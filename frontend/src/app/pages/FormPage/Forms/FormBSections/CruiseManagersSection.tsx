import React from 'react';
import CruiseBasicInfo from '../../../CruiseFormPage/CruiseFormSections/CruiseBasicInfo';
import { SectionWrapper } from '@components/Form/Section/SectionWrapper';
import {
    CruiseApplicationCruiseManagerName,
} from '../../../CruiseApplicationDetailsPage/CruiseApplicationDetailsFields/CruiseApplicationCruiseManagerName';
import {
    CruiseApplicationDeputyManagerName,
} from '../../../CruiseApplicationDetailsPage/CruiseApplicationDetailsFields/CruiseApplicationDeputyManagerName';

import { extendedUseLocation } from '@hooks/extendedUseLocation';
import cruiseApplicationFromLocation from '@hooks/cruiseApplicationFromLocation';
import { cruiseFromLocation } from '@hooks/cruiseFromLocation';


export const BasicInfo = () => {
    const cruise = cruiseFromLocation();
    return (
        <CruiseBasicInfo cruise={cruise} />
    );
};


export const CruiseManagersSection = () => SectionWrapper(
    {
        shortTitle: 'Kierownik',
        longTitle: 'Kierownik zgłaszanego rejsu',
        children:
            <>
                <CruiseApplicationCruiseManagerName />
                <CruiseApplicationDeputyManagerName />
            </>,
    },
);
