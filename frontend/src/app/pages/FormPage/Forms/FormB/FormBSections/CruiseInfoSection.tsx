import React from 'react';
import CruiseBasicInfo from '../../../../CruiseFormPage/CruiseFormSections/CruiseBasicInfo';
import { SectionWrapper } from '../../../../../../components/Form/Section/SectionWrapper';

import { cruiseFromLocation } from '@hooks/cruiseFromLocation';


export const BasicInfo = () => {
    const cruise = cruiseFromLocation();
    console.log(cruise);
    return (
        <CruiseBasicInfo cruise={cruise} />
    );
};


export const CruiseInfoSection = () => SectionWrapper(
    {
        shortTitle: 'Rejs',
        longTitle: 'Numer ewidencyjny rejsu',
        children: <BasicInfo />,
    },
);