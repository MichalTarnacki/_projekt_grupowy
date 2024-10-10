import React from 'react';
import { SectionWrapper } from '@components/Form/Section/SectionWrapper';

export const technicalElementsSectionFieldNames = {};

//  TODO: Change
//                     <TechnicalElementsUsedInput className={"col-12"} name={"technical"}/>

export const TechnicalElementsSection = () => SectionWrapper(
    {
        shortTitle: 'E. techniczne',
        longTitle: 'Elementy techniczne statku wykorzystywane podczas rejsu',
        sectionFieldNames: technicalElementsSectionFieldNames,
        children: <> </>,
    },
);