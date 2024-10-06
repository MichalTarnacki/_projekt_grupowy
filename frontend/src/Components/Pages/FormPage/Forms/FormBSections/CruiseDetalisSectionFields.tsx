import React from "react";
import {CruiseDetailsSection, cruiseDetailsSectionFieldNames} from "./CruiseDetailsSection";
import UgTeamsTable from "../../Inputs/UgTeamsTable/UgTeamsTable";
import {administrationUnits} from "../../../../../resources/administrationUnits";
import {EMPTY_GUID} from "../../../CruiseFormPage/CruiseFormPage";
import EquipmentOutsideTable from "../../Inputs/CruiseDetailsTables/EquipmentOutsideTable";
import EquipmentLeaveTable from "../../Inputs/CruiseDetailsTables/EquipmentLeaveTable";
import PortTable from "../../Inputs/CruiseDetailsTables/PortTable";

export const CruiseDetailsDescription = () => (

    <h5 className={`pb-0 p-4 col-12 text-center`}>Czy w ramach rejsu
        planuje się:</h5>
)

export const EquipmentOutsideField = () => {
        return(
            <EquipmentOutsideTable
                className="single-field"
                fieldLabel="Wystawienie sprzętu"
                fieldName={cruiseDetailsSectionFieldNames.equipmentOutside}
                historicalEquipmentOutside={[
                    {startDate: "10/12/1987",
                        endDate: "11/12/1987",
                        name: "unnamed"
                    },
                    {startDate: "10/12/1989",
                        endDate: "11/12/1989",
                        name: "unnamed"
                    }



                ]}
            />
        )

}

export const EquipmentLeaveField = () => {
        return(
            <EquipmentLeaveTable
                className="single-field"
                fieldLabel="Pozostawienie lub zabranie sprzętu"
                fieldName={cruiseDetailsSectionFieldNames.equipmentLeave}
            />
        )

}

export const PortLeaveField = () => {
        return(
            <PortTable
                className="single-field"
                fieldLabel="Wchodzenie lub wychodzenie z portu"
                fieldName={cruiseDetailsSectionFieldNames.portLeave}
            />
        )

}