import {SectionWrapper} from "../../Wrappers/FormASections";
import React from "react";
import EquipmentTable from "../../Inputs/EquipmentTable/EquipmentTable";

export const equipmentSectionFieldNames = {
    equipment:"equipment"
}

//TODO change
//                     <EquipmentInput className={"col-12"} name={"equipment2"}/>

export const EquipementSection = () => SectionWrapper(
    {
        shortTitle: "Sprzęt",
        longTitle: "Lista sprzętu i aparatury badawczej planowanej do użycia podczas rejsu",
        sectionFieldNames:equipmentSectionFieldNames,
        children: <>
            <EquipmentTable
                className={"single-field"}
                fieldName={equipmentSectionFieldNames.equipment}
                fieldLabel={"Lista sprzętu i aparatury badawczej"}
            />
        </>
    }
)