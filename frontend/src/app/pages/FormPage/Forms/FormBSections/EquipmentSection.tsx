import React from 'react';
import { SectionWrapper } from '@components/Form/Section/SectionWrapper';

export const equipementSectionFieldNames = {};

//TODO change
//                     <EquipmentInput className={"col-12"} name={"equipment2"}/>

export const EquipementSection = () => SectionWrapper(
    {
        shortTitle: 'Sprzęt',
        longTitle: 'Lista sprzętu i aparatury badawczej planowanej do użycia podczas rejsu',
        sectionFieldNames: equipementSectionFieldNames,
        children: <> </>,
    },
);