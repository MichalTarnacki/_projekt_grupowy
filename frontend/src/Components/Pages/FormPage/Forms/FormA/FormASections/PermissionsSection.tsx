import React from "react";
import {SectionWrapper} from "../../../Wrappers/FormASections";
import {PermissionsField} from "./PermissionsSectionFields";

export const permissionsSectionFieldNames = {
    permissionsRequired:"permissionsRequired",
    permissions:"permissions",
}

export const PermissionsSection = () => SectionWrapper(
    {
        shortTitle: "Pozwolenia",
        longTitle: "Dodatkowe pozwolenia do planowanych podczas rejsu badań",
        sectionFieldNames: permissionsSectionFieldNames,
        children: <PermissionsField/>
    }
)