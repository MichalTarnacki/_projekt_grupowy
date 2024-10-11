import { SectionWrapper } from '@components/Form/Section/SectionWrapper';
import EquipmentTable from '@app/pages/FormPage/Inputs/EquipmentTable/EquipmentTable';

export const equipmentSectionFieldNames = {
    equipment: 'equipment',
};

export const EquipementSection = () => SectionWrapper(
    {
        shortTitle: 'Sprzęt',
        longTitle: 'Lista sprzętu i aparatury badawczej planowanej do użycia podczas rejsu',
        sectionFieldNames: equipmentSectionFieldNames,
        children: <>
            <EquipmentTable
                className={'single-field'}
                fieldName={equipmentSectionFieldNames.equipment}
                fieldLabel={'Lista sprzętu i aparatury badawczej'}
            />
        </>,
    },
);