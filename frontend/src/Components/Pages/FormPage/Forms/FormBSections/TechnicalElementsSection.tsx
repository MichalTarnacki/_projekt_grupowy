import {SectionWrapper} from "../../Wrappers/FormASections";
import React from "react";
import EquipmentTable from "../../Inputs/EquipmentTable/EquipmentTable";
import {equipmentSectionFieldNames} from "./EquipmentSection";
import TechnicalElementsTable from "../../Inputs/TechnicalElementsTable/TechnicalElementsTable";

export const technicalElementsSectionFieldNames = {
        technicalElements:"technicalElements"
}

//  TODO: Change
//                     <TechnicalElementsUsedInput className={"col-12"} name={"technical"}/>

export const TechnicalElementsSection = () => SectionWrapper(
    {
        shortTitle: "E. techniczne",
        longTitle: "Elementy techniczne statku wykorzystywane podczas rejsu",
        sectionFieldNames:technicalElementsSectionFieldNames,
        children: <>
                <TechnicalElementsTable
                    className={"single-field"}
                    fieldName={technicalElementsSectionFieldNames.technicalElements}
                    fieldLabel={"Elementy techniczne"}
                />
        </>
    }
)