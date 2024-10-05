import ReadOnlyTextInput from "../../CommonComponents/ReadOnlyTextInput";
import {CruiseApplicationContext} from "../CruiseApplicationDetailsPage/CruiseApplicationDetailsPage";
import {FormALink, FormBLink, FormCLink} from "../CruiseApplicationDetailsPage/CruiseApplicationInfo";
import React, {useContext} from "react";
import {CellContext, FieldContext} from "../FormPage/Wrappers/FieldTableWrapper";
import {CruiseApplication, CruiseApplicationStatus} from "./CruiseApplicationsPage";
import {ApplicationsContext, CruiseApplicationListMode, ListModeContext} from "./CruiseApplicationsList";
import LinkWithState from "../../CommonComponents/LinkWithState";
import {Path} from "../../Tools/Path";
import {CruiseApplicationsContext} from "../CruiseFormPage/CruiseFormPage";
import userBasedAccess from "../../UserBasedAccess";

export const ApplicationTools = () => {
    const cellContext = useContext(CellContext)
    const applicationContext = useContext(ApplicationsContext)

    const application:CruiseApplication = applicationContext![cellContext?.rowIndex!]
    return {application}
}

export const NumberAndDate = () => {
    const {application} = ApplicationTools()
    return (
        <div className={"task-field-input"}>
            <label className={"table-field-input-label"}>
                Numer i data:
            </label>
            <ReadOnlyTextInput value={application.number}/>
            <ReadOnlyTextInput value={application.date}/>
        </div>
    )

}

export const Year = () => {
    const {application} = ApplicationTools()
    return (
        <div className={"task-field-input"}>
            <label className={"table-field-input-label"}>
                Rok rejsu:
            </label>
            <ReadOnlyTextInput value={application.year.toString()}
            />
        </div>
    )
}

export const CruiseManager = () => {
    const {application} = ApplicationTools()
    return (
        <div className={"task-field-input"}>
            <label className={"table-field-input-label"}>
                Kierownik:
            </label>
            <ReadOnlyTextInput value={application.cruiseManagerFirstName}/>
            <ReadOnlyTextInput value={application.cruiseManagerLastName}/>
        </div>
    )
}

export const FormLinks = () => {
    const {application} = ApplicationTools()
    return (
        <CruiseApplicationContext.Provider value={application}>
            <div className={"task-field-input"}>
                <FormALink/>
                <FormBLink/>
                <FormCLink/>
            </div>
        </CruiseApplicationContext.Provider>
    )
}

export const Points = () => {
    const {application} = ApplicationTools()
    return(
        <div className={"task-field-input"}>
            <label className={"table-field-input-label"}>
                Punkty:
            </label>
            <ReadOnlyTextInput value={application!.points}/>
        </div>
    )
}

export const Status = () => {
    const {application} = ApplicationTools()
    const listModeContext = useContext(ListModeContext)
    const {UserHasCruiseManagerAccess} = userBasedAccess()
    return (
        <div className={"task-field-input"}>
            <label className={"table-field-input-label"}>
                Status:
            </label>
            <i>{application!.status}</i>
            {!listModeContext?.mode &&
                <>
                    {application!.status == CruiseApplicationStatus.WaitingForSupervisor && UserHasCruiseManagerAccess() &&
                        <LinkWithState to={Path.Form} state={{formType:"B", cruiseApplication:application}} label={"Wypełnij"}/>}
                    {application!.status == CruiseApplicationStatus.Undertaken && UserHasCruiseManagerAccess() &&
                        <LinkWithState to={Path.Form} state={{formType:"C"}} label={"Wypełnij raport"}/>}
                </>
            }
        </div>
    )
}

export const Actions = () => {
    const {application} = ApplicationTools()
    const listModeContext = useContext(ListModeContext)
    const fieldContext = useContext(FieldContext)

    return (
        <div className="task-field-input">
            <LinkWithState
                className="btn btn-info"
                useWindow={listModeContext?.mode != undefined}
                to={Path.CruiseApplicationDetails}
                label="Szczegóły"
                state={{cruiseApplication: application, readOnly:true}}
            />

            {listModeContext!.mode == CruiseApplicationListMode.Deletion &&
                <a
                    className="btn btn-outline-danger"
                    style={{fontSize: "inherit"}}
                    onClick={() => {
                        const updatedApplications = fieldContext!.value
                            .filter((id) => id !== application.id)
                        fieldContext!.onChange!(updatedApplications)
                    }}
                >
                    Usuń
                </a>
            }
            {listModeContext!.mode == CruiseApplicationListMode.Add &&
                // Show only if the component enables adding applications to a cruise
                <a
                    className="btn btn-outline-success"
                    style={{fontSize: "inherit"}}
                    onClick={() => {
                        const updatedApplications = [...fieldContext!.value, application.id]
                        fieldContext!.onChange(updatedApplications)
                    }}
                >
                    Dołącz
                </a>
            }
        </div>
    )
}


export const CruiseApplicationsTableContent = () => [
    NumberAndDate,
    Year,
    CruiseManager,
    FormLinks,
    Points,
    Status,
    Actions
]